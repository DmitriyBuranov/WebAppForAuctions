using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otus.PublicSale.WebApi.Models
{
    public class AuctionWithBets
    {
        string Name { get; set; }

        int Id {  get; set; }

        int Count {  get; set; }

        decimal CurrentMaxBet {  get; set; }
    }
}
