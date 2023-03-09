using DevSys.Gesinv.Models;

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

    public int BodegaId { get; set; }
    public int? EmpresaId { get; set; }
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
