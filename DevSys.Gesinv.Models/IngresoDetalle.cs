using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class IngresoDetalle
    {
        public int IngresoDetalleId { get; set; }
        public int? ProductoId { get; set; }
        public int? IngresoId { get; set; }
        public double PrecioBruto { get; set; }
        public DateTime Fecha { get; set; }
        public int Caja { get; set; }
        public int Cantidad { get; set; }

        public virtual Ingreso? Ingreso { get; set; }
        public virtual Producto? Producto { get; set; }
    }
}
