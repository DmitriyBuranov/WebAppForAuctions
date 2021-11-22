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
        /// Description
        /// </summary>
        public string Description { get; set; }

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
        /// EndDate
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Price Start
        /// </summary>
        public decimal PriceStart { get; set; }

        /// <summary>
        /// Price Step
        /// </summary>
        public decimal PriceStep { get; set; }

        /// <summary>
        /// Sell Price
        /// </summary>
        public decimal SellPrice {  get; set;}

        /// <summary>
        /// CurrentPrice
        /// </summary>
        public decimal CurrentPrice { get; set; }

        /// <summary>
        /// LowestPrice
        /// </summary>
        public decimal LowestPrice { get; set; }

        /// <summary>
        /// Winner
        /// </summary>
        public string Winner { get; set; }


        /// <summary>
        /// Image
        /// </summary>
        public string Image { get; set; }

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
            Description = auction.Description;
            CreateDate = auction.CreateDate;
            Status = auction.Status;
            StartDate = auction.StartDate;
            EndDate = auction.EndDate;
            PriceStart = auction.PriceStart;
            PriceStep = auction.PriceStep;
            SellPrice = auction.SellPrice;
            CurrentPrice = auction.CurrentPrice;
            LowestPrice = auction.LowestPrice;
            Winner = $"{auction.Winner?.FirstName} {auction.Winner?.LastName}".Trim();
            //EndDate = auction.StartDate.AddSeconds(auction.Duration).Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            Image = auction.Image;

            if (CurrentPrice < PriceStart)
                CurrentPrice = PriceStart;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            var data = obj as AuctionDto;

            return this.Id == data.Id && this.Name == data.Name && this.EndDate == data.EndDate && this.Description == data.Description && this.CreateDate == data.CreateDate && this.PriceStart == data.PriceStart && this.PriceStep == data.PriceStep && this.StartDate == data.StartDate && this.Status == data.Status && this.SellPrice == data.SellPrice;
        }
    }
}
