using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.DAL.DataContext;
using DevSys.Gesinv.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.DAL.Repositories
{
    public class ColorProductoRepository : GenericRepository<ColorProducto>, IColorProductoRepository
    {
        private readonly DbInventarioContext _dbContext;
        public ColorProductoRepository(DbInventarioContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> EliminarColoresByIdProducto(int idProducto)
        {
            List<ColorProducto> _colorListProducto = await _dbContext.ColorProducto.Where(c => c.ProductoId == idProducto).ToListAsync();
            foreach (var colorProducto in _colorListProducto)
            {
                _dbContext.Remove(colorProducto);
            }
            _dbContext.SaveChanges();
            return true;
        }
    }
}
