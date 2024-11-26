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
    public class MarcaService: GenericService<Marca>, IMarcaService
    {
        private readonly IGenericRepository<Marca> _repository;
        public MarcaService(IGenericRepository<Marca> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
