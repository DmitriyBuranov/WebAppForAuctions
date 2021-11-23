using System.ComponentModel.DataAnnotations;

namespace Otus.PublicSale.Users.WebApi.Models
{
    /// <summary>
    /// Register Model
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// First Name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Repeat Password
        /// </summary>
        [Required]
        public string RepeatPassword { get; set; }
    }
}
