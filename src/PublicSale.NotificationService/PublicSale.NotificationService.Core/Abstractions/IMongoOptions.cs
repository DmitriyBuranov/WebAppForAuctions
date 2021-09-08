using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.Core.Abstractions
{
    public interface IMongoOptions
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
    }
}
