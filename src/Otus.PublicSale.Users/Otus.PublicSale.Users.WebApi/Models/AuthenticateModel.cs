using System.ComponentModel.DataAnnotations;

namespace Otus.PublicSale.Users.WebApi.Models
{
    /// <summary>
    /// Authenticate Model
    /// </summary>
    public class AuthenticateModel
    {
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
    }
}
