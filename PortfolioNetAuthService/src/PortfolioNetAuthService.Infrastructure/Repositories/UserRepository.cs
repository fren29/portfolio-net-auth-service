using Microsoft.EntityFrameworkCore;
using PortfolioNetAuthService.Domain.Entities;
using PortfolioNetAuthService.Domain.Interfaces;
using PortfolioNetAuthService.Infrastructure.Data;

namespace PortfolioNetAuthService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
