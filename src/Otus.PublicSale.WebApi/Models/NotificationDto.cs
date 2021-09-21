using Otus.PublicSale.Core.Domain;
using System;

namespace Otus.PublicSale.WebApi.Models
{
    /// <summary>
    /// Notification Dto
    /// </summary>
    public class NotificationDto: BaseEntity
    {
        /// <summary>
        /// EmailFrom
        /// </summary>
        public string EmailFrom { get; set; }

        /// <summary>
        /// Subject 
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// quick
        /// </summary>
        public Boolean Quick { get; set; }



    }
}
