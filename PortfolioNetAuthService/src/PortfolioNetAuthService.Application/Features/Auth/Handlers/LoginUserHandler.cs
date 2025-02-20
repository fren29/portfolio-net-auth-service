using MediatR;
using PortfolioNetAuthService.Application.Features.Auth.Queries;
using PortfolioNetAuthService.Application.Interfaces;
using PortfolioNetAuthService.Domain.Entities;

namespace PortfolioNetAuthService.Application.Features.Auth.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserQuery, AuthResult>
    {
        private readonly IAuthService _authService;

        public LoginUserHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AuthResult> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            return await _authService.LoginAsync(request.Request);
        }
    }
}
