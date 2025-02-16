using PortfolioNetAuthService.Domain.Entities;
using System.Threading.Tasks;

namespace PortfolioNetAuthService.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task CreateUserAsync(User user);
        Task<bool> UserExists(string username);
    }
}
