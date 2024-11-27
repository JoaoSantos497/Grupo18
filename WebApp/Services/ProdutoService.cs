using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Models; 
using WebApp.Data; 

namespace WebApp.Services
{
    public class ProdutoService
    {
        private readonly ApplicationDbContext _context;

        public ProdutoService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Método para criar um novo produto
        public async Task<Produto> CriarProdutoAsync(Produto produto)
        {   
            //Verifica se o objeto é nulo
            ArgumentNullException.ThrowIfNull(produto, nameof(produto));

            try
            {
                // Adiciona o produto ao contexto
                await _context.Produtos.AddAsync(produto);

                // Salva as alterações no banco de dados
                await _context.SaveChangesAsync();

                return produto;
            }
            catch (DbUpdateException ex)
            {
                // Log do erro (substituir por um serviço de log, se disponível)
                Console.WriteLine($"Erro ao adicionar produto: {ex.Message}");
                throw new Exception("Ocorreu um erro ao adicionar o produto.", ex);
            }
        }
    }
}
