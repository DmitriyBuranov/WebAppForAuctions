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
using System.Linq;
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
                .Select(x =>
                new Notification()
                {
                    Email = x.Email,
                    Message = x.Message,
                    Subject = x.Subject,
                    EmailFrom = x.EmailFrom
                }).ToList();

            foreach (var notification in notificationForSent)
                await SendEmailAsync(notification);
        }

        private async Task SendEmailAsync(Notification notification)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("Администрация сайта", notification.EmailFrom));
                emailMessage.To.Add(new MailboxAddress("", notification.Email));
                emailMessage.Subject = notification.Subject;
                emailMessage.Body = new TextPart("Plain")
                {
                    Text = notification.Message
                };

                using var client = new SmtpClient();
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync("team1.publicsale@yandex.com", "chvG9#LgBpDywm3");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error in SendEmailAsync: {ex}");
            }
        }
    }
}
