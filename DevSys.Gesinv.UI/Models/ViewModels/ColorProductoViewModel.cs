using DevSys.Gesinv.Models;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class ColorProductoViewModel
    {
        [Display(Name = "Colores")]
        public int ColorProductoId { get; set; }
        public int ColorId { get; set; }
        public int ProductoId { get; set; } 

        public virtual Producto? Producto { get; set; }
        public virtual Color? Color { get; set; }

        public static ColorProductoViewModel ConvertToViewModel(ColorProducto colorProducto)
        {
            ColorProductoViewModel colorProductoViewModel = new ColorProductoViewModel()
            {
                ColorId = colorProducto.ColorId,
                ColorProductoId = colorProducto.ColorProductoId,
                Color = colorProducto.Color,
                ProductoId = colorProducto.ProductoId,
                Producto = colorProducto.Producto,
            };
            return colorProductoViewModel;
        }

        public static ColorProducto ConvertToModel(ColorProductoViewModel colorProductoViewModel)
        {
            ColorProducto colorProducto = new ColorProducto()
            {
                ColorId = colorProductoViewModel.ColorId,
                ColorProductoId = colorProductoViewModel.ColorProductoId,
                Color = colorProductoViewModel.Color,
                ProductoId = colorProductoViewModel.ProductoId,
                Producto = colorProductoViewModel.Producto,
            };
            return colorProducto;
        }

        public static List<ColorProductoViewModel> ListViewModel(IEnumerable<ColorProducto> lstModel)
        {
            List<ColorProductoViewModel> listViewModel = new List<ColorProductoViewModel>();
            foreach (var model in lstModel)
            {
                listViewModel.Add(ConvertToViewModel(model));
            }
            return listViewModel;
        }
    }
}
