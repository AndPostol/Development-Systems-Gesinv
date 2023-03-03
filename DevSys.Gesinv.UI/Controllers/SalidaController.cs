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

    public SalidaController(ISalidaService salidaService)
    {
      _salidaService = salidaService;
    }

    // GET: SalidaController
    public async Task<IActionResult> Index()
    {
      IEnumerable<Salida> querySalida = await _salidaService.GetAll();
      List<SalidaViewModel> lstSalida = SalidaViewModel.ToSalidaVMList(querySalida.ToList());
      return View(lstSalida);
    }

    // GET: SalidaController/Details/
    public async Task<ActionResult> Details(int id)
    {
      Salida salida = await _salidaService.GetById(id);
      SalidaViewModel salidaVM = SalidaViewModel.ToSalidaVM(salida);
      return View(salidaVM);
    }

    // GET: SalidaController/Delete/
    public async Task<IActionResult> Delete(int id)
    {
      Salida salida = await _salidaService.GetById(id);
      SalidaViewModel salidaVM = SalidaViewModel.ToSalidaVM(salida);

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
