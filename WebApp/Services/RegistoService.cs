using System;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    public class RegistoService : IRegistoService
    {
        private readonly ApplicationDbContext _dbContext;

        public RegistoService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SalvarRegistoAsync(RegistoForm registo)
        {
            if (registo == null) throw new ArgumentNullException(nameof(registo));

            // Mapear RegistoForm para User (ou outro modelo de banco de dados, se necessário)
            var user = new User
            {
                Username = registo.Username,
                Nome = registo.Nome,
                Email = registo.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registo.Password), // Criptografar a senha
                DataNascimento = registo.DataNascimento,
                Genero = registo.Genero,
                DataRegisto = DateTime.UtcNow
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
