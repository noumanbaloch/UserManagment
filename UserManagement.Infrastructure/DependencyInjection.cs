using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.Abstractions.Infrastructure;
using UserManagement.Infrastructure.Contexts;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<UserManagementDbContext>((provider, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        },
        ServiceLifetime.Scoped,
        ServiceLifetime.Singleton);


        services.AddScoped<IUserManagementRepository, UserManagementRepository>();
        return services;
    }
}
