using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class RequisicionViewModel
  {
    public RequisicionViewModel()
    {
      Salida = new HashSet<SalidaViewModel>();
    }

    public int RequisicionId { get; set; }
    public string CodigoRequisicion { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public int? OrdenCompraId { get; set; }
    public string? Comentario { get; set; }

    public virtual Departamento? OrdenCompra { get; set; }
    public virtual ICollection<SalidaViewModel> Salida { get; set; }
  }
}
