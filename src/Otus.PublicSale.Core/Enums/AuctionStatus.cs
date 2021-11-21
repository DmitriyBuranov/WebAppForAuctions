using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.PublicSale.Core.Enums
{
    /// <summary>
    /// Auction Status
    /// </summary>
    public enum AuctionStatus : byte
    {
        /// <summary>
        /// Created
        /// </summary>
        Created = 1,

        /// <summary>
        /// Started
        /// </summary>
        Started = 2,

        /// <summary>
        /// Finished
        /// </summary>
        Finished = 3
    }
}
