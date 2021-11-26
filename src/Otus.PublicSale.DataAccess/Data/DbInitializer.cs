using Otus.PublicSale.Core.Domain.AuctionManagement;
using Otus.PublicSale.Core.Enums;
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
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Auctions.Any())
            {
                return;
            }

            DateTime createDate = DateTime.UtcNow;
            DateTime endDate = createDate.AddDays(5);

            var Auctions = new Auction[]
            {
                new Auction
                {
                    Name= "2019 Mercedes-Benz C, 300",
                    Description= "<h3 class='title'>2019 Mercedes-Benz C, 300</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate.AddDays(-1),
                    Status = (int)AuctionStatus.Created,
                    StartDate = createDate.AddHours(-10),
                    EndDate = createDate.AddMinutes(1),
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2500,
                    Image = "/assets/images/auction/product/01.png"
                    //Id = 1
                },
                new Auction
                {
                    Name= "2018 Hyundai Sonata",
                    Description= "<h3 class='title'>2018 Hyundai Sonata</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate,
                    Status = (int)AuctionStatus.Created,
                    StartDate = createDate.AddDays(1) ,
                    EndDate = endDate,
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2500,//Id = 2,
                    Image = "/assets/images/auction/product/02.png"
                },
                new Auction
                {
                    Name= "2019 Subaru Crosstrek, Premium",
                    Description= "<h3 class='title'>2019 Subaru Crosstrek, Premium</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate,
                    Status = (int)AuctionStatus.Created,
                    StartDate = createDate.AddDays(1) ,
                    EndDate = endDate,
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2500,
                    Image = "/assets/images/auction/product/03.png"
                    //Id = 3,
                },
                new Auction
                {
                    Name= "2019 Ford Expedition",
                    Description= "<h3 class='title'>2019 Ford Expedition</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate.AddDays(-1),
                    Status = (int)AuctionStatus.Started,
                    StartDate = createDate.AddDays(-1) ,
                    EndDate = endDate, 
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2500,
                    Image = "/assets/images/auction/product/04.png"
                    //Id = 4,
                },
                new Auction
                {
                    Name= "2018 Dodge Grand, Sxt",
                    Description= "<h3 class='title'>2018 Dodge Grand, Sxt</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate.AddDays(-1),
                    Status = (int)AuctionStatus.Started,
                    StartDate = createDate.AddDays(-1) ,
                    EndDate = endDate, 
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2500,
                    Image = "/assets/images/auction/product/05.png"
                    //Id = 5,
                },
                new Auction
                {
                    Name= "2016 KIA Optima, EX",
                    Description= "<h3 class='title'>2016 KIA Optima, EX</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate,
                    Status = (int)AuctionStatus.Started,
                    StartDate = createDate,
                    EndDate = endDate,
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2500,
                    Image = "/assets/images/auction/product/06.png"
                    //Id = 6,
                },
                new Auction
                {
                    Name= "2019 Chevrolet Equinox, LT",
                    Description= "<h3 class='title'>2019 Chevrolet Equinox, LT</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate,
                    Status = (int)AuctionStatus.Created,
                    StartDate = createDate.AddDays(2) ,
                    EndDate = endDate,
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2500,
                    Image = "/assets/images/auction/product/07.png"
                    //Id = 7,
                },
                new Auction
                {
                    Name= "2019 Buick Envision",
                    Description= "<h3 class='title'>2019 Buick Envision</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate,
                    Status = (int)AuctionStatus.Created,
                    StartDate = createDate.AddDays(2) ,
                    EndDate = endDate,
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2500,
                    Image = "/assets/images/auction/product/08.png"
                    //Id = 8,
                },
                new Auction
                {
                    Name= "2018 Nissan Versa",
                    Description= "<h3 class='title'>2018 Nissan Versa</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate,
                    Status = (int)AuctionStatus.Created,
                    StartDate = createDate.AddDays(2) ,
                    EndDate = endDate,
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2500,
                    Image = "/assets/images/auction/product/09.png"
                    //Id = 9,
                },
                new Auction
                {
                    Name= "2017 Ford Expedition",
                    Description= "<h3 class='title'>2017 Ford Expedition</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate.AddDays(-1),
                    Status = (int)AuctionStatus.Started,
                    StartDate = createDate.AddDays(-1) ,
                    EndDate = endDate,
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2400,
                    Image = "https://s.aolcdn.com/commerce/autodata/images/USC50FOS311B021001.jpg"
                    //Id = 10,
                },
                new Auction
                {
                    Name= "2017 Dodge Grand, Sxt",
                    Description= "<h3 class='title'>2017 Dodge Grand, Sxt</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate.AddDays(-1),
                    Status = (int)AuctionStatus.Started,
                    StartDate = createDate.AddDays(-1) ,
                    EndDate = endDate, 
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2400,
                    Image = "https://s.aolcdn.com/commerce/autodata/images/CAC70DOV171A021001_2.jpg"
                    //Id = 11,
                },
                new Auction
                {
                    Name= "2016 Ford Expedition",
                    Description= "<h3 class='title'>2016 Ford Expedition</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate.AddDays(-1),
                    Status = (int)AuctionStatus.Started,
                    StartDate = createDate.AddDays(-1) ,
                    EndDate = endDate,
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2300,
                    Image = "https://platform.cstatic-images.com/large/in/v2/stock_photos/69dc7a0e-0fb2-4156-8c1e-a147c0ef4559/adc9297a-5860-4baf-8230-fbcab4d2a6e7.png"
                    //Id = 12,
                },
                new Auction{
                    Name= "2016 Dodge Grand, Sxt",
                    Description= "<h3 class='title'>2016 Dodge Grand, Sxt</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate.AddDays(-1),
                    Status = (int)AuctionStatus.Started,
                    StartDate = createDate.AddDays(-1) ,
                    EndDate = endDate, 
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2300,
                    Image = "https://picolio.auto123.com/16photo/dodge/2016-dodge-grand-caravan-sxt-plus_1.png"
                    //Id = 13,
                },
                new Auction
                {
                    Name= "2015 Ford Expedition",
                    Description= "<h3 class='title'>2015 Ford Expedition</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate.AddDays(-1),
                    Status = (int)AuctionStatus.Started,
                    StartDate = createDate.AddDays(-1) ,
                    EndDate = endDate,
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2200,
                    Image = "https://www.cnet.com/a/img/hub/2015/08/03/e42e2998-05bb-4197-a683-a0054f3c0e6d/img7487.jpg"
                    //Id = 14,
                },
                new Auction
                {
                    Name= "2015 Dodge Grand, Sxt",
                    Description= "<h3 class='title'>2015 Dodge Grand, Sxt</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>",
                    CreateDate= createDate.AddDays(-1),
                    Status = (int)AuctionStatus.Started,
                    StartDate = createDate.AddDays(-1) ,
                    EndDate = endDate,
                    PriceStart = 500,
                    PriceStep = 50,
                    SellPrice =  2200,
                    Image = "https://inv.assets.sincrod.com/ChromeColorMatch/us/WHITE_cc_2015DOD003b_1280_PAU.jpg"
                    //Id = 15,
                },

            };
            foreach (Auction s in Auctions)
            {
                context.Auctions.Add(s);
            }
            context.SaveChanges();


            context.Users.Add(new Core.Domain.Administration.User()
            {
                FirstName = "Jon",
                LastName = "Admin",
                Email = "admin@admin.com",
                Id = 1
            });

            context.Users.Add(new Core.Domain.Administration.User()
            {
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice@alice.com",
                Id = 2
            });

            context.Users.Add(new Core.Domain.Administration.User()
            {
                FirstName = "Bob",
                LastName = "Smith",
                Email = "bob@bob.com",
                Id = 3
            });

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