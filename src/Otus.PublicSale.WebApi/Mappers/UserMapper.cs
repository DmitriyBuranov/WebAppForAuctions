using System;
using Otus.PublicSale.Core.Domain.Administration;
using Otus.PublicSale.WebApi.Models;

namespace Otus.PublicSale.WebApi.Mappers
{
    public static class UserMapper
    {
        /// <summary>
        /// Creates or updates User from Dto request
        /// </summary>
        /// <param name="request">User Dto</param>
        /// <param name="user">User</param>
        /// <returns>User</returns>
        public static User MapFromModel(UserDto request, User user = null)
        {
            if (user == null)
            {
                user = new User();
            }

            user.FirstName = request.FirstName;
            user.Email = request.Email;
            user.LastName = request.LastName;

            //if (!string.IsNullOrWhiteSpace(request.Password))
            //    user.Password = request.Password;

            return user;
        }
    }
}
