using DevSys.Gesinv.Models;
using DevSys.Gesinv.UI.Models.ViewModels;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
  public class SalidaViewModel
  {
    public int SalidaId { get; set; }
    public string Codigo { get; set; } = null!;
    public int? MotivoId { get; set; }
    public string? MotivoNombre { get; set; }
    public DateTime Fecha { get; set; }
    public string? Comentario { get; set; }
    public int? RequisicionId { get; set; }
    public string? RequisicionCodigo { get; set; }
    public int? BodegaId { get; set; }
    public string? BodegaNombre { get; set; }

    public BodegaViewModel? Bodega { get; set; }
    public MotivoViewModel? Motivo { get; set; }
    public RequisicionViewModel? Requisicion { get; set; }

    public List<LineaSalidaViewModel> LineaSalida { get; set; }

    public static SalidaViewModel ToVM(Salida model)
    {
      SalidaViewModel result = new()
      {
        SalidaId = model.SalidaId,
        Codigo = model.Codigo,
        MotivoId = model.MotivoId,
        Fecha = model.Fecha,
        Comentario = model.Comentario,
        RequisicionId = model.RequisicionId,
        BodegaId = model.BodegaId,
        LineaSalida = LineaSalidaViewModel.ToVMList(model.LineaSalida.ToList())
      };
      return result;
    }

    public static List<SalidaViewModel> ToVMList(List<Salida> listModel)
    {
      List<SalidaViewModel> lstModelView = new();
      foreach (Salida model in listModel)
      {
        lstModelView.Add(ToVM(model));
      }
      return lstModelView;
    }
  }
}