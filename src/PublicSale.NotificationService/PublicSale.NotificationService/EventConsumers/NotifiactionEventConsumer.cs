using MassTransit;
using Microsoft.Extensions.Logging;
using PublicSale.NotificationService.Core.Abstractions;
using PublicSale.NotificationService.Core.Abstractions.Services;
using PublicSale.NotificationService.Core.Domain;
using Core.Domain.NotificationManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.WebHost.EventConsumers
{

    public class NotifiactionEventConsumer : IConsumer<INotificationMaket>
    {
        private readonly INotificationSaveService _notificationService;
        private readonly ILogger<NotifiactionEventConsumer> _logger;

        public NotifiactionEventConsumer(
            INotificationSaveService notificationService,
            ILogger<NotifiactionEventConsumer> logger)
        {
            _notificationService = notificationService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<INotificationMaket> context)
        {
            var notification = new Notification 
            {
                Email = context.Message.EmailTo,
                Message = context.Message.Message,
                Subject = context.Message.Subject,
                EmailFrom = context.Message.EmailFrom,
                Quick = context.Message.Quick
            };

            await _notificationService.AddNotificationAsync(notification);
        }
    }

    
}
