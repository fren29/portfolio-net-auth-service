namespace PortfolioNetAuthService.Domain.Entities
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public string Token { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();

        public static AuthResult Fail(params string[] errors)
        {
            return new AuthResult
            {
                Success = false,
                Errors = errors.ToList()
            };
        }

        public static AuthResult SuccessWithToken(string token)
        {
            return new AuthResult
            {
                Success = true,
                Token = token
            };
        }
    }
}
