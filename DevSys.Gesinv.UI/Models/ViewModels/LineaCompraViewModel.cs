using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class LineaCompraViewModel
    {
        public int LineaCompraId { get; set; }
        public int? OrdenCompraId { get; set; }
        public int? ProductoId { get; set; }
        public int? DepartamentoId { get; set; }
        public int Cantidad { get; set; }
        public int? Caja { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }

        public virtual Departamento? Departamento { get; set; }
        public virtual OrdenCompra? OrdenCompra { get; set; }
        public virtual Producto? Producto { get; set; }

        public static LineaCompraViewModel ToViewModel(LineaCompra model) 
        {
            LineaCompraViewModel viewModel = new LineaCompraViewModel() 
            {
                LineaCompraId = model.LineaCompraId,
                OrdenCompraId = model.OrdenCompraId,
                ProductoId = model.ProductoId,
                DepartamentoId = model.DepartamentoId,
                Cantidad = model.Cantidad,
                Caja = model.Caja,
                Precio = model.Precio,
                Descuento = model.Descuento,
                Total = model.Total,
                Departamento = model.Departamento,
                OrdenCompra = model.OrdenCompra,
                Producto = model.Producto
            };
            return viewModel;
        }

        public static List<LineaCompraViewModel> ToViewModelList(List<LineaCompra> lstModel) 
        {
            List<LineaCompraViewModel> lstViewModel = new List<LineaCompraViewModel>();
            foreach (var model in lstModel)
            {
                lstViewModel.Add(ToViewModel(model));
            }
            return lstViewModel;
        }
    }
}
