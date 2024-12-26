using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Admin()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Admin(string username, string password)
    {
        var user = await _userService.AuthenticateAdminAsync(username, password);

        if (user != null)
        {
            // Login bem-sucedido, redirecionar ou salvar sessão
            return RedirectToAction("Dashboard", "Admin");
        }

        // Login falhou, exibir mensagem de erro
        ViewBag.Error = "Credenciais inválidas ou não tem permissão de administrador.";
        return View();
    }
}
