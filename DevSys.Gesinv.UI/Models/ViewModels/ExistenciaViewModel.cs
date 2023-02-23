using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class ExistenciaViewModel
  {
    public int ExistenciaId { get; set; }
    public int? ProductoId { get; set; }
    public int? BodegaId { get; set; }
    public int Stock { get; set; }

    public virtual BodegaViewModel? Bodega { get; set; }
    public virtual ProductoViewModel? Producto { get; set; }
  }
}
