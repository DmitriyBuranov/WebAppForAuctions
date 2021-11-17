using Microsoft.EntityFrameworkCore;
using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Domain.AuctionManagement;
using Otus.PublicSale.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.PublicSale.DataAccess.Repositories
{
    public class AuctionBetRepository<T> : IAuctionBetRepository<T> where T : AuctionBet
    {

        protected readonly DataContext _dbContext;


        private readonly DbSet<T> _dbSet;

        public AuctionBetRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }


        public async Task<T> GetLastBetAsync(int auctionId)
        {
            return await _dbSet.Where(x => x.AuctionId == auctionId).LastOrDefaultAsync();
        }
    }
}
