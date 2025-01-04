using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.Models;


[Route("Admin")] // Define a rota base como /Admin
public class AdminController : Controller
{
    private readonly IUserService _userService;

    // Construtor para injeção de dependência
    public AdminController(IUserService userService)
    {
        _userService = userService;
    }

    // Ação GET para login de Admin
    public IActionResult Index()
    {
        return View(); // Página de login
    }
    
}
