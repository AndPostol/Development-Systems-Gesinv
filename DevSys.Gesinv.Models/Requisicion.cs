using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.DAL
{
    public partial class Requisicion
    {
        public Requisicion()
        {
            Salida = new HashSet<Salida>();
        }

        public int RequisicionId { get; set; }
        public string CodigoRequisicion { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public int? OrdenCompraId { get; set; }
        public string? Comentario { get; set; }

        public virtual Departamento? OrdenCompra { get; set; }
        public virtual ICollection<Salida> Salida { get; set; }
    }
}
