using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.Models;
using Microsoft.AspNetCore.Authentication;


namespace WebApp.Controllers
{
    
    [Route("Admin")] // Define a rota base como /Admin
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        // Construtor para injeção de dependência
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        // Ação GET para login de Admin
        public IActionResult Index()
        {
            return View(); // Página de login
        }

        // Logout
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            // Remove o cookie de autenticação de todos os tipos de role
            await HttpContext.SignOutAsync("AdminCookie");

            // Redireciona para a página inicial
            return RedirectToAction("Index", "Admin");
        }

    }
}

