using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.Core.Services
{
    internal class TimedHostedService : IHostedService, IDisposable
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
            TimeSpan startForEveryDayTimer = DateTime.Today.TimeOfDay - DateTime.Now.TimeOfDay;
            if (startForEveryDayTimer < TimeSpan.Zero)
                startForEveryDayTimer = TimeSpan.FromHours(31) + startForEveryDayTimer;

            _timer = new Timer(DoEveryDayWork, null, startForEveryDayTimer, TimeSpan.FromMinutes(5));

            TimeSpan start = DateTime.Today.TimeOfDay - DateTime.Now.TimeOfDay;
            if (start < TimeSpan.Zero)
                start = TimeSpan.FromMinutes(5) + start;

            return Task.CompletedTask;
        }

        private async void DoEveryDayWork(object state)
        {
            using var scope = _services.CreateScope();
            var sendRegistryInfoService = scope.ServiceProvider
                .GetRequiredService<SendNotificationService>();

            try
            {
                _logger.Info("Start sending notification");
                sendRegistryInfoService.SendMessageAsync();
            }
            catch (Exception ex)
            {
                _logger.Error($"Error: {ex}");
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
