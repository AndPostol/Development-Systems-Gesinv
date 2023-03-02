using DevSys.Gesinv.DAL;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevSys.Gesinv.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public IActionResult Create()
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

                OrdenCompraViewModel nuevaOC = new OrdenCompraViewModel()
                {
                    ProveedorId = Convert.ToInt32(collection["ProveedorId"]),
                    BodegaId = Convert.ToInt32(collection["BodegaId"]),
                    Referencia = collection["Referencia"],
                    CondicionPagoId = Convert.ToInt32(collection["CondicionPagoId"]),
                    Observacion = collection["Observacion"],
                    Fecha = Convert.ToDateTime(collection["Fecha"]),
                    SubTotal = Convert.ToDouble(collection["SubTotal"]),
                    Descuento = Convert.ToDouble(collection["Descuento"]),
                    Impuestos = Convert.ToDouble(collection["Impuestos"]),
                    Total = Convert.ToDouble(collection["Total"]),
                    LineaCompra = new List<LineaCompraViewModel>()
                    
                };
                // Esto es un input que trae la cantidad de lineas a registrar
                int cantidad = Convert.ToInt32(collection["CantidadProducto"]);

                for (int i = 1; i <= cantidad; i++)
                {
                    LineaCompraViewModel row = new LineaCompraViewModel();
                    try
                    {
                        row.ProductoId = Convert.ToInt32(collection[$"Linea-Nombre-{i}"]);
                    }
                    catch (Exception)
                    {
                        row.ProductoId = 0;
                        row.Producto = new Producto
                        {
                            Nombre = collection[$"Linea-Nombre-{i}"],
                            Precio = Convert.ToDouble(collection[$"Linea-PrecioUnitario-{i}"])
                        };
                    }
                    row.DepartamentoId = Convert.ToInt32(collection[$"Linea-Departamento-{i}"]);
                    row.Cantidad = Convert.ToInt32(collection[$"Linea-Cantidad-{i}"]);
                    row.Caja = 0;
                    row.Precio = Convert.ToDouble(collection[$"Linea-PrecioUnitario-{i}"]);
                    row.Descuento = Convert.ToDouble(collection[$"Linea-Descuento-{i}"]);
                    row.Total = Convert.ToDouble(collection[$"Linea-Total-{i}"]);
                    nuevaOC.LineaCompra.Add(row);
                }

                OrdenCompra model = OrdenCompraViewModel.ToModel(nuevaOC);
                OrdenCompra result = await _service.Registrar(model);
                return RedirectToAction("Details", "OrdenCompra", new { id = result.OrdenCompraId });
            }
            catch (Exception e)
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
                if (ModelState.IsValid)
                {
                    OrdenCompra updateOrdenCompra = OrdenCompraViewModel.ToModel(collection);
                    updateOrdenCompra.OrdenCompraId = id;
                    await _service.Update(updateOrdenCompra);
                    return RedirectToAction("Index","OrdenCompra");
                }
                return View(collection.OrdenCompraId);
            }
            catch
            {
                return View(collection.OrdenCompraId);
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
