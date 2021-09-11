using System.Collections.Generic;

namespace Otus.PublicSale.Core.Domain.AuctionManagement
{
    /// <summary>
    /// Category
    /// </summary>
    public partial class Category: BaseEntity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Category()
        {
            Auctions = new HashSet<Auction>();
        }
        
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Auctions
        /// </summary>
        public virtual ICollection<Auction> Auctions { get; set; }
    }
}
