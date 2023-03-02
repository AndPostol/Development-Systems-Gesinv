using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class CondicionPagoViewModel
    {

        public int CondicionPagoId { get; set; }
        public string Nombre { get; set; } = null!;

        public static CondicionPagoViewModel ToViewModel(CondicionPago model) 
        {
            CondicionPagoViewModel modelView = new CondicionPagoViewModel() 
            {
                CondicionPagoId= model.CondicionPagoId,
                Nombre = model.Nombre
            };
            return modelView;
        }
        public static List<CondicionPagoViewModel> ToViewModelList(IEnumerable<CondicionPago> lstModel) 
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
