using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class ProvinciaViewModel
    {
        public int ProvinciaId { get; set; }
        public int? EstadoId { get; set; }
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
        public static List<ProvinciaViewModel> ToListModelView(List<Provincia> lstModel) 
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
