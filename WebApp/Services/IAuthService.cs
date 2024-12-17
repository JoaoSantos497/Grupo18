using WebApp.Models;

namespace WebApp.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// Autentica um usuário e gera um token JWT.
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="password">Senha do usuário</param>
        /// <returns>Token JWT como string se a autenticação for bem-sucedida; null caso contrário.</returns>
        string Authenticate(string email, string password);

        /// <summary>
        /// Registra um novo usuário.
        /// </summary>
        /// <param name="newUser">Objeto do usuário</param>
        /// <returns>True se o registro for bem-sucedido; False caso contrário.</returns>
        bool Registo(User newUser);

        /// <summary>
        /// Busca um usuário pelo email.
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <returns>Objeto User encontrado ou null se não existir.</returns>
        User GetUserByEmail(string email);
    }
}
