using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Otus.PublicSale.Users.DataAccess.DataContexts
{
    /// <summary>
    /// Sqlite Data Context
    /// </summary>
    public class SqliteDataContext : DataContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public SqliteDataContext(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// On Configuring
        /// </summary>
        /// <param name="options">Options</param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("DBConnection"));
        }
    }
}
