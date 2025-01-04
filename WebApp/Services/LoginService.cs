using WebApp.Data;

namespace WebApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationDbContext _dbContext;

        // Construtor com injeção de dependência do DbContext
        public LoginService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <inheritdoc />
        public bool ValidarCredenciais(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return false; // Email ou senha inválidos
            }

            // Busca o utilizador pelo email e seleciona apenas o Email e PasswordHash
            var user = _dbContext.Users
                .Where(u => u.Email == email)
                .Select(u => new { u.Email, u.PasswordHash }) // Evita carregar campos desnecessários
                .SingleOrDefault();

            if (user == null)
            {
                return false; // Utilizador não encontrado
            }

            // Verifica a senha usando a biblioteca BCrypt
            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash); // Retorna true se válido
        }
    }
}
