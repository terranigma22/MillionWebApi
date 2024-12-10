using MediatR;
using Microsoft.EntityFrameworkCore;
using MillionWebApi.Data;
using MillionWebApi.Endpoints;

namespace MillionWebApi.Services;

internal static class ServiceExtensions
{
    public static IServiceCollection AddCorsServices(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(
                name: "ApiCorsPolicy",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("*");
                }
            );
        });

        return services;
    }

    public static IServiceCollection AddManagementDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
            //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        services.AddTransient<DataSeeder>();

        return services;
    }

    public static IServiceCollection AddMediatRServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Program).Assembly);

        return services;
    }

    public static IEndpointRouteBuilder MapRoutes(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapPeoples();

        return endpoint;
    }
}
