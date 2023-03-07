using DevSys.Gesinv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.DAL.Contracts
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        Task<Producto> GetProductoColors(int id);
    }
}
