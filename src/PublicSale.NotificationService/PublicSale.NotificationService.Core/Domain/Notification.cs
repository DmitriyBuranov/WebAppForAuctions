using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.Core.Domain
{
    public class Notification : BaseEntity
    {
        public string Email { get; set; }

        public string Message {  get; set; }

        public string Status {  get; set; }

    }
}
