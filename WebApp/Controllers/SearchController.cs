using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly ProdutoService _productService;

        public SearchController(ProdutoService produtoService)
        {
            _productService = produtoService;
        }

        [HttpGet]
        public IActionResult Search(string query, string category)
        {
            var products = _productService.SearchProduto(query, category);
            return View();
        }
    }
}
