using DevSys.Gesinv.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSys.Gesinv.Models;
namespace DevSys.Gesinv.Logic.Contracts
{
    public interface IOrdenCompraService : IGenericService<OrdenCompra>
    {
        Task<OrdenCompra> Registrar(OrdenCompra entidad);
    }
}
