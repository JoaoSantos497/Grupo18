using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models;

namespace WebApp.Models
{
        public class RegistoForm
        {
            public required string Username { get; set; }
            public required string Nome { get; set; }
            public required string Email { get; set; }
            public required string Password { get; set; }
            public required DateTime DataNascimento { get; set; }
            public required string Genero { get; set; }

            //public required string Role {  get; set; }

        }
    
}
