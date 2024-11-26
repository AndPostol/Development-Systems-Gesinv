using DevSys.Gesinv.Models;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class MedidaViewModel
    {
        public MedidaViewModel()
        {
            Producto = new HashSet<Producto>();
        }

        public int MedidaId { get; set; }

        [StringLength(10, MinimumLength = 1, ErrorMessage = "{0} debe tener al menos 1 letra")]
        public string Dimension { get; set; } = null!;

        public virtual ICollection<Producto> Producto { get; set; }

        public static MedidaViewModel ConvertToViewModel(Medida medida)
        {
            MedidaViewModel medidaViewModel = new MedidaViewModel()
            {
                MedidaId = medida.MedidaId,
                Dimension = medida.Dimension,
                Producto = medida.Producto
            };
            return medidaViewModel;
        }

        public static Medida ConvertToModel(MedidaViewModel medidaViewModel)
        {
            Medida medida = new Medida()
            {
                MedidaId = medidaViewModel.MedidaId,
                Dimension = medidaViewModel.Dimension,
                Producto = medidaViewModel.Producto
            };
            return medida;
        }

        public static List<MedidaViewModel> ListViewModel(IEnumerable<Medida> lstModel)
        {
            List<MedidaViewModel> listViewModel = new List<MedidaViewModel>();
            foreach (var model in lstModel)
            {
                listViewModel.Add(ConvertToViewModel(model));
            }
            return listViewModel;
        }
    }
}
