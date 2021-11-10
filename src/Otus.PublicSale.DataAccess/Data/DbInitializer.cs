



using Otus.PublicSale.Core.Domain.AuctionManagement;
using System.Linq;

namespace Otus.PublicSale.DataAccess.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly DataContext context;

        public DbInitializer(DataContext dataContext)
        {
           context = dataContext;
        }

        public void InitializeDb()
        {
            //context.Database.EnsureCreated();

           
            if (context.Auctions.Any())
            {
                return;   
            }


            var Auctions = new Auction[]
            {
                new Auction{
                Name= "Lada 2105",
                Descition= "string",
                CreateDate= "2021-11-09T10:21:55.963",
                Status = 0,
                StartDate = "2021-11-09T10:21:55.963",
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                Id = 1
                },
                new Auction{

                },
                new Auction{

                },
                new Auction{

                },
                new Auction{

                },
                new Auction{

                },
                new Auction{

                }
            };
            foreach (Auction s in Auctions)
            {
                context.Auctions.Add(s);
            }
            context.SaveChanges();

        }
    }
}