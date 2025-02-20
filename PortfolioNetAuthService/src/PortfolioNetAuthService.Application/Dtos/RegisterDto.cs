using System.ComponentModel.DataAnnotations;

namespace PortfolioNetAuthService.Application.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username is required.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public required string Password { get; set; }
    }
}
