using DevSys.Gesinv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSys.Gesinv.DAL.Contracts;

namespace DevSys.Gesinv.Logic.Contracts
{
    public interface IingresoService : IGenericService<Ingreso>
    {
        Task<Ingreso> Modificar(Ingreso entidad);
    }
}
