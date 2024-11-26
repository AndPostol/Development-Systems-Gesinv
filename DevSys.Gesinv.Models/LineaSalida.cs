using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class LineaSalida
    {
        public int LineaSalidaId { get; set; }
        public int SalidaId { get; set; }
        public int Cantidad { get; set; }
        public double CostoSalida { get; set; }
        public int? ProductoId { get; set; }

        public virtual Producto? Producto { get; set; }
        public virtual Salida Salida { get; set; }
    }
}
