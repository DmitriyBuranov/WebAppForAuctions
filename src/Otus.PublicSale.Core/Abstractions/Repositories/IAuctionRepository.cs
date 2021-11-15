using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Otus.PublicSale.Core.Domain;
using Otus.PublicSale.Core.Domain.AuctionManagement;

namespace Otus.PublicSale.Core.Abstractions.Repositories
{

    public interface IAuctionRepository<T> where T : Auction  
    {
        IEnumerable<T> GetAmountNearToStart(int num);

        IEnumerable<AuctionWithBets> GetAmountNearToEndWithBets(int num);
    }
}
