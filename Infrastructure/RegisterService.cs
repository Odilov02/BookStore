using Application.Comman.Interfaces;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Interceptors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure;

public static class RegisterService
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Default"));
            options.UseLazyLoadingProxies();
        });

        services.AddScoped<IApplicatonDbcontext, ApplicationDbContext>();
        services.AddScoped<AuditableEntitySaveChangesnterceptor>();
        return services;

    }
}
