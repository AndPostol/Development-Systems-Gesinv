using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevSys.Gesinv.UI.Controllers
{
    public class BodegaController : Controller
    {
        private readonly IBodegaService _service;

        public BodegaController(IBodegaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            IEnumerable<Bodega> query = await _service.GetAll();
            List<object> result = new List<object>();
            foreach (var item in query)
            {
                result.Add(new { BodegaId = item.BodegaId, Nombre = item.Direccion });
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
