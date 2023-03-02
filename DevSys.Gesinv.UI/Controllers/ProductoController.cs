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
        private readonly IGrupoService _grupoService;
        private readonly ITipoService _tipoService;

        public ProductoController(IProductoService productoService, IColorService colorService, ILineaService lineaService, IMarcaService marcaService, IGrupoService grupoService, ITipoService tipoService)
        {
            _productoService = productoService;
            _colorService = colorService;
            _lineaService = lineaService;
            _marcaService = marcaService;
            _grupoService = grupoService;
            _tipoService = tipoService;
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
            //Opciones de Linea
            IEnumerable<Linea> queryLinea = await _lineaService.GetAll();
            List<LineaViewModel> lstLineaViewModel = LineaViewModel.ListViewModel(queryLinea);

            var lineas = new ProductoViewModel();
            lineas.LineasSelectList = new List<SelectListItem>();
            foreach (var linea in lstLineaViewModel)
            {
                lineas.LineasSelectList.Add(new SelectListItem
                {
                    Text = linea.Nombre.ToString(),
                    Value = linea.LineaId.ToString(),
                    Selected = false
                });
            }

            ViewBag.LineaOptions = lineas.LineasSelectList;

            //Opciones de Grupo
            IEnumerable<Grupo> queryGrupo = await _grupoService.GetAll();
            List<GrupoViewModel> lstGrupoViewModel = GrupoViewModel.ListViewModel(queryGrupo);

            var grupos = new ProductoViewModel();
            grupos.GruposSelectList = new List<SelectListItem>();
            foreach (var grupo in lstGrupoViewModel)
            {
                grupos.GruposSelectList.Add(new SelectListItem
                {
                    Text = grupo.Nombre.ToString(),
                    Value = grupo.GrupoId.ToString(),
                    Selected = false
                });
            }

            ViewBag.GrupoOptions = grupos.GruposSelectList;

            //Opciones de Marca
            IEnumerable<Marca> queryMarca = await _marcaService.GetAll();
            List<MarcaViewModel> lstMarcaViewModel = MarcaViewModel.ListViewModel(queryMarca);

            var marcas = new ProductoViewModel();
            marcas.MarcasSelectList = new List<SelectListItem>();
            foreach (var marca in lstMarcaViewModel)
            {
                marcas.MarcasSelectList.Add(new SelectListItem
                {
                    Text = marca.Nombre.ToString(),
                    Value = marca.MarcaId.ToString(),
                    Selected = false
                });
            }

            ViewBag.MarcaOptions = marcas.MarcasSelectList;

            //Opciones de Tipo
            IEnumerable<Tipo> queryTipo = await _tipoService.GetAll();
            List<TipoViewModel> lstTipoViewModel = TipoViewModel.ListViewModel(queryTipo);

            var tipos = new ProductoViewModel();
            tipos.TiposSelectList = new List<SelectListItem>();
            foreach (var tipo in lstTipoViewModel)
            {
                tipos.TiposSelectList.Add(new SelectListItem
                {
                    Text = tipo.Nombre.ToString(),
                    Value = tipo.TipoId.ToString(),
                    Selected = false
                });
            }

            ViewBag.TipoOptions = tipos.TiposSelectList;

            //





            return View();
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
