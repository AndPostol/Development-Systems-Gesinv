using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.Models
{
    public partial class Usuario
    {
        public int UsuarioId { get; set; }
        public string Correo { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? EmpresaId { get; set; }

        public virtual Empresa? Empresa { get; set; }
    }
}
