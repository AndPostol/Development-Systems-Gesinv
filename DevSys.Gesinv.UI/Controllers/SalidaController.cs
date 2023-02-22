using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Logic.Services;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevSys.Gesinv.UI.Controllers
{
  public class SalidaController : Controller
  {
    private readonly ISalidaService _salidaService;
    //private readonly IGenericService<Producto> _genericService;
    public SalidaController(ISalidaService salidaService)
    {
      _salidaService = salidaService;
    }


    // GET: SalidaController
    public ActionResult Index()
    {
      //List<Salida> querySalidaSQL = _salidaService.GetAll().Result.ToList();
      //List<SalidaViewModel> lstSalidaViewModel = querySalidaSQL.
      //                                                  Select(s => new SalidaViewModel()
      //                                                  {
      //                                                    SalidaId = s.SalidaId,
      //                                                    Codigo= s.Codigo,
      //                                                    MotivoId = s.MotivoId,
      //                                                    Fecha = s.Fecha,
      //                                                    Comentario = s.Comentario,
      //                                                    RequisicionId = s.RequisicionId,
      //                                                    BodegaId= s.BodegaId
      //                                                  }).ToList();

      //return View(lstSalidaViewModel);

      List<Producto> queryProductosSQL = _genericService.GetAll().Result.ToList();
      List<SalidaViewModel> lstSalidaViewModels = queryProductosSQL
                                                  .Select(p => new SalidaViewModel()
                                                  {
                                                    

                                                  }).ToList();

      return View();
    }

    // GET: SalidaController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: SalidaController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: SalidaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: SalidaController/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: SalidaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: SalidaController/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: SalidaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}
