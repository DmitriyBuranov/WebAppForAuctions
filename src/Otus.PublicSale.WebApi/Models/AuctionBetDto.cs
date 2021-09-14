using Otus.PublicSale.Core.Domain;
using System;
using Otus.PublicSale.Core.Domain.AuctionManagement;

namespace Otus.PublicSale.WebApi.Models
{
    /// <summary>
    /// User Dto
    /// </summary>
    public class AuctionBetDto : BaseEntity
    {
        /// <summary>
        /// Auction Id
        /// </summary>
        public int AuctionId { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Constuctor
        /// </summary>
        public AuctionBetDto()
        {

        }

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="auctionBet">Auction Bet</param>
        public AuctionBetDto(AuctionBet auctionBet)
        {
            Id = auctionBet.Id;
            Amount = auctionBet.Amount;
            AuctionId = auctionBet.AuctionId;
            Date = auctionBet.Date;
            UserId = auctionBet.UserId;
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj">obj</param>
        /// <returns></returns>
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

            var data = obj as AuctionBetDto;

            return this.Id == data.Id && this.AuctionId == data.AuctionId && this.Amount == data.Amount && this.Date == data.Date;
        }

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, AuctionId, UserId, Date, Amount);
        }
    }
}
