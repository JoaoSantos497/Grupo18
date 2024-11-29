using WebApp.Models;

namespace WebApp.Services
{
    public interface IUserService
    {
        User Create(User user);
        Task CreateUserAsync(User user);
    }

}
