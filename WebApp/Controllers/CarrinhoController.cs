using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Authorize(AuthenticationSchemes = "UserCookie", Policy = "Role2Policy")]
    public class CarrinhoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarrinhoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carrinho
        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized(new { message = "Utilizador não autorizado." });
            }
            var carrinho = await _context.CarrinhoCompras.Include(c => c.Produto).Where(c=> c.UserID == int.Parse(userIdClaim)).ToListAsync();
            return View(carrinho);
        }

        // POST: Carrinho
        [HttpPost("/Carrinho")]
        public async Task<IActionResult> Adicionar(int produtoId, int quantidade)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null)
                {
                    return Unauthorized(new { message = "Utilizador não autorizado." });
                }
                // Criar um novo item no carrinho
                var item = await _context.CarrinhoCompras.Where(c => c.ProdutoID == produtoId).FirstOrDefaultAsync();
                if (item == null)
                {
                    var novoItem = new Carrinho
                    {
                        UserID = int.Parse(userIdClaim),
                        ProdutoID = produtoId,
                        Quantidade = quantidade,
                        DataAdicionado = DateTime.Now
                    };

                    // Adicionar ao banco de dados
                    _context.CarrinhoCompras.Add(novoItem);
                } else
                {
                    item!.Quantidade = item.Quantidade + quantidade;
                    _context.CarrinhoCompras.Update(item);
                }
                await _context.SaveChangesAsync();

                // Redirecionar para a página principal do carrinho
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Tratar erros e exibir uma mensagem (ou registrar o log)
                return View("Error", new { mensagem = ex.Message });
            }
        }

        // POST: Carrinho/DeleteCart
        [HttpPost]
        [Route("/Carrinho/DeleteCartItem/{id}")]
        [ValidateAntiForgeryToken] // Protege contra CSRF
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            try
            {
                var ItemsToRemove = _context.CarrinhoCompras.Where(c => c.ProdutoID == id); 
                _context.CarrinhoCompras.RemoveRange(ItemsToRemove);
                await _context.SaveChangesAsync();
                return RedirectToAction("");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao remover o item.", details = ex.Message });
            }
        }
    }
}
