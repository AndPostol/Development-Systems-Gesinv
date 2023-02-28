using Microsoft.AspNetCore.Mvc;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using DevSys.Gesinv.Logic.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DevSys.Gesinv.UI.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;
        private readonly IMarcaService _marcaService;
        private readonly IColorService _colorService;
        private readonly ILineaService _lineaService;


        public ProductoController(IProductoService productoService, IColorService colorService, ILineaService lineaService, IMarcaService marcaService)
        {
            _productoService = productoService;
            _colorService = colorService;
            _lineaService = lineaService;
            _marcaService = marcaService;
        }

        // GET: ProductoController
        public async Task<ActionResult> Index()
        {
            IEnumerable<Producto> queryProducto = await _productoService.GetAll(); 
            List<ProductoViewModel> lstProductoViewModel = ProductoViewModel.ListViewModel(queryProducto);
            return View(lstProductoViewModel);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ProductoViewModel _producto = ProductoViewModel.ConvertToViewModel(await _productoService.GetById(id));
            return View(_producto);
        }

        // GET: ProductoController/Create
        public async Task<ActionResult> Create()
        {
            IEnumerable<Linea> queryLinea = await _lineaService.GetAll();
            List<LineaViewModel> lstLineaViewModel = LineaViewModel.ListViewModel(queryLinea);

            var model = new ProductoViewModel();
            model.LineasSelectList = new List<SelectListItem>();
            foreach (var linea in lstLineaViewModel)
            {
                model.LineasSelectList.Add(new SelectListItem
                {
                    Text = linea.Nombre.ToString(),
                    Value = linea.LineaId.ToString(),
                    Selected = false
                });
            }

            //ViewBag.LineaOptions = model;

            return View(model);
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductoViewModel productoViewModel)
        {
            Producto producto = ProductoViewModel.ConvertToModel(productoViewModel);
            var selectedLinea = productoViewModel.LineaID; //esto no va a ningun lado
            
            try
            {
                if (!ModelState.IsValid)
                {
                    await _productoService.Create(producto); 
                }
                return RedirectToAction("Index", "Producto");
            }
            catch
            {
                return View(productoViewModel);
            }
           
        }

        // GET: ProductoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ProductoViewModel productoViewModel = ProductoViewModel.ConvertToViewModel(await _productoService.GetById(id));
            return View(productoViewModel);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductoViewModel productoViewModel)
        {
            Producto producto = ProductoViewModel.ConvertToModel(productoViewModel);
            try
            {
                await _productoService.Update(producto);
                return RedirectToAction("Index", "Producto");
                
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(productoViewModel);
            }
        }

        // GET: ProductoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ProductoViewModel productoViewModel = ProductoViewModel.ConvertToViewModel(await _productoService.GetById(id));
            return View(productoViewModel);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ProductoViewModel productoViewModel)
        {
            try
            {
                bool respuesta = await _productoService.Delete(id);
                return RedirectToAction("Index", "Producto");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(productoViewModel);
            }
        }
    }
}
