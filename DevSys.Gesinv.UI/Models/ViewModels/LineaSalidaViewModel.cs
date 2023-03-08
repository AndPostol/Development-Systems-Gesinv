using DevSys.Gesinv.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class LineaSalidaViewModel
  {
    //[ValidateNever]
    public int LineaSalidaId { get; set; }
    //[ValidateNever]
    public int SalidaId { get; set; }
    public int Cantidad { get; set; }
    public double CostoSalida { get; set; }
    [Display(Name = "Código")]
    public int? ProductoId { get; set; }
    public int? ProductoCodigo { get; set; }
    [Display(Name = "Producto")]
    public string ProductoNombre { get; set; }
    [Display(Name = "Precio")]
    public double ProductoPrecio { get; set; }
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
        ProductoPrecio = model.Producto.Precio,
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
