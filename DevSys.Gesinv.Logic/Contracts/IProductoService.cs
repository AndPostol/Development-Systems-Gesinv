using DevSys.Gesinv.Models;
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
        //Task<Producto> ObtenerPorCodigo(int Codigo);

        //Estos dos metodos no se van a usar porque ya esta el codigo que hace esto en javascript
        Task<Producto> ObtenerPorNombre(string Nombre);
        Task<Producto> ProductosInactivos(bool Activo);

        //Metodo para poder hacer la consulta muchos a muchos entre Producto y Color
        Task<Producto> GetColors(int id);
  }
}
