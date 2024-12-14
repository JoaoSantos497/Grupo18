using WebApp.Models;

namespace WebApp.Services
{
    public interface IEnderecoService
    {
        Task<bool> AdicionarMoradaAsync(Enderecos endereco);
    }

}
