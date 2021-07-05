using Otus.PublicSale.Core;
using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Domain.Administration;
using Otus.PublicSale.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Otus.PublicSale.Core.Domain.AuctionManagement;

namespace Otus.PublicSale.WebApi.Controllers
{
    /// <summary>
    /// Auctions Controller
    /// </summary>
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

            var list = entities.Select(entity => CreateDto(entity)).ToList();

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

            var model = CreateDto(entity);

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
            var entity = new Auction()
            {
                Name = request.Name,
                Descition = request.Descition,
                CreateDate = request.CreateDate,
                Status = request.Status,
                StartDate = request.StartDate,
                Duration = request.Duration,
                PriceStart = request.PriceStart,
                PriceStep = request.PriceStep
            };


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

            entity.Name = request.Name;
            entity.Descition = request.Descition;
            entity.CreateDate = request.CreateDate;
            entity.Status = request.Status;
            entity.StartDate = request.StartDate;
            entity.Duration = request.Duration;
            entity.PriceStart = request.PriceStart;
            entity.PriceStep = request.PriceStep;


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

        /// <summary>
        /// Creates Auction Dto from Entity
        /// </summary>
        /// <param name="entity">Auction</param>
        /// <returns>Auction Dto</returns>
        private AuctionDto CreateDto(Auction entity)
        {
            return new AuctionDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Descition = entity.Descition,
                CreateDate = entity.CreateDate,
                Status = entity.Status,
                StartDate = entity.StartDate,
                Duration = entity.Duration,
                PriceStart = entity.PriceStart,
                PriceStep = entity.PriceStep
            };
        }
    }
}
