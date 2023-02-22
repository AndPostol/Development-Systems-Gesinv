using DevSys.Gesinv.Models;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class ProductoViewModel
    {
        public int ProductoID { get; set; }
        
        [Required]
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public int? LineaID { get; set; }
        public int? TipoID { get; set; }
        //public string Ubicacion { get; set; }
        public int Unidad { get; set; }
        public int? Caja { get; set; }
        public int? GrupoID { get; set; }
        public bool? Activo { get; set; }
        public bool? Iva { get; set; }
        public bool? Perecible { get; set; }
        public string? Comentario { get; set; }
        public DateTime FechaCaducidad { get; set; } //revisar y cambiar por DateOnly
        public float Precio { get; set; }

        public virtual Grupo? Grupo { get; set; }
        public virtual Linea? Linea { get; set; }
        public virtual Tipo? Tipo { get; set; }
        public virtual ICollection<Color> Color { get; set; }
        public virtual ICollection<Existencia> Existencia { get; set; }
        public virtual ICollection<IngresoDetalle> IngresoDetalle { get; set; }
        public virtual ICollection<LineaCompra> LineaCompra { get; set; }
        public virtual ICollection<LineaSalida> LineaSalida { get; set; }
        public virtual ICollection<Marca> Marca { get; set; }
        public virtual ICollection<Medida> Medida { get; set; }

        public static Producto ToPVM(ProductoViewModel p)
        {
            Producto productoVM = new Producto()
            {
                ProductoId = p.ProductoID,
                Nombre = p.Nombre,
                Codigo = p.Codigo,
                Linea = p.Linea,
                Tipo = p.Tipo,
                Unidad = p.Unidad,
                Caja = p.Caja,
                Grupo = p.Grupo,
                Activo = p.Activo,
                Iva = p.Iva,
                Perecible = p.Perecible,
                Comentario = p.Comentario,
                FechaCaducidad = (DateTime)p.FechaCaducidad,
                Precio = (float)p.Precio
            };
            return productoVM;
        }

    }
}
