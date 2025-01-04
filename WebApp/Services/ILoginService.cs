namespace WebApp.Services
{
    public interface ILoginService
    {
        /// <summary>
        /// Valida as credenciais de um utilizador.
        /// </summary>
        /// <param name="email">O email do utilizador.</param>
        /// <param name="password">A senha em texto plano.</param>
        /// <returns>True se as credenciais forem válidas; False caso contrário.</returns>
        bool ValidarCredenciais(string email, string password);
    }
}
