using Microsoft.Extensions.Logging;
using PublicSale.NotificationService.Core.Abstractions.Repositories;
using PublicSale.NotificationService.Core.Abstractions.Services;
using PublicSale.NotificationService.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.Core.Services
{
    public class NotificationSaveService : INotificationSaveService
    {
        private readonly IRepository<Notification> _notificationRepository;
        private readonly ILogger<NotificationSaveService> _logger;

        public NotificationSaveService(
            IRepository<Notification> notificationRepository,
            ILogger<NotificationSaveService> logger)
        {
            _notificationRepository = notificationRepository;
            _logger = logger;
        }

        public async Task<bool> AddNotificationAsync(Notification notification)
        {
            await _notificationRepository.AddAsync(notification);

            return true;
        }
    }

}
