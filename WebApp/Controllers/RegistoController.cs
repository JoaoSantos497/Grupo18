using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Data;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class RegistoController : Controller
    {
        private readonly IUserService _userService;

        // Construtor com injeção de dependência
        public RegistoController(IUserService userService)
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
        
        public async Task<IActionResult> Index(RegistoForm registo)
        {
            // Verifica se o modelo é válido
            if (!ModelState.IsValid)
            {
                return View(registo);
            }

            try
            {
                // Chama o serviço para criar o utilizador
                var user = new User
                { 
                    Nome = registo.Nome, 
                    Username =  registo.Username,
                    Email = registo.Email,
                    PasswordHash = registo.Password,
                    DataNascimento = registo.DataNascimento,
                    Genero = registo.Genero,
                    DataRegisto = new DateTime()
                };

                await _userService.CreateUserAsync(user);

                // Redireciona para a página de login após sucesso
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                // Log do erro (pode usar um serviço de log no lugar do Console)
                Console.WriteLine($"Erro ao registar utilizador: {ex.Message}");

                // Adiciona erro ao ModelState e retorna a view
                ModelState.AddModelError("", "Ocorreu um erro ao registar o utilizador. Tente novamente.");
                return View(registo);
            }
        }
    }
}