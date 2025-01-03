﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Authorize(Roles = "1")]
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Exibe a página de login para administradores
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Renderiza a view Index.cshtml em /Views/Admin/Index.cshtml
        }

        // POST: Processa o login do administrador
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Admin(string username, string password)
        {
            try
            {
                // Tenta autenticar o administrador usando o serviço
                var admin = await _userService.AuthenticateAdminAsync(username, password);

                // Caso a autenticação falhe
                if (admin == null)
                {
                    ModelState.AddModelError(string.Empty, "Utilizador ou senha inválidos.");
                    return View("Index");
                }

                // Adiciona o UserId do administrador na sessão
                HttpContext.Session.SetString("UserID", admin.UserID.ToString());

                // Redireciona para a página Index do DashboardController
                return RedirectToAction("Index", "Dashboard");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde.");
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return View("Index");
            }
        }

        // GET: Exibe o Dashboard do administrador (área protegida)
        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            // Verifica se o administrador está autenticado
            var userId = HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index, Admin"); // Redireciona para a página de login
            }

            // Carrega o dashboard do administrador
            return View();
        }


        // GET: Faz o logout do administrador
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            // Limpa os dados de sessão
            HttpContext.Session.Clear();

            // Redireciona para a página de login
            return RedirectToAction("Index, Admin");
        }
    }
}
