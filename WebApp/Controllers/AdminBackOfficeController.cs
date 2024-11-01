using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace WebApp.Controllers
{
    [Route("AdminBackOffice/[action]")]
    public class AdminBackOfficeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminBackOfficeController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: AdminBackOffice
        public ActionResult Index()
        {
            return View();
        }


        // GET: AdminBackOffice/GerirProdutos
        [HttpGet("GerirProdutos")]
        public async Task<IActionResult> GerirProdutos()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return View(produtos);
        }

        // GET: AdminBackOffice/GerirProdutos/CreateProduto
        [HttpGet("GerirProdutos/CreateProduto")]
        public IActionResult CreateProduto()
        {
            return View();
        }

        // POST: AdminBackOffice/GerirProdutos/CreateProduto
        [Route("AdminBackOffice/GerirProdutos/[action]")]
        [HttpPost("GerirProdutos/CreateProduto")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduto(Produto product)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("GerirProdutos");
            }
            return View(product);
        }

        // GET: AdminBackOffice/GerirUsers
        public IActionResult GerirUsers()
        {
            // Lógica para exibir e gerir utilizadores
            return View();
        }

        // GET: AdminBackOffice/Settings
        public IActionResult Settings()
        {
            // Lógica para exibir e gerir configurações
            return View();
        }

        // POST: AdminBackOffice/Logout
        public IActionResult Logout()
        {
            // Lógica de logout
            return RedirectToAction("Login", "Registo"); // Redireciona para a página de login
        }

    }
}
