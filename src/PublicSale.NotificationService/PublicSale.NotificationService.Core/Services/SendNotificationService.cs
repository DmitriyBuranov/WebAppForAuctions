using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;
using MimeKit;
using NLog;
using PublicSale.NotificationService.Core.Abstractions.Repositories;
using PublicSale.NotificationService.Core.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.Core.Services
{
    public class SendNotificationService
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IRepository<Notification> _notificationRepository;
        private readonly IServiceProvider _serviceProvider;

        public SendNotificationService(IRepository<Notification> notificationRepository, IServiceProvider serviceProvider)
        {
            _notificationRepository = notificationRepository;
            _serviceProvider = serviceProvider;
        }

        public async void SendMessageAsync()
        {
            var notificationForSent = (await _notificationRepository.GetAllAsync())
                .Where(x => x.IsSend == false).ToList();

            foreach (var notification in notificationForSent)
                await SendEmailAsync(notification);
        }

        private async Task SendEmailAsync(Notification notification)
        {
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

            await _notificationRepository.UpdateAsync(notification);
        }
    }
}
