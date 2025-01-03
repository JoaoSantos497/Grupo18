using WebApp.Models;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IUserService
    {
        // Cria um novo utilizador
        Task CreateUserAsync(User user);

        // Autentica um administrador (assíncrono)
        Task<User?> AuthenticateAdminAsync(string username, string password);

        // Obtém um utilizador pelo nome de utilizador
        Task<User?> GetUserByUsernameAsync(string username);

        // Verifica se um utilizador é administrador
        Task<bool> IsAdminAsync(int userId);

        // Atualiza a última data de login do utilizador
        Task<User?> UpdateLastLoginAsync(String Username);

        // Reseta a senha do utilizador (opcional)
        Task<User?> ResetPasswordAsync(string username, string newPassword);
    }
}
