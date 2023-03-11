using DevSys.Gesinv.DAL;
using DevSys.Gesinv.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public partial class IngresoDetalleViewModel
    {

        
        public int IngresoDetalleId { get; set; } = 0;

        [Required(ErrorMessage = "Por favor ingrese un producto")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido para generar el detalle del ingreso")]
        public int IngresoId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public double PrecioBruto { get; set; }

        [Required(ErrorMessage = "Introduzca la fecha"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Fecha { get; set; }

        [Required (ErrorMessage = "Este campo es requerido"), Range(0, 10000)]
        public int Caja { get; set; }

        [Required(ErrorMessage = "Este campo es requerido"), Range(0, 10000)]
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
