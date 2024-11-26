using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Logic.Services;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Policy;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
      IEnumerable<Salida> _salida = await _salidaService.GetAll();
      List<SalidaViewModel> lstSalidaVM = SalidaViewModel.ToSalidaVMList(_salida.ToList());

      ViewBag.Pedido = await PedidosAPI();

      return View(lstSalidaVM);
    }

    // GET: SalidaController/Details/
    public async Task<ActionResult> Details(int id)
    {
      Salida _salida = await _salidaService.GetById(id);
      SalidaViewModel salidaVM = SalidaViewModel.ToSalidaVM(_salida);

      return View(salidaVM);
    }

    // GET: SalidaController/Create/
    public async Task<IActionResult> Create(int id) //id = PedidoId
    {
      List<PedidoViewModel> pedido = new();
      SalidaViewModel salidaGet = new();
      salidaGet.LineaSalida = new List<LineaSalidaViewModel>();

      pedido = await PedidosAPI(id);

      foreach (var item in pedido)
      {
        Producto producto = await _productoService.GetById(item.ProductoId);
        salidaGet.LineaSalida.Add(new LineaSalidaViewModel() {
          PedidoId = item.Id,
          ProductoId = item.ProductoId,
          ProductoNombre = producto.Nombre,
          Cantidad = item.Cantidad,
          ProductoPrecio = Convert.ToDouble(producto.Precio)
        });
      }

      DDLBodega();
      DDLMotivo();

      salidaGet.PedidoId = id;

      return View(salidaGet);
    }

    // POST: SalidaController/Create/
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SalidaViewModel salidaVM)
    {
      try
      {


        Salida crearSalida = new()
        {
          //SalidaId = Convert.ToInt32(salidaVM.SalidaId),
          MotivoId = Convert.ToInt32(salidaVM.MotivoId),
          Fecha = Convert.ToDateTime(salidaVM.Fecha),
          BodegaId = Convert.ToInt32(salidaVM.BodegaId),
          Comentario = salidaVM.Comentario,
          LineaSalida = LineaSalidaViewModel.ToLineaSalidaModelList(salidaVM.LineaSalida)
        };

        if (ModelState.IsValid)
        {
          await _salidaService.Registrar(crearSalida);
          await CambioEstatusPedido(salidaVM.PedidoId);
          return RedirectToAction("Index", "Salida");
        }
      }
      catch (Exception)
      {

      }
      return View();
    }

    // GET: SalidaController/Edit/
    public async Task<ActionResult> Edit(int id)
    {
      Salida _salida = await _salidaService.GetById(id);
      SalidaViewModel salidaVM = SalidaViewModel.ToSalidaVM(_salida);

      DDLBodega(salidaVM.BodegaId ?? 0);
      DDLMotivo(salidaVM.MotivoId ?? 0);

      return View(salidaVM);
    }

    // POST: SalidaController/Edit/
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, SalidaViewModel salidaVM)
    {
      try
      {
        

        if (ModelState.IsValid)
        {
            Salida editarSalida = new Salida()
            {
              SalidaId = Convert.ToInt32(salidaVM.SalidaId),
              MotivoId = Convert.ToInt32(salidaVM.MotivoId),
              Fecha = Convert.ToDateTime(salidaVM.Fecha),
              BodegaId = Convert.ToInt32(salidaVM.BodegaId),
              Comentario = salidaVM.Comentario,
              LineaSalida = LineaSalidaViewModel.ToLineaSalidaModelList(salidaVM.LineaSalida)
            };
          //editarSalida.SalidaId = id;
          await _salidaService.Update(editarSalida);
          return RedirectToAction("Index", "Salida");
        }

      }
      catch (Exception e)
      {

      }

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
    [ValidateAntiForgeryToken]
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

    // API de Pedidos
    public async Task<List<PedidoViewModel>> PedidosAPI(int? id = null)
    {
      HttpResponseMessage _responseMessage = await client.GetAsync(url);
      List<PedidoViewModel> Pedido = new();
      if (_responseMessage.IsSuccessStatusCode)
      {
        var _responseData = _responseMessage.Content.ReadAsStringAsync().Result;
        Pedido = JsonConvert.DeserializeObject<List<PedidoViewModel>>(_responseData) ?? new List<PedidoViewModel>();
        if (id != null)
        {
          Pedido = Pedido.Where(p => p.Id == id).ToList();
        }
      }
      return Pedido;
    }

    // DropDownList BODEGA 
    public async void DDLBodega(int idSelectBodega = 0)
    {
      List<Bodega> _bodega = _bodegaService.GetAll().Result.ToList();
      List<BodegaViewModel> lstBodegaVM = _bodega
                                          .Select(b => new BodegaViewModel()
                                          {
                                            BodegaId = b.BodegaId,
                                            Direccion = b.Direccion
                                          }).ToList();

      List<SelectListItem> sliBodega = lstBodegaVM.ConvertAll(b =>
      {
          SelectListItem item = new SelectListItem();
          item.Text = b.Direccion.ToString();
          item.Value = b.BodegaId.ToString();

          if (idSelectBodega == b.BodegaId)
          {
             item.Selected = true;
          }
          else
          {
              item.Selected = false;
          }
          return item;
      });
      ViewBag.sliBodega = sliBodega;
    }

    // DropDownList MOTIVO
    public async void DDLMotivo(int idSelectMotivo = 0)
    {
      List<Motivo> _motivo = _motivoService.GetAll().Result.ToList();
      List<MotivoViewModel> lstMotivoVM = _motivo
                                          .Select(m => new MotivoViewModel()
                                          {
                                            MotivoId = m.MotivoId,
                                            Nombre = m.Nombre
                                          }).ToList();

      List<SelectListItem> sliMotivo = lstMotivoVM.ConvertAll(m =>
      {
          SelectListItem item = new SelectListItem();
          item.Text = m.Nombre.ToString();
          item.Value = m.MotivoId.ToString();

          if (idSelectMotivo == m.MotivoId)
          {
              item.Selected = true;
          }
          else
          {
              item.Selected = false;
          }
          return item;
          
      });
      ViewBag.sliMotivo = sliMotivo;
    }

    public async Task<ActionResult> CambioEstatusPedido(int pedidoId)
    {
      HttpResponseMessage _responseMessage = await client.PutAsJsonAsync(url + "/" + pedidoId, new {id = pedidoId});
      if (_responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }

      return RedirectToAction("Error");
    }
  }
}
