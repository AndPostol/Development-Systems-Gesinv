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
    public class ColorProductoService: GenericService<ColorProducto>, IColorProductoService
    {
        private readonly IColorProductoRepository _repository;
        public ColorProductoService(IColorProductoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> EliminarColoresByIdProducto(int idProducto)
        {
            return await _repository.EliminarColoresByIdProducto(idProducto); 
        }
    }
}
