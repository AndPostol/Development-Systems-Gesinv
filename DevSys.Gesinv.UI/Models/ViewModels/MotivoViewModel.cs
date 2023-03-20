using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class MotivoViewModel
  {
    public MotivoViewModel()
    {
      Ingreso = new HashSet<Ingreso>();
      Salida = new HashSet<SalidaViewModel>();
    }

    public int MotivoId { get; set; }

    [StringLength(70, MinimumLength = 3, ErrorMessage = "{0} debe tener al menos 3 letras")]
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Ingreso> Ingreso { get; set; }
    public virtual ICollection<SalidaViewModel> Salida { get; set; }
  }
}
