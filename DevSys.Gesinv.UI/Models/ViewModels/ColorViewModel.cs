using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class ColorViewModel
    {
        public int ColorId { get; set; }
        public string Nombre { get; set; } = null!;

        public static ColorViewModel ConvertToViewModel(Color color)
        {
            ColorViewModel colorViewModel = new ColorViewModel()
            {
                ColorId = color.ColorId,
                Nombre = color.Nombre,
            };
            return colorViewModel;
        }

        public static Color ConvertToModel(ColorViewModel colorViewModel)
        {
            Color color = new Color()
            {
                ColorId = colorViewModel.ColorId,
                Nombre = colorViewModel.Nombre,
            };
            return color;
        }

        public static List<ColorViewModel> ListViewModel(IEnumerable<Color> lstModel)
        {
            List<ColorViewModel> listViewModel = new List<ColorViewModel>();
            foreach (var model in lstModel)
            {
                listViewModel.Add(ConvertToViewModel(model));
            }
            return listViewModel;
        }
    }
}
