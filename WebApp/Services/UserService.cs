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

        // Método para criar um novo user
        public async Task<User> CriarUserAsync(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            // Verifica se o email já existe
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
                throw new InvalidOperationException("Email já está em uso.");

            // Hash da password (substitua com a sua lógica de hash)
            user.PasswordHash = PasswordHash(user.PasswordHash);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Método para fazer o hash da password (para segurança)
        private string PasswordHash(string password)
        {
            // Implemente a sua lógica de hashing aqui.
            // Exemplo simplificado (não para produção):
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public User Create(User user)
        {
            throw new NotImplementedException();
        }
    }
}
