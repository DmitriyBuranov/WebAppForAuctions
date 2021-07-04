using Otus.PublicSale.Core.Domain;

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
        
    }
}
