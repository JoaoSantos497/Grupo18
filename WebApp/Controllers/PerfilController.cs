using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Data;
using WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;

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
            // Agora você pode usar o `userId` para buscar o utilizador no banco de dados ou exibir informações personalizadas
            return View();
        }


        // GET: Perfil/Dados Pessoais
        [HttpGet("DadosPessoais")]
        public async Task<IActionResult> DadosPessoais()
        {
            // Obtendo o UserID das Claims de forma segura
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Verificando se o ID da claim corresponde ao ID passado
            if (userIdClaim == null)
            {
                return Unauthorized(new { message = "Utilizador não autorizado." });
            }

            // Encontrando o utilizador pelo ID
            var user = await _context.Users.FindAsync(int.Parse(userIdClaim));

            return View(user);
        }


        // POST: A tua Conta/Dados Pessoais
        [Route("/DadosPessoais/UpdateDados/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDados(int id, string Email, string Username, string Nome)
        {
            // Obtendo o UserID das Claims de forma segura
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Verificando se o ID da claim corresponde ao ID passado
            if (userIdClaim == null || int.Parse(userIdClaim) != id)
            {
                return Unauthorized(new { message = "Utilizador não autorizado." });
            }

            // Encontrando o Utilizador pelo ID
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(new { message = "Utilizador não encontrado." });
            }

            try
            {
                // Atualiza os campos permitidos com os valores fornecidos
                user.Nome = Nome;
                user.Email = Email;
                user.Username = Username;

                // Atualiza o Utilizador no banco de dados
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Dados Atualizados";
                return RedirectToAction("DadosPessoais");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao atualizar os dados pessoais.", details = ex.Message });
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
                TempData["SuccessMessage"] = "Endereco removido!";
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
                // Defina o UserID com o ID do utilizador autenticado
                // Supondo que você tenha uma sessão com o utilizador autenticado
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier); // Usando Claims para pegar o UserID
                var userId = userIdClaim?.Value;

                endereco.UserID = int.Parse(userId);

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
