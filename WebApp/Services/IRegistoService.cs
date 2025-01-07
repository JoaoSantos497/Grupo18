using WebApp.Models;

namespace WebApp.Services
{
    public interface IRegistoService
    {
        Task SalvarCreateUserAsync(CreateUserForm registo);
        Task SalvarRegistoAsync(RegistoForm registo);
    }
}
