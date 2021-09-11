using Otus.PublicSale.Core.Domain.Administration;
using System.Collections.Generic;

namespace Otus.PublicSale.Core.Domain.AuctionManagement
{

    public partial class Favorites : BaseEntity
    {
        public virtual User User { get; set; }
        public virtual Auction Auction { get; set; }
        
    }
}
