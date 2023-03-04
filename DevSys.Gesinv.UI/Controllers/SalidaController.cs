using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Logic.Services;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DevSys.Gesinv.UI.Controllers
{
  public class SalidaController : Controller
  {
    private readonly ISalidaService _salidaService;
    private readonly IBodegaService _bodegaService;
    private readonly IMotivoService _motivoService;

    public SalidaController(ISalidaService salidaService, IBodegaService bodegaService, IMotivoService motivoService)
    {
      _salidaService = salidaService;
      _bodegaService = bodegaService;
      _motivoService = motivoService;
    }

    // GET: SalidaController
    public async Task<IActionResult> Index()
    {
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

    // GET: SalidaController/Details/
    public async Task<ActionResult> Edit(int id)
    {
      Salida _salida = await _salidaService.GetById(id);
      SalidaViewModel salidaVM = SalidaViewModel.ToSalidaVM(_salida);

      //BODEGA
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

      //MOTIVO
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


    // GET: SalidaController/Delete/
    public async Task<IActionResult> Delete(int id)
    {
      Salida _salida = await _salidaService.GetById(id);
      SalidaViewModel salidaVM = SalidaViewModel.ToSalidaVM(_salida);

      return View(salidaVM);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id, SalidaViewModel salidaViewModel)
    {
        bool respuesta = await _salidaService.Delete(id);
        return RedirectToAction("Index", "Salida");
    }
  }
}
