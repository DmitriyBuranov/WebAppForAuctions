using Otus.PublicSale.Core.Domain;
using System;
using Otus.PublicSale.Core.Domain.AuctionManagement;

namespace Otus.PublicSale.WebApi.Models
{
    /// <summary>
    /// Action Dto
    /// </summary>
    public class AuctionUserDto : BaseEntity
    {
        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// AuctionId
        /// </summary>
        public int AuctionId { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Constuctor
        /// </summary>
        public AuctionUserDto()
        {
            
        }

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="auctionUser">Auction User</param>
        public AuctionUserDto(AuctionUser auctionUser)
        {
            Id = auctionUser.Id;
            Date = auctionUser.Date;
            UserId = auctionUser.UserId;
            AuctionId = auctionUser.AuctionId;
        }
    }
}
