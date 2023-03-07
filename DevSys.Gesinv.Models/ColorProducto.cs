using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.Models
{
    public class ColorProducto
    {   
        public int ColorProductoId { get; set; }
        public int ColorId { get; set; }
        public int ProductoId { get; set; }
        public virtual Producto? Producto { get; set; }
        public virtual Color? Color { get; set; }
    }
}
