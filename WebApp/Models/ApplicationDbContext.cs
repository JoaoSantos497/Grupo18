using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


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

        //public required DbSet<Encomenda> Encomenda { get; set; }

        public required DbSet<Order> Orders { get; set; } // Adicionar a entidade Order


        //public required DbSet<Search> Produtos { get; set; }

        // Outras tabelas podem ser adicionadas aqui
        // public DbSet<OutraEntidade> OutraEntidades { get; set; }
    }
}