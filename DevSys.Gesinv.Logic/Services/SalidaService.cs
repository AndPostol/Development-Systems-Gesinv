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
  public class SalidaService : GenericService<Salida>, ISalidaService
  {
        private ISalidaRepository _repository;

        public SalidaService(ISalidaRepository repository) : base(repository)
        {
          _repository = repository;
        }

        public async Task<Salida> Registrar(Salida salida)
        {
            return await _repository.Registrar(salida);
        }
    }
}
