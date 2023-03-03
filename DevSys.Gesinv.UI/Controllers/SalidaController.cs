using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DevSys.Gesinv.UI.Controllers
{
  public class SalidaController : Controller
  {
    private readonly ISalidaService _salidaService;
    private readonly ILineaSalidaService _lineaSalidaService;
    private readonly IProductoService _productoService;

    public SalidaController(ISalidaService salidaService,
                            ILineaSalidaService lineaSalidaService,
                            IProductoService productoService)
    {
      _salidaService = salidaService;
      _lineaSalidaService = lineaSalidaService;
      _productoService = productoService;
    }

    // GET: SalidaController
    public async Task<IActionResult> Index()
    {
      IEnumerable<Salida> querySalida = await _salidaService.GetAll();
      List<SalidaViewModel> lstSalida = SalidaViewModel.ToSalidaVMList(querySalida.ToList());
      return View(lstSalida);
    }

    // GET: SalidaController/Details/5
    public async Task<ActionResult> Details(int id)
    {

      Salida salida = await _salidaService.GetById(id);
      SalidaViewModel salidaVM = SalidaViewModel.ToSalidaVM(salida);

      //SalidaViewModel salidaViewModel = new()
      //{
      //  SalidaId = salida.SalidaId,
      //  Codigo = salida.Codigo,
      //  MotivoNombre = salida.Motivo.Nombre,
      //  Fecha = salida.Fecha,
      //  BodegaNombre = salida.Bodega.Direccion,
      //  LineaSalida = (List<LineaSalidaViewModel>)salida.LineaSalida
      //};


      //List<LineaSalida> lineaSalida = _lineaSalidaService.GetAll().Result.Where(s => s.SalidaId == salida.SalidaId).ToList();


      //List<SalidaViewModel> lstSalidaVM = from s in salida
      //                                    join ls in lineaSalida on s.SalidaId equals ls.SalidaId
      //                                    group s by new
      //                                    {
      //                                      s.Codigo,
      //                                      ls.Cantidad,
      //                                      ls.CostoSalida
      //                                    } into grupo
      //                                    select grupo;

      return View(salidaVM);
    }


    public async Task<IActionResult> Delete(int id)
    {
      Salida salida = await _salidaService.GetById(id);

      SalidaViewModel salidaViewModel = new()
      {
        SalidaId = salida.SalidaId,
        Codigo = salida.Codigo,
        MotivoNombre = salida.Motivo.Nombre,
        Fecha = salida.Fecha,
        BodegaNombre = salida.Bodega.Direccion,
      };
      return View(salidaViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id, SalidaViewModel salidaViewModel)
    {
      //if (ModelState.IsValid)
      //{
        bool respuesta = await _salidaService.Delete(id);
        return RedirectToAction("Index", "Salida");
      //}
      return View();
    }
  }
}
