using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class SalidaViewModel
  {
    public SalidaViewModel()
    {
      LineaSalida = new HashSet<LineaSalida>();
    }

    public int SalidaId { get; set; }
    public string Codigo { get; set; } = null!;
    public int? MotivoId { get; set; }
    public DateTime Fecha { get; set; }
    public string? Comentario { get; set; }
    public int? RequisicionId { get; set; }
    public int? BodegaId { get; set; }

    public virtual Bodega? Bodega { get; set; }
    public virtual Motivo? Motivo { get; set; }
    public virtual Requisicion? Requisicion { get; set; }
    public virtual ICollection<LineaSalida> LineaSalida { get; set; }
  }
}