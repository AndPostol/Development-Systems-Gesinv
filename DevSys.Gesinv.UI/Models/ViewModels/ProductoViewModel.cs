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
        public string? Bodega { get; set; }
        public int Unidad { get; set; }
        public int? Caja { get; set; }
        public int? GrupoID { get; set; }
        public bool? Activo { get; set; }
        public bool? Iva { get; set; }
        public bool? Perecible { get; set; }
        public string? Comentario { get; set; }
        public DateTime? FechaCaducidad { get; set; } //revisar y cambiar por DateOnly
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

        public static ProductoViewModel ToVM(Producto pM)
        {
            ProductoViewModel productoVM = new ProductoViewModel()
            {
                ProductoID = pM.ProductoId,
                Nombre = pM.Nombre,
                Codigo = pM.Codigo,
                Linea = pM.Linea,
                Tipo = pM.Tipo,
                Unidad = pM.Unidad,
                Caja = pM.Caja,
                Grupo = pM.Grupo,
                Activo = pM.Activo,
                Iva = pM.Iva,
                Perecible = pM.Perecible,
                Comentario = pM.Comentario,
                FechaCaducidad = pM.FechaCaducidad,
                Precio = (float)pM.Precio
            };
            return productoVM;
        }

        public static Producto ToM(ProductoViewModel pMV)
        {
            Producto productoVM = new Producto()
            {
                ProductoId = pMV.ProductoID,
                Nombre = pMV.Nombre,
                Codigo = pMV.Codigo,
                Linea = pMV.Linea,
                Tipo = pMV.Tipo,
                Unidad = pMV.Unidad,
                Caja = pMV.Caja,
                Grupo = pMV.Grupo,
                Activo = pMV.Activo,
                Iva = pMV.Iva,
                Perecible = pMV.Perecible,
                Comentario = pMV.Comentario,
                FechaCaducidad = pMV.FechaCaducidad,
                Precio = (float)pMV.Precio
            };
            return productoVM;
        }

        public static List<ProductoViewModel> ListVM(IEnumerable<Producto> lstModel)
        {
            List<ProductoViewModel> listVM = new List<ProductoViewModel>();
            foreach (var model in lstModel)
            {
                listVM.Add(ToVM(model));
            }
            return listVM;
        }

    }
}
