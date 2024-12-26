using WebApp.Models;

namespace WebApp.Services
{
    public interface IUserService
    {
        User Create(User user);
        Task CreateUserAsync(User user);

        //Task DeleteUserAsync(User user);
        //Task UpdateUserAsync(User user);

        User AuthenticateAdmin(string username, string password);

        Task<User> AuthenticateAdminAsync(string username, string password);
    }

   
        
}
