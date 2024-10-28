using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AdminBackOffice : Controller
    {
        // GET: AdminBackOffice
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminBackOffice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminBackOffice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminBackOffice/Create
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

        // GET: AdminBackOffice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminBackOffice/Edit/5
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

        // GET: AdminBackOffice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminBackOffice/Delete/5
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
