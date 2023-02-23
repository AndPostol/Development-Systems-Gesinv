using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class ProductoViewModel
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public int Codigo { get; set; }
        public int? LineaId { get; set; }
        public int? TipoId { get; set; }
        public int Unidad { get; set; }
        public int? Caja { get; set; }
        public int? GrupoId { get; set; }
        public bool? Activo { get; set; }
        public bool? Iva { get; set; }
        public bool? Perecible { get; set; }
        public string? Comentario { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public double Precio { get; set; }

        public static ProductoViewModel ToViewModel(Producto model)
        {
            ProductoViewModel viewModel = new ProductoViewModel()
            {
                ProductoId = model.ProductoId,
                Nombre = model.Nombre,
                Codigo = model.Codigo,
                LineaId = model.LineaId,
                TipoId = model.TipoId,
                Unidad = model.Unidad,
                Caja = model.Caja,
                GrupoId= model.GrupoId,
                Activo= model.Activo,
                Iva= model.Iva,
                Perecible= model.Perecible,
                Comentario= model.Comentario,
                FechaCaducidad = model.FechaCaducidad,
                Precio= model.Precio
            };
            return viewModel;
        }
        public static List<ProductoViewModel> ToViewModelList(IEnumerable<Producto> lstModel)
        {
            List<ProductoViewModel> lstViewModel = new List<ProductoViewModel>();
            foreach (var model in lstModel)
            {
                lstViewModel.Add(ToViewModel(model));
            }
            return lstViewModel;
        }
    }
}
