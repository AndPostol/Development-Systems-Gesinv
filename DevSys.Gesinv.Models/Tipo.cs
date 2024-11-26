using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Producto = new HashSet<Producto>();
        }

        public int TipoId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
