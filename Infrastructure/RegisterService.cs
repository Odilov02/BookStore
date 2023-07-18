using Application.Abstraction;
using Application.Interfaces.ServiceInterfaces;
using Infrastructure.DataAcces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure;

public static class RegisterService
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Default"));
        });
        services.AddScoped<IApplicatonDbcontext, AppDbContext>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<ICommentaryService, CommentarySerivce>();
        services.AddScoped<IUserService, UserSevice>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IUserService, UserSevice>();
        return services;

    }
}
