using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;


namespace WebApp.Controllers
{
	public class ProdutoController : Controller
    {
		private readonly ApplicationDbContext gettech;
		public ProdutoController(ApplicationDbContext context)
		{
			gettech = context;
		}
		public IActionResult Index()
        {

            return View();
        }

		// GET: Produto/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Produto/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Produto produto)
		{
			if (ModelState.IsValid)
			{
				// Adiciona o produto ao banco de dados
				_context.Produtos.Add(produto);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();

				// Redireciona para a página principal ou lista de produtos após a criação
				return RedirectToAction("Index");
			}
			return View(produto);
		}

		[Route("[controller]/{id?}")]
        public IActionResult Produtos(int id)
        {
            return View();
        }
    }
}
