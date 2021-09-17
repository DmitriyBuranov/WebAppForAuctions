using MassTransit;
using Microsoft.Extensions.Logging;
using PublicSale.NotificationService.Core.Abstractions;
using PublicSale.NotificationService.Core.Abstractions.Services;
using PublicSale.NotificationService.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.WebHost.EventConsumers
{

    public class AddNotifiactionEventConsumer : IConsumer<IReceiveNotification>
    {
        private readonly INotificationService _notificationService;
        private readonly ILogger<AddNotifiactionEventConsumer> _logger;

        public AddNotifiactionEventConsumer(
            INotificationService notificationService,
            ILogger<AddNotifiactionEventConsumer> logger)
        {
            _notificationService = notificationService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<IReceiveNotification> context)
        {
            var notification = new Notification 
            {
                Email = context.Message.Email,
                Message = context.Message.Message,
                Subject = context.Message.Subject,
                EmailFrom = context.Message.EmailFrom
            };

            await _notificationService.AddNotificationAsync(notification);
        }
    }

    
}
