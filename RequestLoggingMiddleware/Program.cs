using RequestLoggingMiddleware.Extensions;
using RequestLoggingMiddleware.Middlewares;

namespace RequestLoggingMiddleware;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Add default logging
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddFile("Logs/app-{Date}.txt");

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        
        

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRequestLogger();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        


        app.Run();
    }
}