using Core.Domain.NotificationManagement;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Domain.Administration;
using Otus.PublicSale.Core.Domain.AuctionManagement;
using Otus.PublicSale.WebApi.Models;
using System.Threading.Tasks;

namespace Otus.PublicSale.WebApi.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> SendNotification (int id, NotificationDto request)
        {
            var user = await _repositoryUsers.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            await _publishEndpoint.Publish<INotificationMaket>(
                new
                {
                    EmailFrom = request.EmailFrom,
                    EmailTo = user.Email,
                    Subject = request.Subject,
                    Message = request.Message,
                    Quick = request.Quick
    
                });

            return Ok();

        }
    }
}
