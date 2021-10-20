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

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            var data = obj as AuctionUserDto;

            return this.Id == data.Id && this.AuctionId == data.AuctionId && this.Date == data.Date;
        }

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, AuctionId, UserId, Date);
        }
    }


}
