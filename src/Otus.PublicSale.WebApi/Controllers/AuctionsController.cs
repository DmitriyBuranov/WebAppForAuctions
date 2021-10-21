using Otus.PublicSale.Core;
using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Domain.Administration;
using Otus.PublicSale.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Otus.PublicSale.Core.Domain.AuctionManagement;
using Otus.PublicSale.WebApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Otus.PublicSale.WebApi.Extensions;
using System.Collections.Generic;

namespace Otus.PublicSale.WebApi.Controllers
{
    /// <summary>
    /// Auctions Controller
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuctionsController : ControllerBase
    {
        /// <summary>
        /// Constants
        /// </summary>
        private const string _cacheOneKey = "Action_{0}";
        private const string _cacheAllKey = "Actions";

        /// <summary>
        /// Cache
        /// </summary>
        private readonly IDistributedCache _cache;

        /// <summary>
        /// Auctions repository
        /// </summary>
        private readonly IRepository<Auction> _repositoryAuctions;

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="repositoryAuctions">Auctions repository</param>            
        /// <param name="cache">Cache</param>     
        public AuctionsController(IRepository<Auction> repositoryAuctions, IDistributedCache cache)
        {
            _repositoryAuctions = repositoryAuctions;
            _cache = cache;
        }

        /// <summary>
        /// Gets List of Auctions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<AuctionDto>> GetAuctionsAsync()
        {
            var list = await _cache.GetRecordAsync<List<AuctionDto>>(_cacheAllKey);
            if (list is null)
            {
                var entities = await _repositoryAuctions.GetAllAsync();                
                list = entities.Select(entity => new AuctionDto(entity)).ToList();                                
                await _cache.SetRecordAsync(_cacheAllKey, list);
            }

            return Ok(list);
        }

        /// <summary>
        /// Gets Auction By Id
        /// </summary>
        /// <param name="id">Auction Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AuctionDto>> GetAuctionAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var model = await _cache.GetRecordAsync<AuctionDto>(string.Format(_cacheOneKey, id));
            if (model is null)
            {
                var entity = await _repositoryAuctions.GetByIdAsync(id);

                if (entity == null)
                    return NotFound();

                model = new AuctionDto(entity);
                await _cache.SetRecordAsync(string.Format(_cacheOneKey, id), model);
            }

            return Ok(model);
        }

        /// <summary>
        /// Creates Auction
        /// </summary>        
        /// <param name="request">Auction Dto</param>
        /// <returns>Auction Id</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> CreatetAuctionAsync(AuctionDto request)
        {
            var entity = AuctionMapper.MapFromModel(request);            
            await _repositoryAuctions.AddAsync(entity);

            ClearCacheRecord(entity.Id);

            return Ok(entity.Id);
        }

        /// <summary>
        /// Updates Auction
        /// </summary>
        /// <param name="id">Auction Id</param>
        /// <param name="request">Auction Dto</param> 
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatetAuctionAsync(int id, AuctionDto request)
        {
            var entity = await _repositoryAuctions.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            AuctionMapper.MapFromModel(request, entity);
            
            await _repositoryAuctions.UpdateAsync(entity);

            ClearCacheRecord(id);

            return Ok();
        }

        /// <summary>
        /// Deletes Auction
        /// </summary>
        /// <param name="id">Auction Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeletetAuction(int id)
        {
            var entity = await _repositoryAuctions.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            await _repositoryAuctions.RemoveAsync(entity);

            ClearCacheRecord(id);

            return Ok();
        }


        /// <summary>
        /// Clears Cache Record
        /// </summary>
        /// <param name="id">Entity Id</param>
        private void ClearCacheRecord(int id)
        {
            _cache.RemoveRecordAsync(string.Format(_cacheOneKey, id));
            _cache.RemoveRecordAsync(_cacheAllKey);
        }
    }
}
