﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HttpMiddlewareExtensions
{
    public class HttpExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HttpExceptionMiddleware> _logger;

        public HttpExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory?.CreateLogger<HttpExceptionMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
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
                
                await context.Response.WriteAsync(JsonConvert.SerializeObject(ex));
            }
        }
    }

    public static class HttpExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseDeveloperExceptionResponse(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpExceptionMiddleware>();
        }
    }
}
