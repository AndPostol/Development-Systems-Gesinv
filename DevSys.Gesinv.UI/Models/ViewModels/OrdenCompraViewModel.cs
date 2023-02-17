using DevSys.Gesinv.DAL;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class OrdenCompraViewModel
    {
        public OrdenCompraViewModel()
        {
            LineaCompra = new HashSet<LineaCompra>();
        }

        public int OrdenCompraId { get; set; }
        public int? ProveedorId { get; set; }
        public int CodProveedor { get; set; }
        public string? Referencia { get; set; }
        public int? CondicionPagoId { get; set; }
        public string? Observacion { get; set; }
        public DateTime? Fecha { get; set; }
        public double SubTotal { get; set; }
        public double Descuento { get; set; }
        public double Impuestos { get; set; }
        public double Total { get; set; }

        public virtual CondicionPago? CondicionPago { get; set; }
        public virtual Proveedor? Proveedor { get; set; }
        public virtual ICollection<LineaCompra> LineaCompra { get; set; }

        public static List<OrdenCompraViewModel> ToListOCModelView(List<OrdenCompra> lstModel) 
        {
            List<OrdenCompraViewModel> lstModelView = new List<OrdenCompraViewModel>();
            foreach (var model in lstModel)
            {
                lstModelView.Add(ToOCModelView(model));
            }

            return lstModelView;
        }
        public static OrdenCompraViewModel ToOCModelView(OrdenCompra model)
        {
            OrdenCompraViewModel result = new OrdenCompraViewModel() 
            { 
                OrdenCompraId = model.OrdenCompraId,
                ProveedorId= model.ProveedorId,
                CodProveedor= model.CodProveedor,
                Referencia= model.Referencia,
                CondicionPagoId= model.CondicionPagoId,
                Observacion = model.Observacion,
                Fecha= model.Fecha,
                SubTotal= model.SubTotal,
                Descuento= model.Descuento,
                Impuestos= model.Impuestos,
                Total= model.Total
            };
            return result;
        }


    }
}
