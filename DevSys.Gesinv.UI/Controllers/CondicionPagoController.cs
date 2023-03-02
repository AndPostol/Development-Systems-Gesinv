using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevSys.Gesinv.UI.Controllers
{
    public class CondicionPagoController : Controller
    {
        private readonly ICondicionPagoService _service;

        public CondicionPagoController(ICondicionPagoService service)
        {
            _service = service;
        }
        // GET: CondicionPagoController
        public ActionResult Index()
        {
            List<CondicionPago> query = _service.GetAll().Result.ToList();
            return View(CondicionPagoViewModel.ToViewModelList(query));
        }

        [HttpGet]
        public async Task<IActionResult> getList()
        {
            IEnumerable<CondicionPago> query = await _service.GetAll();
            List<CondicionPagoViewModel> lstVM = CondicionPagoViewModel.ToViewModelList(query);
            return StatusCode(StatusCodes.Status200OK, lstVM);
        }

        // GET: CondicionPagoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CondicionPagoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CondicionPagoController/Create
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

        // GET: CondicionPagoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CondicionPagoController/Edit/5
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

        // GET: CondicionPagoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CondicionPagoController/Delete/5
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
