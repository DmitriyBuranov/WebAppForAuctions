using Otus.PublicSale.Core.Domain.AuctionManagement;
using Otus.PublicSale.WebApi.Models;

namespace Otus.PublicSale.WebApi.Mappers
{
    public class AuctionUserMapper
    {
        /// <summary>
        /// Creates or updates AuctionUser from Dto request
        /// </summary>
        /// <param name="request">Auction User Dto</param>
        /// <param name="auctionUser">Auction User</param>
        /// <returns>AuctionUser</returns>
        public static AuctionUser MapFromModel(AuctionUserDto request, AuctionUser auctionUser = null)
        {
            if (auctionUser == null)
                auctionUser = new AuctionUser();

            auctionUser.Date = request.Date;
            auctionUser.UserId = request.UserId;
            auctionUser.AuctionId = request.AuctionId;

            return auctionUser;
        }
    }
}
