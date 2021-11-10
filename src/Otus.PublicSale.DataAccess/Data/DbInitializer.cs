using Otus.PublicSale.Core.Domain.AuctionManagement;
using System;
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


            DateTime createDate = DateTime.UtcNow;

            var Auctions = new Auction[]
            {
                new Auction{
                Name= "2019 Mercedes-Benz C, 300",
                Descition= "string",
                CreateDate= createDate,
                Status = 0,
                StartDate = createDate.AddDays(1) ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2500
                },
                new Auction{
                Name= "2018 Hyundai Sonata",
                Descition= "string",
                CreateDate= createDate,
                Status = 0,
                StartDate = createDate.AddDays(1) ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2500
                },
                new Auction{
                Name= "2019 Subaru Crosstrek, Premium",
                Descition= "string",
                CreateDate= createDate,
                Status = 0,
                StartDate = createDate.AddDays(1) ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2500
                },
                new Auction{
                Name= "2019 Ford Expedition",
                Descition= "string",
                CreateDate= createDate.AddDays(-1),
                Status = 0,
                StartDate = createDate.AddDays(-1) ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2500
                },
                new Auction{
                Name= "2018 Dodge Grand, Sxt",
                Descition= "string",
                CreateDate= createDate.AddDays(-1),
                Status = 0,
                StartDate = createDate.AddDays(-1) ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2500
                },
                new Auction{
                Name= "2016 KIA Optima, EX",
                Descition= "string",
                CreateDate= createDate,
                Status = 0,
                StartDate = createDate,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2500
                },
                new Auction{
                Name= "2018 Toyota Camry, L/Le/Xle/Se/Xse",
                Descition= "string",
                CreateDate= createDate,
                Status = 0,
                StartDate = createDate ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2500
                },
                new Auction{
                Name= "2019 Chevrolet Equinox, LT",
                Descition= "string",
                CreateDate= createDate,
                Status = 0,
                StartDate = createDate.AddDays(2) ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2500
                },
                new Auction{
                Name= "2019 Buick Envision",
                Descition= "string",
                CreateDate= createDate,
                Status = 0,
                StartDate = createDate.AddDays(2) ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2500
                },
                new Auction{
                Name= "2018 Nissan Versa",
                Descition= "string",
                CreateDate= createDate,
                Status = 0,
                StartDate = createDate.AddDays(2) ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2500
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