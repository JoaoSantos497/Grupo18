using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    public class SearchService 
    {
        private readonly ApplicationDbContext _context;

        public SearchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Produto> SearchProducts(string searchQuery, string categoriaid)
        {
            var query = _context.Produtos.AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(p =>
                    p.Nome.Contains(searchQuery) ||
                    p.Marca.Contains(searchQuery) ||
                    p.Modelo.Contains(searchQuery));
            }

            if (!string.IsNullOrEmpty(categoriaid))
            {
                //query = query.Where(p => p.CategoriaID == categoriaid);
            }

            return query.ToList();
        }
    }
}