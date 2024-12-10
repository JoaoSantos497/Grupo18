using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebApp.Models;

namespace WebApp.Services 
{
    public class AuthService : IAuthService
    {

        public object Authenticate(object email, object passwordhash)
        {
            throw new NotImplementedException();
        }

        public User Authenticate(string email, string passwordhash)
        {
            throw new NotImplementedException();
        }

        public bool Register(User newUser, string password)
        {
            throw new NotImplementedException();
        }

        public bool Registo(User newUser, string password)
        {
            throw new NotImplementedException();
        }

        string IAuthService.Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
