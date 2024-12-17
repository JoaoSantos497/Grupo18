using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;
using WebApp.Models;


namespace WebApp.Controllers
{
    public class TrackingController : Controller
    {
        /*[HttpGet]
        public ActionResult Index(string numeroRastreamento)
        {
            // Simular dados de rastreamento (substitua por consulta ao banco de dados ou API)
            var historico = new List<string>
        {
            "Encomenda enviada",
            "Encomenda em trânsito",
            "Encomenda chegou ao centro de distribuição"
        };

            var encomenda = new Encomenda
            {
                NumeroRastreamento = numeroRastreamento ?? "12345",
                Status = "Em trânsito",
                LocalizacaoAtual = "Centro de Distribuição - São Paulo",
                DataUltimaAtualizacao = DateTime.Now,
                Historico = historico
            };

            return View(encomenda);
        }*/
    }
}

