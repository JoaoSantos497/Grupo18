using Microsoft.EntityFrameworkCore;
using WebApp.Models;


namespace WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {

        // Construtor corrigido para aceitar opções
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets que representam tabelas na base de dados
        public required DbSet<Produto> Produtos { get; set; } // Entidade Produto
        public required DbSet<User> Users { get; set; } // Entidade User 
        public object User { get; internal set; }

        // Outras tabelas podem ser adicionadas aqui
        // public DbSet<OutraEntidade> OutraEntidades { get; set; }
    }
}