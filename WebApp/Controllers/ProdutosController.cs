using Microsoft.AspNetCore.Mvc;
//using WebApp.Models;


namespace WebApp.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        //[Route("[controller]/{id?}")]
        /*public IActionResult Produto(int id)
        {
            return View(new Produto { Id = id, Nome = "Teclado", Marca = "Razer", Modelo = "Blackwidow", Preço = 220, Stock = "5" });
        }*/
    }
}
