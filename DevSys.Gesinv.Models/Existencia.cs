using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class Existencia
    {
        public int ExistenciaId { get; set; }
        public int? ProductoId { get; set; }
        public int? BodegaId { get; set; }
        public int Stock { get; set; }

        public virtual Bodega? Bodega { get; set; }
        public virtual Producto? Producto { get; set; }
    }
}
