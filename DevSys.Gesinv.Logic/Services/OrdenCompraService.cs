using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.DAL;
using DevSys.Gesinv.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.DAL.Repositories;

namespace DevSys.Gesinv.Logic.Services
{
    public class OrdenCompraService : GenericService<OrdenCompra>, IOrdenCompraService
    {
        private IOrdenCompraRepository _repository;
        public OrdenCompraService(IOrdenCompraRepository respository) : base(respository)
        {
            _repository = respository;
        }

        public async Task<OrdenCompra> Registrar(OrdenCompra entidad)
        {
            return await _repository.Registrar(entidad);
        }
    }
}
