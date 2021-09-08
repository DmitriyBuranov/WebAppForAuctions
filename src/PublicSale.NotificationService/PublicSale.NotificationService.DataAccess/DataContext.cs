using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PublicSale.NotificationService.DataAccess
{
    public class DataContext
         : IDataContext
    {
        public IMongoDatabase Database { get; set; }

        public DataContext(IOptions<MongoOptions> options)
        {
            var connectionString = options.Value.ConnectionString;
            var client = new MongoClient(connectionString);
            Database = client.GetDatabase(options.Value.Database);
        }

        internal object Set<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}
