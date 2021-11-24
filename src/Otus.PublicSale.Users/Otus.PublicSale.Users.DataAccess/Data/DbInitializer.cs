using Otus.PublicSale.Users.DataAccess.DataContexts;

namespace Otus.PublicSale.Users.DataAccess.Data
{
    /// <summary>
    /// Db Initializer
    /// </summary>
    public class DbInitializer : IDbInitializer
    {
        /// <summary>
        /// DB Context
        /// </summary>
        private readonly DataContext _dataContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataContext">DB Context</param>
        public DbInitializer(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Initialize Db
        /// </summary>
        public void InitializeDb()
        {
            _dataContext.Database.EnsureDeleted();
            _dataContext.Database.EnsureCreated();

            _dataContext.AddRange(FakeDataFactory.Users);
            _dataContext.SaveChanges();
        }
    }
}
