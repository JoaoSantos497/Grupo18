using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    [Route("Perfil")]
    public class PerfilController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerfilController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Perfil
        [HttpGet("")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Perfil/Dados Pessoais
        [HttpGet("DadosPessoais")]
        public IActionResult DadosPessoais()
        {
            return View();
        }

        //POST: A tua Conta/Dados Pessoais
        [HttpPost("DadosPessoais")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDadosPessoais(string Nome, string Email, string Password)
        {
            // Lógica para salvar os dados recebidos no banco de dados
            // Por exemplo:
            //_context.Users.Update(new User { Nome = Nome, Email = Email, Password = Password });

            TempData["Mensagem"] = "Dados atualizados com sucesso!";
            return RedirectToAction("DadosPessoais");
        }

        // GET: Perfil/Moradas
        [HttpGet("Moradas")]
        public IActionResult Moradas()
        {
            return View();
        }

    }
}
