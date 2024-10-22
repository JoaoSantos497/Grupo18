using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Home Page
        public IActionResult index()
        {
            return View();
        }

        // Produtos Page
        /*public IActionResult Produtos()
        {
            var produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Teclado", Marca = "Razer", Modelo = "Blackwidow", Preço = 220, Stock = "5" },
                new Produto { Id = 3, Nome = "Monitor", Preço = 800 }
            };

            return View(produtos);
        }*/

        // Privacy Page
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
