using Microsoft.AspNetCore.Mvc;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;


namespace DevSys.Gesinv.UI.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductoViewModel productoViewModel)
        {
            Producto producto = ProductoViewModel.ConvertToModel(productoViewModel);
            try
            {
                await _productoService.Create(producto);
                return RedirectToAction("Index", "Producto");
            }
            catch
            {
                return View();
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
