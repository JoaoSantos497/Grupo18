using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

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
     
        [HttpGet("HistoricoEncomendas")]
        public async Task<IActionResult> HistoricoEncomendas()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var encomendas = await _context.Orders
                .Where(o => o.UserID == int.Parse(userId))
                .Select(o => new Encomenda
                {
                    EncomendaID = o.OrderID,
                    DataEncomenda = o.DataPedido, // Certifique-se de mapear corretamente
                    Total = o.Total,
                    Estado = o.Status
                })
                .ToListAsync();

            return View(encomendas);
        }


        [HttpGet("Tracking")]
        public IActionResult Tracking(string numeroRastreamento)
        {
            if (string.IsNullOrEmpty(numeroRastreamento))
            {
                return View(new Encomenda());
            }

            // Simulação de dados: substitua por busca real na base de dados
            var encomenda = new Encomenda
            {
                EncomendaID = 1,
                NumeroRastreamento = numeroRastreamento,
                Status = "Em trânsito",
                LocalizacaoAtual = "Centro de Distribuição - Lisboa",
                DataUltimaAtualizacao = DateTime.Now.AddHours(-2),
                Historico = new List<string>
        {
            "Encomenda recebida no centro de distribuição",
            "Encomenda saiu para entrega"
        }
            };

            return View(encomenda);
        }

    }
}
