using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class Color
    {
        public Color()
        {
            ColorProducto = new HashSet<ColorProducto>();
        }
        
        public int ColorId { get; set; }
        public string Nombre { get; set; } = null!;
        
        public virtual ICollection<ColorProducto> ColorProducto { get; set; }
    }
}
