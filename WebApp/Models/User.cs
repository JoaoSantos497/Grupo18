using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models;

namespace WebApp.Models
{
    public class User {
        //[Column("userid")]
        // ID do utilizador (chave primária)
        public int UserID { get; set; }

        // Nome do utilizador
        //[Column("nome")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public  string Nome { get; set; } = string.Empty;

        // Username do utilizador
        //[Column("username")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public string Username { get; set; } = string.Empty;

        // Email do utilizador
        //[Column("email")]
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        public  string Email { get; set; } = string.Empty;

        // Password do utilizador
        //[Column("passwordhash")]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        public  string PasswordHash { get; set; } = string.Empty;

        // Data de Nascimento
        //[Column("datanascimento")]
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        //[StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        public  DateTime DataNascimento { get; set; }

        // Genero
        //[Column("genero")]
        public string Genero { get; set; } = string.Empty;

        // Role do utilizador
        //[Required(ErrorMessage = "Role é obrigatória.")]
        [StringLength(100, ErrorMessage = "A Role não foi definida")]
        public string? Roles { get; set; }   // Para definir cargos de utilizador (Admin, user, etc.)


        // Data de registo
        public DateTime DataRegisto { get; set; } = DateTime.UtcNow;

        // Outros campos opcionais para adicionar

        // Campo opcional para ativar/desativar utilizadores
        public bool IsActive { get; set; } = true; // Para ativar/desativar utilizadores
    }
}
