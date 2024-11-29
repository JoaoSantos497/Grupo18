using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models;

namespace WebApp.Models
{
    public class RegistoForm
    {
        // Nome do utilizador
        //[Column("nome")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 50 caracteres.")]
        public required string Nome { get; set; }

        // Username do utilizador
        //[Column("username")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(20, ErrorMessage = "O nome não pode ter mais que 20 caracteres.")]
        public required string Username { get; set; }

        // Email do utilizador
        //[Column("email")]
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        public required string Email { get; set; }

        //Password
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(16, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.", MinimumLength = 8)]
        public required string Password { get; set; }

        // Data de Nascimento
        //[Column("datanascimento")]
        [DataType (DataType.Date)]
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public required DateTime DataNascimento { get; set; }

        // Genero
        [Column("genero")]
        public required string Genero { get; set; }
    }
}
