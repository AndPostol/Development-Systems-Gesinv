using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Bodega = new HashSet<Bodega>();
            Proveedor = new HashSet<Proveedor>();
            Provincia = new HashSet<Provincia>();
        }

        public int EstadoId { get; set; }
        public string Estado1 { get; set; } = null!;

        public virtual ICollection<Bodega> Bodega { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
        public virtual ICollection<Provincia> Provincia { get; set; }
    }
}
