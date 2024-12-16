using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; } // Removido o `required`, pois [Key] já é obrigatório.

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string Genero { get; set; } = string.Empty;

        public DateTime DataRegisto { get; set; } = DateTime.UtcNow;

        // Construtor padrão (sem parâmetros) para o Entity Framework
        public User()
        {
        }

        // Construtor com parâmetros
        public User(int userId, string nome, string username, string email, string passwordHash, DateTime dataNascimento, string genero)
        {
            UserID = userId;
            Nome = nome;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            DataNascimento = dataNascimento;
            Genero = genero;
            DataRegisto = DateTime.UtcNow;
        }
    }
}
