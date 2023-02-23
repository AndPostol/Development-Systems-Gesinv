using DevSys.Gesinv.Models;
namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class ProductoViewModel
  {
    public ProductoViewModel()
    {
      Color = new HashSet<Color>();
      Existencia = new HashSet<ExistenciaViewModel>();
      IngresoDetalle = new HashSet<IngresoDetalle>();
      LineaCompra = new HashSet<LineaCompra>();
      LineaSalida = new HashSet<LineaSalidaViewModel>();
      Marca = new HashSet<Marca>();
      Medida = new HashSet<Medida>();
    }

    public int ProductoId { get; set; }
    public string Nombre { get; set; } = null!;
    public int Codigo { get; set; }
    public int? LineaId { get; set; }
    public int? TipoId { get; set; }
    public int Unidad { get; set; }
    public int? Caja { get; set; }
    public int? GrupoId { get; set; }
    public bool? Activo { get; set; }
    public bool? Iva { get; set; }
    public bool? Perecible { get; set; }
    public string? Comentario { get; set; }
    public DateTime? FechaCaducidad { get; set; }
    public double Precio { get; set; }

    public Grupo? Grupo { get; set; }
    public Linea? Linea { get; set; }
    public Tipo? Tipo { get; set; }
    public ICollection<Color> Color { get; set; }
    public ICollection<ExistenciaViewModel> Existencia { get; set; }
    public ICollection<IngresoDetalle> IngresoDetalle { get; set; }
    public ICollection<LineaCompra> LineaCompra { get; set; }
    public ICollection<LineaSalidaViewModel> LineaSalida { get; set; }
    public ICollection<Marca> Marca { get; set; }
    public ICollection<Medida> Medida { get; set; }
  }
}