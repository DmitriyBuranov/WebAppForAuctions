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
using Otus.PublicSale.WebApi.Infostructure;
using Microsoft.Extensions.Caching.Distributed;
using Otus.PublicSale.WebApi.Extensions;
using System.Collections.Generic;

namespace Otus.PublicSale.WebApi.Controllers
{
    /// <summary>
    /// Auction Users Controller
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuctionUsersController : ControllerBase
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
        /// Auctions repository
        /// </summary>
        private readonly IRepository<AuctionUser> _repositoryAuctionUsers;
        private readonly IRepository<User> _repositoryUsers;
        private readonly IRepository<Auction> _repositoryAuctions;

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="repositoryAuctionUsers">Auction users repository</param>
        /// <param name="repositoryUsers">Users repository</param>
        /// <param name="repositoryAuctions">Auctions repository</param>
        /// <param name="cache">Distributed Cache</param>
        public AuctionUsersController(
            IRepository<AuctionUser> repositoryAuctionUsers, 
            IRepository<User> repositoryUsers, 
            IRepository<Auction> repositoryAuctions,
            IDistributedCache cache)
        {
            _repositoryAuctionUsers = repositoryAuctionUsers;
            _repositoryUsers = repositoryUsers;
            _repositoryAuctions = repositoryAuctions;

            _cache = cache;
        }

        /// <summary>
        /// Gets List of Auction Users
        /// </summary>
        /// <param name="auctionId">Auction Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<AuctionUserDto>> GetAuctionUsersAsync(int auctionId)
        {
            if (auctionId <= 0)
                return BadRequest();

            var list = await _cache.GetRecordAsync<List<AuctionUserDto>>(string.Format(_cacheAllKey, auctionId));
            if (list is null)
            {
                var entities = await _repositoryAuctionUsers.GetAllAsync(x => x.AuctionId == auctionId);
                list = entities.Select(entity => new AuctionUserDto(entity)).ToList();
                await _cache.SetRecordAsync(string.Format(_cacheAllKey, auctionId), list);
            }

            return Ok(list);
        }
        
        /// <summary>
        /// Gets Auction User By Id
        /// </summary>
        /// <param name="id">Auction User Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AuctionUserDto>> GettAuctionUserAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var model = await _cache.GetRecordAsync<AuctionUserDto>(string.Format(_cacheOneKey, id));
            if (model is null)
            {
                var entity = await _repositoryAuctionUsers.GetByIdAsync(id);

                if (entity == null)
                    return NotFound();

                model = new AuctionUserDto(entity);
                await _cache.SetRecordAsync(string.Format(_cacheOneKey, id), model);
            }

            return Ok(model);
        }
        
        /// <summary>
        /// Creates AuctionUser
        /// </summary>        
        /// <param name="request">Auction User Dto</param>
        /// <returns>Auction User Id</returns>
        [HttpPost]
        public async Task<ActionResult<int>> CreatetAuctionUserAsync(AuctionUserDto request)
        {
            var user = await _repositoryUsers.GetByIdAsync(request.UserId);

            if (user == null)
                return NotFound();

            var auction = await _repositoryAuctions.GetByIdAsync(request.AuctionId);

            if (auction == null)
                return NotFound();

            var entity = AuctionUserMapper.MapFromModel(request);

            await _repositoryAuctionUsers.AddAsync(entity);

            ClearCacheRecord(entity.Id, auction.Id);

            return Ok(entity.Id);
        }
        
        /// <summary>
        /// Updates Auction User
        /// </summary>
        /// <param name="id">Auction Id</param>
        /// <param name="request">Auction Dto</param> 
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatetAuctionAsync(int id, AuctionUserDto request)
        {
            var entity = await _repositoryAuctionUsers.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            var user = await _repositoryUsers.GetByIdAsync(request.UserId);

            if (user == null)
                return NotFound();

            var auction = await _repositoryAuctions.GetByIdAsync(request.AuctionId);

            if (auction == null)
                return NotFound();

            AuctionUserMapper.MapFromModel(request, entity);

            await _repositoryAuctionUsers.UpdateAsync(entity);

            ClearCacheRecord(entity.Id, auction.Id);

            return Ok();
        }
        
        /// <summary>
        /// Deletes Auction User
        /// </summary>
        /// <param name="id">Auction User Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeletetAuction(int id)
        {
            var entity = await _repositoryAuctionUsers.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            await _repositoryAuctionUsers.RemoveAsync(entity);

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
