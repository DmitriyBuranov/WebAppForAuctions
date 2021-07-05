using Otus.PublicSale.Core.Domain;
using System;

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
    }
}
