using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.DAL
{
    public partial class Marca
    {
        public int MarcaId { get; set; }
        public int Nombre { get; set; }
        public int? ProductoId { get; set; }

        public virtual Producto? Producto { get; set; }
    }
}
