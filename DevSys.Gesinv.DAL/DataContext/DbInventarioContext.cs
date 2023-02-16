using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DevSys.Gesinv.DAL;
using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.DAL.DataContext
{
    public partial class DbInventarioContext : DbContext
    {
        public DbInventarioContext()
        {
        }

        public DbInventarioContext(DbContextOptions<DbInventarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bodega> Bodega { get; set; } = null!;
        public virtual DbSet<Color> Color { get; set; } = null!;
        public virtual DbSet<CondicionPago> CondicionPago { get; set; } = null!;
        public virtual DbSet<Departamento> Departamento { get; set; } = null!;
        public virtual DbSet<Empresa> Empresa { get; set; } = null!;
        public virtual DbSet<Estado> Estado { get; set; } = null!;
        public virtual DbSet<Existencia> Existencia { get; set; } = null!;
        public virtual DbSet<Grupo> Grupo { get; set; } = null!;
        public virtual DbSet<Ingreso> Ingreso { get; set; } = null!;
        public virtual DbSet<IngresoDetalle> IngresoDetalle { get; set; } = null!;
        public virtual DbSet<Linea> Linea { get; set; } = null!;
        public virtual DbSet<LineaCompra> LineaCompra { get; set; } = null!;
        public virtual DbSet<LineaSalida> LineaSalida { get; set; } = null!;
        public virtual DbSet<Marca> Marca { get; set; } = null!;
        public virtual DbSet<Medida> Medida { get; set; } = null!;
        public virtual DbSet<Motivo> Motivo { get; set; } = null!;
        public virtual DbSet<OrdenCompra> OrdenCompra { get; set; } = null!;
        public virtual DbSet<Producto> Producto { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedor { get; set; } = null!;
        public virtual DbSet<Provincia> Provincia { get; set; } = null!;
        public virtual DbSet<Requisicion> Requisicion { get; set; } = null!;
        public virtual DbSet<Salida> Salida { get; set; } = null!;
        public virtual DbSet<Tipo> Tipo { get; set; } = null!;
        public virtual DbSet<TipoIngreso> TipoIngreso { get; set; } = null!;
        public virtual DbSet<TipoPersona> TipoPersona { get; set; } = null!;
        public virtual DbSet<TipoProveedor> TipoProveedor { get; set; } = null!;
        public virtual DbSet<Usuario> Usuario { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DbInventario;Trust Server Certificate=True;Integrated Security=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.Property(e => e.BodegaId)
                    .ValueGeneratedNever()
                    .HasColumnName("BodegaID");

                entity.Property(e => e.Direccion).HasMaxLength(255);

                entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");

                entity.Property(e => e.EstadoId).HasColumnName("EstadoID");

                entity.Property(e => e.ProvinciaId).HasColumnName("ProvinciaID");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Bodega)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK__Bodega__EmpresaI__68487DD7");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Bodega)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("FK__Bodega__EstadoID__6A30C649");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Bodega)
                    .HasForeignKey(d => d.ProvinciaId)
                    .HasConstraintName("FK__Bodega__Provinci__693CA210");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.ColorId)
                    .ValueGeneratedNever()
                    .HasColumnName("ColorID");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Color)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__Color__ProductoI__7F2BE32F");
            });

            modelBuilder.Entity<CondicionPago>(entity =>
            {
                entity.Property(e => e.CondicionPagoId)
                    .ValueGeneratedNever()
                    .HasColumnName("CondicionPagoID");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.Property(e => e.DepartamentoId)
                    .ValueGeneratedNever()
                    .HasColumnName("DepartamentoID");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasIndex(e => e.Correo, "UQ__Empresa__60695A19A357ACD3")
                    .IsUnique();

                entity.Property(e => e.EmpresaId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmpresaID");

                entity.Property(e => e.Correo).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.EstadoId)
                    .ValueGeneratedNever()
                    .HasColumnName("EstadoID");

                entity.Property(e => e.Estado1)
                    .HasMaxLength(255)
                    .HasColumnName("Estado");
            });

            modelBuilder.Entity<Existencia>(entity =>
            {
                entity.Property(e => e.ExistenciaId)
                    .ValueGeneratedNever()
                    .HasColumnName("ExistenciaID");

                entity.Property(e => e.BodegaId).HasColumnName("BodegaID");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.Bodega)
                    .WithMany(p => p.Existencia)
                    .HasForeignKey(d => d.BodegaId)
                    .HasConstraintName("FK__Existenci__Bodeg__797309D9");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Existencia)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__Existenci__Produ__787EE5A0");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.Property(e => e.GrupoId)
                    .ValueGeneratedNever()
                    .HasColumnName("GrupoID");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<Ingreso>(entity =>
            {
                entity.HasIndex(e => e.CodigoIngreso, "UQ__Ingreso__31F11754717B18ED")
                    .IsUnique();

                entity.Property(e => e.IngresoId)
                    .ValueGeneratedNever()
                    .HasColumnName("IngresoID");

                entity.Property(e => e.BodegaId).HasColumnName("BodegaID");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.MotivoId).HasColumnName("MotivoID");

                entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

                entity.Property(e => e.TipoIngresoId).HasColumnName("TipoIngresoID");

                entity.HasOne(d => d.Bodega)
                    .WithMany(p => p.Ingreso)
                    .HasForeignKey(d => d.BodegaId)
                    .HasConstraintName("FK__Ingreso__BodegaI__6FE99F9F");

                entity.HasOne(d => d.Motivo)
                    .WithMany(p => p.Ingreso)
                    .HasForeignKey(d => d.MotivoId)
                    .HasConstraintName("FK__Ingreso__MotivoI__6EF57B66");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Ingreso)
                    .HasForeignKey(d => d.ProveedorId)
                    .HasConstraintName("FK__Ingreso__Proveed__6E01572D");

                entity.HasOne(d => d.TipoIngreso)
                    .WithMany(p => p.Ingreso)
                    .HasForeignKey(d => d.TipoIngresoId)
                    .HasConstraintName("FK__Ingreso__TipoIng__70DDC3D8");
            });

            modelBuilder.Entity<IngresoDetalle>(entity =>
            {
                entity.Property(e => e.IngresoDetalleId)
                    .ValueGeneratedNever()
                    .HasColumnName("IngresoDetalleID");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IngresoId).HasColumnName("IngresoID");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.Ingreso)
                    .WithMany(p => p.IngresoDetalle)
                    .HasForeignKey(d => d.IngresoId)
                    .HasConstraintName("FK__IngresoDe__Ingre__72C60C4A");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.IngresoDetalle)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__IngresoDe__Produ__71D1E811");
            });

            modelBuilder.Entity<Linea>(entity =>
            {
                entity.Property(e => e.LineaId)
                    .ValueGeneratedNever()
                    .HasColumnName("LineaID");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<LineaCompra>(entity =>
            {
                entity.Property(e => e.LineaCompraId)
                    .ValueGeneratedNever()
                    .HasColumnName("LineaCompraID");

                entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoID");

                entity.Property(e => e.OrdenCompraId).HasColumnName("OrdenCompraID");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.LineaCompra)
                    .HasForeignKey(d => d.DepartamentoId)
                    .HasConstraintName("FK__LineaComp__Depar__7C4F7684");

                entity.HasOne(d => d.OrdenCompra)
                    .WithMany(p => p.LineaCompra)
                    .HasForeignKey(d => d.OrdenCompraId)
                    .HasConstraintName("FK__LineaComp__Orden__7A672E12");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.LineaCompra)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__LineaComp__Produ__7B5B524B");
            });

            modelBuilder.Entity<LineaSalida>(entity =>
            {
                entity.Property(e => e.LineaSalidaId)
                    .ValueGeneratedNever()
                    .HasColumnName("LineaSalidaID");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.SalidaId).HasColumnName("SalidaID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.LineaSalida)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__LineaSali__Produ__7E37BEF6");

                entity.HasOne(d => d.Salida)
                    .WithMany(p => p.LineaSalida)
                    .HasForeignKey(d => d.SalidaId)
                    .HasConstraintName("FK__LineaSali__Salid__7D439ABD");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.Property(e => e.MarcaId)
                    .ValueGeneratedNever()
                    .HasColumnName("MarcaID");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Marca)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__Marca__ProductoI__00200768");
            });

            modelBuilder.Entity<Medida>(entity =>
            {
                entity.Property(e => e.MedidaId)
                    .ValueGeneratedNever()
                    .HasColumnName("MedidaID");

                entity.Property(e => e.Dimension).HasMaxLength(255);

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Medida)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__Medida__Producto__01142BA1");
            });

            modelBuilder.Entity<Motivo>(entity =>
            {
                entity.Property(e => e.MotivoId)
                    .ValueGeneratedNever()
                    .HasColumnName("MotivoID");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<OrdenCompra>(entity =>
            {
                entity.Property(e => e.OrdenCompraId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrdenCompraID");

                entity.Property(e => e.CondicionPagoId).HasColumnName("CondicionPagoID");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Observacion).HasColumnType("text");

                entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

                entity.Property(e => e.Referencia).HasMaxLength(255);

                entity.HasOne(d => d.CondicionPago)
                    .WithMany(p => p.OrdenCompra)
                    .HasForeignKey(d => d.CondicionPagoId)
                    .HasConstraintName("FK__OrdenComp__Condi__6D0D32F4");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.OrdenCompra)
                    .HasForeignKey(d => d.ProveedorId)
                    .HasConstraintName("FK__OrdenComp__Prove__6C190EBB");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasIndex(e => e.Codigo, "UQ__Producto__06370DACC4CC2AFF")
                    .IsUnique();

                entity.Property(e => e.ProductoId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductoID");

                entity.Property(e => e.Activo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Caja).HasDefaultValueSql("((0))");

                entity.Property(e => e.Comentario).HasColumnType("text");

                entity.Property(e => e.FechaCaducidad).HasColumnType("datetime");

                entity.Property(e => e.GrupoId).HasColumnName("GrupoID");

                entity.Property(e => e.Iva)
                    .HasColumnName("IVA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LineaId).HasColumnName("LineaID");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.Property(e => e.Perecible).HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoId).HasColumnName("TipoID");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.GrupoId)
                    .HasConstraintName("FK__Producto__GrupoI__628FA481");

                entity.HasOne(d => d.Linea)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.LineaId)
                    .HasConstraintName("FK__Producto__LineaI__60A75C0F");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.TipoId)
                    .HasConstraintName("FK__Producto__TipoID__619B8048");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasIndex(e => e.Codigo, "UQ__Proveedo__06370DAC9D934684")
                    .IsUnique();

                entity.Property(e => e.ProveedorId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProveedorID");

                entity.Property(e => e.Contacto).HasMaxLength(255);

                entity.Property(e => e.Correo).HasMaxLength(255);

                entity.Property(e => e.Direccion).HasMaxLength(255);

                entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");

                entity.Property(e => e.EstadoId).HasColumnName("EstadoID");

                entity.Property(e => e.PaginaWeb).HasMaxLength(255);

                entity.Property(e => e.Plazo).HasColumnType("datetime");

                entity.Property(e => e.ProvinciaId).HasColumnName("ProvinciaID");

                entity.Property(e => e.RazonSocial).HasMaxLength(255);

                entity.Property(e => e.Ruc)
                    .HasMaxLength(255)
                    .HasColumnName("RUC");

                entity.Property(e => e.Telefono).HasMaxLength(255);

                entity.Property(e => e.TipoProveedorId).HasColumnName("TipoProveedorID");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Proveedor)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK__Proveedor__Empre__6383C8BA");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Proveedor)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("FK__Proveedor__Estad__66603565");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Proveedor)
                    .HasForeignKey(d => d.ProvinciaId)
                    .HasConstraintName("FK__Proveedor__Provi__656C112C");

                entity.HasOne(d => d.TipoPersonaNavigation)
                    .WithMany(p => p.Proveedor)
                    .HasForeignKey(d => d.TipoPersona)
                    .HasConstraintName("FK__Proveedor__TipoP__6754599E");

                entity.HasOne(d => d.TipoProveedor)
                    .WithMany(p => p.Proveedor)
                    .HasForeignKey(d => d.TipoProveedorId)
                    .HasConstraintName("FK__Proveedor__TipoP__6477ECF3");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.Property(e => e.ProvinciaId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProvinciaID");

                entity.Property(e => e.EstadoId).HasColumnName("EstadoID");

                entity.Property(e => e.Provincia1)
                    .HasMaxLength(255)
                    .HasColumnName("Provincia");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Provincia)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("FK__Provincia__Estad__6B24EA82");
            });

            modelBuilder.Entity<Requisicion>(entity =>
            {
                entity.HasIndex(e => e.CodigoRequisicion, "UQ__Requisic__5DC360DE65177AD9")
                    .IsUnique();

                entity.Property(e => e.RequisicionId)
                    .ValueGeneratedNever()
                    .HasColumnName("RequisicionID");

                entity.Property(e => e.CodigoRequisicion).HasMaxLength(255);

                entity.Property(e => e.Comentario).HasMaxLength(255);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.OrdenCompraId).HasColumnName("OrdenCompraID");

                entity.HasOne(d => d.OrdenCompra)
                    .WithMany(p => p.Requisicion)
                    .HasForeignKey(d => d.OrdenCompraId)
                    .HasConstraintName("FK__Requisici__Orden__76969D2E");
            });

            modelBuilder.Entity<Salida>(entity =>
            {
                entity.HasIndex(e => e.Codigo, "UQ__Salida__06370DAC61F83C43")
                    .IsUnique();

                entity.Property(e => e.SalidaId)
                    .ValueGeneratedNever()
                    .HasColumnName("SalidaID");

                entity.Property(e => e.BodegaId).HasColumnName("BodegaID");

                entity.Property(e => e.Codigo).HasMaxLength(255);

                entity.Property(e => e.Comentario).HasColumnType("text");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.MotivoId).HasColumnName("MotivoID");

                entity.Property(e => e.RequisicionId).HasColumnName("RequisicionID");

                entity.HasOne(d => d.Bodega)
                    .WithMany(p => p.Salida)
                    .HasForeignKey(d => d.BodegaId)
                    .HasConstraintName("FK__Salida__BodegaID__75A278F5");

                entity.HasOne(d => d.Motivo)
                    .WithMany(p => p.Salida)
                    .HasForeignKey(d => d.MotivoId)
                    .HasConstraintName("FK__Salida__MotivoID__73BA3083");

                entity.HasOne(d => d.Requisicion)
                    .WithMany(p => p.Salida)
                    .HasForeignKey(d => d.RequisicionId)
                    .HasConstraintName("FK__Salida__Requisic__74AE54BC");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.Property(e => e.TipoId)
                    .ValueGeneratedNever()
                    .HasColumnName("TipoID");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<TipoIngreso>(entity =>
            {
                entity.Property(e => e.TipoIngresoId)
                    .ValueGeneratedNever()
                    .HasColumnName("TipoIngresoID");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<TipoPersona>(entity =>
            {
                entity.Property(e => e.TipoPersonaId)
                    .ValueGeneratedNever()
                    .HasColumnName("TipoPersonaID");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<TipoProveedor>(entity =>
            {
                entity.Property(e => e.TipoProveedorId)
                    .ValueGeneratedNever()
                    .HasColumnName("TipoProveedorID");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A19C81B76A1")
                    .IsUnique();

                entity.Property(e => e.UsuarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("UsuarioID");

                entity.Property(e => e.Correo).HasMaxLength(255);

                entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK__Usuario__Empresa__778AC167");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
