using Blog.Service.BlogApi.Api.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Blog.Service.BlogApi.Api.Extensions
{
    public static class ErrorHandlingMiddlewareExtension
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
