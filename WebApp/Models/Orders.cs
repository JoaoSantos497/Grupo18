namespace WebApp.Models
{
    public class Order
    {
        public int OrderID { get; set; } // Chave primária
        public int UserID { get; set; } // FK para a tabela Users
        public DateTime DataPedido { get; set; } // Data do pedido
        public decimal Total { get; set; } // Valor total da encomenda
        public string Status { get; set; } // Estado: Pendente, Enviado, Entregue, etc.
    }
}
