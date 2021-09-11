using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.PublicSale.Core.Abstractions.Services
{
    public interface ISendNotification
    {
        public string EmailFrom { get;  }

        public string EmailTo { get;}

        public string Subject { get; }

        public string Message { get; }
    }
}
