using Microsoft.Extensions.DependencyInjection;
using PortfolioNetAuthService.Domain.Interfaces;
using PortfolioNetAuthService.Infrastructurebkp.Data;
using Microsoft.EntityFrameworkCore; 
using PortfolioNetAuthService.Infrastructurebkp.Repositories;

namespace PortfolioNetAuthService.Infrastructurebkp.DependencyInjection
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString)); // Alterado para SQL Server

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
