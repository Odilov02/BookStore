using Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using WebApi.Comman.Services;

namespace WebApi
{
    public static class ConfigureService
    {
        public static IServiceCollection AddWebUIServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddMediatR(src => src.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddIdentity<User, IdentityRole>()
                     .AddUserManager<UserManager<User>>()
                    .AddRoleManager<RoleManager<IdentityRole>>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddSignInManager();

            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            return services;
        }
    }
}
