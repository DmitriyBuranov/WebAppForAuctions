﻿using System.Collections.Generic;

namespace Otus.PublicSale.WebApi.Hubs
{
    /// <summary>
    /// Hub Handler
    /// </summary>
    public static class HubHandler
    {
        /// <summary>
        /// Connected Ids
        /// </summary>
        public static Dictionary<string, string> ConnectedIds = new Dictionary<string, string>();
    }
}
