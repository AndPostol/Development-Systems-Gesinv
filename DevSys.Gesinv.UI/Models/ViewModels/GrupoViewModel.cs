using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class GrupoViewModel
    {
        public GrupoViewModel()
        {
            Producto = new HashSet<Producto>();
        }

        public int GrupoId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Producto> Producto { get; set; }


        public static GrupoViewModel ConvertToViewModel(Grupo grupo)
        {
            GrupoViewModel grupoViewModel = new GrupoViewModel()
            {
                GrupoId = grupo.GrupoId,
                Nombre = grupo.Nombre,
            };
            return grupoViewModel;
        }

        public static Grupo ConvertToModel(GrupoViewModel grupoViewModel)
        {
            Grupo grupo = new Grupo()
            {
                GrupoId = grupoViewModel.GrupoId,
                Nombre = grupoViewModel.Nombre,
            };
            return grupo;
        }

        public static List<GrupoViewModel> ListViewModel(IEnumerable<Grupo> lstModel)
        {
            List<GrupoViewModel> listViewModel = new List<GrupoViewModel>();
            foreach (var model in lstModel)
            {
                listViewModel.Add(ConvertToViewModel(model));
            }
            return listViewModel;
        }
    }
}
