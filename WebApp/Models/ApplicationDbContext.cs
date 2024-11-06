using WebApp.Data;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using Microsoft.Extensions.Configuration;

namespace WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; } // Exemplo de uma entidade Produto
        public DbSet<User> Users { get; set; } // Exemplo de uma entidade User

        // Defina as tabelas (DbSets) que você quer incluir no banco de dados


        // Outras tabelas podem ser adicionadas aqui
        // public DbSet<OutraEntidade> OutraEntidades { get; set; }
    }
}