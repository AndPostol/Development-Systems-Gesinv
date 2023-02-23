using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.Logic.Contracts
{
    public interface IProductoService: IGenericService<Producto>
    {
        Task<Producto> ObtenerPorCodigo(int Codigo);
        Task<Producto> ObtenerPorNombre(string Nombre);
        Task<Producto> ProductosInactivos(bool Activo);
    }
}
