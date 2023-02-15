using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.DAL
{
    public partial class Departamento
    {
        public Departamento()
        {
            LineaCompra = new HashSet<LineaCompra>();
            Requisicion = new HashSet<Requisicion>();
        }

        public int DepartamentoId { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<LineaCompra> LineaCompra { get; set; }
        public virtual ICollection<Requisicion> Requisicion { get; set; }
    }
}
