using PortfolioNetAuthService.Domain.Entities;
using PortfolioNetAuthService.Infrastructurebkp.Data;
using Microsoft.EntityFrameworkCore;

namespace PortfolioNetAuthService.Infrastructurebkp.DAOs
{
    public class UserDao
    {
        private readonly DataContext _context;

        public UserDao(DataContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
