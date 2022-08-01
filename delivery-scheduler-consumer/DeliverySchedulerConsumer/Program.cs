using Confluent.Kafka;
using DeliverySchedulerConsumer.Repositories;
using GroceryDeliveryAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DeliverySchedulerConsumer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        builder.Services.RegisterMiddleware(configuration);
        builder.Services.RegisterDependencies();

        var app = builder.Build();

        if (builder.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
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
    internal static IServiceCollection RegisterMiddleware(this IServiceCollection services, IConfiguration configuration)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "broker:29092",
            EnableAutoCommit = false,
            GroupId = "delivery-scheduler-consumer",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        var consumer = new ConsumerBuilder<string, string>(config).Build();
        consumer.Subscribe("postgres_db.public.orders");

        // Entity Framework Core
        services.AddDbContext<DeliverySchedulerDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("GroceryDeliveryServiceDB"));
        });

        services.AddHostedService<Worker>(sp => new Worker(
            consumer,
            sp.GetRequiredService<ILogger<Worker>>(),
            sp
        ));

        return services;
    }

    internal static IServiceCollection RegisterDependencies(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
