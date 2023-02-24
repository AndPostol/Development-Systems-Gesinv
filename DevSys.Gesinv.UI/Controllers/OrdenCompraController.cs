using DevSys.Gesinv.DAL;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevSys.Gesinv.Models;
using System.Collections.Generic;

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
        public async Task<ActionResult> Index()
        {
            IEnumerable<OrdenCompra> query = await _service.GetAll();
            List<OrdenCompraViewModel> lstViewModel = OrdenCompraViewModel.ToViewModelList(query.ToList());
            return View(lstViewModel);
        }

        // GET: OrdenCompraController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            OrdenCompra query = await _service.GetById(id);
            OrdenCompraViewModel modelView = OrdenCompraViewModel.ToViewModel(query);
            return View(modelView);
        }

        // GET: OrdenCompraController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: OrdenCompraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {

                OrdenCompraViewModel nuevaOC = new OrdenCompraViewModel() {
                    ProveedorId = Convert.ToInt32(collection["ProveedorId"]),
                    Referencia = collection["Referencia"],
                    CondicionPagoId = Convert.ToInt32(collection["CondicionPagoId"]),
                    Observacion = collection["Observacion"],
                    Fecha = Convert.ToDateTime(collection["Fecha"]),
                    SubTotal = Convert.ToDouble(collection["SubTotal"]),
                    Descuento = Convert.ToInt32(collection["Descuento"]),
                    Impuestos = Convert.ToInt32(collection["Impuestos"]),
                    Total = Convert.ToInt32(collection["Total"])
                };
                Dictionary<string,string> listLinea = new Dictionary<string, string>();
                int num = 0;
                foreach (var item in collection)
                {

                    if (item.Key.StartsWith("Linea-"))
                    {
                        //listLinea.Add(item.Key);
                    }
                }
                //if (ModelState.IsValid)
                //{ 
                //    OrdenCompra nOrdenCompra = OrdenCompraViewModel.ToModel(collection);

                //    await _service.Create(nOrdenCompra); 
                //    return RedirectToAction("Index","OrdenCompra");
                //}
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenCompraController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            OrdenCompra query = await _service.GetById(id);
            OrdenCompraViewModel viewModel = OrdenCompraViewModel.ToViewModel(query);
            return View(viewModel);
        }

        // POST: OrdenCompraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, OrdenCompraViewModel collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    OrdenCompra updateOrdenCompra = OrdenCompraViewModel.ToModel(collection);
                    updateOrdenCompra.OrdenCompraId = id;
                    await _service.Update(updateOrdenCompra);
                    return RedirectToAction("Index","OrdenCompra");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenCompraController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            OrdenCompra query = await _service.GetById(id);
            OrdenCompraViewModel viewModel = OrdenCompraViewModel.ToViewModel(query);
            return View(viewModel);
        }

        // POST: OrdenCompraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, OrdenCompraViewModel collection)
        {
            try
            {             
                await _service.Delete(id);
                return RedirectToAction("Index", "OrdenCompra");   
            }
            catch
            {
                return View();
            }
        }
    }
}
