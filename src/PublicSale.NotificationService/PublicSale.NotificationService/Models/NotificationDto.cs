using PublicSale.NotificationService.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.WebHost.Models
{
    public class NotificationDto : BaseEntity
    {
        public string Email { get; set; }

        public string EmailFrom { get; set; }

        public string Message { get; set; }

        public string Subject { get; set; }

    }
}
