using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class ProveedorViewModel
    {
        public int ProveedorId { get; set; }
        public int? EmpresaId { get; set; }
        public string RazonSocial { get; set; } = null!;
        public int Codigo { get; set; }
        public string Contacto { get; set; } = null!;
        public int? TipoProveedorId { get; set; }
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public DateTime? Plazo { get; set; }
        public string Ruc { get; set; } = null!;
        public int? ProvinciaId { get; set; }
        public int? EstadoId { get; set; }
        public int? TipoPersonaId { get; set; }
        public string? PaginaWeb { get; set; }

        public static ProveedorViewModel ToViewModel(Proveedor model)
        {
            ProveedorViewModel modelView = new ProveedorViewModel()
            {
                ProveedorId = model.ProveedorId,
                EmpresaId = model.EmpresaId,
                RazonSocial = model.RazonSocial,
                //Codigo= model.Codigo,
                Contacto = model.Contacto,
                TipoProveedorId = model.TipoProveedorId,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                Correo = model.Correo,
                Plazo = model.Plazo,
                Ruc = model.Ruc,
                ProvinciaId = model.ProvinciaId,
                EstadoId = model.EstadoId,
                TipoPersonaId = model.TipoPersonaId,
                PaginaWeb = model.PaginaWeb
            };
            return modelView;
        }
        public static List<ProveedorViewModel> ToViewModelList(IEnumerable<Proveedor> lstModel)
        {
            List<ProveedorViewModel> lstViewModel = new List<ProveedorViewModel>();
            foreach (var item in lstModel)
            {
                lstViewModel.Add(ToViewModel(item));
            }
            return lstViewModel;
        }

    }
}
