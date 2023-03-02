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
        RequisicionCodigo = model.Requisicion.CodigoRequisicion,
        BodegaNombre = model.Bodega.Direccion,
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

//void mAutorLibros()
//{
//  Console.WriteLine("Autores y Publicaciones:");
//  int resultado = 0;
//  var agrupacion = from libro in DataList.ListBooks
//                   join autor in DataList.ListAuthors on libro.AuthorId equals autor.AuthorId
//                   group libro by new
//                   {
//                     libro.AuthorId,
//                     autor.Name
//                   } into grupo
//                   select grupo;

//  foreach (var grupo in agrupacion)
//  {
//    Console.WriteLine("\nAutor: " + grupo.Key.Name + ", (ID: " + grupo.Key.AuthorId + ")");
//    foreach (var objetoAgrupado in grupo)
//    {
//      Console.WriteLine("Titulo: " + objetoAgrupado.Title + ", Fecha de publicacion: " + objetoAgrupado.PublicationDate + ", Ventas: " + objetoAgrupado.Sales + " millones");
//      resultado++;
//    }
//    Console.WriteLine("Cantidad de Publicaciones: " + resultado);
//    resultado = 0;
//  }
//}