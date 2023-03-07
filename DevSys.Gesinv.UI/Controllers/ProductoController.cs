using Microsoft.AspNetCore.Mvc;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using DevSys.Gesinv.Logic.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;

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

            //Opciones de Colores
            List<ColorViewModel> lstColorProducto = ColorViewModel.ListViewModel(await _colorService.GetAll());
            ViewBag.ColorOptions = lstColorProducto;

            //Opciones de Medidas
            List<MedidaViewModel> lstMedida = MedidaViewModel.ListViewModel(await _medidaService.GetAll());
            ViewBag.MedidaOptions = lstMedida;

            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductoViewModel productoViewModel)
        {
            Producto producto = ProductoViewModel.ConvertToModel(productoViewModel);
            producto.ColorProducto = new List<ColorProducto>();
            if (producto.ColorProducto != null)
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

            List<MarcaViewModel> lstMarca = MarcaViewModel.ListViewModel(await _marcaService.GetAll());
            ViewBag.MarcaOptions = lstMarca;

            List<LineaViewModel> lstLinea = LineaViewModel.ListViewModel(await _lineaService.GetAll());
            ViewBag.LineaOptions = lstLinea;

            List<GrupoViewModel> lstGrupo = GrupoViewModel.ListViewModel(await _grupoService.GetAll());
            ViewBag.GrupoOptions = lstGrupo;

            List<MedidaViewModel> lstMedida = MedidaViewModel.ListViewModel(await _medidaService.GetAll());
            ViewBag.MedidaOptions = lstMedida;

            List<TipoViewModel> lstTipo = TipoViewModel.ListViewModel(await _tipoService.GetAll());
            ViewBag.TipoOptions = lstTipo;

            List<ColorViewModel> lstColor = ColorViewModel.ListViewModel(await _colorService.GetAll());
            foreach(int idColor in productoViewModel.ListaColoresId)
            {
                ColorViewModel colorSelect = lstColor.Find(c => c.ColorId == idColor); //?? new ColorViewModel(); //condicion que reemplaza con el segundo valor
                if (colorSelect != null)
                {
                    colorSelect.IsSelected = true;
                }
            }
            ViewBag.ColorOptions = lstColor;

            return View(productoViewModel);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductoViewModel productoViewModel)
        {
            Producto producto = ProductoViewModel.ConvertToModel(productoViewModel);
            producto.ColorProducto = new List<ColorProducto>();
            if (producto.ColorProducto != null)
            {
                producto.ColorProducto.Clear();
                foreach (var item in productoViewModel.ListaColoresId)
                {
                    producto.ColorProducto.Add(new ColorProducto { ProductoId = productoViewModel.ProductoID,ColorId = item });
                }
            }

            try
            {
                await _colorProductoService.EliminarColoresByIdProducto(producto.ProductoId);
                if (ModelState.IsValid)
                {
                    await _productoService.Update(producto);
                }
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
