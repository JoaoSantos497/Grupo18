namespace WebApp.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public decimal Preço { get; set; }
        public string? Stock { get; set; }
    }
}
