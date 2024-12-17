namespace WebApp.Models
{
    public class Orders
    {
        public int OrderID { get; set; }

        public required int UserID { get; set; }

        public required DateTime DataPedido { get; set; }

        public required string Status { get; set; }
        public required decimal Total { get; set; }

        public required int EnderecoEntregaID { get; set; }
        public required int CupomID { get; set; }
    }
}
