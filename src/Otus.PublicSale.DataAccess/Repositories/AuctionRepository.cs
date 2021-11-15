using Microsoft.EntityFrameworkCore;
using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Domain.AuctionManagement;
using Otus.PublicSale.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Otus.PublicSale.DataAccess.Repositories
{
    public class AuctionRepository<T> : IAuctionRepository<T> where T : Auction
    { 

        protected readonly DataContext _dbContext;


        private readonly DbSet<T> _dbSet;

        public AuctionRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public  IEnumerable<T> GetAmountNearToStart(int num)
        {
            return  _dbSet.Where(x => x.StartDate > DateTime.UtcNow).OrderBy(x => x.StartDate).Take(num);
        }

        public IEnumerable<AuctionWithBets> GetAmountNearToEndWithBets(int num)
        {
            var auctions = _dbSet.Where(x => x.StartDate < DateTime.UtcNow).OrderBy(x => x.StartDate.AddDays(x.Duration)).Take(num);
            var list =   auctions.Select(x=> new AuctionWithBets
                {
                    Name = x.Name,
                    Id = x.Id,
                    Count = x.AuctionBets.Count(),
                    CurrentMaxBet = x.AuctionBets.Max(x => x.Amount)
                }).ToList();

            return list;
        }
    }
}
