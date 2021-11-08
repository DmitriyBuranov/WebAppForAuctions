using Otus.PublicSale.Users.Core.Abstractions.Services;
using Otus.PublicSale.Users.Core.Domain;
using Otus.PublicSale.Users.DataAccess;
using Otus.PublicSale.Users.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

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
        /// Constructor
        /// </summary>
        /// <param name="context">DB Context</param>
        public UserService(DataContext context)
        {
            _context = context;
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
        /// <returns></returns>
        public User Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Users.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            PasswordHash.Create(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

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
    }
}
