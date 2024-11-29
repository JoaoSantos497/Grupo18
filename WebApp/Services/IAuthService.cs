using WebApp.Models;

namespace WebApp.Services
{
    public interface IAuthService 
    {
        User Authenticate(string email, string passwordhash);
        object Authenticate(object email, object passwordhash);
        bool Registo(User newUser, string password);
   
    }
}
