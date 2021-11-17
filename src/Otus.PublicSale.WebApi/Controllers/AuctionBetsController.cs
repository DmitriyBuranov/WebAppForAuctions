using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Otus.PublicSale.Core.Domain.AuctionManagement;
using System.Collections.Generic;
using Otus.PublicSale.WebApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Otus.PublicSale.WebApi.Extensions;
using Microsoft.AspNetCore.SignalR;
using Otus.PublicSale.WebApi.Hubs;

namespace Otus.PublicSale.WebApi.Controllers
{
    /// <summary>
    /// AuctionBets Controller
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuctionBetsController : ControllerBase
    {
        /// <summary>
        /// Constants
        /// </summary>
        private const string _cacheOneKey = "AuctionBet_{0}";
        private const string _cacheAllKey = "AuctionBets_{0}";

        /// <summary>
        /// Cache
        /// </summary>
        private readonly IDistributedCache _cache;

        /// <summary>
        /// AuctionBets repository
        /// </summary>
        private readonly IRepository<AuctionBet> _repositoryAuctionBets;

        /// <summary>
        /// Auctions repository
        /// </summary>
        private readonly IRepository<Auction> _repositoryAuctions;

        /// <summary>
        /// Auction Bets Hub
        /// </summary>
        private readonly IHubContext<AuctionBetsHub> _hubContext;

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="repositoryAuctionBets">AuctionBets repository</param>        
        /// <param name="repositoryAuctions">Auctions repository</param>        
        /// <param name="cache">Cache</param>     
        /// <param name="hubContext">Hub Context</param>     
        public AuctionBetsController(
            IRepository<AuctionBet> repositoryAuctionBets, 
            IRepository<Auction> repositoryAuctions, 
            IDistributedCache cache,
            IHubContext<AuctionBetsHub> hubContext)
        {
            _repositoryAuctionBets = repositoryAuctionBets;
            _repositoryAuctions = repositoryAuctions;

            _cache = cache;
            _hubContext = hubContext;
        }

        /// <summary>
        /// Gets List of Auction Bets
        /// </summary>
        /// <param name="auctionId">Auction Id</param>
        /// <returns></returns>
        [HttpGet("GetAll/{auctionId}")]
        public async Task<ActionResult<List<AuctionBetDto>>> GetAllAsync(int auctionId)
        {
            if (auctionId <= 0)
                return BadRequest();

            var list = await _cache.GetRecordAsync<List<AuctionBetDto>>(string.Format(_cacheAllKey, auctionId));
            if (list is null)
            {
                var entities = await _repositoryAuctionBets.GetAllAsync(x => x.AuctionId == auctionId);
                list = entities.Select(entity => new AuctionBetDto(entity)).ToList();
                await _cache.SetRecordAsync(string.Format(_cacheAllKey, auctionId), list);
            }            

            return Ok(list);
        }

        /// <summary>
        /// Gets AuctionBet By Id
        /// </summary>
        /// <param name="id">AuctionBet Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AuctionBetDto>> GetOneAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var model = await _cache.GetRecordAsync<AuctionBetDto>(string.Format(_cacheOneKey, id));
            if (model is null)
            {
                var entity = await _repositoryAuctionBets.GetByIdAsync(id);

                if (entity == null)
                    return NotFound();

                model = new AuctionBetDto(entity);
                await _cache.SetRecordAsync(string.Format(_cacheOneKey, id), model);
            }

            return Ok(model);
        }

        /// <summary>
        /// Creates AuctionBet
        /// </summary>        
        /// <param name="request">AuctionBet Dto</param>
        /// <returns>AuctionBet Id</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Guid>> CreateAsync(AuctionBetDto request)
        {
            request.UserId = 1;

            var auction = await _repositoryAuctions.GetByIdAsync(request.AuctionId);

            if (auction == null)
                return NotFound();

            var entity = AuctionBetMapper.MapFromModel(request, auction);     

            await _repositoryAuctionBets.AddAsync(entity);

            ClearCacheRecord(entity.Id, auction.Id);

            await _hubContext.Clients.Group($"Auction_{auction.Id}").SendAsync("NewBet", $"{DateTime.UtcNow} - new bet added");

            return Ok(entity.Id);
        }

        /// <summary>
        /// Updates AuctionBet
        /// </summary>
        /// <param name="id">AuctionBet Id</param>
        /// <param name="request">AuctionBet Dto</param> 
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, AuctionBetDto request)
        {
            var entity = await _repositoryAuctionBets.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            AuctionBetMapper.MapFromModel(request: request, auctionBet: entity);
            
            await _repositoryAuctionBets.UpdateAsync(entity);

            ClearCacheRecord(entity.Id, entity.AuctionId);

            return Ok();
        }

        /// <summary>
        /// Deletes AuctionBet
        /// </summary>
        /// <param name="id">AuctionBet Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repositoryAuctionBets.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            await _repositoryAuctionBets.RemoveAsync(entity);

            ClearCacheRecord(entity.Id, entity.AuctionId);

            return Ok();
        }

        /// <summary>
        /// Clears Cache Record
        /// </summary>
        /// <param name="id">Entity Id</param>
        /// <param name="auctionId">Auction Id</param>
        private void ClearCacheRecord(int id, int auctionId)
        {
            _cache.RemoveRecordAsync(string.Format(_cacheOneKey, id));
            _cache.RemoveRecordAsync(string.Format(_cacheAllKey, auctionId));
        }
    }
}
