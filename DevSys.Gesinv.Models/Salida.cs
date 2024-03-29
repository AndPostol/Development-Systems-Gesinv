﻿using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.DAL
{
    public partial class Salida
    {
        public Salida()
        {
            LineaSalida = new HashSet<LineaSalida>();
        }

        public int SalidaId { get; set; }
        public string Codigo { get; set; } = null!;
        public int? MotivoId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Comentario { get; set; }
        public int? RequisicionId { get; set; }
        public int BodegaId { get; set; }

        public virtual Bodega Bodega { get; set; } = null!;
        public virtual Motivo? Motivo { get; set; }
        public virtual Requisicion? Requisicion { get; set; }
        public virtual ICollection<LineaSalida> LineaSalida { get; set; }
    }
}
