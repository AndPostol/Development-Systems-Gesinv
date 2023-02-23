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

        
        public bool Activo { get; set; }
        public bool Iva { get; set; }
        public bool Perecible { get; set; }
        public string? Comentario { get; set; }
        public DateOnly FechaCaducidad { get; set; } 
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

        public static ProductoViewModel ConvertToViewModel(Producto producto)
        {
            ProductoViewModel productoViewModel = new ProductoViewModel()
            {
                ProductoID = producto.ProductoId,
                Nombre = producto.Nombre,
                Codigo = producto.Codigo,
                Linea = producto.Linea,
                Tipo = producto.Tipo,
                Unidad = producto.Unidad,
                Caja = producto.Caja,
                Grupo = producto.Grupo,
                Activo = producto.Activo,
                Iva = producto.Iva,
                Perecible = producto.Perecible,
                Comentario = producto.Comentario,
                FechaCaducidad = producto.FechaCaducidad,
                Precio = (float)producto.Precio
            };
            return productoViewModel;
        }

        public static Producto ConvertToModel(ProductoViewModel productoViewModel)
        {
            Producto productoVM = new Producto()
            {
                ProductoId = productoViewModel.ProductoID,
                Nombre = productoViewModel.Nombre,
                Codigo = productoViewModel.Codigo,
                Linea = productoViewModel.Linea,
                Tipo = productoViewModel.Tipo,
                Unidad = productoViewModel.Unidad,
                Caja = productoViewModel.Caja,
                Grupo = productoViewModel.Grupo,
                Activo = productoViewModel.Activo,
                Iva = productoViewModel.Iva,
                Perecible = productoViewModel.Perecible,
                Comentario = productoViewModel.Comentario,
                FechaCaducidad = productoViewModel.FechaCaducidad,
                Precio = (float)productoViewModel.Precio
            };
            return productoVM;
        }

        public static List<ProductoViewModel> ListViewModel(IEnumerable<Producto> lstModel)
        {
            List<ProductoViewModel> listViewModel = new List<ProductoViewModel>();
            foreach (var model in lstModel)
            {
                listViewModel.Add(ConvertToViewModel(model));
            }
            return listViewModel;
        }

    }
}
