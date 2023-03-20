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
    public class IngresoService : GenericService<Ingreso>, IIngresoService
    {
        private IIngresoRepository _repository;

        public IngresoService(IIngresoRepository respository) : base(respository)
        {
            _repository = respository;
        }

        public async Task<Ingreso> Registrar(Ingreso ingreso)
        {
            return await _repository.Registrar(ingreso);
        }
    }
}
