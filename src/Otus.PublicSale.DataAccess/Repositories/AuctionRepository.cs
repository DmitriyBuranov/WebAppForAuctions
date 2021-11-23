using Microsoft.EntityFrameworkCore;
using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Domain.AuctionManagement;
using Otus.PublicSale.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
            return  _dbSet.Where(x => x.StartDate > DateTime.UtcNow).Include(x => x.Winner).OrderBy(x => x.StartDate).Take(num);
        }

        public IEnumerable<AuctionWithBets> GetAmountNearToEndWithBets(int num)
        {
            return _dbSet.Where(x => x.StartDate < DateTime.UtcNow && x.EndDate > DateTime.UtcNow)
                .OrderBy(x => x.EndDate).Take(num)
                .Select(x=> new AuctionWithBets
                {
                    Name = x.Name,
                    Id = x.Id,
                    Count = x.AuctionBets.Count(),
                    PriceStart = x.PriceStart,
                    CurrentMaxBet = x.AuctionBets.Max(x => x.Amount),
                    Image = x.Image
                }).ToList();
        }


        public IEnumerable<AuctionWithBets> GetAmountWithBetsOrderedByAll(int num)
        {
            return _dbSet
                .OrderBy(x => x.Name).ThenBy(x=> x.StartDate).Take(num)
                .Select(x => new AuctionWithBets
                {
                    Name = x.Name,
                    Id = x.Id,
                    SellPrice = x.SellPrice,
                    Count = x.AuctionBets.Count(),
                    CurrentMaxBet = x.AuctionBets.Max(x => x.Amount),
                    PriceStart = x.PriceStart,
                    Image = x.Image
                }).ToList();
        }

        public IEnumerable<AuctionWithBets> GetAmountWithBetsOrderedByName(int num)
        {
            return _dbSet
                .OrderBy(x => x.Name).Take(num)
                .Select(x => new AuctionWithBets
                {
                    Name = x.Name,
                    Id = x.Id,
                    SellPrice = x.SellPrice,
                    Count = x.AuctionBets.Count(),
                    CurrentMaxBet = x.AuctionBets.Max(x => x.Amount),
                    PriceStart = x.PriceStart,
                    Image = x.Image
                }).ToList();
        }

        public IEnumerable<AuctionWithBets> GetAmountWithBetsOrderedByDate(int num)
        {
            return _dbSet
                .OrderBy(x => x.EndDate).Take(num)
                .Select(x => new AuctionWithBets
                {
                    Name = x.Name,
                    Id = x.Id,
                    SellPrice = x.SellPrice,
                    Count = x.AuctionBets.Count(),
                    CurrentMaxBet = x.AuctionBets.Max(x => x.Amount),
                    PriceStart = x.PriceStart,
                    Image = x.Image
                }).ToList();
        }

        public async Task<List<T>> GetJustHaveFinnishedAsync(DateTime endTime)
        {
            return await _dbSet.Where(x => x.EndDate.Year == endTime.Year && x.EndDate.DayOfYear == endTime.DayOfYear && 
            x.EndDate.Hour == endTime.Hour && x.EndDate.Minute == endTime.Minute && x.EndDate.Second == endTime.Second).ToListAsync();
        }
    }
}
