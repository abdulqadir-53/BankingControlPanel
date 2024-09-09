using BankingControlPanel.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BankingControlPanel.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterUser(User user)
        {
            // Password hashing should be implemented here
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> LoginUser(string email, string password)
        {
            // Implement login logic with password verification
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
