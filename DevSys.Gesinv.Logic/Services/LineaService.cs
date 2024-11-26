using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.DAL.Contracts;

namespace DevSys.Gesinv.Logic.Services
{
    public class LineaService: GenericService<Linea>, ILineaService
    {

         private readonly IGenericRepository<Linea> _repository;
         public LineaService(IGenericRepository<Linea> repository) : base(repository)
         {
            _repository = repository;
         }
    }
}
