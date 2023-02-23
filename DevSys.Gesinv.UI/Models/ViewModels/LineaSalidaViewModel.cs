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

    public ProductoViewModel? Producto { get; set; }
    public SalidaViewModel? Salida { get; set; }

    public static LineaSalidaViewModel ToVM(LineaSalida model)
    {
      LineaSalidaViewModel result = new()
      {
        LineaSalidaId = model.LineaSalidaId,
        SalidaId = model.SalidaId,
        Cantidad = model.Cantidad,
        CostoSalida = model.CostoSalida,
        ProductoId = model.ProductoId
      };
      return result;
    }

    public static List<LineaSalidaViewModel> ToVMList(List<LineaSalida> listModel)
    {
      List<LineaSalidaViewModel> lstModelView = new();
      foreach (LineaSalida model in listModel)
      {
        lstModelView.Add(ToVM(model));
      }
      return lstModelView;
    }
  }
}
