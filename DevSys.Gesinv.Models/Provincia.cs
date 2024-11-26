using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Bodega = new HashSet<Bodega>();
            Proveedor = new HashSet<Proveedor>();
        }

        public int ProvinciaId { get; set; }
        public int? EstadoId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual Estado? Estado { get; set; }
        public virtual ICollection<Bodega> Bodega { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
