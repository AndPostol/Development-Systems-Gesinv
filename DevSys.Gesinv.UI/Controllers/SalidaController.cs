using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevSys.Gesinv.UI.Controllers
{
  public class SalidaController : Controller
  {
    private readonly IGenericService<Salida> _salidaService;

    public SalidaController(IGenericService<Salida> salidaService)
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
  }
}
