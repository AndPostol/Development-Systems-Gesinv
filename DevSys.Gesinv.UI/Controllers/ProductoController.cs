 using Microsoft.AspNetCore.Mvc;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace DevSys.Gesinv.UI.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;
        private readonly IMarcaService _marcaService;
        private readonly IColorProductoService _colorProductoService;
        private readonly ILineaService _lineaService;
        private readonly IGrupoService _grupoService;
        private readonly ITipoService _tipoService;
        private readonly IMedidaService _medidaService;
        private readonly IColorService _colorService;

        public ProductoController(IProductoService productoService, IColorProductoService colorProductoService, ILineaService lineaService, IMarcaService marcaService, IGrupoService grupoService, ITipoService tipoService, IMedidaService medidaService, IColorService colorService)
        {
            _productoService = productoService;
            _colorProductoService = colorProductoService;
            _lineaService = lineaService;
            _marcaService = marcaService;
            _grupoService = grupoService;
            _tipoService = tipoService;
            _medidaService = medidaService;
            _colorService = colorService;
        }

        [HttpGet]
        public async Task<ActionResult> getAllProducto()
        {
            IEnumerable<Producto> queryProducto = await _productoService.GetAll();
            List<object> lstProductoData = new List<object>();
            foreach (Producto producto in queryProducto)
            {
                lstProductoData.Add(new {
                    productoId = producto.ProductoId,
                    Nombre = producto.Nombre,
                    codigo = producto.ProductoId.ToString(),
                    precio = producto.Precio,
                });
            }
            return StatusCode(StatusCodes.Status200OK, lstProductoData);
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
            ProductoViewModel productoViewModel = ProductoViewModel.ConvertToViewModel(await _productoService.GetById(id));
            return View(productoViewModel);
        }

        // GET: ProductoController/Create
        public async Task<ActionResult> Create()
        {
            object info = await dataForms(null);
            ViewBag.Info = info;
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductoViewModel productoViewModel)
        {
            Producto producto = ProductoViewModel.ConvertToModel(productoViewModel);
            producto.ColorProducto = new List<ColorProducto>();
            if (producto.ColorProducto != null & productoViewModel.ListaColoresId?.FirstOrDefault() != null)
            {
                foreach (var item in productoViewModel.ListaColoresId)
                {
                    producto.ColorProducto.Add(new ColorProducto { ColorId = item });
                }
            }
            try
            {
                if (ModelState.IsValid)
                {
                    await _productoService.Create(producto); 
                    return RedirectToAction("Index", "Producto");
                }
                else
                {
                    object info = await dataForms(productoViewModel);
                    ViewBag.Info = info;
                    return View(productoViewModel);
                }
            }
            catch
            {
                object info = await dataForms(productoViewModel);
                ViewBag.Info = info;
                return View(productoViewModel);
            }
           
        }

        // GET: ProductoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ProductoViewModel productoViewModel = ProductoViewModel.ConvertToViewModel(await _productoService.GetById(id));

            object info = await dataForms(productoViewModel); 
            ViewBag.Info = info;

            return View(productoViewModel);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductoViewModel productoViewModel)
        {
            Producto producto = ProductoViewModel.ConvertToModel(productoViewModel);
            producto.ColorProducto = new List<ColorProducto>();
            if (producto.ColorProducto != null & productoViewModel.ListaColoresId?.FirstOrDefault() != null)
            {
                producto.ColorProducto.Clear();
                foreach (var item in productoViewModel.ListaColoresId){
                    producto.ColorProducto.Add(new ColorProducto { ProductoId = productoViewModel.ProductoID,ColorId = item });
                }             
            }

            try
            {
                if (ModelState.IsValid)
                {
                    await _productoService.Update(producto);
                    return RedirectToAction("Index" , "Producto");
                }
                else
                {
                    object info = await dataForms(productoViewModel);
                    ViewBag.Info = info;
                    return View(productoViewModel);
                }

            }
            catch (Exception ex)
            {
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

        private async Task<object> dataForms(ProductoViewModel? productoViewModel = null) { // This function is for get data for fill options and inputs for forms
            List<MarcaViewModel> lstMarca = MarcaViewModel.ListViewModel(await _marcaService.GetAll());
            List<LineaViewModel> lstLinea = LineaViewModel.ListViewModel(await _lineaService.GetAll());
            List<GrupoViewModel> lstGrupo = GrupoViewModel.ListViewModel(await _grupoService.GetAll());
            List<MedidaViewModel> lstMedida = MedidaViewModel.ListViewModel(await _medidaService.GetAll());
            List<TipoViewModel> lstTipo = TipoViewModel.ListViewModel(await _tipoService.GetAll());
            List<ColorViewModel> lstColor = ColorViewModel.ListViewModel(await _colorService.GetAll());
            if (productoViewModel != null)
            {
                if (productoViewModel.ListaColoresId != null)
                {
                    foreach (int idColor in productoViewModel.ListaColoresId)
                    {
                        ColorViewModel colorSelect = lstColor.Find(c => c.ColorId == idColor); //?? new ColorViewModel(); //condicion que reemplaza con el segundo valor
                        if (colorSelect != null)
                        {
                            colorSelect.IsSelected = true;
                        }
                    }
                }

            }
            return new { 
                MarcaOptions = lstMarca,
                LineaOptions = lstLinea,
                GrupoOptions = lstGrupo,
                MedidaOptions = lstMedida,
                TipoOptions = lstTipo,
                ColorOptions = lstColor
            };
        }
    }
}
