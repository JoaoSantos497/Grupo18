using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Autenticação: verifica email e senha
        public User Authenticate(string email, string password)
        {
            // Busca o usuário pelo email
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return null;

            // Verifica se o hash da senha fornecida corresponde ao armazenado
            var hashedPassword = HashPassword(password);
            if (user.Password != hashedPassword) return null;

            return user;
        }

        // Registro de um novo usuário
        public bool Registo(User newUser)
        {
            // Verifica se o email ou username já existem
            if (_context.Users.Any(u => u.Email == newUser.Email || u.Username == newUser.Username))
                return false;

            // Hash da senha antes de armazenar
            newUser.Password = HashPassword(newUser.Password);

            // Adiciona o novo usuário no banco de dados
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return true;
        }

        // Método auxiliar: gera o hash da senha
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Busca user pelo email
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        string IAuthService.Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
