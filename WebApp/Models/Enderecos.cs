using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models;
using Xunit;
using Xunit.Sdk;


namespace WebApp.Models
{
    //[Table("Produtos")]
    public class Enderecos
    {

        
        //[StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public string EnderecoID { get; set; } = string.Empty;

        // Endereço 1
        [StringLength(100, ErrorMessage = "O endereçco não pode ter mais do que 100 caracteres.")]
        public string EnderecoLinha1 { get; set; } = string.Empty;

        // Endereço 2
        [StringLength(100,ErrorMessage = "O endereçco não pode ter mais do que 100 caracteres.")]
        public string EnderecoLinha2 { get; set; } = string.Empty;

        // Numero
        public string Numero { get; set; } = string.Empty;
        // Codigo Postal
        [StringLength(7, ErrorMessage = "Campo tem de ser preenchido.")]
        public string CodigoPostal { get; set; } = string.Empty;

        // Nome de empresa (opcional)
        [StringLength(50, ErrorMessage = "Campo tem de ser preenchido.")]
        public string Empresa { get; set; } = string.Empty;

        // Cidade
        [StringLength(25, ErrorMessage = "Campo tem de ser preenchido.")]
        public string Cidade { get; set; } = string.Empty;

        // Distrito
        [StringLength(25, ErrorMessage = "Campo tem de ser preenchido.")]
        public string Distrito { get; set; } = string.Empty;

        // Pais
        [StringLength(50, ErrorMessage = "Campo tem de ser preenchido.")]
        public string Pais {  get; set; } = string.Empty;

        // NIF
        [StringLength(9, ErrorMessage = "Campo tem de ser preenchido.")]
        public string NIF { get; set; } = string.Empty;

        //Telemovel
        public string Telemovel { get; set; } = string.Empty;

        // Tipo (Morada de entrega ou Faturação
        public string Tipo { get; set; } = string.Empty;

    }
}