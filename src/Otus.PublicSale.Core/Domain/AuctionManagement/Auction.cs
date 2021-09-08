﻿using System;
using System.Collections.Generic;

namespace Otus.PublicSale.Core.Domain.AuctionManagement
{
    /// <summary>
    /// Auction
    /// </summary>
    public partial class Auction: BaseEntity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Auction()
        {
            AuctionBets = new HashSet<AuctionBet>();
            AuctionFiles = new HashSet<AuctionFile>();
            AuctionUsers = new HashSet<AuctionUser>();
        }
        
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descition
        /// </summary>
        public string Descition { get; set; }

        /// <summary>
        /// Create Date
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Duration
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Price Start
        /// </summary>
        public decimal PriceStart { get; set; }

        /// <summary>
        /// Price Step
        /// </summary>
        public decimal PriceStep { get; set; }

        /// <summary>
        /// Auction Bets
        /// </summary>
        public virtual ICollection<AuctionBet> AuctionBets { get; set; }

        /// <summary>
        /// Auction Files
        /// </summary>
        public virtual ICollection<AuctionFile> AuctionFiles { get; set; }

        /// <summary>
        /// Auction Users
        /// </summary>
        public virtual ICollection<AuctionUser> AuctionUsers { get; set; }

        /// <summary>
        /// SellPrice
        /// </summary>
        public decimal SellPrice { get; set; }

        /// <summary>
        /// CurrentPrice
        /// </summary>
        public decimal CurrentPrice { get; set; }

        /// <summary>
        /// LowestPrice
        /// </summary>
        public decimal LowestPrice { get; set; }


    }
}
