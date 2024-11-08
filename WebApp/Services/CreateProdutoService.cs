using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Models; 
using WebApp.Data; 

namespace WebApp.Services
{
    public class CreateProdutoService
    {
        private readonly ApplicationDbContext _context;

        public CreateProdutoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para criar um novo produto
        public async Task<Produto> CriarProdutoAsync(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
    }
}
