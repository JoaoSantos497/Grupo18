using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models;


namespace WebApp.Models
{
    
    public class Perfil
    {

        // Nome do utilizador
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        // Username do utilizador
        [StringLength(25, ErrorMessage = "O nome não pode ter mais que 25 caracteres.")]
        public string Username { get; set; } = string.Empty;

        // Email do utilizador
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        public string Email { get; set; } = string.Empty;

        // Password do utilizador
        [StringLength(16, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        public string PasswordHash { get; set; } = string.Empty;

    }
}