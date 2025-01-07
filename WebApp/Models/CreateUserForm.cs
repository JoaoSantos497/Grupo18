using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models;

namespace WebApp.Models
{
        public class CreateUserForm
        {
            public required string Username { get; set; }
            public required string Nome { get; set; }
            public required string Email { get; set; }
            public required string Password { get; set; }
            public required int RoleID { get; set; }
        }
    
}
