using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Domain.Administration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Otus.PublicSale.Core.Services
{
    /// <summary>
    /// User Background Service
    /// </summary>
    public class UserBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public UserBackgroundService(
            IServiceScopeFactory scopeFactory,
            IConfiguration configuration,
            ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _scopeFactory = scopeFactory;
            _logger = loggerFactory.CreateLogger<UserBackgroundService>();

            var connectionFactory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQ:HostName"],
                UserName = _configuration["RabbitMQ:Username"],
                Password = _configuration["RabbitMQ:Password"]
            };
            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "RefreshUserData", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (stoppingToken.IsCancellationRequested)
            {
                _channel.Dispose();
                _connection.Dispose();
                return Task.CompletedTask;
            }

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                if (message != null)
                {
                    Task.Run(async () =>
                    {
                        try
                        {
                            var userNew = JsonConvert.DeserializeObject<User>(message);
                            if (userNew != null)
                            {
                                using var scope = _scopeFactory.CreateScope();
                                var _repositoryUsers = scope.ServiceProvider.GetRequiredService<IRepository<User>>();

                                var userOld = await _repositoryUsers.GetByIdAsync(userNew.Id);
                                if (userOld != null)
                                {
                                    userOld.FirstName = userNew.FirstName;
                                    userOld.LastName = userNew.LastName;
                                    userOld.Email = userNew.Email;

                                    await _repositoryUsers.UpdateAsync(userOld);
                                }
                                else
                                {
                                    await _repositoryUsers.AddAsync(userNew);
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            _logger.LogError($"UserBackgroundService Error: {ex}");
                        }
                    });
                };
            };

            _channel.BasicConsume(queue: "RefreshUserData", autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
