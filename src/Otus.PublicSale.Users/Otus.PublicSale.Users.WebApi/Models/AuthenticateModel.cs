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
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}
