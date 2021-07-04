namespace Otus.PublicSale.Core.Domain.AuctionManagement
{
    /// <summary>
    /// Auction File
    /// </summary>
    public partial class AuctionFile: BaseEntity
    {
        /// <summary>
        /// Auction Id
        /// </summary>
        public int AuctionId { get; set; }

        /// <summary>
        /// File Name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Auction
        /// </summary>
        public virtual Auction Auction { get; set; }
    }
}
