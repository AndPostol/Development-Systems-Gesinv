namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class ProductoViewModel
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public int? LineaID { get; set; }
        public int? TipoID { get; set; }
        //public string Ubicacion { get; set; }
        public int Unidad { get; set; }
        public int? Caja { get; set; }
        public int? GrupoID { get; set; }
        public bool? Activo { get; set; }
        public bool? Iva { get; set; }
        public bool? Perecible { get; set; }
        public string? Comentario { get; set; }
        public DateTime FechaCaducidad { get; set; } //revisar y cambiar por DateOnly
        public float Precio { get; set; }




    }
}
