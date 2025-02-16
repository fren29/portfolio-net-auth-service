using PortfolioNetAuthService.Domain.Entities;

namespace PortfolioNetAuthService.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(User user, string password);
        Task<string> LoginAsync(string username, string password);
    }
}
