using Otus.PublicSale.Core.Domain;
using System;
using Otus.PublicSale.Core.Domain.AuctionManagement;

namespace Otus.PublicSale.WebApi.Models
{
    /// <summary>
    /// Auction Bet Statistic
    /// </summary>
    public class AuctionBetStatistic
    {
        /// <summary>
        /// Active Bidders
        /// </summary>
        public int ActiveBidders { get; set; }

        /// <summary>
        /// Watching
        /// </summary>
        public int Watching { get; set; }

        /// <summary>
        /// Total Bids
        /// </summary>
        public int TotalBids { get; set; }

    }
}
