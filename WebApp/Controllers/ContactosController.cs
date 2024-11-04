using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ContactosController : Controller
    {
        // GET: ContactosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContactosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactosController/Create
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

        // GET: ContactosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactosController/Edit/5
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

        // GET: ContactosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactosController/Delete/5
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
