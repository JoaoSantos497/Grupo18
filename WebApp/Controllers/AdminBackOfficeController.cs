using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace WebApp.Controllers
{
    //[Route("AdminBackOffice[action]")]
    [Route("AdminBackOffice")]
    public class AdminBackOfficeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminBackOfficeController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: AdminBackOffice
        [HttpGet("")]
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
        [HttpPost("GerirProdutos/CreateProduto")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduto(Produto Produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(Produto);
                await _context.SaveChangesAsync();
                return RedirectToAction("GerirProdutos");
            }
            return View(Produto);
        }

        // GET: AdminBackOffice/GerirUsers
        [HttpGet("GerirUsers")]
        public async Task<IActionResult> GerirUsers()
        {
            // Lógica para exibir e gerir utilizadores
            var users = await _context.Users.ToListAsync();
            return View();
        }


        // GET: AdminBackOffice/GerirUsers/CreateUser
        [HttpGet("GerirUsers/CreateUser")]
        public IActionResult CreateUser()
        {
            return View();
        }


        // POST: AdminBackOffice/GerirUsers/CreateUser
        [HttpPost("GerirUsers/CreateUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(User User)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(User);
                await _context.SaveChangesAsync();
                return RedirectToAction("GerirProdutos");
            }
            return View(User);
        }

        // GET: AdminBackOffice/Settings
        [HttpGet("Settings")]
        public IActionResult Settings()
        {
            // Lógica para exibir e gerir configurações
            return View();
        }

        // POST: AdminBackOffice/Logout
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            // Lógica de logout
            return RedirectToAction("Login", "Registo"); // Redireciona para a página de login
        }

    }
}
