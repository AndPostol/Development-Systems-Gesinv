using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class Marca
    {
        public int MarcaId { get; set; }
        public string Nombre { get; set; } = null!;
        public int? ProductoId { get; set; }

        public virtual Producto? Producto { get; set; }
    }
}
