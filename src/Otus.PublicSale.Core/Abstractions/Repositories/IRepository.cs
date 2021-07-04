﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Otus.PublicSale.Core.Domain;

namespace Otus.PublicSale.Core.Abstractions.Repositories
{
    /// <summary>
    /// IRepository
    /// </summary>
    /// <typeparam name="T">Base Entity</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get All Entities
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Get Entity By Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Add new Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Remove Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task RemoveAsync(T entity);
    }
}
