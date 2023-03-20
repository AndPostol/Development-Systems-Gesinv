using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            LineaCompra = new HashSet<LineaCompra>();
        }

        public int DepartamentoId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<LineaCompra> LineaCompra { get; set; }
    }
}
