using WebApp.Data;

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
        // Get apenas o Email e PasswordHash do utilizador
        var user = _dbContext.Users
            .Where(u => u.Email == email)
            .Select(u => new { u.Email, u.PasswordHash }) // Faz get apenas do email e password
            .SingleOrDefault();

        if (user == null)
        {
            return false; // Utilizador não encontrado
        }

        // Verifica a PasswordHash (usar BCrypt ou outra biblioteca segura)
        return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
    }
}

