using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortfolioNetAuthService.Domain.Interfaces;
using PortfolioNetAuthService.Infrastructure.Data;
using PortfolioNetAuthService.Infrastructure.Repositories;

namespace PortfolioNetAuthService.Infrastructure.DependencyInjection;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
