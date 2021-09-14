using System;
using Otus.PublicSale.Core.Domain.AuctionManagement;
using Otus.PublicSale.WebApi.Models;

namespace Otus.PublicSale.WebApi.Mappers
{
    public static class AuctionBetMapper
    {
        /// <summary>
        /// Creates or updates Auction Bet from Dto request
        /// </summary>
        /// <param name="request">Auction Bet Dto</param>
        /// <param name="auction">Auction</param>
        /// <param name="auctionBet">Auction Bet</param>
        /// <returns>AuctionBet</returns>
        public static AuctionBet MapFromModel(AuctionBetDto request, Auction auction = null, AuctionBet auctionBet = null)
        {
            if (auctionBet == null)
            {
                auctionBet = new AuctionBet();
                auctionBet.Date = DateTime.UtcNow;
            }
            else
            {
                auctionBet.Date = request.Date;
            }

            auctionBet.Amount = request.Amount;
            auctionBet.AuctionId = auction != null ? auction.Id : request.AuctionId;
            auctionBet.UserId = request.UserId;

            return auctionBet;
        }
    }
}
