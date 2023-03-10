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
    public class EmpresaService : GenericService<Empresa>, IEmpresaService
    {
        public EmpresaService(IGenericRepository<Empresa> respository) : base(respository)
        {
        }
    }
}
