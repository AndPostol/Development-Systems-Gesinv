using DevSys.Gesinv.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class LineaSalidaViewModel
  {
    public int LineaSalidaId { get; set; }
    public int SalidaId { get; set; }
    public int Cantidad { get; set; }
    public double CostoSalida { get; set; }
    [Display(Name = "Código")]
    public int? ProductoId { get; set; }
    public int? ProductoCodigo { get; set; }
    public string ProductoNombre { get; set; }

    public SalidaViewModel Salida { get; set; }
    public ProductoViewModel? Producto { get; set; }

    public static LineaSalidaViewModel ToLineaSalidaVM(LineaSalida model)
    {
      LineaSalidaViewModel result = new()
      {
        //LineaSalidaId = model.LineaSalidaId,
        SalidaId = model.SalidaId,
        ProductoId = model.Producto.ProductoId,
        ProductoNombre = model.Producto.Nombre,
        Cantidad = model.Cantidad,
        CostoSalida = model.CostoSalida,
      };
      return result;
    }

    public static List<LineaSalidaViewModel> ToLineaSalidaVMList(List<LineaSalida> listModel)
    {
      List<LineaSalidaViewModel> lstModelView = new();
      foreach (LineaSalida model in listModel)
      {
        lstModelView.Add(ToLineaSalidaVM(model));
      }
      return lstModelView;
    }
  }
}
