namespace Otus.PublicSale.Users.WebApi.Models
{
    /// <summary>
    /// Authenticate Response
    /// </summary>
    public class AuthenticateResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Admin
        /// </summary>
        public bool Admin { get; set; }

        /// <summary>
        /// JWT Token
        /// </summary>
        public string Token { get; set; }
    }
}
