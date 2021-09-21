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
        /// Auctions repository
        /// </summary>
        private readonly IRepository<Auction> _repositoryAuctions;

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="repositoryAuctions">Auctions repository</param>        
        /// <param name="repositoryRoles">Roles repository</param>        
        public AuctionsController(IRepository<Auction> repositoryAuctions)
        {
            _repositoryAuctions = repositoryAuctions;
        }

        /// <summary>
        /// Gets List of Auctions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<AuctionDto>> GetAuctionsAsync()
        {
            var entities = await _repositoryAuctions.GetAllAsync();

            var list = entities.Select(entity => new AuctionDto(entity)).ToList();

            return Ok(list);
        }

        /// <summary>
        /// Gets Auction By Id
        /// </summary>
        /// <param name="id">Auction Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AuctionDto>> GettAuctionAsync(int id)
        {
            var entity = await _repositoryAuctions.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            var model = new AuctionDto(entity);

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

            return Ok();
        }
    }
}
