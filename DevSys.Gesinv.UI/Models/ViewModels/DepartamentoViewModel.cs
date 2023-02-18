using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class DepartamentoViewModel
    {
        public DepartamentoViewModel()
        {
            LineaCompra = new HashSet<LineaCompra>();
            Requisicion = new HashSet<Requisicion>();
        }

        public int DepartamentoId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<LineaCompra> LineaCompra { get; set; }
        public virtual ICollection<Requisicion> Requisicion { get; set; }

        public static DepartamentoViewModel ToViewModel(Departamento model) 
        {
            DepartamentoViewModel viewModel = new DepartamentoViewModel() 
            {
                DepartamentoId = model.DepartamentoId,
                Nombre = model.Nombre,
                LineaCompra = model.LineaCompra,
                Requisicion = model.Requisicion
            };
            return viewModel;
        }

        public static Departamento ToModel(DepartamentoViewModel modelView) 
        {
            Departamento model = new Departamento() 
            {
                DepartamentoId = modelView.DepartamentoId,
                Nombre = modelView.Nombre,
                LineaCompra = modelView.LineaCompra,
                Requisicion = modelView.Requisicion
            };
            return model;
        }

        public static List<DepartamentoViewModel> ToViewModelList(List<Departamento> lstModel) 
        {
            List<DepartamentoViewModel> lstViewModel = new List<DepartamentoViewModel>();
            foreach (var model in lstModel)
            {
                lstViewModel.Add(ToViewModel(model));
            }
            return lstViewModel;
        }
    }
}
