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

        public static IngresoDetalle ToINGModel(IngresoDetalle model)
        {
            IngresoDetalle viewINGModel = new IngresoDetalle()
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
        public static IngresoDetalle ToINGModelList(IngresoDetalle ViewINModel)
        {
            IngresoDetalle INGModel = new IngresoDetalle()
            {
                IngresoDetalleId = ViewINModel.IngresoDetalleId,
                ProductoId = ViewINModel.ProductoId,
                IngresoId = ViewINModel.IngresoId,
                PrecioBruto = ViewINModel.PrecioBruto,
                Fecha = ViewINModel.Fecha,
                Caja = ViewINModel.Caja,
                Cantidad = ViewINModel.Cantidad
            };
            return INGModel;
        }
      

    }
}
