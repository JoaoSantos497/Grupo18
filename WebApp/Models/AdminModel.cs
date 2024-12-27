using System.ComponentModel.DataAnnotations;

public class Admin
{   
    // ID do admin
    public int Id { get; set; }

    // Username do Admin
    [Required]
    [StringLength(50)]
    public required string Username { get; set; }

    // Password do Admin
    [Required]
    public required string PasswordHash { get; set; }

    [Required]
    public required int RoleID { get; set; }



    // Adicione outros campos conforme necessário
}


