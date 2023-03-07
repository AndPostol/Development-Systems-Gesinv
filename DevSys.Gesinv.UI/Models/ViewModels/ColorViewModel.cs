using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class ColorViewModel
    {
        //public ColorViewModel()
        //{
        //    ColorProducto = new HashSet<ColorProducto>();
        //}

        public int ColorId { get; set; }
        public string Nombre { get; set; } = null!;
        public bool IsSelected { get; set; } = false;

       //public virtual ICollection<ColorProducto> ColorProducto { get; set; }

        public static ColorViewModel ConvertToViewModel(Color color)
        {
            ColorViewModel colorViewModel = new ColorViewModel()
            {
                ColorId = color.ColorId,
                Nombre = color.Nombre,
                //ColorProducto = color.ColorProducto
            };
            return colorViewModel;
        }

        public static Color ConvertToModel(ColorViewModel colorViewModel)
        {
            Color color = new Color()
            {
                ColorId = colorViewModel.ColorId,
                Nombre = colorViewModel.Nombre,
                //ColorProducto = colorViewModel.ColorProducto
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

        public static List<ColorViewModel> PruebaLista(List<Color> lstModel)
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
