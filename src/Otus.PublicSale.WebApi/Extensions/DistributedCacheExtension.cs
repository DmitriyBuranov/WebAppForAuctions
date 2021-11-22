using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Otus.PublicSale.WebApi.Extensions
{
    /// <summary>
    /// Distributed Cache Extension
    /// </summary>
    public static class DistributedCacheExtension
    {
        /// <summary>
        /// Sets Record Async
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="cache">Cache</param>
        /// <param name="cacheKey">Cache Key</param>
        /// <param name="data">Data</param>
        /// <param name="absoluteExpireTime">Absolute Expire Time</param>
        /// <param name="slidingExpirationTime">Sliding Expiration Time</param>
        /// <returns></returns>
        public static async Task SetRecordAsync<T>(this IDistributedCache cache, string cacheKey, T data, TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpirationTime = null)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60),
                SlidingExpiration = slidingExpirationTime
            };
            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(cacheKey, jsonData, options);
        }

        /// <summary>
        /// Gets Record Async
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="cache">Cache</param>
        /// <param name="cacheKey">Cache Key</param>
        /// <returns></returns>
        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string cacheKey)
        {
            var jsonData = await cache.GetStringAsync(cacheKey);
            if (jsonData is null || string.IsNullOrEmpty(jsonData))
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(jsonData);
        }

        /// <summary>
        /// Removes Record Async
        /// </summary>        
        /// <param name="cache">Cache</param>
        /// <param name="cacheKey">Cache Key</param>
        /// <returns></returns>
        public static async void RemoveRecordAsync(this IDistributedCache cache, string cacheKey)
        {
            await cache.RemoveAsync(cacheKey);
        }
    }
}
