using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevSys.Gesinv.UI.Controllers
{
    public class IngresoDetalleController : Controller
    {
        // GET: IngresoDetalleController
        public ActionResult Index()
        {
            return View();
        }

        // GET: IngresoDetalleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IngresoDetalleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngresoDetalleController/Create
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

        // GET: IngresoDetalleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IngresoDetalleController/Edit/5
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

        // GET: IngresoDetalleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IngresoDetalleController/Delete/5
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
