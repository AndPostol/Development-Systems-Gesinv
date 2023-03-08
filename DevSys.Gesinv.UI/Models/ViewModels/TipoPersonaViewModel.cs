using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class TipoPersonaViewModel
    {
        public int TipoPersonaId { get; set; }
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
