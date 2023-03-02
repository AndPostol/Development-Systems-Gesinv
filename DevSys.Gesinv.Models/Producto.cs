using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Color = new HashSet<Color>();
            Existencia = new HashSet<Existencia>();
            IngresoDetalle = new HashSet<IngresoDetalle>();
            LineaCompra = new HashSet<LineaCompra>();
            LineaSalida = new HashSet<LineaSalida>();
        }

        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public int Codigo { get; set; }
        public int? LineaId { get; set; }
        public int? TipoId { get; set; }
        public int? MarcaId { get; set; } 
        public int Unidad { get; set; }
        public int? Caja { get; set; }
        public int? GrupoId { get; set; }
        public bool Activo { get; set; }
        public bool Iva { get; set; }
        public bool Perecible { get; set; }
        public string? Comentario { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public decimal Precio { get; set; }

        public virtual Grupo? Grupo { get; set; }
        public virtual Linea? Linea { get; set; }
        public virtual Tipo? Tipo { get; set; }
        public virtual ICollection<Color> Color { get; set; }
        public virtual ICollection<Existencia> Existencia { get; set; }
        public virtual ICollection<IngresoDetalle> IngresoDetalle { get; set; }
        public virtual ICollection<LineaCompra> LineaCompra { get; set; }
        public virtual ICollection<LineaSalida> LineaSalida { get; set; }
        public virtual Marca? Marca { get; set; }
        public virtual Medida? Medida { get; set; }
    }
}
