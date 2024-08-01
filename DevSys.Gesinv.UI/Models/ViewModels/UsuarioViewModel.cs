using DevSys.Gesinv.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class UsuarioViewModel
    {
        [ValidateNever]
        public int UsuarioId { get; set; } = 0;
        [Required(ErrorMessage = "Requerido")]
        public string Correo { get; set; } = null!;
        [Required(ErrorMessage = "Requerido")]

        public string Password { get; set; } = null!;
        public int? EmpresaId { get; set; }
        public static UsuarioViewModel ToViewModel(Usuario model) {
            return new UsuarioViewModel() { 
                UsuarioId= model.UsuarioId,
                Correo= model.Correo,
                Password= model.Password
            };
        }
        public static Usuario ToModel(UsuarioViewModel viewModel)
        {
            return new Usuario()
            {
                UsuarioId = viewModel.UsuarioId,
                Correo = viewModel.Correo,
                Password = viewModel.Password
            };
        }
    }
}
