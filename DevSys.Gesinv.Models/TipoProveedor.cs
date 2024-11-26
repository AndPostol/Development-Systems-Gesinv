using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class TipoProveedor
    {
        public TipoProveedor()
        {
            Proveedor = new HashSet<Proveedor>();
        }

        public int TipoProveedorId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
