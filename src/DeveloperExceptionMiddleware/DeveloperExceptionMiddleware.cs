using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using DeveloperExceptionMiddleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
    public class DeveloperExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<DeveloperExceptionMiddleware> _logger;

        public DeveloperExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory?.CreateLogger<DeveloperExceptionMiddleware>() 
                      ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (context.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
                    throw;
                }

                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(JsonSerializer.Serialize(new Error(ex)));
            }
        }
    }

    public static class DeveloperExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Captures synchronous and asynchronous <see cref="Exception"/> instances from the pipeline and generates HTML error responses.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/>.</param>
        /// <returns>A reference to the <paramref name="app"/> after the operation has completed.</returns>
        public static IApplicationBuilder UseDeveloperExceptionResponse(this IApplicationBuilder app)
        {
            return app == null
                ? throw new ArgumentNullException(nameof(app))
                : app.UseMiddleware<DeveloperExceptionMiddleware>();
        }
    }
}
