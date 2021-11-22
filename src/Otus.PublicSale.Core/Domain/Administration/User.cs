using Otus.PublicSale.Core.Domain.AuctionManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Otus.PublicSale.Core.Domain.Administration
{
    /// <summary>
    /// User
    /// </summary>
    public partial class User : BaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public new int Id { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public User()
        {
            AuctionBets = new HashSet<AuctionBet>();
            AuctionUsers = new HashSet<AuctionUser>();
        }

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

        ///// <summary>
        ///// Password
        ///// </summary>
        //public string Password { get; set; }

        ///// <summary>
        ///// Role Id
        ///// </summary>
        //public int RoleId { get; set; }

        ///// <summary>
        ///// Role
        ///// </summary>
        //public virtual Role Role { get; set; }

        /// <summary>
        /// Auction Bets
        /// </summary>
        public virtual ICollection<AuctionBet> AuctionBets { get; set; }

        /// <summary>
        /// Auction Users
        /// </summary>
        public virtual ICollection<AuctionUser> AuctionUsers { get; set; }


        ///// <summary>
        ///// Users BirthDay
        ///// </summary>
        //public DateTime BirthDay { get; set; }

        ///// <summary>
        ///// Address
        ///// </summary>
        //public string Address { get; set; }

        ///// <summary>
        ///// Language
        ///// </summary>
        //public string Language { get; set; }

        ///// <summary>
        ///// Status
        ///// </summary>
        //public string Status { get; set; }

        ///// <summary>
        ///// Phone
        ///// </summary>
        //public string Phone { get; set; }
    }
}
