using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Otus.PublicSale.Users.Core.Domain;

namespace Otus.PublicSale.Users.DataAccess.DataContexts
{
    /// <summary>
    /// Data Context
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Configuration
        /// </summary>
        protected readonly IConfiguration Configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// On Configuring
        /// </summary>
        /// <param name="options">Options</param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("DBConnection"));
        }

        /// <summary>
        /// Users
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
