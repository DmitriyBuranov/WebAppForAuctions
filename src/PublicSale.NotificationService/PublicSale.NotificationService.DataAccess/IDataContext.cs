using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.DataAccess
{
    public interface IDataContext
    {
        IMongoDatabase Database { get; set; }
    }
}
