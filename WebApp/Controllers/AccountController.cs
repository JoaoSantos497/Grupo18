using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User request)
        {
            var user = _authService.Authenticate(request.Email, request.PasswordHash);
            if (user == null)
            {
                return Unauthorized("Credenciais inválidas.");
            }
            return Ok(new { Message = "Login bem-sucedido!", User = user });
        }

        [HttpPost("Registo")]
        public IActionResult Register([FromBody] User request)
        {
            var newUser = new User
            {
                Username = request.Username,
                Nome = request.Nome,
                Email = request.Email
            };

            var success = _authService.Registo(newUser, request.PasswordHash);
            if (!success)
            {
                return BadRequest("Utilizador ou email já existe.");
            }
            return Ok(new { Message = "Registo bem-sucedido!" });
        }
    }
}

