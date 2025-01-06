using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;



namespace WebApp.Controllers
{
    [Authorize(AuthenticationSchemes = "AdminCookie", Policy = "Role1Policy")]
    [Route("/Admin/Dashboard")]
    public class Dashboard : Controller
    {
        private readonly ApplicationDbContext _context;

        public Dashboard(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("")]
        public ActionResult Index()
        {
            // Lógica do dashboard
            return View();
        }

        // GET: Dashboard/GerirProdutos
        [HttpGet("GerirProdutos")]
        public async Task<IActionResult> GerirProdutos()
        {
            var Produtos = await _context.Produtos.ToListAsync();
            return View(Produtos);
        }

        // GET: Dashboard/GerirProdutos/CreateProduto
        [HttpGet("GerirProdutos/CreateProduto")]
        public IActionResult CreateProduto()
        {
            return View();
        }


        // POST: Dashboard/GerirProdutos/CreateProduto
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

        // GET: Dashboard/GerirUsers
        [HttpGet("GerirUsers")]
        public async Task<IActionResult> GerirUsers()
        {
            var Users = await _context.Users.ToListAsync();
            return View(Users);
        }

        [HttpPost]
        [Route("/GerirUsers/DeleteUser/{id}")]
        [ValidateAntiForgeryToken] // Protege contra CSRF
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(new { message = "Utilizador não encontrado." });
            }

            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("GerirUsers");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao remover o utilizador.", details = ex.Message });
            }
        }


        // GET: Dashboard/GerirUsers/CreateUser
        [HttpGet("GerirUsers/CreateUser")]
        public IActionResult CreateUser()
        {
            return View();
        }


        // POST: Dashboard/GerirUsers/CreateUser
        [HttpPost("GerirUsers/CreateUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(User User)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(User);
                await _context.SaveChangesAsync();
                return RedirectToAction("GerirUsers");
            }
            return View(User);
        }

        // GET: Dashboard/Settings
        [HttpGet("Settings")]
        public IActionResult Settings()
        {
            // Lógica para exibir e gerir configurações
            return View();
        }
    }
}
