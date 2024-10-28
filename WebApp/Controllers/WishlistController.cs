using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class WishlistController : Controller
    {
        // GET: WishlistController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WishlistController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WishlistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WishlistController/Create
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

        // GET: WishlistController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WishlistController/Edit/5
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

        // GET: WishlistController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WishlistController/Delete/5
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
