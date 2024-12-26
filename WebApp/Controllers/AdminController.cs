using Microsoft.AspNetCore.Mvc;
using WebApp.Services;


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

        // GET: Admin Login Page
        [HttpGet("")]
        public IActionResult Admin()
        {
            return View();
        }

        // POST: Authenticate Admin
        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Admin(string username, string password)
        {
            // Chama o serviço para autenticar o administrador
            var user = await _userService.AuthenticateAdminAsync(username, password);

            // Se o método retornar null, o login falhou
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
                return View(); // Retorna à página de login com mensagem de erro
            }

            // Verifica explicitamente a Role do usuário
            if (user.Role != 1)
            {
                ModelState.AddModelError(string.Empty, "Acesso restrito a administradores.");
                return View();
            }

            // Autenticação bem-sucedida, cria a sessão do administrador
            HttpContext.Session.SetString("UserID", user.ToString());
            return RedirectToAction("Dashboard", "Admin");
        }


        // GET: Admin Dashboard (área protegida)
        public IActionResult Dashboard()
        {
            var UserID = HttpContext.Session.GetString("AdminUserId");

            // Verifica se o administrador está logado
            if (string.IsNullOrEmpty(UserID))
            {
                return RedirectToAction("Admin", "Admin"); // Redireciona para login
            }

            return View(); // Retorna a página do dashboard
        }

        // GET: Logout
        public IActionResult Logout()
        {
            // Limpa a sessão
            HttpContext.Session.Clear();
            return RedirectToAction("Admin", "Admin"); // Redireciona para o login
        }
    }

}
