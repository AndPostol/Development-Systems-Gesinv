using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class LineaViewModel
    {
        public int LineaId { get; set; }
        public string Nombre { get; set; }


        public static LineaViewModel ConvertToViewModel(Linea linea)
        {
            LineaViewModel lineaViewModel = new LineaViewModel()
            {
                LineaId = linea.LineaId,
                Nombre = linea.Nombre,
            };
            return lineaViewModel;
        }

        public static Linea ConvertToModel(LineaViewModel lineaViewModel)
        {
            Linea linea = new Linea()
            {
                LineaId = lineaViewModel.LineaId,
                Nombre = lineaViewModel.Nombre,
            };
            return linea;
        }

        public static List<LineaViewModel> ListViewModel(IEnumerable<Linea> lstModel)
        {
            List<LineaViewModel> listViewModel = new List<LineaViewModel>();
            foreach (var model in lstModel)
            {
                listViewModel.Add(ConvertToViewModel(model));
            }
            return listViewModel;
        }


    }
}
