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
            // Busca o usuário pelo nome de utilizador
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.RoleID == 1);

            // Verifica se o usuário existe e a senha está correta
            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                return user;
            }

            return null; // Retorna null caso a autenticação falhe
        }

        // Método para criar um utilizador
        public async Task CreateUserAsync(User user)
        {
            user.PasswordHash = HashPassword(user.PasswordHash); // Gera o hash da senha
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public Task<User?> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAdminAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> ResetPasswordAsync(string username, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateLastLoginAsync(string Username)
        {
            throw new NotImplementedException();
        }

        // Método para gerar hash de senha seguro (BCrypt)
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Método para verificar a senha (BCrypt)
        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
