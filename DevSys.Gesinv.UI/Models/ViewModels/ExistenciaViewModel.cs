using DevSys.Gesinv.Models;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class ExistenciaViewModel
  {
    [Required]
    public int ExistenciaId { get; set; }

    public int? ProductoId { get; set; }
    public int? BodegaId { get; set; }

    [Range(0, 10000)]
    public int Stock { get; set; }

    public virtual BodegaViewModel? Bodega { get; set; }
    public virtual ProductoViewModel? Producto { get; set; }
  }
}
