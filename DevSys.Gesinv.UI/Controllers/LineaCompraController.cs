using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevSys.Gesinv.UI.Controllers
{
    [Authorize]
    public class LineaCompraController : Controller
    {
        // GET: LineaCompraController
        private readonly ILineaCompraService _service;

        public LineaCompraController(ILineaCompraService service)
        {
            _service = service;
        }

        public async Task<ActionResult> Index()
        {
            IEnumerable<LineaCompra> query = await _service.GetAll();
            List<LineaCompraViewModel> lstViewModel = LineaCompraViewModel.ToViewModelList(query.ToList());
            return View(lstViewModel);
        }

        // GET: LineaCompraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LineaCompraController/Create
        public async Task<ActionResult> Create()
        {

            return View();
        }

        // POST: LineaCompraController/Create
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

        // GET: LineaCompraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LineaCompraController/Edit/5
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

        // GET: LineaCompraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LineaCompraController/Delete/5
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
