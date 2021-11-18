using MongoDB.Driver;
using PublicSale.NotificationService.Core.Abstractions.Repositories;
using PublicSale.NotificationService.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.DataAccess.Repositories
{
    public class MongoRepository<T>
           : IRepository<T>
           where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IDataContext dataContext)
        {
            _collection = dataContext.Database.GetCollection<T>(typeof(T).Name);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await (await _collection.FindAsync(x => true)).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).SingleOrDefaultAsync();

        }

        public async Task UpdateAsync(T entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await _collection.DeleteOneAsync(x => x.Id == entity.Id);
        }

        public async Task DeleteAllAsync()
        {
            await _collection.DeleteManyAsync(x => true);
        }

    }
}
