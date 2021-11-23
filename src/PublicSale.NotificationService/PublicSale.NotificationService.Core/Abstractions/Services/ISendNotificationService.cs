using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.Core.Domain.NotificationManagement
{
    public interface ISendNotificationService
    {
        Task SendEmailAsync(Notification notification);

        void SendMessageAsync();
    }
}
