using MediatR;
using PortfolioNetAuthService.Application.DTOs;
using PortfolioNetAuthService.Domain.Entities;

namespace PortfolioNetAuthService.Application.Features.Auth.Commands
{
    public record RegisterUserCommand(string Username, string Password) : IRequest<AuthResult>;
}
