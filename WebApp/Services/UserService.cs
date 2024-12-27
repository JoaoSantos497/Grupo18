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

        // Método assíncrono para autenticação de administrador
        public async Task<User?> AuthenticateAdminAsync(string username, string password)
        {
            var hashedPassword = HashPassword(password); // Gera o hash da senha fornecida

            // Procura um administrador válido  
            return await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.Username == username &&
                    u.PasswordHash == hashedPassword &&
                    u.RoleID == 1); // RoleID = 1 indica que é administrador
        }

        // Método para criar um utilizador
        public async Task CreateUserAsync(User user)
        {
            user.PasswordHash = HashPassword(user.PasswordHash); // Gera o hash da senha
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        // Método para gerar hash de senha
        private string HashPassword(string password)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
