using Microsoft.AspNetCore.Builder;

namespace Otus.PublicSale.Core.Middlewares
{
    /// <summary>
    /// Request Response Logging Middleware Extensions
    /// </summary>
    public static class RequestResponseLoggingMiddlewareExtensions
    {
        /// <summary>
        /// Use Request Response Logging
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
