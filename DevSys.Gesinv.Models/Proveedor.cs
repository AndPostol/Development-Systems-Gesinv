using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DevSys.Gesinv.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Ingreso = new HashSet<Ingreso>();
            OrdenCompra = new HashSet<OrdenCompra>();
        }

        public int ProveedorId { get; set; }
        public int? EmpresaId { get; set; }
        public string RazonSocial { get; set; } = null!;
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
        [DefaultValue(true)]
        public bool Confirmado { get; set; }
        public bool Activo { get; set; }

        public virtual Empresa? Empresa { get; set; }
        public virtual Estado? Estado { get; set; }
        public virtual Provincia? Provincia { get; set; }
        public virtual TipoPersona? TipoPersona { get; set; }
        public virtual TipoProveedor? TipoProveedor { get; set; }
        public virtual ICollection<Ingreso> Ingreso { get; set; }
        public virtual ICollection<OrdenCompra> OrdenCompra { get; set; }
    }
}
