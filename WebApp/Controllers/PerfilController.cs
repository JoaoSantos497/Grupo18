using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Data;
using WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace WebApp.Controllers
{
    [Authorize(AuthenticationSchemes = "UserCookie", Policy = "Role2Policy")]
    [Route("Perfil")]
    public class PerfilController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerfilController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Perfil
        [HttpGet("")]
        public ActionResult Index()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier); // Acessando o UserID dos claims
            // Agora você pode usar o `userId` para buscar o usuário no banco de dados ou exibir informações personalizadas
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
                return RedirectToAction("DadosPessoais"); // Adicione um retorno explícito aqui
            }
            else
            {
                return RedirectToAction("DadosPessoais");
            }
        }

        // GET: Perfil/Moradas
        [HttpGet("Moradas")]
        public async Task<IActionResult> Moradas()
        {
            // Obtendo o UserID das Claims de forma segura
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized(); // Retorna um erro 401 caso o UserID não seja válido
            }
            var enderecos = await _context.Enderecos.Where(e =>e.UserID==userId).ToListAsync();
            return View(enderecos);
        }

        [HttpPost]
        [Route("/Moradas/DeleteMorada/{id}")]
        [ValidateAntiForgeryToken] // Protege contra CSRF
        public async Task<IActionResult> DeleteMorada(int id)
        {
            var enderecos = await _context.Enderecos.FindAsync(id);

            if (enderecos == null)
            {
                return NotFound(new { message = "Morada não encontrada." });
            }

            try
            {
                _context.Enderecos.Remove(enderecos);
                await _context.SaveChangesAsync();
                return RedirectToAction("Moradas");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao remover a Morada.", details = ex.Message });
            }
        }

        // GET: Perfil/Moradas/CriarMorada
        [HttpGet("Moradas/CriarMorada")]
        public IActionResult CriarMorada()
        {
            return View();
        }

        // POST: Perfil/Moradas/CriarMorada
        [HttpPost("Moradas/CriarMorada")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarMorada(Enderecos endereco)
        {
            // Validação do NIF
            if (!ValidarNIF(endereco.NIF))
                ModelState.AddModelError("NIF", "O NIF fornecido não é válido.");

            // Validações gerais do ModelState
            if (!ModelState.IsValid)
                return View(endereco);

            try
            {
                // Defina o UserID com o ID do usuário autenticado
                // Supondo que você tenha uma sessão com o usuário logado
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier); // Usando Claims para pegar o UserID
                var userId = userIdClaim?.Value;

                endereco.UserID = int.Parse(userId);
                     // Ajuste para o tipo correto (supondo que seja int)

                // Adiciona o endereço na base de dados
                _context.Enderecos.Add(endereco);
                await _context.SaveChangesAsync();

                // Mensagem de sucesso
                TempData["SuccessMessage"] = "Endereço adicionado com sucesso!";
                return RedirectToAction("Moradas", "Perfil"); // Redireciona para a lista de moradas
            }
            catch (Exception)
            {
                // Mensagem de erro
                TempData["ErrorMessage"] = "Ocorreu um erro ao guardar o endereço.";
                return View(endereco);
            }
        }

        // Validação do NIF 
        private bool ValidarNIF(int nif)
        {
            // Se o NIF não for um número com 9 dígitos
            return nif.ToString().Length == 9;
        }

        // GET: Perfil/Tracking
        [HttpGet("Tracking")]
        public IActionResult Tracking()
        {
            return View();
        }

        
        
    }
}
