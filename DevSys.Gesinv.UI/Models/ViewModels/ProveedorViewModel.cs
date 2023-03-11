using DevSys.Gesinv.Models;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class ProveedorViewModel
    {
        public int ProveedorId { get; set; }

        [Display(Name = "Empresa")]
        public int? EmpresaId { get; set; }
        public bool Activo { get; set; } = false;

        [Display(Name ="Razón Social"), Required]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "Indique el nombre del proveedor"), Display(Name = "Nombre")]
        public string Contacto { get; set; } = null!;
        
        [Display(Name ="Tipo")]
        public int? TipoProveedorId { get; set; }

        [Required(ErrorMessage ="Este campo es requerido"), StringLength(2)]
        public string Direccion { get; set; } = null!;

        [Phone, Required(ErrorMessage ="Este campo es requerido")]
        public string Telefono { get; set; } = null!;

        [EmailAddress, Required(ErrorMessage = "Este campo es requerido")]
        public string Correo { get; set; } = null!;

        public DateTime? Plazo { get; set; }

        [Display(Name = "RIF"), Required(ErrorMessage = "Este campo es requerido")]
        public string Ruc { get; set; } = null!;

        [Display(Name ="Provincia")]
        public int? ProvinciaId { get; set; }

        [Display(Name ="Estado")]
        public int? EstadoId { get; set; }

        [Display(Name = "Tipo")]
        public int? TipoPersonaId { get; set; }

        [Url]
        public string? PaginaWeb { get; set; }

        public static ProveedorViewModel ToViewModel(Proveedor model)
        {
            ProveedorViewModel modelView = new ProveedorViewModel()
            {
                ProveedorId = model.ProveedorId,
                EmpresaId = model.EmpresaId,
                Activo = model.Activo,
                RazonSocial = model.RazonSocial,
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
        public static Proveedor ToModel(ProveedorViewModel modelView)
        {
            Proveedor model = new Proveedor()
            {
                ProveedorId = modelView.ProveedorId,
                EmpresaId = modelView.EmpresaId,
                Activo = modelView.Activo,
                RazonSocial = modelView.RazonSocial,
                Contacto = modelView.Contacto,
                TipoProveedorId = modelView.TipoProveedorId,
                Direccion = modelView.Direccion,
                Telefono = modelView.Telefono,
                Correo = modelView.Correo,
                Plazo = modelView.Plazo,
                Ruc = modelView.Ruc,
                ProvinciaId = modelView.ProvinciaId,
                EstadoId = modelView.EstadoId,
                TipoPersonaId = modelView.TipoPersonaId,
                PaginaWeb = modelView.PaginaWeb
            };
            return model;
        }

    }
}
