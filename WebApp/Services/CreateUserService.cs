using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Models; // Substitua com o namespace dos seus modelos
using WebApp.Data; // Substitua com o namespace do seu contexto de dados

namespace WebApp.Services
{
    public class CreateUserService
    {
        private readonly ApplicationDbContext _context;

        public CreateUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para criar um novo user
        public async Task<User> CriarUserAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            // Verifica se o email já existe
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
                throw new InvalidOperationException("Email já está em uso.");

            // Hash da password (substitua com a sua lógica de hash)
            user.PasswordHash = HashPassword(user.PasswordHash);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Método para fazer o hash da password (para segurança)
        private string HashPassword(string password)
        {
            // Implemente a sua lógica de hashing aqui.
            // Exemplo simplificado (não para produção):
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
