using WebApp.Models;

namespace WebApp.Services
{
    public interface IRegistoService
    {
        Task SalvarRegistoAsync(RegistoForm registo);
    }
}
