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
        public required string Nome { get; set; }

        // Username do utilizador
        //[Column("username")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public required string Username { get; set; }

        // Email do utilizador
        //[Column("email")]
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        public required string Email { get; set; }

        // Password do utilizador
        //[Column("passwordhash")]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        public required string PasswordHash { get; set; }

        // Data de Nascimento
        //[Column("datanascimento")]
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        //[StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        public required string DataNascimento { get; set; }

        // Genero
        //[Column("genero")]
        public required string Genero { get; set; }

        // Role do utilizador
        //[Required(ErrorMessage = "Role é obrigatória.")]
        //[StringLength(100, ErrorMessage = "A Role não foi definida")]
        //public required string Roles { get; set; }   // Para definir papéis de utilizador (Admin, user, etc.)


        // Data de registo
        public DateTime DataRegisto { get; set; }

        // Outros campos opcionais para adicionar
        //public bool IsActive { get; set; }  // Para ativar/desativar utilizadores
    }
}
