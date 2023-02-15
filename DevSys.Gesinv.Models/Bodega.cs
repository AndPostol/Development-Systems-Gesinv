using System;
using System.Collections.Generic;

namespace DevSys.Gesinv.DAL
{
    public partial class Bodega
    {
        public Bodega()
        {
            Existencia = new HashSet<Existencia>();
            Ingreso = new HashSet<Ingreso>();
            Salida = new HashSet<Salida>();
        }

        public int BodegaId { get; set; }
        public int? EmpresaId { get; set; }
        public string Direccion { get; set; } = null!;
        public int? ProvinciaId { get; set; }
        public int? EstadoId { get; set; }

        public virtual Empresa? Empresa { get; set; }
        public virtual Estado? Estado { get; set; }
        public virtual Provincia? Provincia { get; set; }
        public virtual ICollection<Existencia> Existencia { get; set; }
        public virtual ICollection<Ingreso> Ingreso { get; set; }
        public virtual ICollection<Salida> Salida { get; set; }
    }
}
