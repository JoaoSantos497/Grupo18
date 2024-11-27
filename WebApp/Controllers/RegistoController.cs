using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Data;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class RegistoController : Controller
    {
        private readonly UserService _userService;

        // Construtor com injeção de dependência
        public RegistoController(UserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        // Exibe a página de registo
        [HttpGet("Registo")]
        public IActionResult Index()
        {
            return View();
        }

        // Processa o formulário de registro
        [HttpPost("Registo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(User Registo)
        {
            // Verifica se o modelo é válido
            if (!ModelState.IsValid)
            {
                return View(Registo);
            }

            try
            {
                // Chama o serviço para criar o utilizador
                await _userService.CreateUserAsync(Registo);

                // Redireciona para a página de login após sucesso
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                // Log do erro (pode usar um serviço de log no lugar do Console)
                Console.WriteLine($"Erro ao registar utilizador: {ex.Message}");

                // Adiciona erro ao ModelState e retorna a view
                ModelState.AddModelError("", "Ocorreu um erro ao registar o utilizador. Tente novamente.");
                return View(Registo);
            }
        }
    }
}