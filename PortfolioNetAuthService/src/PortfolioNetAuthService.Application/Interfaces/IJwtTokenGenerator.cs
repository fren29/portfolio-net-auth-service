using PortfolioNetAuthService.Domain.Entities;

namespace PortfolioNetAuthService.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
