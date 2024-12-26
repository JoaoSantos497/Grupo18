using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApp.Services;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Exibe a página de login para administradores
        [HttpGet("")]
        public IActionResult Admin()
        {
            return View("Index"); // Renderiza a view Index.cshtml
        }

        // POST: Processa o login do administrador
        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Admin(string username, string password)
        {
            // Autentica o administrador usando o serviço
            var admin = await _userService.AuthenticateAdminAsync(username, password);

            // Caso a autenticação falhe
            if (admin == null)
            {
                ModelState.AddModelError(string.Empty, "Utilizador ou senha inválidos.");
                return View("Index"); // Retorna para a página de login com mensagem de erro
            }

            // Adiciona o UserId do administrador na sessão
            HttpContext.Session.SetString("UserId", admin.UserID.ToString());

            // Redireciona para o Dashboard do administrador
            return RedirectToAction("Dashboard");
        }

        // GET: Exibe o Dashboard do administrador (área protegida)
        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            // Verifica se o administrador está autenticado
            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Admin"); // Redireciona para a página de login
            }

            // Carrega o dashboard do administrador
            return View();
        }

        // GET: Faz o logout do administrador
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            // Limpa os dados de sessão
            HttpContext.Session.Clear();

            // Redireciona para a página de login
            return RedirectToAction("Admin");
        }
    }
}
