using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class LineaSalidaViewModel
  {
    public int LineaSalidaId { get; set; }
    public int? SalidaId { get; set; }
    public int Cantidad { get; set; }
    public double CostoSalida { get; set; }
    public int? ProductoId { get; set; }

    public virtual ProductoViewModel? Producto { get; set; }
    public virtual SalidaViewModel? Salida { get; set; }
  }
}
