using Otus.PublicSale.Users.Core.Domain;
using System.Collections.Generic;

namespace Otus.PublicSale.Users.Core.Abstractions.Services
{
    /// <summary>
    /// User Service interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Authenticates user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        User Authenticate(string username, string password);

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAll();

        /// <summary>
        /// Gets user by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        User GetById(int id);

        /// <summary>
        /// Creates user
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="password">Password</param>
        /// <param name="repeatPassword">Repeat password</param>
        /// <returns></returns>
        User Create(User user, string password, string repeatPassword);

        /// <summary>
        /// Updates user
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="password">Password</param>
        void Update(User user, string password = null);

        /// <summary>
        /// Deletes user
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
