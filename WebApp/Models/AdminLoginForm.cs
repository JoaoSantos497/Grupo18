using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models;

namespace WebApp.Models
{
    public class AdminLoginModel
    {
        // Username do Administrador
        [Required(ErrorMessage = "O nome de usuário é obrigatório")]
        public required string Username { get; set; }

        // Password do Administrador
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public required string PasswordHash { get; set; }

        public required int RoleID { get; set; }
    }
}


        
