using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class LineaSalidaViewModel
  {
    public int LineaSalidaId { get; set; }
    public int SalidaId { get; set; }
    public int Cantidad { get; set; }
    public double CostoSalida { get; set; }
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
        //SalidaId = model.SalidaId,
        ProductoCodigo = model.Producto.Codigo,
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
