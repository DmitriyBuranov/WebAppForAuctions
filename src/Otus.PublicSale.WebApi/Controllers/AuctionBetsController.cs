using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Otus.PublicSale.Core.Domain.AuctionManagement;
using System.Collections.Generic;
using Otus.PublicSale.WebApi.Mappers;

namespace Otus.PublicSale.WebApi.Controllers
{
    /// <summary>
    /// AuctionBets Controller
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuctionBetsController : ControllerBase
    {
        /// <summary>
        /// AuctionBets repository
        /// </summary>
        private readonly IRepository<AuctionBet> _repositoryAuctionBets;

        /// <summary>
        /// Auctions repository
        /// </summary>
        private readonly IRepository<Auction> _repositoryAuctions;

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="repositoryAuctionBets">AuctionBets repository</param>        
        /// <param name="repositoryAuctions">Auctions repository</param>        
        public AuctionBetsController(
            IRepository<AuctionBet> repositoryAuctionBets, 
            IRepository<Auction> repositoryAuctions)
        {
            _repositoryAuctionBets = repositoryAuctionBets;
            _repositoryAuctions = repositoryAuctions;
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

            var entities = await _repositoryAuctionBets.GetAllAsync(x => x.AuctionId == auctionId);

            var list = entities.Select(entity => new AuctionBetDto(entity)).ToList();

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

            var entity = await _repositoryAuctionBets.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            var model = new AuctionBetDto(entity);

            return Ok(model);
        }

        /// <summary>
        /// Creates AuctionBet
        /// </summary>        
        /// <param name="request">AuctionBet Dto</param>
        /// <returns>AuctionBet Id</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync(AuctionBetDto request)
        {
            var auction = await _repositoryAuctions.GetByIdAsync(request.AuctionId);

            if (auction == null)
                return NotFound();

            var entity = AuctionBetMapper.MapFromModel(request, auction);     

            await _repositoryAuctionBets.AddAsync(entity);

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

            return Ok();
        }
    }
}
