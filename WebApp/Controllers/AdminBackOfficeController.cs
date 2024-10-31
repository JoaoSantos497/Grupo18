using Microsoft.AspNetCore.Mvc;
using WebApp.Models;


namespace WebApp.Controllers
{
    public class AdminBackOfficeController : Controller
    {   

        // GET: AdminBackOffice
        public ActionResult index()
        {
            return View();
        }

        // GET: Admin/GerirProdutos
        public IActionResult GerirProdutos()
        {
            // Lógica para exibir os produtos
            return View();
        }

        // GET: Admin/GerirUsers
        public IActionResult GerirUsers()
        {
            // Lógica para exibir e gerir utilizadores
            return View();
        }

        // GET: Admin/Settings
        public IActionResult Settings()
        {
            // Lógica para exibir e gerir configurações
            return View();
        }

        // POST: Admin/Logout
        public IActionResult Logout()
        {
            // Lógica de logout
            return RedirectToAction("Login", "Account"); // Redireciona para a página de login
        }

        // POST: Admin/CreateProduct - Processa o formulário para criar um novo produto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduto(Produto product)
        {
            //if (ModelState.IsValid)
            //{
               // AdminBackOffice.ProdutoID.Add(product);
                //return RedirectToAction(nameof(GerirProdutos));
            //}
            return View(product);
        }

        private static void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
