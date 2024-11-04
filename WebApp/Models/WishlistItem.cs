using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models
{
 
        public class WishlistItem
        {
            public int WishlistID { get; set; }
            public required string Nome { get; set; }
            public required string Marca { get; set; }
            public required string Modelo { get; set; }
            public required string Descricao { get; set; }
            public decimal Preco { get; set; }
            public decimal Stock { get; set; }
    }
}
 
