using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Carrinho
    {
        [Key]
        public int CarrinhoID { get; set; }
        public required int UserID { get; set; }
        public required int ProdutoID { get; set; }
        public Produto? Produto { get; set; }
        public required int Quantidade { get; set; }
        public required DateTime DataAdicionado { get; set; }
    }
}
