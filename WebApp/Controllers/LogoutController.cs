using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Authorize] 
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : Controller
    {
        // Endpoint para fazer o logout
        [HttpPost]
        [Route("")]
        public IActionResult Logout()
        {
            // Se estiver usando cookies, remova-os
            HttpContext.Response.Cookies.Delete("AuthToken");

            // Para JWT, você pode implementar a invalidação em uma blacklist no lado do servidor (opcional)

            // Retorna uma resposta indicando que o logout foi concluído
            return Ok(new { message = "Logout realizado com sucesso." });
        }
    }
}
