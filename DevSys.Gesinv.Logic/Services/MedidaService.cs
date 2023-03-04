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
    public class MedidaService: GenericService<Medida>, IMedidaService
    {
        private readonly IGenericRepository<Medida> _repository;
        public MedidaService(IGenericRepository<Medida> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
