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
        public AuctionUsersController(IRepository<AuctionUser> repositoryAuctionUsers, IRepository<User> repositoryUsers, IRepository<Auction> repositoryAuctions)
        {
            _repositoryAuctionUsers = repositoryAuctionUsers;
            _repositoryUsers = repositoryUsers;
            _repositoryAuctions = repositoryAuctions;
        }

        /// <summary>
        /// Gets List of Auction Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<AuctionDto>> GetAuctionUsersAsync()
        {
            var entities = await _repositoryAuctionUsers.GetAllAsync();

            var list = entities.Select(entity => new AuctionUserDto(entity)).ToList();

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
            var entity = await _repositoryAuctionUsers.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            var model = new AuctionUserDto(entity);

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

            return Ok();
        }
    }
}
