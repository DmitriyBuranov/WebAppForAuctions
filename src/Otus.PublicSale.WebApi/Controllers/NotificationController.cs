using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Abstractions.Services;
using Otus.PublicSale.Core.Domain.Administration;
using Otus.PublicSale.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otus.PublicSale.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {


        private readonly IRepository<User> _repositoryUsers;

        readonly IPublishEndpoint _publishEndpoint;
    
        public NotificationController(IRepository<User> repositoryUsers, IPublishEndpoint publishEndpoint)
        {
            _repositoryUsers = repositoryUsers;
            _publishEndpoint = publishEndpoint;
        }

        /// <summary>
        /// Send Notification to User
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="request">Notification Dto</param> 
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> SendNotification (int id, NotificationDto request)
        {
            var user = await _repositoryUsers.GetByIdAsync(id);

            await _publishEndpoint.Publish<ISendNotification>(
                new
                {
                    EmailFrom = request.EmailFrom,
                    EmailTo = user.Email,
                    Subject = request.Subject,
                    Message = request.Message
    
                });


            return Ok();

        }
    }
}
