using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.DAL
{
    public partial class Linea
    {
        public Linea()
        {
            Producto = new HashSet<Producto>();
        }

        public int LineaId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
