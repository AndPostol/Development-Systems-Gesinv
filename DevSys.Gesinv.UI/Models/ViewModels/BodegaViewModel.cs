using DevSys.Gesinv.Models;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class BodegaViewModel
  {
    public BodegaViewModel()
    {
      Existencia = new HashSet<ExistenciaViewModel>();
      Ingreso = new HashSet<Ingreso>();
      Salida = new HashSet<SalidaViewModel>();
    }
    [Required]
    public int BodegaId { get; set; }

    [Display(Name = "Empresa")]
    public int? EmpresaId { get; set; }

    [StringLength(70, MinimumLength = 3, ErrorMessage = "{0} debe tener al menos 3 letras")]
    public string Direccion { get; set; } = null!;
    
    public int? ProvinciaId { get; set; }
    public int? EstadoId { get; set; }

    public virtual Empresa? Empresa { get; set; }
    public virtual Estado? Estado { get; set; }
    public virtual Provincia? Provincia { get; set; }

    public virtual ICollection<ExistenciaViewModel> Existencia { get; set; }
    public virtual ICollection<Ingreso> Ingreso { get; set; }
    public virtual ICollection<SalidaViewModel> Salida { get; set; }
  }
}
