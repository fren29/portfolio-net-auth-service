using MediatR;
using PortfolioNetAuthService.Application.DTOs;
using PortfolioNetAuthService.Domain.Entities;

namespace PortfolioNetAuthService.Application.Features.Auth.Queries
{
    public record LoginUserQuery(LoginDto Request) : IRequest<AuthResult>;
}
