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
            //context.Database.EnsureDeleted();
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
                SellPrice =  2500,
                //Id = 1
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
                SellPrice =  2500,
                //Id = 2,
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
                SellPrice =  2500,
                //Id = 3,
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
                SellPrice =  2500,
                //Id = 4,
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
                SellPrice =  2500,
                //Id = 5,
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
                SellPrice =  2500,
                //Id = 6,
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
                SellPrice =  2500,
                //Id = 7,
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
                SellPrice =  2500,
                //Id = 8,
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
                SellPrice =  2500,
                //Id = 9,
                },
                new Auction{
                Name= "2017 Ford Expedition",
                Descition= "string",
                CreateDate= createDate.AddDays(-1),
                Status = 0,
                StartDate = createDate.AddDays(-1) ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2400,
                //Id = 10,
                },
                new Auction{
                Name= "2017 Dodge Grand, Sxt",
                Descition= "string",
                CreateDate= createDate.AddDays(-1),
                Status = 0,
                StartDate = createDate.AddDays(-1) ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2400,
                //Id = 11,
                },
                new Auction{
                Name= "2016 Ford Expedition",
                Descition= "string",
                CreateDate= createDate.AddDays(-1),
                Status = 0,
                StartDate = createDate.AddDays(-1) ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2300,
                //Id = 12,
                },
                new Auction{
                Name= "2016 Dodge Grand, Sxt",
                Descition= "string",
                CreateDate= createDate.AddDays(-1),
                Status = 0,
                StartDate = createDate.AddDays(-1) ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2300,
                //Id = 13,
                },
                new Auction{
                Name= "2015 Ford Expedition",
                Descition= "string",
                CreateDate= createDate.AddDays(-1),
                Status = 0,
                StartDate = createDate.AddDays(-1) ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2200,
                //Id = 14,
                },
                new Auction{
                Name= "2015 Dodge Grand, Sxt",
                Descition= "string",
                CreateDate= createDate.AddDays(-1),
                Status = 0,
                StartDate = createDate.AddDays(-1) ,
                Duration = 5,
                PriceStart = 500,
                PriceStep = 50,
                SellPrice =  2200,
                //Id = 15,
                },

            };
            foreach (Auction s in Auctions)
            {
                context.Auctions.Add(s);
            }
            context.SaveChanges();


            int userId = 1;

            var AuctionBets = new AuctionBet[]
            {
                new AuctionBet
                {
                    AuctionId = 10,
                    Date = createDate.AddDays(-1).AddHours(1),
                    Amount = 550,
                    UserId = userId,
                },
                new AuctionBet
                {
                    AuctionId = 10,
                    Date = createDate.AddDays(-1).AddHours(2),
                    Amount = 600,
                    UserId = userId,
                },                
                new AuctionBet
                {
                    AuctionId = 10,
                    Date = createDate.AddDays(-1).AddHours(3),
                    Amount = 650,
                    UserId = userId,
                },
                new AuctionBet
                {
                    AuctionId = 11,
                    Date = createDate.AddDays(-1).AddHours(1),
                    Amount = 550,
                    UserId = userId,
                },
                new AuctionBet
                {
                    AuctionId = 11,
                    Date = createDate.AddDays(-1).AddHours(2),
                    Amount = 600,
                    UserId = userId,
                },
                new AuctionBet
                {
                    AuctionId = 11,
                    Date = createDate.AddDays(-1).AddHours(3),
                    Amount = 650,
                    UserId = userId,
                },
                new AuctionBet
                {
                    AuctionId = 11,
                    Date = createDate.AddDays(-1).AddHours(4),
                    Amount = 700,
                    UserId = userId,
                },
            };

            foreach (AuctionBet s in AuctionBets)
            {
                context.AuctionBets.Add(s);
            }
            context.SaveChanges();


        }
    }
}