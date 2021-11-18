using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicSale.NotificationService.Core.Abstractions.Repositories;
using PublicSale.NotificationService.Core.Domain;
using PublicSale.NotificationService.WebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IRepository<Notification> _notificationRepository;

        public NotificationController(IRepository<Notification> notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreatetNotificationAsync(NotificationDto request)
        {
            var entity = new Notification()
            {
                Email = request.Email,
                Message = request.Message,
                Subject = request.Subject,
                EmailFrom = request.EmailFrom
            };

            await _notificationRepository.AddAsync(entity);

            return Ok(entity.Id);
        }

        [HttpGet]
        public async Task<List<Notification>> GetNotificationAsync()
        {
            var notifications = await _notificationRepository.GetAllAsync();

            var notificationsList = notifications.ToList();

            return notificationsList;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await _notificationRepository.DeleteAllAsync();

            return Ok();
        }


    }
}
