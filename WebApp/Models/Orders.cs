using System.Globalization;

namespace WebApp.Models
{
    public class Orders
    {
        public int OrderID { get; set; }

        public int UserID { get; set; }

        public DateTime DataPedido { get; set; }

        //public string Status { get; set; }
        public decimal Total { get; set; }

        public int EnderecoEntregaID { get; set; }
        public int CupomID {get; set; }
    }
}
