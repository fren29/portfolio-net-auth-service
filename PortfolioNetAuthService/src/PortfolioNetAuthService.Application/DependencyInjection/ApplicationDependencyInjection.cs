using Microsoft.Extensions.DependencyInjection;

namespace PortfolioNetAuthService.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        // Aqui podemos adicionar services específicos da camada Application no futuro
        return services;
    }
}
