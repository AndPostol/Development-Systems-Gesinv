using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  
  public class SalidaViewModel
  {
    public int SalidaId { get; set; }
    public string Codigo { get; set; } = null!;
    public int? MotivoId { get; set; }
    [Display(Name ="Motivo")]
    public string? MotivoNombre { get; set; }
    public DateTime Fecha { get; set; }
    public string? Comentario { get; set; }
    public int? RequisicionId { get; set; }
    [Display(Name = "Requisición")]
    public string? RequisicionCodigo { get; set; }
    public int? BodegaId { get; set; }
    [Display(Name = "Bodega")]
    public string? BodegaNombre { get; set; }

    public BodegaViewModel? Bodega { get; set; }
    public MotivoViewModel? Motivo { get; set; }
    public RequisicionViewModel? Requisicion { get; set; }
    public List<LineaSalidaViewModel> LineaSalida { get; set; }

    public static SalidaViewModel ToSalidaVM(Salida model)
    {
      SalidaViewModel result = new()
      {
        SalidaId = model.SalidaId,
        Codigo = model.Codigo,
        MotivoNombre = model.Motivo.Nombre,
        Fecha = model.Fecha,
        //RequisicionCodigo = model.Requisicion.CodigoRequisicion,
        BodegaNombre = model.Bodega.Direccion,
        Comentario = model.Comentario,
        LineaSalida = LineaSalidaViewModel.ToLineaSalidaVMList(model.LineaSalida.ToList())
      };
      return result;
    }

    public static List<SalidaViewModel> ToSalidaVMList(List<Salida> listModel)
    {
      List<SalidaViewModel> lstModelView = new();
      foreach (Salida model in listModel)
      {
        lstModelView.Add(ToSalidaVM(model));
      }
      return lstModelView;
    }
  }
}
