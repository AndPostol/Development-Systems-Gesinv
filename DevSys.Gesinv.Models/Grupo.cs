using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            Producto = new HashSet<Producto>();
        }

        public int GrupoId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
