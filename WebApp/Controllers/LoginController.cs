using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebAppp.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _LoginService;

        // Injeção de dependência para o service
        public LoginController()
        {
            _LoginService = new LoginService();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user); // Retorna com mensagens de erro de validação
            }

            if (_LoginService.ValidarCredenciais(user.Email, user.PasswordHash))
            {
                return RedirectToAction("Perfil");
            }
            else
            {
                TempData["Erro"] = "Email ou password inválidos.";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Perfil()
        {
            return View();
        }
    }
}