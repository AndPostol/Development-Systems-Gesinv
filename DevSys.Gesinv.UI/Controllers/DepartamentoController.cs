using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevSys.Gesinv.UI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoService _service;

        public DepartamentoController(IDepartamentoService service)
        {
            _service = service;
        }

        // GET: DepartamentoController
        public async Task<ActionResult> Index()
        {
            IEnumerable<Departamento> query = await _service.GetAll();
            List<DepartamentoViewModel> lstViewModel = DepartamentoViewModel.ToViewModelList(query.ToList());
            return View(lstViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> getList() 
        {
            IEnumerable<Departamento> query = await _service.GetAll();
            List<DepartamentoViewModel> lstVM = DepartamentoViewModel.ToViewModelList(query);
            return StatusCode(StatusCodes.Status200OK, lstVM);
        }

        // GET: DepartamentoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Departamento query = await _service.GetById(id);
            DepartamentoViewModel modelView = DepartamentoViewModel.ToViewModel(query);
            return View(modelView);
        }

        // GET: DepartamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DepartamentoViewModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewData["Message"] = "Su Departamento se a creado correctamente";
                    Departamento nDepartamento = DepartamentoViewModel.ToModel(collection);
                    await _service.Create(nDepartamento); 
                    return RedirectToAction("Index","Departamento");
                }
                ViewData["Message"] = "Ha ocurrido un error";
                return View();
            }
            catch
            {
                ViewData["Message"] = "Ha ocurrido un error";
                return View();
            }
        }

        // GET: DepartamentoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Departamento query = await _service.GetById(id);
            DepartamentoViewModel viewModel = DepartamentoViewModel.ToViewModel(query);
            return View(viewModel);
        }

        // POST: DepartamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DepartamentoViewModel collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    ViewData["Message"] = "El departamento se a modificado correctamente";
                    Departamento updateDepartamento = DepartamentoViewModel.ToModel(collection);
                    updateDepartamento.DepartamentoId = id;
                    await _service.Update(updateDepartamento);
                    return RedirectToAction("Index","Departamento");
                }
                ViewData["Message"] = "Ha ocurrido un error";
                return View();
            }
            catch
            {
                ViewData["Message"] = "Ha ocurrido un error";
                return View();
            }
        }

        // GET: DepartamentoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Departamento query = await _service.GetById(id);
            DepartamentoViewModel viewModel = DepartamentoViewModel.ToViewModel(query);
            return View(viewModel);
        }

        // POST: DepartamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, DepartamentoViewModel collection)
        {
            try
            {   
                ViewData["Message"] = "Su Departamento se a eliminado correctamente";
                await _service.Delete(id);
                return RedirectToAction("Index", "Departamento");   
            }
            catch
            {
                ViewData["Message"] = "Ha ocurrido un error";
                return View();
            }
        }
    }
}
