using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class Ingreso
    {
        public Ingreso()
        {
            IngresoDetalle = new HashSet<IngresoDetalle>();
        }

        public int IngresoId { get; set; }
        public int OrdenCompraId { get; set; }

        public int CodigoIngreso { get; set; }
        public int? ProveedorId { get; set; }
        public int? MotivoId { get; set; }
        public int? BodegaId { get; set; }
        public int? TipoIngresoId { get; set; }
        public DateTime Fecha { get; set; }
        public double Descuento { get; set; }
        public double Impuestos { get; set; }
        public double Total { get; set; }

        public virtual Bodega? Bodega { get; set; }
        public virtual OrdenCompra OrdenCompra{ get; set; }
        
        public virtual Motivo? Motivo { get; set; }
        public virtual Proveedor? Proveedor { get; set; }
        public virtual TipoIngreso? TipoIngreso { get; set; }
        public virtual ICollection<IngresoDetalle> IngresoDetalle { get; set; }
        public double SubTotal { get; set; }
    }
}
