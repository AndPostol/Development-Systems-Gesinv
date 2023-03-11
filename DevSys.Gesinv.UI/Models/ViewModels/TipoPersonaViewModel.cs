using DevSys.Gesinv.Models;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class TipoPersonaViewModel
    {
        public int TipoPersonaId { get; set; }

        [StringLength(15, MinimumLength = 2, ErrorMessage = "{0} debe tener al menos 2 letras")]
        public string Nombre { get; set; } = null!;

        public static TipoPersonaViewModel ToModelView(TipoPersona model)
        {
            TipoPersonaViewModel TipoPersonaViewModel = new TipoPersonaViewModel()
            {
                TipoPersonaId = model.TipoPersonaId,
                Nombre = model.Nombre
            };
            return TipoPersonaViewModel;
        }
        public static List<TipoPersonaViewModel> ToListModelView(IEnumerable<TipoPersona> lstModel)
        {
            List<TipoPersonaViewModel> TipoPersonaListViewModel = new List<TipoPersonaViewModel>();
            foreach (TipoPersona item in lstModel)
            {
                TipoPersonaListViewModel.Add(ToModelView(item));
            }
            return TipoPersonaListViewModel;
        }
    }
}
