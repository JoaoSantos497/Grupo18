using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class RegistoController : Controller
    {
        private readonly IRegistoService _registoService;

        public RegistoController(IRegistoService registoService)
        {
            _registoService = registoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Index(RegistoForm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Retornar para o formulário em caso de erro
            }

            // Salvar o registro no banco de dados
            await _registoService.SalvarRegistoAsync(model);

            // Redirecionar após sucesso
            return RedirectToAction("", "Login");
        }

        public IActionResult Sucesso()
        {
            return View(); // Exibe uma página de sucesso após registro
        }
    }
}
