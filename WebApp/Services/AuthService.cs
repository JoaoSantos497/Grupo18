using WebApp.Data;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;



public interface IAuthService
{
    Task<User?> AuthenticateAdminAsync(string username, string password);
    Task<User?> AuthenticateClientAsync(string email, string password);
}

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IPasswordHashingService _hashingService;

    public AuthService(ApplicationDbContext context, IPasswordHashingService hashingService)
    {
        _context = context;
        _hashingService = hashingService;
    }

    public async Task<User?> AuthenticateAdminAsync(string username, string password)
    {
        var admin = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.RoleID == 1);

        if (admin != null && _hashingService.VerifyPassword(admin.PasswordHash, password))
            return admin;

        return null;
    }

    public async Task<User?> AuthenticateClientAsync(string email, string password)
    {
        var client = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.RoleID == 2);

        if (client != null && _hashingService.VerifyPassword(client.PasswordHash, password))
            return client;

        return null;
    }
}
