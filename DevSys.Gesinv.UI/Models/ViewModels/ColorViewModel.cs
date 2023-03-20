using DevSys.Gesinv.Models;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class ColorViewModel
    {
        [Required]
        public int ColorId { get; set; }

        [StringLength(15, MinimumLength = 3, ErrorMessage = "{0} debe tener al menos 3 letras")]
        public string Nombre { get; set; } = null!;

        [Required]
        public bool IsSelected { get; set; } = false;

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
    }
}
