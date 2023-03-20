using DevSys.Gesinv.Models;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class CondicionPagoViewModel
    {
        [Required]
        public int CondicionPagoId { get; set; }

        [StringLength(70, MinimumLength = 3)]
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
