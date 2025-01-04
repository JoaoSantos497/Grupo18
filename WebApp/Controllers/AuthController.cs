using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp.Data;

public class AuthController : Controller
{
    private readonly ApplicationDbContext _context;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string usernameOrEmail, string password)
    {
        var user = _context.Users.FirstOrDefault(u =>
            (u.Username == usernameOrEmail || u.Email == usernameOrEmail) &&
            PasswordHasher.VerifyPassword(u.PasswordHash, password));

        if (user == null)
        {
            ViewBag.Error = "Credenciais inválidas!";
            return View();
        }

        if (user.RoleID == 1) // Admin
        {
            // Redirecionar para a área de Admin
            return RedirectToAction("Index", "Admin");
        }
        else if (user.RoleID == 2) // Cliente
        {
            // Redirecionar para a área de Cliente
            return RedirectToAction("Index", "Cliente");
        }

        ViewBag.Error = "Role inválida!";
        return View();
    }

    [HttpGet]
    public IActionResult Logout()
    {
        // Limpar sessão ou autenticação
        return RedirectToAction("Login");
    }
}
