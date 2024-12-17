using System.Collections.Generic;

namespace WebApp.Services
{
    public class LoginService
    {
        // Simulação de utilizadores em memória. Substituir por lógica de acesso à base de dados.
        private readonly List<(string Email, string Password)> users = new List<(string, string)>
        {
            ("teste@exemplo.com", "1234"),
            ("admin@exemplo.com", "admin123")
        };

        /// <summary>
        /// Verifica se as credenciais do usuário são válidas.
        /// </summary>
        /// <param name="email">Email do utilzidor.</param>
        /// <param name="password">Senha do utilizador.</param>
        /// <returns>True se as credenciais forem válidas; caso contrário, False.</returns>
        public bool ValidarCredenciais(string email, string password)
        {
            // Busca o utilizador na "base de dados" (lista simulada)
            return users.Exists(u => u.Email == email && u.Password == password);
        }
    }
}
