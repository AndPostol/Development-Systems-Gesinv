using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.DAL
{
    public partial class TipoIngreso
    {
        public TipoIngreso()
        {
            Ingreso = new HashSet<Ingreso>();
        }

        public int TipoIngresoId { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Ingreso> Ingreso { get; set; }
    }
}
