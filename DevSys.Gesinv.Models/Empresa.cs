using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.DAL
{
    public partial class Empresa
    {
        public Empresa()
        {
            Bodega = new HashSet<Bodega>();
            Proveedor = new HashSet<Proveedor>();
            Usuario = new HashSet<Usuario>();
        }

        public int EmpresaId { get; set; }
        public string Correo { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Bodega> Bodega { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
