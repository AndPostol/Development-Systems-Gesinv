using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class OrdenCompraViewModel
    {

        public int OrdenCompraId { get; set; }
        public int? ProveedorId { get; set; }
        public string? Referencia { get; set; }
        public int? CondicionPagoId { get; set; }
        public string? Observacion { get; set; }
        public DateTime? Fecha { get; set; }
        public double SubTotal { get; set; }
        public double Descuento { get; set; }
        public double Impuestos { get; set; }
        public double Total { get; set; }
        public List<LineaCompraViewModel> LineaCompra { get; set; }


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
                Referencia= modelView.Referencia,
                CondicionPagoId= modelView.CondicionPagoId,
                Observacion = modelView.Observacion,
                Fecha = modelView.Fecha.Value,
                SubTotal= modelView.SubTotal,
                Descuento= modelView.Descuento,
                Impuestos= modelView.Impuestos,
                Total= modelView.Total
            };
            return model;
        }
        public static OrdenCompraViewModel ToViewModel(OrdenCompra model)
        {
            OrdenCompraViewModel result = new OrdenCompraViewModel() 
            { 
                OrdenCompraId = model.OrdenCompraId,
                ProveedorId= model.Proveedor.ProveedorId,
                Referencia= model.Referencia,
                CondicionPagoId= model.CondicionPago.CondicionPagoId,
                Observacion = model.Observacion,
                Fecha= model.Fecha,
                SubTotal= model.SubTotal,
                Descuento= model.Descuento,
                Impuestos= model.Impuestos,
                Total= model.Total,
                LineaCompra = LineaCompraViewModel.ToViewModelList(model.LineaCompra)
            };
            return result;
        }


    }
}
