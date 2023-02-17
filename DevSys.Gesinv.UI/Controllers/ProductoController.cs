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
                LineaID = p.LineaId,
                TipoID = p.TipoId,
                Unidad = p.Unidad,
                Caja = p.Caja,
                GrupoID = p.GrupoId,
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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
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

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoController/Edit/5
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

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoController/Delete/5
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
