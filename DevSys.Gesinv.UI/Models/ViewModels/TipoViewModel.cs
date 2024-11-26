using DevSys.Gesinv.Models;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class TipoViewModel
    {
        public int TipoId { get; set; }

        [StringLength(15, MinimumLength = 2, ErrorMessage = "{0} debe tener al menos 2 letras")]
        public string Nombre { get; set; } = null!;

        public static TipoViewModel ConvertToViewModel(Tipo tipo)
        {
            TipoViewModel tipoViewModel = new TipoViewModel()
            {
                TipoId = tipo.TipoId,
                Nombre = tipo.Nombre,
            };
            return tipoViewModel;
        }

        public static Tipo ConvertToModel(TipoViewModel tipoViewModel)
        {
            Tipo tipo = new Tipo()
            {
                TipoId = tipoViewModel.TipoId,
                Nombre = tipoViewModel.Nombre,
            };
            return tipo;
        }

        public static List<TipoViewModel> ListViewModel(IEnumerable<Tipo> lstModel)
        {
            List<TipoViewModel> listViewModel = new List<TipoViewModel>();
            foreach (var model in lstModel)
            {
                listViewModel.Add(ConvertToViewModel(model));
            }
            return listViewModel;
        }
    }
}
