using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class TipoProveedorViewModel
    {
        public int TipoProveedorId { get; set; }
        public string Nombre { get; set; } = null!;

        public static TipoProveedorViewModel ToModelView(TipoProveedor model)
        {
            TipoProveedorViewModel TipoProveedorViewModel = new TipoProveedorViewModel()
            {
                TipoProveedorId = model.TipoProveedorId,
                Nombre = model.Nombre
            };
            return TipoProveedorViewModel;
        }
        public static List<TipoProveedorViewModel> ToListModelView(IEnumerable<TipoProveedor> lstModel)
        {
            List<TipoProveedorViewModel> TipoProveedorListViewModel = new List<TipoProveedorViewModel>();
            foreach (TipoProveedor item in lstModel)
            {
                TipoProveedorListViewModel.Add(ToModelView(item));
            }
            return TipoProveedorListViewModel;
        }

    }
}
