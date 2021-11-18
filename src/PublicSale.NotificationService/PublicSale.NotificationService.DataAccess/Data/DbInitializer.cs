using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSale.NotificationService.DataAccess.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IMongoDatabase _database;

        public DbInitializer(IDataContext dataContext)
        {
            _database = dataContext.Database;
        }

        public void InitializeDb()
        {
            //_database.Client.DropDatabase(_database.DatabaseNamespace.DatabaseName);

        }
    }
}
