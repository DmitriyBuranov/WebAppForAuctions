using Otus.PublicSale.Core.Domain;
using Otus.PublicSale.Core.Domain.Administration;

namespace Otus.PublicSale.WebApi.Models
{
    /// <summary>
    /// User Dto
    /// </summary>
    public class UserDto: BaseEntity
    {
        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public RoleDto Role { get; set; }

        /// <summary>
        /// Constuctor
        /// </summary>
        public UserDto()
        {
            
        }

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="user">User</param>
        public UserDto(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            Email = user.Email;
            LastName = user.LastName;
            Password = "*****************";
            //Role = new RoleDto()
            //{
            //    Id = user.Role?.Id ?? user.RoleId,
            //    Name = user.Role?.Name
            //};
        }

    }
}
