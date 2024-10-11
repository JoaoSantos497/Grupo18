using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class RegistoController : Controller
    {
        // GET: RegistoController
        public ActionResult Index()
        {
            return View();
        }


        // POST: RegistoController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(LoginController.Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
