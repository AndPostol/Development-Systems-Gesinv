using DevSys.Gesinv.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class ProductoViewModel
  {
        [ScaffoldColumn(false), Display(Name = "Codigo")] // oculta el atributo de las vistas
        public int ProductoID { get; set; }

        [Required(ErrorMessage ="Indique el nombre del producto")]
        public string Nombre { get; set; }

        [Display(Name = "Linea")]
        public int? LineaID { get; set; }

        [Display(Name = "Tipo")]
        public int? TipoID { get; set; }

        public string? Bodega { get; set; }

        [Display(Name = "Marca")]
        public int? MarcaId { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        public int Unidad { get; set; }
        public int? Caja { get; set; }

        [Display(Name = "Grupo")]
        public int? GrupoID { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public bool Iva { get; set; }

        public bool Perecible { get; set; }

        [MaxLength(50), ValidateNever] //tuve que colocarlo validate never porque me traia false en el ModelState.IsValid
        public string? Comentario { get; set; }

        [Display(Name = "Caducidad"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public string? FechaCaducidad { get; set; }

        [Column(TypeName = "decimal(5, 2)"), Required]
        public decimal Precio { get; set; }
        
        [Display(Name = "Medida")]
        public int? MedidaId { get; set; }

        public virtual Marca? Marca { get; set; }
        public virtual Medida? Medida { get; set; }
        public virtual Grupo? Grupo { get; set; }
        public virtual Linea? Linea { get; set; }
        public virtual Tipo? Tipo { get; set; }


        [Display(Name = "Color"), ValidateNever]
        public virtual ICollection<ColorProducto> ColorProducto { get; set; }

        [ValidateNever]
        public virtual ICollection<Existencia> Existencia { get; set; }

        [ValidateNever]
        public virtual ICollection<IngresoDetalle> IngresoDetalle { get; set; }

        [ValidateNever]
        public virtual ICollection<LineaCompra> LineaCompra { get; set; }

        [ValidateNever]
        public virtual ICollection<LineaSalida> LineaSalida { get; set; }


        //Solo para las Vistas
        [Display(Name = "Linea"), ValidateNever]
        public string? LineaNombre { get; set; }

        [Display(Name = "Marca"), ValidateNever]
        public string MarcaNombre { get; set; }

        [Display(Name = "Tipo")]
        public string? TipoNombre { get; set; }

        [Display(Name = "Grupo")]
        public string? GrupoNombre { get; set; }

        [Display(Name = "Medida")]
        public string? MedidaNombre { get; set; }

        public List<int> ListaColoresId { get; set; }

        [ValidateNever] //para que no valide, ya que son datos extra
        public List<SelectListItem> LineasSelectList { get; set; }

        [ValidateNever]
        public List<SelectListItem> TiposSelectList { get; set; }

        [ValidateNever]
        public List<SelectListItem> GruposSelectList { get; set; }

        [ValidateNever]
        public List<SelectListItem> MarcasSelectList { get; set; }   
        

        public static ProductoViewModel ConvertToViewModel(Producto producto)
        {
            
            ProductoViewModel productoViewModel = new ProductoViewModel()
            {
                ProductoID = producto.ProductoId,
                Nombre = producto.Nombre,
                //Codigo = producto.Codigo,
                Unidad = producto.Unidad,
                Caja = producto.Caja,
                Activo = producto.Activo,
                Iva = producto.Iva,
                Perecible = producto.Perecible,
                Comentario = producto.Comentario,
                FechaCaducidad = producto.FechaCaducidad.Value.ToString("dd/MM/yyyy"),
                Precio = producto.Precio,
                LineaNombre = producto.Linea.Nombre,
                TipoNombre = producto.Tipo.Nombre,
                GrupoNombre = producto.Grupo.Nombre,
                MarcaNombre = producto.Marca.Nombre,
                MedidaNombre = producto.Medida.Dimension,
                MarcaId = producto.MarcaId,
                MedidaId = producto.MedidaId,
                Existencia = producto.Existencia,
                ColorProducto = producto.ColorProducto,
                ListaColoresId = producto.ColorProducto.Select(c => c.ColorId).ToList(),

            };
            return productoViewModel;
        }

        public static Producto ConvertToModel(ProductoViewModel productoViewModel)
        {
            Producto producto = new Producto()
            {
                ProductoId = productoViewModel.ProductoID,
                Nombre = productoViewModel.Nombre,
                //Codigo = productoViewModel.Codigo,
                LineaId = productoViewModel.LineaID,
                TipoId = productoViewModel.TipoID,
                Unidad = productoViewModel.Unidad,
                Caja = productoViewModel.Caja,
                GrupoId = productoViewModel.GrupoID,
                Activo = productoViewModel.Activo,
                Iva = productoViewModel.Iva,
                MarcaId = productoViewModel.MarcaId,
                MedidaId= productoViewModel.MedidaId,
                Perecible = productoViewModel.Perecible,
                Comentario = productoViewModel.Comentario,
                FechaCaducidad = DateTime.Parse(productoViewModel.FechaCaducidad),
                Precio = (decimal)productoViewModel.Precio,
                ColorProducto = productoViewModel.ColorProducto
            };
            return producto;
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