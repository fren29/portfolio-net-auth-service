using PortfolioNetAuthService.Application.DTOs;
using PortfolioNetAuthService.Domain.Entities;

namespace PortfolioNetAuthService.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(RegisterDto registerDto);
        Task<AuthResult> LoginAsync(LoginDto loginDto);
    }
}
