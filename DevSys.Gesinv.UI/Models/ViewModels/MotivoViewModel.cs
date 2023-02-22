using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class MotivoViewModel
  {
    public MotivoViewModel()
    {
      Ingreso = new HashSet<Ingreso>();
      Salida = new HashSet<Salida>();
    }

    public int MotivoId { get; set; }
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Ingreso> Ingreso { get; set; }
    public virtual ICollection<Salida> Salida { get; set; }
  }
}
