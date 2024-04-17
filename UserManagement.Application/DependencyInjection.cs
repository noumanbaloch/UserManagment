using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.Abstractions.Application;
using UserManagement.Application.Services;

namespace UserManagement.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserManagmenetService, UserManagementService>();
        return services;
    }
}