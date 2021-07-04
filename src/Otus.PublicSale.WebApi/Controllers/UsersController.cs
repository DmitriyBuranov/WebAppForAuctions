using Otus.PublicSale.Core;
using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Domain.Administration;
using Otus.PublicSale.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Otus.PublicSale.WebApi.Controllers
{
    /// <summary>
    /// Users Controller
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Users repository
        /// </summary>
        private readonly IRepository<User> _repositoryUsers;

        /// <summary>
        /// Roles repository
        /// </summary>
        private readonly IRepository<Role> _repositoryRoles;

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="repositoryUsers">Users repository</param>        
        /// <param name="repositoryRoles">Roles repository</param>        
        public UsersController(IRepository<User> repositoryUsers, IRepository<Role> repositoryRoles)
        {
            _repositoryUsers = repositoryUsers;
            _repositoryRoles = repositoryRoles;
        }

        /// <summary>
        /// Gets List of Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUsersAsync()
        {
            var entities = await _repositoryUsers.GetAllAsync();

            var list = entities.Select(entity => CreateDto(entity)).ToList();

            return Ok(list);
        }

        /// <summary>
        /// Gets User By Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GettUserAsync(int id)
        {
            var entity = await _repositoryUsers.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            var model = CreateDto(entity);

            return Ok(model);
        }

        /// <summary>
        /// Creates User
        /// </summary>        
        /// <param name="request">User Dto</param>
        /// <returns>User Id</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> CreatetUserAsync(UserDto request)
        {
            var entity = new User()
            {
                FirstName = request.FirstName,
                Email = request.Email,
                LastName = request.LastName,
                Password = request.Password
            };

            var role = await GetOrCreateRole(request);

            entity.RoleId = role.Id;

            await _repositoryUsers.AddAsync(entity);

            return Ok(entity.Id);

        }

        /// <summary>
        /// Updates User
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="request">User Dto</param> 
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatetUserAsync(int id, UserDto request)
        {
            var entity = await _repositoryUsers.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            entity.FirstName = request.FirstName;
            entity.Email = request.Email;
            entity.LastName = request.LastName;

            if (!string.IsNullOrWhiteSpace(request.Password))
                entity.Password = request.Password;

            var role = await GetOrCreateRole(request);
            entity.RoleId = role.Id;

            await _repositoryUsers.UpdateAsync(entity);

            return Ok();
        }

        /// <summary>
        /// Deletes User
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeletetUser(int id)
        {
            if (id == Constants.DefaultAdminUserId)
                return BadRequest($"Can't delete Default Admin User");

            var entity = await _repositoryUsers.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            await _repositoryUsers.RemoveAsync(entity);

            return Ok();
        }

        /// <summary>
        /// Creates User Dto from Entity
        /// </summary>
        /// <param name="entity">User</param>
        /// <returns>User Dto</returns>
        private UserDto CreateDto(User entity)
        {
            return new UserDto()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                Email = entity.Email,
                LastName = entity.LastName,
                Password = "*****************",
                Role = new RoleDto()
                {
                    Id = entity.Role?.Id ?? entity.RoleId,
                    Name = entity.Role?.Name
                }
            };
        }

        /// <summary>
        /// Gets or Creates Role from User Dto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<Role> GetOrCreateRole(UserDto request) {
            var role = await _repositoryRoles.GetByIdAsync(request.Role?.Id ?? 0);
            if (role == null)
            {
                role = new Role() { Name = request.Role?.Name ?? $"New Role {Guid.NewGuid()}" };
                await _repositoryRoles.AddAsync(role);
            }

            return role;
        }
    }
}
