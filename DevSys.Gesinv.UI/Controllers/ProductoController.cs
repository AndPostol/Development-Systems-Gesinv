using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Logic.Services;
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
            IEnumerable<Producto> queryProductoSQL = await _productoService.GetAll();
            List<ProductoViewModel> lstProductoVM = queryProductoSQL.Select(p => new ProductoViewModel()
            {
                ProductoID = p.ProductoId,
                Nombre = p.Nombre,
                Codigo = p.Codigo,
                Linea = p.Linea,
                Tipo = p.Tipo,
                Unidad = p.Unidad,
                Caja = p.Caja,
                Grupo = p.Grupo,
                Activo = p.Activo,
                Iva = p.Iva,
                Perecible = p.Perecible,
                Comentario = p.Comentario,
                FechaCaducidad = (DateTime)p.FechaCaducidad,
                Precio = (float)p.Precio,

            }).ToList();
            return View(lstProductoVM);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Task<Producto> _producto = _productoService.GetById(id);
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
        public async Task<ActionResult> Create(ProductoViewModel p)
        {
            Producto producto = ProductoViewModel.ToPVM(p);
            try
            {
                await _productoService.Create(producto);
                return RedirectToAction("Index", "Producto");
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: ProductoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Task<Producto> p = _productoService.GetById(id);

            ProductoViewModel productoViewModel = new ProductoViewModel()
            {
                ProductoID = p.Result.ProductoId,
                Nombre = p.Result.Nombre,
                Codigo = p.Result.Codigo,
                Linea = p.Result.Linea,
                Tipo = p.Result.Tipo,
                Unidad = p.Result.Unidad,
                Caja = p.Result.Caja,
                Grupo = p.Result.Grupo,
                Activo = (bool)p.Result.Activo,
                Iva = p.Result.Iva,
                Perecible = p.Result.Perecible,
                Comentario = p.Result.Comentario,
                FechaCaducidad = (DateTime)p.Result.FechaCaducidad,
                Precio = (float)p.Result.Precio,
            };
            return View(productoViewModel);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductoViewModel p)
        {
            Producto producto = ProductoViewModel.ToPVM(p);
            try
            {
                await _productoService.Update(producto);
                return RedirectToAction("Index", "Producto");
                
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(p);
            }
        }

        // GET: ProductoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Task<Producto> p = _productoService.GetById(id);
            ProductoViewModel productoViewModel = new ProductoViewModel()
            {
                ProductoID = p.Result.ProductoId,
                Nombre = p.Result.Nombre,
                Codigo = p.Result.Codigo,
                Linea = p.Result.Linea,
                Tipo = p.Result.Tipo,
                Unidad = p.Result.Unidad,
                Caja = p.Result.Caja,
                Grupo = p.Result.Grupo,
                Activo = p.Result.Activo,
                Iva = p.Result.Iva,
                Perecible = p.Result.Perecible,
                Comentario = p.Result.Comentario,
                FechaCaducidad = (DateTime)p.Result.FechaCaducidad,
                Precio = (float)p.Result.Precio,
            };
            return View(productoViewModel);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ProductoViewModel p)
        {
            try
            {
                bool respuesta = await _productoService.Delete(id);
                return RedirectToAction("Index", "Producto");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
