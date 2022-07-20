using GroceryDeliveryAPI.Profiles;
using GroceryDeliveryAPI.Repositories;
using GroceryDeliveryAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GroceryDeliveryAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        builder.Services.RegisterMiddleware(configuration);
        builder.Services.RegisterDependencies();

        var app = builder.Build();

        // Middleware Configuration
        if (builder.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GroceryDeliveryAPI v1"));
        }

        app.UseCors(options =>
        {
            options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
        });

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}

internal static class ProgramBuilderExtensions
{
    internal static IServiceCollection RegisterMiddleware(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors();
        services.AddAutoMapper(typeof(OrderProfile), typeof(ProductProfile));

        // Entity Framework Core
        services.AddDbContext<GroceryDeliveryServiceContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("GroceryDeliveryServiceDB"));
        });

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "GroceryDeliveryAPI", Version = "v1" });
        });

        return services;
    }

    internal static IServiceCollection RegisterDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
