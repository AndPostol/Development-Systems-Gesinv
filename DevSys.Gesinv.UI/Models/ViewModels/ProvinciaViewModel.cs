using DevSys.Gesinv.Models;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class ProvinciaViewModel
    {
        public int ProvinciaId { get; set; }

        [Display(Name = "Estado")]
        public int? EstadoId { get; set; }

        [StringLength(15, MinimumLength = 3, ErrorMessage = "El {0} debe tener al menos 3 letras")]
        public string Nombre { get; set; } = null!;

        public static ProvinciaViewModel ToModelView(Provincia model)
        {
            ProvinciaViewModel provinciaViewModel = new ProvinciaViewModel() 
            {
                ProvinciaId= model.ProvinciaId,
                EstadoId= model.EstadoId,
                Nombre= model.Nombre
            };
            return provinciaViewModel;
        }
        public static List<ProvinciaViewModel> ToListModelView(IEnumerable<Provincia> lstModel) 
        {
            List<ProvinciaViewModel> provinciaListViewModel = new List<ProvinciaViewModel>();
            foreach (Provincia item in lstModel)
            {
                provinciaListViewModel.Add(ToModelView(item));
            }
            return provinciaListViewModel;
        }

    }
}
