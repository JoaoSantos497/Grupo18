using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
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

        // Exibe a página de login
        [HttpGet("")]
        public IActionResult Index()
        {
            // Verifica se o user já está autenticado
            //if (User.Identity.IsAuthenticated)
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated)

            {
                // Se o user for admin, redireciona para o Dashboard
                if (User.IsInRole("1")) // RoleID para Admin
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                // Se o user for cliente, redireciona para o Perfil
                else if (User.IsInRole("2")) // RoleID para Cliente
                {
                    return RedirectToAction("Index", "Perfil");
                }
            }

            // Caso não esteja autenticado, exibe a página de login
            return View();
        }

        // Processa o login
        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string email, string username, string password)
        {
            // Validação dos campos
            if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Por favor, preencha todos os campos.";
                return View();
            }

            // Lógica para verificar se é um Admin (username) ou Cliente (email)
            var user = _context.Users
                .FirstOrDefault(u =>
                    (u.Username == username && u.RoleID == 1) || // Admin: procura pelo username
                    (u.Email == email && u.RoleID == 2) // Cliente: procura pelo email
                );

            // Verifica se o user foi encontrado e se a senha é válida
            if (user == null || !_passwordHasherService.VerifyPassword(user.PasswordHash, password))
            {
                ViewBag.Error = "Credenciais inválidas!";
                return View();
            }

            // Criação dos claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.Role, user.RoleID.ToString()),             // Role do user
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString())    // ID do user
            };

            // Criação da identidade de claims
            //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Propriedades de autenticação
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, // Define o cookie como persistente
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30) // Define o tempo de expiração
            };

            // Fazendo o login do usuário e criando o cookie
            if (user.RoleID == 1) // Admin
            {
                var claimsIdentity = new ClaimsIdentity(claims, "AdminCookie");
                await HttpContext.SignInAsync("AdminCookie", new ClaimsPrincipal(claimsIdentity), authProperties);
                return RedirectToAction("Index", "Dashboard"); // Redireciona para o Dashboard do admin
            }
            else if (user.RoleID == 2) // Cliente
            {
                var claimsIdentity = new ClaimsIdentity(claims, "UserCookie");
                await HttpContext.SignInAsync("UserCookie", new ClaimsPrincipal(claimsIdentity), authProperties);
                return RedirectToAction("Index", "Perfil"); // Redireciona para o perfil do cliente
            }

            return HandleInvalidRole();
        }

        // Caso o user tenha uma role inválida
        private IActionResult HandleInvalidRole()
        {
            ViewBag.Error = "Role inválida! Entre em contato com o suporte.";
            return View("Index");
        }

        // Logout
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            // Remove o cookie de autenticação de todos os tipos de role
            await HttpContext.SignOutAsync("UserCookie");

            // Redireciona para a página inicial
            return RedirectToAction("Index", "Home");
        }
    }
}
