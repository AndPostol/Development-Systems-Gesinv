using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class LineaCompra
    {
        public int LineaCompraId { get; set; }
        public int? OrdenCompraId { get; set; }
        public int? ProductoId { get; set; }
        public int? DepartamentoId { get; set; }
        public int Cantidad { get; set; }
        public int? Caja { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }

        public virtual Departamento? Departamento { get; set; }
        public virtual OrdenCompra? OrdenCompra { get; set; }
        public virtual Producto? Producto { get; set; }
    }
}
