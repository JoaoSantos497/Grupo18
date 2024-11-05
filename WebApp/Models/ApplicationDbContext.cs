using WebApp.Data;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data // Substitua "SeuProjetoNamespace" pelo namespace do seu projeto
{
    public class ApplicationDbContext : DbContext // Se você não estiver usando Identity, substitua por DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }// Exemplo de uma entidade Produto
        public DbSet<User> Users { get; set; }

        // Defina as tabelas (DbSets) que você quer incluir no banco de dados


        // Outras tabelas podem ser adicionadas aqui
        // public DbSet<OutraEntidade> OutraEntidades { get; set; }
    }
}