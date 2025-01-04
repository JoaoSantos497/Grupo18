using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;
using WebApp.Data;
using System.Security.Claims;

namespace WebApp.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasherService _passwordHasherService;

        public LoginController(ILoginService loginService, IPasswordHasherService passwordHasherService, ApplicationDbContext context)
        {
            _loginService = loginService;
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _passwordHasherService = passwordHasherService ?? throw new ArgumentNullException(nameof(passwordHasherService));
        }   

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string email, string username, string password)
        {
            if ((string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(username)) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Por favor, preencha todos os campos.";
                if (username != null) return RedirectToAction("Index", "Admin");
                return View();
            }

            // Lógica para verificar se é um Admin (username) ou Cliente (email)
            var user = _context.Users
                .FirstOrDefault(u =>
                    (u.Username == username && u.RoleID == 1) || // Admin: procura pelo username
                    (u.Email == email && u.RoleID == 2) // Cliente: procura pelo email
                );

            // Verifica se o usuário foi encontrado e se a senha é válida
            if (user == null || !_passwordHasherService.VerifyPassword(user.PasswordHash, password))
            {
                ViewBag.Error = "Credenciais inválidas!";
                if (username != null) return RedirectToAction("Index", "Admin");
                return View();
            }
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.Role, user.RoleID.ToString())
            };

            // Create claims identity
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Create authentication properties
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, // Persistent cookie
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30) // Expiry time
            };

            // Sign in the user
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

            // Redirecionamento com base na role
            return user.RoleID switch
            {
                1 => RedirectToAction("Index", "Dashboard"),   // Admin
                2 => RedirectToAction("Index", "Perfil"), // Cliente
                _ => HandleInvalidRole()
            };
        }

        private IActionResult HandleInvalidRole()
        {
            ViewBag.Error = "Role inválida! Entre em contato com o suporte.";
            return View("Login");
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
