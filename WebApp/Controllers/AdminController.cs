using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

[Authorize(Roles = "1")]
[Route("Admin")]
public class AdminController : Controller
{
    private readonly IUserService _userService;

    public AdminController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Index()
    {
        return View(); // Página de login
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Admin([Bind("Username, Password")] AdminLoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }

        try
        {
            var admin = await _userService.AuthenticateAdminAsync(model.Username, model.PasswordHash);

            if (admin == null)
            {
                ModelState.AddModelError(string.Empty, "Utilizador ou senha inválidos.");
                return View("Index");
            }

            HttpContext.Session.SetString("UserID", admin.UserID.ToString());
            return RedirectToAction("Dashboard");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
            ModelState.AddModelError(string.Empty, "Ocorreu um erro inesperado. Por favor, tente novamente.");
            return View("Index");
        }
    }

    [HttpGet("Dashboard")]
    public IActionResult Dashboard()
    {
        return View(); // Página do dashboard
    }

    
}
