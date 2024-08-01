using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class PedidoViewModel
  {
    public int Id { get; set; }
    public bool Estatus { get; set; }
    //public int LineaPedidoId { get; set; }
    public int ProductoId { get; set; }
    [Required(ErrorMessage = "Requerido")]
    public int Cantidad { get; set; }
  }
}
