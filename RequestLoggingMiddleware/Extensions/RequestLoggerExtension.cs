using RequestLoggingMiddleware.Middlewares;

namespace RequestLoggingMiddleware.Extensions;

public static class RequestLoggerExtension
{

    public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLogger>();
    }
    
}