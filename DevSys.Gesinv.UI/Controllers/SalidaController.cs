using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Logic.Services;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace DevSys.Gesinv.UI.Controllers
{
  public class SalidaController : Controller
  {
    //API PEDIDO
    HttpClient client;
    string url = "https://localhost:7219/api/Pedido";
    //API PEDIDO

    private readonly ISalidaService _salidaService;
    private readonly ILineaSalidaService _lineaSalidaService;
    private readonly IBodegaService _bodegaService;
    private readonly IMotivoService _motivoService;
    private readonly IProductoService _productoService;

    public SalidaController(ISalidaService salidaService,
                            ILineaSalidaService lineaSalidaService,
                            IBodegaService bodegaService,
                            IMotivoService motivoService,
                            IProductoService productoService)
    {
      _salidaService = salidaService;
      _lineaSalidaService = lineaSalidaService;
      _bodegaService = bodegaService;
      _motivoService = motivoService;
      _productoService = productoService;

      //API PEDIDO
      client = new HttpClient();
      client.BaseAddress = new Uri(url);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));      
      //API PEDIDO
    }

    // GET: SalidaController/Index/
    public async Task<IActionResult> Index()
    {
      //API PEDIDO
      HttpResponseMessage _responseMessage = await client.GetAsync(url);
      if (_responseMessage.IsSuccessStatusCode)
      {
        var _responseData = _responseMessage.Content.ReadAsStringAsync().Result;

        var Pedido = JsonConvert.DeserializeObject<List<PedidoViewModel>>(_responseData);
        ViewBag.Pedido = Pedido;
      }
      //API PEDIDO

      IEnumerable<Salida> _salida = await _salidaService.GetAll();
      List<SalidaViewModel> lstSalidaVM = SalidaViewModel.ToSalidaVMList(_salida.ToList());
      return View(lstSalidaVM);
    }

    // GET: SalidaController/Details/
    public async Task<ActionResult> Details(int idPedido, int idProducto)
    {
      Salida _salida = await _salidaService.GetById(idPedido);
      SalidaViewModel salidaVM = SalidaViewModel.ToSalidaVM(_salida);
      return View(salidaVM);
    }

    // GET: SalidaController/Create/
    public async Task<IActionResult> Create(int id)
    {
      List<PedidoViewModel> pedido = new();
      SalidaViewModel salidaGet = new();
      salidaGet.LineaSalida = new List<LineaSalidaViewModel>();

      //API PEDIDO
      HttpResponseMessage _responseMessage = await client.GetAsync(url);
      if (_responseMessage.IsSuccessStatusCode)
      {
        var _responseData = _responseMessage.Content.ReadAsStringAsync().Result;
        var query = JsonConvert.DeserializeObject<List<PedidoViewModel>>(_responseData);
        pedido = query.Where(p => p.Id == id).ToList();
        ViewBag.Pedido = pedido;
      }
      //API PEDIDO

      foreach (var item in pedido)
      {
        Producto producto = await _productoService.GetById(item.ProductoId);
        salidaGet.LineaSalida.Add(new LineaSalidaViewModel() {
          ProductoId = item.ProductoId,
          ProductoNombre = producto.Nombre,
          Cantidad = item.Cantidad,
          CostoSalida = producto.Precio
        });
      }


      //BODEGA DropDownList
      List<Bodega> _bodega = _bodegaService.GetAll().Result.ToList();
      List<BodegaViewModel> lstBodegaVM = _bodega
                                          .Select(b => new BodegaViewModel()
                                          {
                                            BodegaId = b.BodegaId,
                                            Direccion = b.Direccion
                                          }).ToList();

      List<SelectListItem> sliBodega = lstBodegaVM.ConvertAll(b =>
      {
        return new SelectListItem()
        {
          Text = b.Direccion.ToString(),
          Value = b.BodegaId.ToString(),
          Selected = false
        };
      });
      ViewBag.sliBodega = sliBodega;

      //MOTIVO DropDownList
      List<Motivo> _motivo = _motivoService.GetAll().Result.ToList();
      List<MotivoViewModel> lstMotivoVM = _motivo
                                          .Select(m => new MotivoViewModel()
                                          {
                                            MotivoId = m.MotivoId,
                                            Nombre = m.Nombre
                                          }).ToList();

      List<SelectListItem> sliMotivo = lstMotivoVM.ConvertAll(m =>
      {
        return new SelectListItem()
        {
          Text = m.Nombre.ToString(),
          Value = m.MotivoId.ToString(),
          Selected = false
        };
      });
      ViewBag.sliMotivo = sliMotivo;

      return View(salidaGet);
    }

    // POST: SalidaController/Create/
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(IFormCollection collection)
    {
        //SalidaViewModel salidaNueva = new()
        //{
        //  SalidaId = Convert.ToInt32(collection["SalidaId"]),
        //  MotivoNombre = collection["MotivoNombre"],
        //  Fecha = Convert.ToDateTime(collection["Fecha"]),
        //  BodegaNombre = collection["BodegaNombre"],
        //  Comentario = collection["Comentario"],
        //};

      return View();
    }

    // GET: SalidaController/Edit/
    public async Task<ActionResult> Edit(int id)
    {
      Salida _salida = await _salidaService.GetById(id);
      SalidaViewModel salidaVM = SalidaViewModel.ToSalidaVM(_salida);

      //BODEGA DropDownList
      List<Bodega> _bodega = _bodegaService.GetAll().Result.ToList();
      List<BodegaViewModel> lstBodegaVM = _bodega
                                          .Select(b => new BodegaViewModel()
                                          {
                                            BodegaId = b.BodegaId,
                                            Direccion = b.Direccion
                                          }).ToList();

      List<SelectListItem> sliBodega = lstBodegaVM.ConvertAll(b =>
      {
        return new SelectListItem()
        {
          Text = b.Direccion.ToString(),
          Value = b.BodegaId.ToString(),
          Selected = false
        };
      });
      ViewBag.sliBodega = sliBodega;

      //MOTIVO DropDownList
      List<Motivo> _motivo = _motivoService.GetAll().Result.ToList();
      List<MotivoViewModel> lstMotivoVM = _motivo
                                          .Select(m => new MotivoViewModel()
                                          {
                                            MotivoId = m.MotivoId,
                                            Nombre = m.Nombre
                                          }).ToList();

      List<SelectListItem> sliMotivo = lstMotivoVM.ConvertAll(m =>
      {
        return new SelectListItem()
        {
          Text = m.Nombre.ToString(),
          Value = m.MotivoId.ToString(),
          Selected = false
        };
      });
      ViewBag.sliMotivo = sliMotivo;

      return View(salidaVM);
    }

    // POST: SalidaController/Edit/
    [HttpPost]
    public async Task<IActionResult> Edit(int id, SalidaViewModel salidaViewModel)
    {

      return View();
    }


    // GET: SalidaController/Delete/
    public async Task<IActionResult> Delete(int id)
    {
      Salida _salida = await _salidaService.GetById(id);
      SalidaViewModel salidaVM = SalidaViewModel.ToSalidaVM(_salida);

      return View(salidaVM);
    }

    // POST: SalidaController/Delete/
    [HttpPost]
    public async Task<IActionResult> Delete(int id, SalidaViewModel salidaViewModel)
    {
      try
      {
        bool respuesta = await _salidaService.Delete(id);
        return RedirectToAction("Index", "Salida");
      }
      catch
      {
        return View();
      }
    }

    public async void allAPI()
    {
      //API PEDIDO
      HttpResponseMessage _responseMessage = await client.GetAsync(url);
      if (_responseMessage.IsSuccessStatusCode)
      {
        var _responseData = _responseMessage.Content.ReadAsStringAsync().Result;

        var Pedido = JsonConvert.DeserializeObject<List<PedidoViewModel>>(_responseData);
        ViewBag.Pedido = Pedido;
      }
      //API PEDIDO
    }
  }
}
