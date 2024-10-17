using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (IsValidUser(username, password))
            {
                // Armazenar o nome do user
                HttpContext.Session.SetString("Username", username);

                // Manda para a página inicial após o login
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Adiciona uma mensagem de erro caso o login falhe
                ViewBag.ErrorMessage = "Username ou password incorretos";
                return View("Index");
            }
        }

        private bool IsValidUser(string username, string password)
        {
            // Valida o user
            // Implementa a verificação com base na base de dados
            return username == "admin" && password == "password";
        }
    }
}

