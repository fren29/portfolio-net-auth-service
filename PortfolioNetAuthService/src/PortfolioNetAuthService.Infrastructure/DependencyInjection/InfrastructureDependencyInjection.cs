using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortfolioNetAuthService.Application.Configuration;
using PortfolioNetAuthService.Application.Interfaces;
using PortfolioNetAuthService.Domain.Interfaces;
using PortfolioNetAuthService.Infrastructure.Data;
using PortfolioNetAuthService.Infrastructure.Repositories;
using PortfolioNetAuthService.Infrastructure.Services;

namespace PortfolioNetAuthService.Infrastructure.DependencyInjection;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, string connectionString, JwtSettings jwtSettings)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddSingleton(jwtSettings); 
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>(); 

        return services;
    }
}
