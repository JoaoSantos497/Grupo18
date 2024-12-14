using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public class EnderecoService
    {
        private readonly DbContext _context;

        public EnderecoService(DbContext context)
        {
            _context = context;
        }

        // Create (Cria novo endereco)
        public async Task<bool> AddEnderecoAsync(Enderecos endereco)
        {
            try
            {
                await _context.Set<Enderecos>().AddAsync(endereco);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Read (Lista todos os enderecos)
        public async Task<List<Enderecos>> GetAllEnderecosAsync()
        {
            return await _context.Set<Enderecos>().ToListAsync();
        }

        // Read (Lista o endereco correspondente ao ID)
        public async Task<Enderecos?> GetEnderecoByIdAsync(string enderecoId)
        {
            return await _context.Set<Enderecos>().FindAsync(enderecoId);
        }

        // Update (Editar um endereco existente)
        public async Task<bool> UpdateEnderecoAsync(Enderecos endereco)
        {
            try
            {
                _context.Set<Enderecos>().Update(endereco);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Delete (Remover um endereco)
        public async Task<bool> DeleteEnderecoAsync(string enderecoId)
        {
            try
            {
                var endereco = await _context.Set<Enderecos>().FindAsync(enderecoId);
                if (endereco == null) return false;

                _context.Set<Enderecos>().Remove(endereco);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

