using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Logic.Services;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    private readonly IBodegaService _bodegaService;
    private readonly IMotivoService _motivoService;

    public SalidaController(ISalidaService salidaService, IBodegaService bodegaService, IMotivoService motivoService)
    {
      _salidaService = salidaService;
      _bodegaService = bodegaService;
      _motivoService = motivoService;

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
    public async Task<ActionResult> Details(int id)
    {
      Salida _salida = await _salidaService.GetById(id);
      SalidaViewModel salidaVM = SalidaViewModel.ToSalidaVM(_salida);
      return View(salidaVM);
    }

    // GET: SalidaController/Create/
    public async Task<IActionResult> Create()
    {
      return View();
    }

    // POST: SalidaController/Create/
    [HttpPost]
    public async Task<IActionResult> Create(SalidaViewModel salidaVM)
    {
      //SalidaViewModel nSalida = new()
      //{
      //  SalidaId = Convert.ToInt32(salidaVM["SalidaId"]),
      //  MotivoNombre = Convert.ToString(salidaVM["MotivoNombre"]),
      //  Referencia = collection["Referencia"],
      //  CondicionPagoId = Convert.ToInt32(collection["CondicionPagoId"]),
      //  Observacion = collection["Observacion"],
      //  Fecha = Convert.ToDateTime(collection["Fecha"]),
      //  SubTotal = Convert.ToDouble(collection["SubTotal"]),
      //  Descuento = Convert.ToDouble(collection["Descuento"]),
      //  Impuestos = Convert.ToDouble(collection["Impuestos"]),
      //  Total = Convert.ToDouble(collection["Total"]),
      //  LineaSalida = new List<LineaSalidaViewModel>()
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
  }
}
