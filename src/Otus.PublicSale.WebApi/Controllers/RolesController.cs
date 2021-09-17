using Otus.PublicSale.Core;
using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Domain.Administration;
using Otus.PublicSale.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Otus.PublicSale.WebApi.Mappers;

namespace Otus.PublicSale.WebApi.Controllers
{
    ///// <summary>
    ///// Roles Controller
    ///// </summary>
    //[ApiController]
    //[Authorize]
    //[Route("api/v1/[controller]")]
    //public class RolesController : ControllerBase
    //{
    //    /// <summary>
    //    /// Repository
    //    /// </summary>
    //    private readonly IRepository<Role> _repositoryRoles;

    //    /// <summary>
    //    /// Constuctor
    //    /// </summary>
    //    /// <param name="repositoryRoles">Roles Repository</param>        
    //    public RolesController(IRepository<Role> repositoryRoles)
    //    {
    //        _repositoryRoles = repositoryRoles;
    //    }

    //    /// <summary>
    //    /// Gets List of Roles
    //    /// </summary>
    //    /// <returns></returns>
    //    [HttpGet]
    //    public async Task<ActionResult<RoleDto>> GetRolesAsync()
    //    {
    //        var entities = await _repositoryRoles.GetAllAsync();

    //        var list = entities.Select(entity => new RoleDto(entity)).ToList();

    //        return Ok(list);
    //    }

    //    /// <summary>
    //    /// Gets Role By Id
    //    /// </summary>
    //    /// <param name="id">Role Id</param>
    //    /// <returns></returns>
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<RoleDto>> GettRoleAsync(int id)
    //    {
    //        var entity = await _repositoryRoles.GetByIdAsync(id);

    //        if (entity == null)
    //            return NotFound();

    //        var Dto = new RoleDto(entity);

    //        return Ok(Dto);
    //    }

    //    /// <summary>
    //    /// Creates Role
    //    /// </summary>        
    //    /// <param name="request">Role Dto</param>
    //    /// <returns>Role Id</returns>
    //    [HttpPost]
    //    public async Task<ActionResult<Guid>> CreatetRoleAsync(RoleDto request)
    //    {            
    //        var entity = RoleMapper.MapFromModel(request);

    //        await _repositoryRoles.AddAsync(entity);

    //        return Ok(entity.Id);

    //    }

    //    /// <summary>
    //    /// Updates Role
    //    /// </summary>
    //    /// <param name="id">Role Id</param>
    //    /// <param name="request">Role Dto</param> 
    //    /// <returns></returns>
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> UpdatetRoleAsync(int id, RoleDto request)
    //    {
    //        var entity = await _repositoryRoles.GetByIdAsync(id);

    //        if (entity == null)
    //            return NotFound();

    //        RoleMapper.MapFromModel(request, entity);

    //        await _repositoryRoles.UpdateAsync(entity);

    //        return Ok();
    //    }

    //    /// <summary>
    //    /// Deletes Role
    //    /// </summary>
    //    /// <param name="id">Role Id</param>
    //    /// <returns></returns>
    //    [HttpDelete]
    //    public async Task<IActionResult> DeletetRole(int id)
    //    {
    //        if (id == Constants.AdminRoleId)
    //            return BadRequest($"Can't delete Admin Role");

    //        if (id == Constants.UserRoleId)
    //            return BadRequest($"Can't delete User Role");

    //        var entity = await _repositoryRoles.GetByIdAsync(id);

    //        if (entity == null)
    //            return NotFound();

    //        if (entity.Users?.Count >0)
    //            return BadRequest($"Can't delete Role because there are {entity.Users?.Count} users with this role");

    //        await _repositoryRoles.RemoveAsync(entity);

    //        return Ok();
    //    }
    //}
}
