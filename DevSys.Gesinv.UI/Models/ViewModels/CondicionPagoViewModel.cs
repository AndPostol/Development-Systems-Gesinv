using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class CondicionPagoViewModel
    {
        public CondicionPagoViewModel()
        {
            OrdenCompra = new HashSet<OrdenCompra>();
        }

        public int CondicionPagoId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<OrdenCompra> OrdenCompra { get; set; }

        public static CondicionPagoViewModel ToViewModel(CondicionPago model) 
        {
            CondicionPagoViewModel modelView = new CondicionPagoViewModel() 
            {
                CondicionPagoId= model.CondicionPagoId,
                Nombre = model.Nombre,
                OrdenCompra= model.OrdenCompra
            };
            return modelView;
        }
        public static List<CondicionPagoViewModel> ToViewModelList(List<CondicionPago> lstModel) 
        {
            List<CondicionPagoViewModel> lstViewModel = new List<CondicionPagoViewModel>();
            foreach (var item in lstModel)
            {
                lstViewModel.Add(ToViewModel(item));
            }            
            return lstViewModel;
        }
    }
}
