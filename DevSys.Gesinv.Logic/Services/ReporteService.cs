using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.Logic.Services
{
    public class ReporteService : IReporteService
    {
        private readonly IReporteRepository _repository;
        public ReporteService(IReporteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ReporteIngreso>> obtenerReporteProveedores()
        {
            List<ReporteIngreso> result = await _repository.obtenerReporteProveedores();
            return result;
        }
    }
}
