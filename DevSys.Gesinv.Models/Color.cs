using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.DAL
{
    public partial class Color
    {
        public int ColorId { get; set; }
        public string Nombre { get; set; } = null!;
        public int? ProductoId { get; set; }

        public virtual Producto? Producto { get; set; }
    }
}
