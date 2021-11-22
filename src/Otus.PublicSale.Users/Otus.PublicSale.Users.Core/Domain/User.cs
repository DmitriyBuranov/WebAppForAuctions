using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Otus.PublicSale.Users.Core.Domain
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        /// Password Hash
        /// </summary>
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// Password Salt
        /// </summary>
        public byte[] PasswordSalt { get; set; }
    }
}
