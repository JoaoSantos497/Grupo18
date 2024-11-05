using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;


namespace WebApp.Controllers
{
	public class ProdutoController : Controller
    {
		private readonly ApplicationDbContext _context;
		public ProdutoController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Produto/Index
		public IActionResult Index()
        {
            var produtos = _context.Produtos.ToList(); // Retorna a lista de produtos para a visualização
            return View(produtos);
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
