using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class User
    {
        // ID do utilizador (chave primária)
        public int UserID { get; set; }

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

        // Role do utilizador
        [Required(ErrorMessage = "Role é obrigatória.")]
        [StringLength(100, ErrorMessage = "A Role não foi definida")]
        public required string Role { get; set; }   // Para definir papéis de utilizador (Admin, user, etc.)


        // Data de registo
        public DateTime RegisteredDate { get; set; }

        // Outros campos opcionais para adicionar
        public bool IsActive { get; set; }  // Para ativar/desativar utilizadores
    }
}
