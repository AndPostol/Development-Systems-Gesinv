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
    public class TipoService: GenericService<Tipo>, ITipoService
    {
        private readonly IGenericRepository<Tipo> _repository;
        public TipoService(IGenericRepository<Tipo> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
