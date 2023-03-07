using DevSys.Gesinv.DAL;
using DevSys.Gesinv.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class IngresoViewModel
    {
        public IngresoViewModel()
        {
            IngresoDetalle = new HashSet<IngresoDetalle>();
        }
        public int IngresoId { get; set; }
        public int CodigoIngreso { get; set; }
        public int? ProveedorId { get; set; }
        public int? MotivoId { get; set; }
        public int? BodegaId { get; set; }
        public int? TipoIngresoId { get; set; }
        public DateTime Fecha { get; set; }
        public double Descuento { get; set; }
        public double Impuestos { get; set; }
        public double Total { get; set; }

        public virtual Bodega? Bodega { get; set; }
        public virtual Motivo? Motivo { get; set; }
        public virtual Proveedor? Proveedor { get; set; }
        public virtual TipoIngreso? TipoIngreso { get; set; }
        public virtual ICollection<IngresoDetalle> IngresoDetalle { get; set; }


        public static List<IngresoViewModel> ToListIngModel(IEnumerable<Ingreso> lstModel)
        {
            
            List<IngresoViewModel> lstModelView = new List<IngresoViewModel>();
            foreach (var model in lstModel) 
            {
                lstModelView.Add(ToINGModelView(model));
            }
            return lstModelView;
        }
        public static Ingreso ToModelViewING(IngresoViewModel modelViewIng)
        {
            Ingreso modelingreso = new Ingreso()
            {
                IngresoId = modelViewIng.IngresoId,
                CodigoIngreso = modelViewIng.CodigoIngreso,
                ProveedorId = modelViewIng.ProveedorId,
                MotivoId = modelViewIng.MotivoId,
                BodegaId = modelViewIng.BodegaId,
                TipoIngresoId = modelViewIng.TipoIngresoId,
                Fecha = modelViewIng.Fecha,
                Descuento = modelViewIng.Descuento,
                Impuestos = modelViewIng.Impuestos,
                Total = modelViewIng.Total
            };
            return modelingreso;
        }
        public static IngresoViewModel ToINGModelView(Ingreso model)
        {
            IngresoViewModel result = new IngresoViewModel()
             {
                    IngresoId = model.IngresoId,
                    CodigoIngreso = model.CodigoIngreso,
                    ProveedorId = model.ProveedorId,
                    MotivoId = model.MotivoId,
                    BodegaId = model.BodegaId,
                    TipoIngresoId = model.TipoIngresoId,
                    Fecha = model.Fecha,
                    Descuento = model.Descuento,
                    Impuestos = model.Impuestos,
                    Total = model.Total
             };
            return result;   
        }

        internal class ToListINGModel : List<IngresoViewModel>
        {
            private List<Ingreso> ingresos;

            public ToListINGModel(List<Ingreso> ingresos)
            {
                this.ingresos = ingresos;
            }
        }
    }
}
