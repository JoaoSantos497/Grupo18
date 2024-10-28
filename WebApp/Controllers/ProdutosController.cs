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

        /*[Route("[controller]/{id?}")]
        public IActionResult Produtos(int id)
        {
            return View();
        }*/
    }
}
