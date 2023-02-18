using DevSys.Gesinv.Models;

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

        public static List<OrdenCompraViewModel> ToViewModelList(List<OrdenCompra> lstModel) 
        {
            List<OrdenCompraViewModel> lstModelView = new List<OrdenCompraViewModel>();
            foreach (var model in lstModel)
            {
                lstModelView.Add(ToViewModel(model));
            }

            return lstModelView;
        }
        public static OrdenCompra ToModel(OrdenCompraViewModel modelView) 
        {
            OrdenCompra model = new OrdenCompra() 
            {
                OrdenCompraId = modelView.OrdenCompraId,
                ProveedorId= modelView.ProveedorId,
                CodProveedor= modelView.CodProveedor,
                Referencia= modelView.Referencia,
                CondicionPagoId= modelView.CondicionPagoId,
                Observacion = modelView.Observacion,
                Fecha = modelView.Fecha.Value,
                SubTotal= modelView.SubTotal,
                Descuento= modelView.Descuento,
                Impuestos= modelView.Impuestos,
                Total= modelView.Total,
                CondicionPago= modelView.CondicionPago,
                Proveedor=modelView.Proveedor,
                LineaCompra= modelView.LineaCompra
            };
            return model;
        }
        public static OrdenCompraViewModel ToViewModel(OrdenCompra model)
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
                Total= model.Total,
                CondicionPago= model.CondicionPago,
                Proveedor=model.Proveedor,
                LineaCompra= model.LineaCompra
            };
            return result;
        }


    }
}
