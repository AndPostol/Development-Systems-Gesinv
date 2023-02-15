using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.DAL
{
    public partial class Motivo
    {
        public Motivo()
        {
            Ingreso = new HashSet<Ingreso>();
            Salida = new HashSet<Salida>();
        }

        public int MotivoId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Ingreso> Ingreso { get; set; }
        public virtual ICollection<Salida> Salida { get; set; }
    }
}
