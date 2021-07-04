﻿using Otus.PublicSale.Core.Domain.Administration;
using System;

namespace Otus.PublicSale.Core.Domain.AuctionManagement
{
    /// <summary>
    /// Auction Bet
    /// </summary>
    public partial class AuctionBet: BaseEntity
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
        /// Auction
        /// </summary>
        public virtual Auction Auction { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public virtual User User { get; set; }
    }
}
