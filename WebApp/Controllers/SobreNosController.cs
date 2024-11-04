using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SobreNosController : Controller
    {
        // GET: SobreNosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SobreNosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SobreNosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SobreNosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SobreNosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SobreNosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SobreNosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SobreNosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
