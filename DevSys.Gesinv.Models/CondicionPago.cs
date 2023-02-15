using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.DAL
{
    public partial class CondicionPago
    {
        public CondicionPago()
        {
            OrdenCompra = new HashSet<OrdenCompra>();
        }

        public int CondicionPagoId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<OrdenCompra> OrdenCompra { get; set; }
    }
}
