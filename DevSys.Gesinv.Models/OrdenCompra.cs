using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DevSys.Gesinv.Models
{
    public partial class OrdenCompra
    {
        public OrdenCompra()
        {
            LineaCompra = new HashSet<LineaCompra>();
        }

        public int OrdenCompraId { get; set; }
        public int ProveedorId { get; set; }
        public string? Referencia { get; set; }
        public int CondicionPagoId { get; set; }
        public int BodegaId { get; set; }

        public string? Observacion { get; set; }
        public DateTime Fecha { get; set; }
        public double SubTotal { get; set; }
        public double Descuento { get; set; }
        public double Impuestos { get; set; }
        public double Total { get; set; }
        
        [DefaultValue(false)]
        public bool Confirmado { get; set; }

        public virtual CondicionPago? CondicionPago { get; set; }
        public virtual Proveedor? Proveedor { get; set; }
        public virtual Ingreso Ingreso { get; set; }
        public virtual Bodega Bodega { get; set; }

        public virtual ICollection<LineaCompra> LineaCompra { get; set; }
    }
}
