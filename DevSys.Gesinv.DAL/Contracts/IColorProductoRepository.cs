
using DevSys.Gesinv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.DAL.Contracts
{
    public interface IColorProductoRepository : IGenericRepository<ColorProducto>
    {
        Task<bool> EliminarColoresByIdProducto(int idProducto);
    }
}
