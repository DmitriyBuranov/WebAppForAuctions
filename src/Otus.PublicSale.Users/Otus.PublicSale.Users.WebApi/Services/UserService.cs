using Newtonsoft.Json;
using Otus.PublicSale.Users.Core.Abstractions.Services;
using Otus.PublicSale.Users.Core.Domain;
using Otus.PublicSale.Users.DataAccess.DataContexts;
using Otus.PublicSale.Users.WebApi.Models;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Otus.PublicSale.WebApi.Users.Services
{
    /// <summary>
    /// Auth User Service
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// DB Context
        /// </summary>
        private DataContext _context;

        /// <summary>
        /// Configuration
        /// </summary>
        private IConfiguration _configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">DB Context</param>
        /// <param name="context">Configuration</param>
        public UserService(DataContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// Authenticates user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!PasswordHash.Verify(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        /// <summary>
        /// Gets user by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        /// <summary>
        /// Creates user
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="password">Password</param>
        /// <param name="repeatPassword">Repeat password</param>
        /// <returns></returns>
        public User Create(User user, string password, string repeatPassword)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            // validation
            if (string.IsNullOrWhiteSpace(repeatPassword))
                throw new AppException("Repeat Password is required");

            // validation
            if (string.Compare(password, repeatPassword, false) != 0)
                throw new AppException("Password and Repeat Password are different");

            if (_context.Users.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            PasswordHash.Create(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            SendUserDataToMessageBrokers(user);

            return user;
        }

        /// <summary>
        /// Updates user
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="password">Password</param>
        public void Update(User userParam, string password = null)
        {
            var user = _context.Users.Find(userParam.Id);

            if (user == null)
                throw new AppException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            {
                // throw error if the new username is already taken
                if (_context.Users.Any(x => x.Username == userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");

                user.Username = userParam.Username;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                user.FirstName = userParam.FirstName;

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
                user.LastName = userParam.LastName;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                PasswordHash.Create(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();

            SendUserDataToMessageBrokers(user);
        }

        /// <summary>
        /// Deletes user
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Send user data to message brokers
        /// </summary>
        /// <param name="user">User</param>
        private void SendUserDataToMessageBrokers(User user)
        {
            var connectionFactory = new ConnectionFactory() { 
                HostName = _configuration["RabbitMQ:HostName"],
                UserName = _configuration["RabbitMQ:Username"],
                Password = _configuration["RabbitMQ:Password"]
            };
            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "RefreshUserData", durable: false, exclusive: false, autoDelete: false, arguments: null);
            string message = JsonConvert.SerializeObject(new { 
                user.Id,
                user.FirstName,
                user.LastName,
                Email = user.Username
            });            
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "", routingKey: "RefreshUserData", basicProperties: null, body: body);
        }
    }
}
