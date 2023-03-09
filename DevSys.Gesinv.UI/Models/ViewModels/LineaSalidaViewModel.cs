using DevSys.Gesinv.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class LineaSalidaViewModel
  {
    public int LineaSalidaId { get; set; } = 0;
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
    public int PedidoId { get; set; }

    [ValidateNever]
    public virtual SalidaViewModel Salida { get; set; }
    [ValidateNever]
    public virtual ProductoViewModel? Producto { get; set; }

    public static LineaSalidaViewModel ToLineaSalidaVM(LineaSalida model)
    {
      LineaSalidaViewModel result = new()
      {
        LineaSalidaId = model.LineaSalidaId,
        SalidaId = model.SalidaId,
        ProductoId = model.Producto.ProductoId,
        ProductoNombre = model.Producto.Nombre,
        ProductoPrecio = Convert.ToDouble(model.Producto.Precio),
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

    public static LineaSalida ToLineaSalidaModel(LineaSalidaViewModel viewModel)
    {
      LineaSalida model = new()
      {
        SalidaId = viewModel.SalidaId,
        ProductoId = viewModel.ProductoId,
        Cantidad = viewModel.Cantidad,
        CostoSalida = viewModel.CostoSalida,
      };
      return model;
    }

    public static List<LineaSalida> ToLineaSalidaModelList(List<LineaSalidaViewModel> listViewModel)
    {
      List<LineaSalida> lstModel = new();
      foreach (LineaSalidaViewModel viewModel in listViewModel)
      {
        lstModel.Add(ToLineaSalidaModel(viewModel));
      }
      return lstModel;
    }
  }
}



