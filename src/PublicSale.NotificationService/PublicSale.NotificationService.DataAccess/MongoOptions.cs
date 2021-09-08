using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PublicSale.NotificationService.Core.Abstractions;

namespace PublicSale.NotificationService.DataAccess
{
    public class MongoOptions : IMongoOptions
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
