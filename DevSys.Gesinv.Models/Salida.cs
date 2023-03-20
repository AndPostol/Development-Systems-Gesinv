using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class Salida
    {
        public Salida()
        {
            LineaSalida = new HashSet<LineaSalida>();
        }

        public int SalidaId { get; set; }
        public int? MotivoId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Comentario { get; set; }
        public int? BodegaId { get; set; }

        public virtual Bodega? Bodega { get; set; }
        public virtual Motivo? Motivo { get; set; }
        public virtual ICollection<LineaSalida> LineaSalida { get; set; }
    }
}
