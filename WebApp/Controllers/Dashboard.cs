using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;



namespace WebApp.Controllers
{
    [Authorize(Roles = "1")]
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

        // GET: Dashboard
        /*[HttpGet("")]
        public ActionResult Index()
        {
            // Verificar se o utilizador está autenticado
            if (User?.Identity == null || !User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }

            // Lógica do dashboard
            return View();
        }*/

        // GET: Dashboard/GerirProdutos
        [HttpGet("GerirProdutos")]
        public async Task<IActionResult> GerirProdutos()
        {
            var Produtos = await _context.Produtos.ToListAsync();
            return View(Produtos);
        }

        // GET: Dashboard/GerirUsers
        [HttpGet("GerirUsers")]
        public async Task<IActionResult> GerirUsers()
        {
            var Users = await _context.Users.ToListAsync();
            return View(Users);
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
                //using ( var context )
                _context.Produtos.Add(Produto);
                await _context.SaveChangesAsync();
                return RedirectToAction("GerirProdutos");
            }
            return View(Produto);
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
                return RedirectToAction("GerirProdutos");
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

        // POST: Dashboard/Logout
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            // Lógica de logout
            return RedirectToAction("Login", "Registo"); // Redireciona para a página de login
        }

    }
}
