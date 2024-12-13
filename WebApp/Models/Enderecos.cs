using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models;


namespace WebApp.Models
{
    //[Table("Produtos")]
    public class Enderecos
    {

        
        //[StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public string EnderecoID { get; set; } = string.Empty;

        // Username do utilizador
        //[Column("username")]
        [StringLength(100, ErrorMessage = "O endereçco não pode ter mais do que 100 caracteres.")]
        public string EnderecoLinha1 { get; set; } = string.Empty;

        // Email do utilizador
        //[Column("email")]
        [StringLength(100,ErrorMessage = "O endereçco não pode ter mais do que 100 caracteres.")]
        public string EnderecoLinha2 { get; set; } = string.Empty;

        // Password do utilizador
        //[Column("passwordhash")]
        //[StringLength(50, ErrorMessage = "A cidade.")]
        public string Cidade { get; set; } = string.Empty;
        [StringLength(7,ErrorMessage = "O campo é obrigatório" )]
        public string CodigoPostal {  get; set; } = string.Empty;

        public string Pais { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;

    }
}