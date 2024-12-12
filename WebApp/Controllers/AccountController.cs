using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User request)
        {
            // Validações básicas para os campos obrigatórios
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.PasswordHash))
            {
                return BadRequest("Email e password são obrigatórios.");
            }

            // Autentica o usuário
            var user = _authService.Authenticate(request.Email, request.PasswordHash);
            if (user == null)
            {
                return Unauthorized(new { Message = "Credenciais inválidas." });
            }

            return Ok(new
            {
                Message = "Login bem-sucedido!",
                User = user
            });
        }

        public class LoginRequest
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
        }

        [HttpPost("Registo")]
        public IActionResult Registo([FromBody] User request)
        {
            // Validações básicas para os campos obrigatórios
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Nome) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.PasswordHash))
            {
                return BadRequest("Todos os campos são obrigatórios.");
            }

            // Cria um novo objeto User
            var newUser = new User
            {
                Username = request.Username,
                Nome = request.Nome,
                Email = request.Email,
                DataNascimento = request.DataNascimento
            };

            // Tenta registrar o novo usuário
            var success = _authService.Registo(newUser, request.PasswordHash);
            if (!success)
            {
                return BadRequest(new { Message = "Utilizador ou email já existe." });
            }

            return Ok(new
            {
                Message = "Registo bem-sucedido!"
            });
        }
    }
}

