using DevSys.Gesinv.Models;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class EstadoViewModel
    {
        [Required]
        public int EstadoId { get; set; }

        [StringLength(70, MinimumLength = 3)]
        public string Nombre { get; set; } = null!;

        public virtual List<ProvinciaViewModel> Provincia { get; set; }

        public static EstadoViewModel ToModelView(Estado model)
        {
            EstadoViewModel estadoViewModel = new EstadoViewModel() 
            {
                EstadoId= model.EstadoId,
                Nombre= model.Nombre,
                Provincia= ProvinciaViewModel.ToListModelView(model.Provincia.ToList())
            };
            return estadoViewModel;
        }
        public static List<EstadoViewModel> ToListModelView(IEnumerable<Estado> lstModel)
        {
            List<EstadoViewModel> EstadoListViewModel = new List<EstadoViewModel>();
            foreach (Estado item in lstModel)
            {
                EstadoListViewModel.Add(ToModelView(item));
            }
            return EstadoListViewModel;
        }
    }
}
