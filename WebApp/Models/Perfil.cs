using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models;


namespace WebApp.Models
{
    //[Table("Produtos")]
    public class Perfil
    {

        // Nome do utilizador
        //[Column("nome")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        // Username do utilizador
        //[Column("username")]
        [StringLength(25, ErrorMessage = "O nome não pode ter mais que 25 caracteres.")]
        public string Username { get; set; } = string.Empty;

        // Email do utilizador
        //[Column("email")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        public string Email { get; set; } = string.Empty;

        // Password do utilizador
        //[Column("passwordhash")]
        [StringLength(16, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        public string PasswordHash { get; set; } = string.Empty;

    }
}