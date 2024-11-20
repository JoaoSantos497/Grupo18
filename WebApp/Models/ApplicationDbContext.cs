using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using Microsoft.Extensions.Configuration;
using WebApp.Data;

namespace WebApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public required DbSet<Produto> Produtos { get; set; } // Exemplo de uma entidade Produto
        public required DbSet<User> Users { get; set; } // Exemplo de uma entidade User

        // Defina as tabelas (DbSets) que você quer incluir no banco de dados


        // Outras tabelas podem ser adicionadas aqui
        // public DbSet<OutraEntidade> OutraEntidades { get; set; }
    }
}