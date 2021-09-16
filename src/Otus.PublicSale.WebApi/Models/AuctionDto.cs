using Otus.PublicSale.Core.Domain;
using System;
using Otus.PublicSale.Core.Domain.AuctionManagement;

namespace Otus.PublicSale.WebApi.Models
{
    /// <summary>
    /// Action Dto
    /// </summary>
    public class AuctionDto : BaseEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descition
        /// </summary>
        public string Descition { get; set; }

        /// <summary>
        /// Create Date
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Duration
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Price Start
        /// </summary>
        public decimal PriceStart { get; set; }

        /// <summary>
        /// Price Step
        /// </summary>
        public decimal PriceStep { get; set; }

        /// <summary>
        /// Constuctor
        /// </summary>
        public AuctionDto()
        {
            
        }

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="auction">Auction</param>
        public AuctionDto(Auction auction)
        {
            Id = auction.Id;
            Name = auction.Name;
            Descition = auction.Descition;
            CreateDate = auction.CreateDate;
            Status = auction.Status;
            StartDate = auction.StartDate;
            Duration = auction.Duration;
            PriceStart = auction.PriceStart;
            PriceStep = auction.PriceStep;
        }
    }
}
