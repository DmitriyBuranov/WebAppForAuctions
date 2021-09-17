using PublicSale.NotificationService.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.Core.Abstractions.Services
{
    public interface INotificationService
    {
        Task<bool> AddNotificationAsync(Notification notification);
    }

}
