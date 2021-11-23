using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Otus.PublicSale.Users.Core.Abstractions.Services;
using Otus.PublicSale.Users.WebApi.Models;
using Otus.PublicSale.Users.Core.Domain;
using Otus.PublicSale.Core;

namespace Otus.PublicSale.Users.WebApi.Controllers
{
    /// <summary>
    /// Users Controller
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Authenticates user
        /// </summary>
        /// <param name="model">AuthenticateModel</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            if (model == null)
                return BadRequest();

            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("FullName", $"{user.FirstName} {user.LastName}"),
                    new Claim("Email", user.Username),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new AuthenticateResponse()
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString,
                Admin = user.Admin
            });
        }

        /// <summary>
        /// Registers new user
        /// </summary>
        /// <param name="model">RegisterModel</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            // map model to entity
            var user = _mapper.Map<User>(model);

            try
            {
                // create user
                _userService.Create(user, model.Password, model.RepeatPassword);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var model = _mapper.Map<IList<UserModel>>(users);
            return Ok(model);
        }

        /// <summary>
        /// Gets user by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            var model = _mapper.Map<UserModel>(user);
            return Ok(model);
        }

        /// <summary>
        /// Updates user
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="model">UpdateModel</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateModel model)
        {
            // map model to entity and set id
            var user = _mapper.Map<User>(model);
            user.Id = id;

            try
            {
                // update user 
                _userService.Update(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes user by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
