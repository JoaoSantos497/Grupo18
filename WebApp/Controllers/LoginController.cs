using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;


namespace WebApp.Controllers
{
    public class LoginController : Controller
    {

        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (IsValidUser(email, password))
            {
                // Armazenar o email do user
                HttpContext.Session.SetString("Email", email);

                // Manda para a página inicial após o login
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Adiciona uma mensagem de erro caso o login falhe
                ViewBag.ErrorMessage = "Email ou password incorretos";
                return View("Index");
            }
        }

        private bool IsValidUser(string email, string password)
        {
            // Valida o user
            // Implementa a verificação com base na base de dados
            return email == "admin" && password == "password";
        }
    }
}

