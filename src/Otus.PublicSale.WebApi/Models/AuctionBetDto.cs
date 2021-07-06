using Otus.PublicSale.Core.Domain;
using System;

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
    }
}
