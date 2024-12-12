using System.Collections.Generic;
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

        public User Authenticate(string email, string password)
        {
            // Procura o utilizador no banco de dados
            return _context.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
        }

        internal bool Registo(User newUser, string passwordHash)
        {
            throw new NotImplementedException();
        }

        string IAuthService.Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
