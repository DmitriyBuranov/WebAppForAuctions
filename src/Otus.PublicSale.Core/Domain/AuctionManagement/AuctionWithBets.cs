using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otus.PublicSale.Core.Domain.AuctionManagement
{
    public class AuctionWithBets
    {
        public string Name { get; set; }

        public int Id {  get; set; }

        public int Count {  get; set; }

        public decimal PriceStart { get; set; }

        public decimal? CurrentMaxBet {  get; set; }

        public decimal SellPrice { get; set; }

        public string Image { get; set; }
    }
}
