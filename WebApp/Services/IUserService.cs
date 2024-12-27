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
    }
}
