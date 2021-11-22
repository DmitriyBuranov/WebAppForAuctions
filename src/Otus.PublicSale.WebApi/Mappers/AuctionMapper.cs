using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Otus.PublicSale.Core.Domain.AuctionManagement;
using Otus.PublicSale.WebApi.Models;

namespace Otus.PublicSale.WebApi.Mappers
{
    public static class AuctionMapper
    {
        /// <summary>
        /// Creates or updates Auction from Dto request
        /// </summary>
        /// <param name="request">Auction Dto</param>
        /// <param name="auction">Auction</param>
        /// <returns>Auction</returns>
        public static Auction MapFromModel(AuctionDto request, Auction auction = null)
        {
            if (auction == null)
                auction = new Auction();

            auction.Name = request.Name;
            auction.Description = request.Description;
            auction.CreateDate = request.CreateDate;
            auction.Status = request.Status;
            auction.StartDate = request.StartDate;
            auction.EndDate = request.EndDate;
            auction.PriceStart = request.PriceStart;
            auction.PriceStep = request.PriceStep;
            auction.SellPrice = request.SellPrice;
            auction.Image = request.Image;

            return auction;
        }
    }
}
