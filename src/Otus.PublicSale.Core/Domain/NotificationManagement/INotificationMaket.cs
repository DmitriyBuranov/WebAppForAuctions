using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.NotificationManagement

{
    public interface INotificationMaket
    {
        public string EmailFrom { get;  }

        public string EmailTo { get;  }

        public string Subject { get; }

        public string Message { get;  }

        public Boolean Quick {  get;  }
    }
}
