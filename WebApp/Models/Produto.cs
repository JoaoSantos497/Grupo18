using System;
using System.ComponentModel.DataAnnotations;
using WebApp.Models;


namespace WebApp.Models
{
    public class Product
    {
        // ID do produto (chave primária)
        public int ProdutoID { get; set; }

        // Nome do produto
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do produto não pode ter mais que 100 caracteres.")]
        public required string Nome { get; set; }

        // Descrição do produto
        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição do produto não pode ter mais que 500 caracteres.")]
        public required string Descricao { get; set; }

        // Preço do produto
        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        // Quantidade em estoque
        [Required(ErrorMessage = "A quantidade em estoque é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
        public int StockQuantity { get; set; }

        // URL da imagem do produto
        [Url(ErrorMessage = "A URL da imagem do produto não é válida.")]
        public required string ImageUrl { get; set; }

        // Data de criação do produto
        public DateTime CreatedDate { get; set; }

        // Campo para verificar se o produto está ativo
        public bool IsActive { get; set; } // Para ativar/desativar produtos
    }
}