using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApp.Models;
public interface IAuthenticationService
{
    string Authenticate(string email, string password);
}

public class AuthenticationService : IAuthenticationService
{
    private readonly IConfiguration _configuration;

    // Simulação de usuários no sistema
    private readonly IDictionary<string, string> _users = new Dictionary<string, string>
    {
        { "admin", "password123" },
        { "user", "mypassword" }
    };

    public AuthenticationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Authenticate(string username, string password)
    {
        // Valida usuário e senha
        if (!_users.ContainsKey(username) || _users[username] != password)
            return null;

        // Gera o token JWT
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "User") // Adiciona mais claims se necessário
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
