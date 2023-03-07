using DevSys.Gesinv.DAL;
using DevSys.Gesinv.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public partial class IngresoDetalleViewModel
    {
      
        public int IngresoDetalleId { get; set; }
        public int? ProductoId { get; set; }
        public int? IngresoId { get; set; }
        public double PrecioBruto { get; set; }
        public DateTime Fecha { get; set; }
        public int Caja { get; set; }
        public int Cantidad { get; set; }

        public virtual Ingreso? Ingreso { get; set; }
        public virtual Producto? Producto { get; set; }

        public static IngresoDetalleViewModel ToINGModelView(IngresoDetalle model)
        {
            IngresoDetalleViewModel viewINGModel = new IngresoDetalleViewModel()
            {
                 IngresoDetalleId  = model.IngresoDetalleId,
                 ProductoId = model.ProductoId,
                 IngresoId = model.IngresoId,
                 PrecioBruto = model.PrecioBruto,
                 Fecha = model.Fecha,
                 Caja = model.Caja,
                 Cantidad = model.Cantidad
            };
            return viewINGModel;
        }
     
    }
}
