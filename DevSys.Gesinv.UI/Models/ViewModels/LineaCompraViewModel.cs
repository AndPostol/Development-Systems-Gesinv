using DevSys.Gesinv.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class LineaCompraViewModel
    {
        public int LineaCompraId { get; set; }
        public int OrdenCompraId { get; set; }
        public int ProductoId { get; set; }
        public int DepartamentoId { get; set; }
        public int Cantidad { get; set; }
        public int? Caja { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }

        [ValidateNever]
        public virtual Departamento? Departamento { get; set; }
        [ValidateNever]
        public virtual OrdenCompra? OrdenCompra { get; set; }
        [ValidateNever]
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
        public static LineaCompra ToModel(LineaCompraViewModel viewModel) {
            
            LineaCompra model = new LineaCompra()
            {
                LineaCompraId = viewModel.LineaCompraId,
                OrdenCompraId = viewModel.OrdenCompraId,
                ProductoId = viewModel.ProductoId,
                DepartamentoId = viewModel.DepartamentoId,
                Cantidad = viewModel.Cantidad,
                Caja = viewModel.Caja,
                Precio = viewModel.Precio,
                Descuento = viewModel.Descuento,
                Total = viewModel.Total,
                Departamento = viewModel.Departamento,
                OrdenCompra = viewModel.OrdenCompra,
                Producto = viewModel.Producto
            };
            return model;
        }
        public static List<LineaCompraViewModel> ToViewModelList(IEnumerable<LineaCompra> lstModel) 
        {
            List<LineaCompraViewModel> lstViewModel = new List<LineaCompraViewModel>();
            foreach (var model in lstModel)
            {
                lstViewModel.Add(ToViewModel(model));
            }
            return lstViewModel;
        }
        public static List<LineaCompra> ToModelList(IEnumerable<LineaCompraViewModel> lstViewModel)
        {
            List<LineaCompra> lstModel = new List<LineaCompra>();
            foreach (var model in lstViewModel)
            {
                lstModel.Add(ToModel(model));
            }
            return lstModel;
        }
    }
}
