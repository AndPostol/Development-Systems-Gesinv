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
      //Salida salida = await _salidaService.GetById(id);
      //SalidaViewModel salidaVM = SalidaViewModel.ToSalidaVM(salida);

      //List<LineaSalida> lineaSalidas = _lineaSalidaService.GetAll().Result.Where(s => s.SalidaId == salida.SalidaId).ToList();




      //var dbContext = new GestionClinicaEntities();

      //var actualizarMedico = dbContext.Medico.Where(m => m.Nombre.StartsWith("Pablo"));

      //foreach (var m in actualizarMedico)
      //{
      //  m.Nombre = m.Nombre.Replace("Pablo", "Pablo Jose");
      //}


      ////List<LineaSalida> lineaSalidas = LineaSalidaViewModel.ToLineaSalidaVMList(salidaVM.LineaSalida);

      //List<SalidaViewModel> lstSalidaVM = from s in salidaVM
      //                                    join ls in lineaSalidas on s.SalidaID equals ls.SalidaId
      //                                    group s by new
      //                                    {
      //                                      s.Codigo,
      //                                      s.Motivo.Nombre,
      //                                      s.Fecha,
      //                                      s.Requisicion.CodigoRequisicion,
      //                                      s.Bodega.Direccion,
      //                                      ls.LineaSalidaId,
      //                                      ls.ProductoId,
      //                                      ls.Cantidad,
      //                                      ls.CostoSalida
      //                                    } into grupo
      //                                    select grupo;

      return View();
    }
  }
}
