﻿using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    //[Table("Produtos")]
    public class Produto {
        //[Column("produtoid")]
        // ID do produto (chave primária)
        public int ProdutoID { get; set; }

        // Nome do produto
        //[Column("nome")]
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do produto não pode ter mais que 100 caracteres.")]
        public required string Nome { get; set; }

        // Marca do produto
        //[Column("marca")]
        [Required(ErrorMessage = "A marca do produto é obrigatória.")]
        [StringLength(500, ErrorMessage = "A marca do produto não pode ter mais que 500 caracteres.")]
        public required string Marca { get; set; }

        // Modelo do produto
        //[Column("modelo")]
        [Required(ErrorMessage = "O modelo do produto é obrigatória.")]
        [StringLength(500, ErrorMessage = "O modelo do produto não pode ter mais que 500 caracteres.")]
        public required string Modelo { get; set; }

        // Descrição do produto
        //[Column("descricao")]
        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição do produto não pode ter mais que 500 caracteres.")]
        public required string Descricao { get; set; }

        // Preço do produto
        //[Column("preco")]
        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public required decimal Preco { get; set; }

        // Quantidade em stock
        //[Column("stock")]
        [Required(ErrorMessage = "A quantidade em stock é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
        public required int Stock { get; set; }

        //public string CategoriaID { get; set; }

        // URL da imagem do produto
        //[Url(ErrorMessage = "A URL da imagem do produto não é válida.")]
        public string? ImagemProduto { get; set; }



        // Data de criação do produto
        //public DateTime CreatedDate { get; set; }

        // Campo para verificar se o produto está ativo
        //public bool IsActive { get; set; } // Para ativar/desativar produtos
    }
}