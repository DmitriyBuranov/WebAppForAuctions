using Otus.PublicSale.Core.Domain.AuctionManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Otus.PublicSale.Core.Abstractions.Repositories
{
    public interface IAuctionBetRepository<T> where T : AuctionBet
    {
        Task<T> GetLastBetAsync(int auctionId);

    }
}
