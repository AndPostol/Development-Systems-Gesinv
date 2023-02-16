using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class TipoPersona
    {
        public TipoPersona()
        {
            Proveedor = new HashSet<Proveedor>();
        }

        public int TipoPersonaId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
