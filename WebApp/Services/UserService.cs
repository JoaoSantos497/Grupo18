using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public async Task CreateUserAsync(User user)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
