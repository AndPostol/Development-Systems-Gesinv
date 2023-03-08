using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Producto = new HashSet<Producto>();
        }

        public int MarcaId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
