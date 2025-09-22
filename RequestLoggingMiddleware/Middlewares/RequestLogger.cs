namespace RequestLoggingMiddleware.Middlewares;

public class RequestLogger(RequestDelegate next, ILogger<RequestLogger> logger)
{

    public async Task InvokeAsync(HttpContext context)
    {
        logger.LogInformation(
            "Incoming request method {method}, URL {url} and IP {ip}",
            context.Request.Method,
            context.Request.Path + context.Request.QueryString,
            context.Connection.RemoteIpAddress
            );
        foreach (var header in context.Request.Headers)
        {
            logger.LogInformation(
                "Incoming request headers : Key {key}, Value {value}",
                header.Key,
                header.Value
                );
            
        }

        await next(context);
        
        logger.LogInformation(
            "Outgoing response {statuscode}",
            context.Response.StatusCode
            );
        
        foreach (var header in context.Response.Headers)
        {
            logger.LogInformation(
                "Incoming response headers : Key {key}, Value {value}",
                   header.Key,
                header.Value
            );
            
        }
        
        

    }
}