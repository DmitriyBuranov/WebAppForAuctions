using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IO;

namespace Otus.PublicSale.Core.Middlewares
{
    /// <summary>
    /// Request Response Logging Middleware
    /// </summary>
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        private string _requestLog;
        private string _responseLog;        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="loggerFactory"></param>
        public RequestResponseLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestResponseLoggingMiddleware>();
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await LogRequest(context);
                await LogResponse(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_requestLog}{Environment.NewLine}{Environment.NewLine}Error: {ex}");
            }
            finally {
                _logger.LogInformation($"{_requestLog}{Environment.NewLine}{Environment.NewLine}{_responseLog}");
            }
        }

        /// <summary>
        /// Logs Request
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task LogRequest(HttpContext context)
        {
            context.Request.EnableBuffering();

            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);
            _requestLog = $"Http Request Information:{Environment.NewLine}" +
                                   $"Schema:{context.Request.Scheme}{Environment.NewLine}" +
                                   $"Method:{context.Request.Method}{Environment.NewLine}" +
                                   $"Host: {context.Request.Host}{Environment.NewLine}" +
                                   $"Path: {context.Request.Path}{Environment.NewLine}" +
                                   $"QueryString: {context.Request.QueryString}{Environment.NewLine}" +
                                   $"Request Body: {ReadStreamInChunks(requestStream)}{Environment.NewLine}";

            context.Request.Body.Position = 0;
        }

        /// <summary>
        /// Logs Response
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task LogResponse(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            _responseLog =  $"Http Response Information:{Environment.NewLine}" +
                                   $"Schema:{context.Request.Scheme}{Environment.NewLine}" +
                                   $"Method:{context.Request.Method}{Environment.NewLine}" +
                                   $"Host: {context.Request.Host}{Environment.NewLine}" +
                                   $"Path: {context.Request.Path}{Environment.NewLine}" +
                                   $"QueryString: {context.Request.QueryString}{Environment.NewLine}" +
                                   $"Response Body: {text}{Environment.NewLine}";

            await responseBody.CopyToAsync(originalBodyStream);
        }

        /// <summary>
        /// Reads Stream In Chunks
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;

            stream.Seek(0, SeekOrigin.Begin);

            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);

            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;

            do
            {
                readChunkLength = reader.ReadBlock(readChunk, 0, readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);

            return textWriter.ToString();
        }
    }
}
