using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.DAL
{
    public partial class Provincia
    {
        public Provincia()
        {
            Bodega = new HashSet<Bodega>();
            Proveedor = new HashSet<Proveedor>();
        }

        public int ProvinciaId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Bodega> Bodega { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
