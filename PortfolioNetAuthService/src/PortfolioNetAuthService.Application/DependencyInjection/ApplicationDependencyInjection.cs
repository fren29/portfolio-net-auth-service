using Microsoft.Extensions.DependencyInjection;
using PortfolioNetAuthService.Application.Interfaces;
using PortfolioNetAuthService.Application.Services;

namespace PortfolioNetAuthService.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}
