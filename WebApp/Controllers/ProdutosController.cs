using Microsoft.AspNetCore.Mvc;
using WebApp.Models;


namespace WebApp.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            var produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Teclado", Marca = "Razer", Modelo = "Blackwidow", Preço = 220, Stock = "5" },
                new Produto { Id = 3, Nome = "Rato", Preço = 100 },
                new Produto { Id = 4, Nome = "Monitor", Preço = 800 }
            };

            return View(produtos);
        }

        [Route("[controller]/{id?}")]
        public IActionResult Produto(int id)
        {
            return View(new Produto { Id = id, Nome = "Teclado", Marca = "Razer", Modelo = "Blackwidow", Preço = 220, Stock = "5" });
        }
    }
}
