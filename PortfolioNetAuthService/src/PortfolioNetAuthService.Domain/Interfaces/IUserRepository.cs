using PortfolioNetAuthService.Domain.Entities;

namespace PortfolioNetAuthService.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByUsernameAsync(string username);
    Task<User?> GetUserByEmailAsync(string email);
    Task CreateUserAsync(User user);
}
