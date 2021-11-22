using Otus.PublicSale.Core.Domain;
using System;
using Otus.PublicSale.Core.Domain.AuctionManagement;

namespace Otus.PublicSale.WebApi.Models
{
    /// <summary>
    /// Auction Bet History Item
    /// </summary>
    public class AuctionBetHistoryItem : BaseEntity
    {
        /// <summary>
        /// Auction Id
        /// </summary>
        public string FullName { get; set; }        

        /// <summary>
        /// Date
        /// </summary>
        public double Date { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Constuctor
        /// </summary>
        public AuctionBetHistoryItem()
        {
        }

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="auctionBet">Auction Bet</param>
        public AuctionBetHistoryItem(AuctionBet auctionBet)
        {
            Id = auctionBet.Id;
            Amount = auctionBet.Amount;            
            Date = auctionBet.Date.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            FullName = $"{auctionBet.User.FirstName} {auctionBet.User.LastName}";
            UserId = auctionBet.UserId;
        }
    }
}
