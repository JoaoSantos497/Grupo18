public interface IPasswordHashingService
{
    string HashPassword(string password);
    bool VerifyPassword(string hashedPassword, string password);
}

public class PasswordHashingService : IPasswordHashingService
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password); // Usando BCrypt
    }

    public bool VerifyPassword(string hashedPassword, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
