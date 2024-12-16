using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/[controller]")] // Define a rota base para o controlador
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Endpoint para login de usuários
        /// </summary>
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validações básicas
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Autenticar o usuário
            var user = _authService.Authenticate(request.Email, request.Password);
            if (user == null)
            {
                return Unauthorized(new { Message = "Credenciais inválidas." });
            }

            return Ok(new
            {
                Message = "Login bem-sucedido!",
                User = new
                {
                    user.UserID,
                    user.Nome,
                    user.Email,
                    user.Username
                }
            });
        }

        /// <summary>
        /// Endpoint para registo de usuários
        /// </summary>
        [HttpPost("Registo")]
        public IActionResult Registo([FromBody] RegistoRequest request)
        {
            // Validações básicas
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Criar o objeto User
            var newUser = new User
            {
                Username = request.Username,
                Nome = request.Nome,
                Email = request.Email,
                PasswordHash = request.Password,
                DataNascimento = request.DataNascimento,
                Genero = request.Genero
            };

            // Registar o novo utilizador
            var success = _authService.Registo(newUser, request.Password);
            if (!success)
            {
                return BadRequest(new { Message = "Utilizador ou email já existe." });
            }

            return Ok(new { Message = "Registo bem-sucedido!" });
        }
    }

    // Modelos de requisições
    public class LoginRequest
    {
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email é inválido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A password é obrigatória.")]
        public required string Password { get; set; }
    }

    public class RegistoRequest
    {
        [Required(ErrorMessage = "O username é obrigatório.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email é inválido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A password é obrigatória.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        public required DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O Genero é obrigatória.")]
        public required string Genero { get; set; }
    }
}

