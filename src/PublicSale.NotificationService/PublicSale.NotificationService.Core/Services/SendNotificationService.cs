using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;
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
    public class SendNotoficationService
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IRepository<Notification> _notificationRepository;
        private readonly IServiceProvider _serviceProvider;

        public SendNotoficationService( IRepository<Notification> notificationRepository, IServiceProvider serviceProvider)
        {
            _notificationRepository = notificationRepository;
            _serviceProvider = serviceProvider;
        }

        public async void SendMessageAsync()
        {
            var currentDay = DateTime.Now.Date;
            var notificationForSent =await _notificationRepository.GetAllAsync();

            var notificationForSentlList = notificationForSent.Select(x =>
                new NotificationDto()
                {
                    Email = x.Email,
                    Message = x.Message,
                    Subject = x.Subject,
                    EmailFrom = x.EmailFrom
                }).ToList();


            foreach (var notification in notificationForSent)
            {
                 async Task SendEmailAsync(string email, string subject, string message)
                {
                    var emailMessage = new MimeMessage();

                    emailMessage.From.Add(new MailboxAddress("Администрация сайта", "login@yandex.ru"));
                    emailMessage.To.Add(new MailboxAddress("", email));
                    emailMessage.Subject = subject;
                    emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                    {
                        Text = message
                    };

                    using (var client = new SmtpClient())
                    {
                        await client.ConnectAsync("smtp.yandex.ru", 25, false);
                        await client.AuthenticateAsync("login@yandex.ru", "password");
                        await client.SendAsync(emailMessage);

                        await client.DisconnectAsync(true);
                    }
                }

            }

            //if (isSended)
            //    _logger.Info($"Send");
            //else
            //    _logger.Error($"Error");
        }

    }
}
