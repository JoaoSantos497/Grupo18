using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Users
    {
        // ID do utilizador (chave primária)
        public int Id { get; set; }

        // Nome do utilizador
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public required string Username { get; set; }

        // Email do utilizador
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        public required string Email { get; set; }

        // Senha do utilizador
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        public required string Password { get; set; }

        // Data de registo
        public DateTime RegisteredDate { get; set; }

        // Outros campos que você pode querer adicionar
        public bool IsActive { get; set; }  // Para ativar/desativar utilizadores
        public required string Role { get; set; }     // Para definir papéis de utilizador (Admin, Usuário, etc.)
    }
}
