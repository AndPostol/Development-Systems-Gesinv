using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class SalidaViewModel
  {
    public SalidaViewModel()
    {
      LineaSalida = new HashSet<LineaSalidaViewModel>();
    }

    public int SalidaId { get; set; }
    public string Codigo { get; set; } = null!;
    public int? MotivoId { get; set; }
    public DateTime Fecha { get; set; }
    public string? Comentario { get; set; }
    public int? RequisicionId { get; set; }
    public int? BodegaId { get; set; }

    public virtual BodegaViewModel? Bodega { get; set; }
    public virtual MotivoViewModel? Motivo { get; set; }
    public virtual RequisicionViewModel? Requisicion { get; set; }
    public virtual ICollection<LineaSalidaViewModel> LineaSalida { get; set; }
  }
}