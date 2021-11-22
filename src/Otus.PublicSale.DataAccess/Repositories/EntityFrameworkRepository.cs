using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Domain;
using Otus.PublicSale.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace Otus.PublicSale.DataAccess.Repositories
{
    /// <summary>
    /// Entity Framework Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityFrameworkRepository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// DB Context
        /// </summary>
        protected readonly DataContext _dbContext;

        /// <summary>
        /// DB Set
        /// </summary>
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">DB Context</param>
        public EntityFrameworkRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        /// <summary>
        /// Get All Entities
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync(); 
        }

        /// <summary>
        /// Get Entity By Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Add new Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Remove Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get All Entities with condition
        /// </summary>
        /// <param name="predicate">Condition</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Gets query of Entities
        /// </summary>
        /// <param name="predicate">Cndition</param>        
        /// <returns></returns>
        public IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }
    }
}
