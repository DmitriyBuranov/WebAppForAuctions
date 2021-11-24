using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Otus.PublicSale.Users.DataAccess.DataContexts
{
    /// <summary>
    /// Postgres Data Context
    /// </summary>
    public class PostgresDataContext : DataContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public PostgresDataContext(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// On Configuring
        /// </summary>
        /// <param name="options">Options</param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseNpgsql(Configuration.GetConnectionString("DBConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            base.OnModelCreating(modelBuilder);
        }
    }
}
