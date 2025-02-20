using MediatR;
using PortfolioNetAuthService.Application.Features.Auth.Commands;
using PortfolioNetAuthService.Application.Interfaces;
using PortfolioNetAuthService.Domain.Entities;
using PortfolioNetAuthService.Domain.Interfaces;

namespace PortfolioNetAuthService.Application.Features.Auth.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, AuthResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterUserHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { Username = request.Username };
            await _userRepository.CreateUserAsync(user);

            var token = _jwtTokenGenerator.GenerateToken(user);
            return AuthResult.SuccessWithToken(token);
        }
    }
}
