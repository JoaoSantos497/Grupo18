﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class User
    {

        //[Column("userid")]
        // ID do utilizador (chave primária)
        public int UserID { get; set; }

        // Nome do utilizador
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        // Username do utilizador
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(25, ErrorMessage = "O nome não pode ter mais que 25 caracteres.")]
        public string Username { get; set; } = string.Empty;

        // Email do utilizador
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        public string Email { get; set; } = string.Empty;

        // Password do utilizador
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(16, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        public string PasswordHash { get; set; } = string.Empty;

        // Data de Nascimento
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        // Genero
        public string Genero { get; set; } = string.Empty;

        //Role do utilizador
        //[Required(ErrorMessage = "Role é obrigatória.")]
        //[StringLength(50, ErrorMessage = "A Role não foi definida")]
        public int RoleID { get; set; }  // Para definir cargos de utilizador (Admin, user, etc.)

        // Data de registo
        public DateTime DataRegisto { get; set; } = DateTime.UtcNow;

        // Outros campos opcionais para adicionar

    }
}

