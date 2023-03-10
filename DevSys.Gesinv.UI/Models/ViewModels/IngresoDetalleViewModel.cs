using DevSys.Gesinv.DAL;
using DevSys.Gesinv.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public partial class IngresoDetalleViewModel
    {

        public int IngresoDetalleId { get; set; } = 0;
        public int ProductoId { get; set; }
        public int IngresoId { get; set; }
        public double PrecioBruto { get; set; }
        public DateTime Fecha { get; set; }
        public int Caja { get; set; }
        public int Cantidad { get; set; }

        // Datos Extras
        [ValidateNever]
        public string? ProductoNombre { get; set; }


        public static IngresoDetalleViewModel ToViewModel(IngresoDetalle IngresoDetalleModel)
        {
            IngresoDetalleViewModel IngresoDetalleViewModel = new IngresoDetalleViewModel()
            {
                 IngresoDetalleId  = IngresoDetalleModel.IngresoDetalleId,
                 ProductoId = IngresoDetalleModel.ProductoId ?? 0,
                 IngresoId = IngresoDetalleModel.IngresoId ?? 0,
                 PrecioBruto = IngresoDetalleModel.PrecioBruto,
                 Fecha = IngresoDetalleModel.Fecha,
                 Caja = IngresoDetalleModel.Caja,
                 Cantidad = IngresoDetalleModel.Cantidad,
                 ProductoNombre = IngresoDetalleModel.Producto?.Nombre ?? "Ninguno"
            };
            return IngresoDetalleViewModel;
        }
        public static IngresoDetalle ToModel(IngresoDetalleViewModel IngresoDetalleViewModel)
        {
            IngresoDetalle IngresoDetalleModel = new IngresoDetalle()
            {
                IngresoDetalleId = IngresoDetalleViewModel.IngresoDetalleId,
                ProductoId = IngresoDetalleViewModel.ProductoId,
                IngresoId = IngresoDetalleViewModel.IngresoId,
                PrecioBruto = IngresoDetalleViewModel.PrecioBruto,
                Fecha = IngresoDetalleViewModel.Fecha,
                Caja = IngresoDetalleViewModel.Caja,
                Cantidad = IngresoDetalleViewModel.Cantidad,
            };
            return IngresoDetalleModel;
        }
        public static List<IngresoDetalleViewModel> ToListViewModel(ICollection<IngresoDetalle> lstIngresoDetalleModel)
        {
            List<IngresoDetalleViewModel> lstIngresoDetalleViewModel = new List<IngresoDetalleViewModel>();
            foreach (IngresoDetalle ingresoDetalle in lstIngresoDetalleModel)
            {
                lstIngresoDetalleViewModel.Add(ToViewModel(ingresoDetalle));
            }
            return lstIngresoDetalleViewModel;
        }
        public static List<IngresoDetalle> ToListModel(List<IngresoDetalleViewModel> lstIngresoDetalleViewModel)
        {
            List<IngresoDetalle> lstIngresoDetalleModel = new List<IngresoDetalle>();
            foreach (IngresoDetalleViewModel ingresoDetalleViewModel in lstIngresoDetalleViewModel)
            {
                lstIngresoDetalleModel.Add(ToModel(ingresoDetalleViewModel));
            }
            return lstIngresoDetalleModel;
        }


    }
}
