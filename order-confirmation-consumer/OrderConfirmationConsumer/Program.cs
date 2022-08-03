using Confluent.Kafka;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OrderConfirmationConsumer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        builder.Services.RegisterMiddleware();

        var app = builder.Build();

        if (builder.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors("CorsPolicy");

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<OrderConfirmationHub>("/orderconfirmation");
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        });

        app.Run();
    }
}

internal static class ProgramBuilderExtensions
{
    internal static IServiceCollection RegisterMiddleware(this IServiceCollection services)
    {
        services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });

        var config = new ConsumerConfig
        {
            BootstrapServers = "broker:29092",
            EnableAutoCommit = false,
            GroupId = "order-confirmation-consumers",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        var consumer = new ConsumerBuilder<string, string>(config).Build();
        consumer.Subscribe("orders");

        services.AddSignalR();
        services.AddHostedService<Worker>(sp => new Worker(
            sp.GetRequiredService<IHubContext<OrderConfirmationHub>>(),
            consumer,
            sp.GetRequiredService<ILogger<Worker>>()
        ));

        return services;
    }
}
