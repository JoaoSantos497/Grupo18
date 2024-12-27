using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;

        // Injeção de dependência do LoginService
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        // GET: Login
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user); // Retorna com mensagens de erro de validação
            }

            if (_loginService.ValidarCredenciais(user.Email, user.PasswordHash))
            {
                // User autenticado com sucesso, redireciona para o perfil
                return RedirectToAction("Perfil");
            }
            else
            {
                TempData["Erro"] = "Email ou password inválidos.";
                return RedirectToAction("Login"); // Mantém na página de login
            }
        }

        // POST: Logout
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}


