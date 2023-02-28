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
    public class ColorService: GenericService<Color>, IColorService
    {
        private readonly IGenericRepository<Color> _repository;
        public ColorService(IGenericRepository<Color> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
