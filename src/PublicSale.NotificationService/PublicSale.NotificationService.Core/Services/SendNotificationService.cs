using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;
using MimeKit;
using NLog;
using PublicSale.NotificationService.Core.Abstractions.Repositories;
using PublicSale.NotificationService.Core.Abstractions.Services;
using PublicSale.NotificationService.Core.Domain;
using PublicSale.NotificationService.Core.Domain.NotificationManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.Core.Services
{
    public class SendNotificationService : ISendNotificationService
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IRepository<Notification> _notificationRepository;
        private readonly IServiceProvider _serviceProvider;
        private readonly INotificationSaveService _notificationService;

        public SendNotificationService(IRepository<Notification> notificationRepository,
            IServiceProvider serviceProvider, INotificationSaveService notificationService)
        {
            _notificationRepository = notificationRepository;
            _serviceProvider = serviceProvider;
            _notificationService = notificationService;
        }

        public async void SendMessageAsync()
        {
            var notificationForSent = (await _notificationRepository.GetAllAsync())
                .Where(x => x.IsSend == false).ToList();

            foreach (var notification in notificationForSent)
                await SendEmailAsync(notification);
        }

        public async Task SendEmailAsync(Notification notification)
        {
            Console.WriteLine("Start save notification");
            try
            {
                var emailMessage = new MailMessage
                {
                    From = new MailAddress(notification.EmailFrom),
                    Subject = notification.Subject,
                    Body = notification.Message,
                    
                };
                emailMessage.To.Add(notification.Email);

                var client = new System.Net.Mail.SmtpClient("mysmtphost")
                {
                    DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                    PickupDirectoryLocation = @"C:\Emails"
                };
                client.Send(emailMessage);

                notification.IsSend = true;

            }
            catch (Exception ex)
            {
                _logger.Error($"Error in SendEmailAsync: {ex}");
                notification.ErrorsСount++;
            }

            await _notificationService.AddNotificationOrUpdateAsync(notification);
        }
    }
}
