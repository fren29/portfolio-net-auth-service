using AutoMapper;
using PortfolioNetAuthService.Application.DTOs;
using PortfolioNetAuthService.Application.Interfaces;
using PortfolioNetAuthService.Domain.Entities;
using PortfolioNetAuthService.Domain.Interfaces;

namespace PortfolioNetAuthService.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        public async Task<AuthResult> RegisterAsync(RegisterDto request)
        {
            // Verifica se o usuário já existe
            var existingUser = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (existingUser != null)
            {
                return AuthResult.Fail("Usuário já existe.");
            }

            // Mapeia DTO para entidade User
            var user = _mapper.Map<User>(request);

            // Gera hash da senha
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Salva no banco
            await _userRepository.CreateUserAsync(user);

            // Gera token JWT
            var token = _jwtTokenGenerator.GenerateToken(user);

            return AuthResult.SuccessWithToken(token);
        }

        /// <summary>
        /// Faz login de um usuário existente
        /// </summary>
        public async Task<AuthResult> LoginAsync(LoginDto request)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return AuthResult.Fail("Credenciais inválidas.");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);
            return AuthResult.SuccessWithToken(token);
        }
    }
}
