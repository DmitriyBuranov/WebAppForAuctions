using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.Core.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IServiceProvider _services;
        private Timer _timer;

        public TimedHostedService(IServiceProvider services)
        {
            _services = services;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.Info("Timed Hosted Service running.");

            TimeSpan startForEveryDayTimer = TimeSpan.Zero;

            _timer = new Timer(DoEveryDayWork, null, startForEveryDayTimer, TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        private  void DoEveryDayWork(object state)
        {
            using (var scope = _services.CreateScope())
            {
                var sendNotificationService = scope.ServiceProvider
                                .GetRequiredService<SendNotificationService>();

                try
                {
                    _logger.Info("Start sending notification");
                    Console.WriteLine("Start sending notification");
                    sendNotificationService.SendMessageAsync();
                }
                catch (Exception ex)
                {
                    _logger.Error($"Error: {ex}");
                    Console.WriteLine($"Error: {ex}");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.Info("Timed Hosted stopped.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
