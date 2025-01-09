using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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
        public required DbSet<Enderecos> Enderecos { get; set; } // Entidade Enderecos

        public required DbSet<Carrinho> CarrinhoCompras { get; set; } // Entidade Carrinho

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações específicas, caso necessário
            modelBuilder.Entity<Enderecos>().HasKey(e => e.EnderecoID);

            modelBuilder.Entity<Carrinho>()
                .HasOne(c => c.Produto)
                .WithMany()
                .HasForeignKey(c => c.ProdutoID);
        }

    }
}