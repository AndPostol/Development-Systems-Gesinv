using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.DAL;
using DevSys.Gesinv.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.Logic.Services
{
    public class OrdenCompraService : GenericService<OrdenCompra>, IOrdenCompraService
    {
        public OrdenCompraService(IGenericRepository<OrdenCompra> respository) : base(respository)
        {
        }
    }
}
