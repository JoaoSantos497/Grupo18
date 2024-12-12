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
        public IActionResult Index()
        {
            return View();
        }

        // GET: Perfil/Dados Pessoais
        [HttpGet("DadosPessoais")]
        public ActionResult DadosPessoais()
        {
            //var users = await _context.Users.ToListAsync();
            return View();
            
        }

        //POST: A tua Conta/Dados Pessoais
        [HttpPost("DadosPessoais")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDadosPessoais(string Nome, string Email, string Password)
        {
            // Lógica para salvar os dados no banco de dados
            var user = _context.Users.FirstOrDefault(u => u.Email == Email);
            if (user != null)
            {
                user.Nome = Nome;
                user.Email = Email;
                user.PasswordHash = Password; // Considere hashear a senha antes de salvar
                _context.SaveChanges();

                TempData["Mensagem"] = "Dados atualizados com sucesso!";
            }
            else
            {
                TempData["Erro"] = "Utilizador não foi encontrado!";
            }

            return RedirectToAction("DadosPessoais");
        }

        // GET: Perfil/Moradas
        [HttpGet("Moradas")]
        public IActionResult Moradas()
        {
            return View();
        }

        // GET: Perfil/Tracking
        [HttpGet("Tracking")]
        public IActionResult Tracking()
        {
            return View();
        }

    }
}
