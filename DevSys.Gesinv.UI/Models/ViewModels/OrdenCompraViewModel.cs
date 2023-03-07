using DevSys.Gesinv.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class OrdenCompraViewModel
    {
        public int OrdenCompraId { get; set; }
        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; }
        public string? Referencia { get; set; }
        [Display(Name = "Condicion de pago")]
        public int CondicionPagoId { get; set; }
        [Display(Name = "Bodega")]
        public int BodegaId { get; set; }

        public string? Observacion { get; set; }
        public DateTime? Fecha { get; set; }
        public double SubTotal { get; set; }
        public double Descuento { get; set; }
        public double Impuestos { get; set; }
        public double Total { get; set; }
        public List<LineaCompraViewModel> LineaCompra { get; set; }
        // Adds
        [ValidateNever]
        public string? NombreProveedor { get; set; }
        [ValidateNever]
        public string? CondicionPago { get; set; }
        [ValidateNever]
        public string? BodedaNombre { get; set; }


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
                BodegaId = modelView.BodegaId,
                Referencia= modelView.Referencia,
                CondicionPagoId= modelView.CondicionPagoId,
                Observacion = modelView.Observacion,
                Fecha = modelView.Fecha.Value,
                SubTotal= modelView.SubTotal,
                Descuento= modelView.Descuento,
                Impuestos= modelView.Impuestos,
                Total= modelView.Total,
                LineaCompra = LineaCompraViewModel.ToModelList(modelView.LineaCompra)
            };
            return model;
        }
        public static OrdenCompraViewModel ToViewModel(OrdenCompra model)
        {
            OrdenCompraViewModel result = new OrdenCompraViewModel() 
            { 
                OrdenCompraId = model.OrdenCompraId,
                ProveedorId= model.Proveedor.ProveedorId,
                BodegaId= model.BodegaId,
                BodedaNombre = model.Bodega.Direccion,
                Referencia= model.Referencia,
                CondicionPagoId= model.CondicionPago.CondicionPagoId,
                Observacion = model.Observacion,
                Fecha= model.Fecha,
                SubTotal= model.SubTotal,
                Descuento= model.Descuento,
                Impuestos= model.Impuestos,
                Total= model.Total,
                LineaCompra = LineaCompraViewModel.ToViewModelList(model.LineaCompra),
                NombreProveedor = model.Proveedor.RazonSocial,
                CondicionPago = model.CondicionPago.Nombre
            };
            return result;
        }


    }
}
