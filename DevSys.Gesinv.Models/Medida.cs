using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class Medida
    {
        public Medida()
        {
            Producto = new HashSet<Producto>();
        }

        public int MedidaId { get; set; }
        public string Dimension { get; set; } = null!;

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
