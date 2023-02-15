using DevSys.Gesinv.Logic.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevSys.Gesinv.UI.Controllers
{
    public class OrdenCompraController : Controller
    {
        private readonly IOrdenCompraService _service;
        public OrdenCompraController(IOrdenCompraService service) 
        {
            _service = service;
        }
        // GET: OrdenCompraController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrdenCompraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenCompraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdenCompraController/Create
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

        // GET: OrdenCompraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenCompraController/Edit/5
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

        // GET: OrdenCompraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenCompraController/Delete/5
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
