using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Enderecos
    {
        [Key]
        public required int EnderecoID { get; set; }

        public required int UserID { get; set; }

        // Nome
        [StringLength(50, ErrorMessage = "O Nome não pode ter mais do que 50 caracteres.")]
        public required string Nome { get; set; }

        // Endereço 1
        [StringLength(100, ErrorMessage = "O endereço não pode ter mais do que 100 caracteres.")]
        public required string EnderecoLinha1 { get; set; }

        // Endereço 2
        [StringLength(100, ErrorMessage = "O endereço não pode ter mais do que 100 caracteres.")]
        public string EnderecoLinha2 { get; set; } = string.Empty;

        // Número (manter como int)
        [Range(1, int.MaxValue, ErrorMessage = "O número deve ser válido.")]
        public required int Numero { get; set; }

        // Código Postal (manter como int)
        [StringLength(8, ErrorMessage = "O código postal não pode ter mais do que 9 caracteres.")]
        public required string CodigoPostal { get; set; }

        // Nome de empresa (opcional)
        [StringLength(50, ErrorMessage = "O nome da empresa não pode ter mais do que 50 caracteres.")]
        public required string Empresa { get; set; } = string.Empty;

        // Cidade
        [StringLength(25, ErrorMessage = "A cidade não pode ter mais do que 25 caracteres.")]
        public required string Cidade { get; set; }

        // Distrito
        [StringLength(25, ErrorMessage = "O distrito não pode ter mais do que 25 caracteres.")]
        public required string Distrito { get; set; }

        // País
        [StringLength(50, ErrorMessage = "O país não pode ter mais do que 50 caracteres.")]
        public required string Pais { get; set; }

        // NIF (manter como int)
        [Range(100000000, 999999999, ErrorMessage = "O NIF deve ter exatamente 9 dígitos.")]
        public required int NIF { get; set; }

        // Telemóvel (manter como int)
        [Range(100000000, 999999999, ErrorMessage = "O Telemóvel deve ter exatamente 9 dígitos.")]
        public required int Telemovel { get; set; }

        // Tipo (Morada de entrega ou Faturação)
        [StringLength(50, ErrorMessage = "O tipo não pode ter mais do que 50 caracteres.")]
        public required string Tipo { get; set; }
    }
}