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

        // Método síncrono para autenticação
        public async Task<User?> AuthenticateAdmin(string username, string password)
        {
            // Busca um usuário com username e senha correspondentes e Role = 1
            return await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.Username == username &&
                    u.PasswordHash == password &&
                    u.Role == 1); // Filtra apenas administradores
        }

        // Método assíncrono para autenticação
        public async Task<User> AuthenticateAdminAsync(string username, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.Username == username &&
                    u.PasswordHash == password &&
                    u.Role == 1);

            if (user == null)
            {
                throw new InvalidOperationException("Utilizador não encontrado ou não é administrador.");
            }

            return user;
        }

        // Método para criar um utilizador (síncrono)
        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        // Método para criar um utilizador (assíncrono)
        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        User IUserService.AuthenticateAdmin(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
