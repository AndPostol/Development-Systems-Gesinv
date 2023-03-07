using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.DAL.DataContext;
using DevSys.Gesinv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.DAL.Repositories
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        private readonly DbInventarioContext _dbContext;

        public ProductoRepository(DbInventarioContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<bool> pruebaUpdate(Producto inProducto)
        {
            bool result = false;

            Producto find = await _dbContext.Producto.FindAsync(inProducto.ProductoId);
            if (find != null) 
            {
                find.ColorProducto.Clear();
                find = inProducto;

                await _dbContext.SaveChangesAsync();
                result= true;
            }
             
            return result;
        }
    }
}
