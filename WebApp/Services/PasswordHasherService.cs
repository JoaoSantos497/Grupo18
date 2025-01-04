using System.Security.Cryptography;
using System.Text;

namespace WebApp.Services
{
    public static class PasswordHasherService
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public static bool VerifyPassword(string hashedPassword, string password)
        {
            var hashOfInput = HashPassword(password);
            return hashedPassword == hashOfInput;
        }
    }
}

