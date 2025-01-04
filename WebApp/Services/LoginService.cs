using WebApp.Data;


namespace WebApp.Services
{
    public class LoginService
    {
        private readonly ApplicationDbContext _dbContext;

        // Construtor com injeção de dependência do DbContext
        public LoginService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Valida credenciais do utilizador
        public bool ValidarCredenciais(string email, string password)
        {
            // Busca apenas o Email e PasswordHash do utilizador
            var user = _dbContext.Users
                .Where(u => u.Email == email)
                .Select(u => new { u.Email, u.PasswordHash }) // Busca apenas os campos necessários
                .SingleOrDefault();

            if (user == null)
            {
                return false; // Utilizador não encontrado
            }

            // Verifica a senha usando a biblioteca BCrypt
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash); // Método correto na versão Next

            return isPasswordValid; // Retorna true se a senha for válida, caso contrário false
        }
    }
}

