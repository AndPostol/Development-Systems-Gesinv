using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DevSys.Gesinv.DAL;
using DevSys.Gesinv.Models;
using System.ComponentModel;

namespace DevSys.Gesinv.DAL.DataContext
{
    public class DbInventarioContext : DbContext
    {
        public DbInventarioContext()
        {

        }
        public DbInventarioContext(DbContextOptions<DbInventarioContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder
                .Entity<LineaCompra>()
                .HasKey(l => l.LineaCompraId);

            //modelBuilder
            //    .Entity<LineaCompra>()
            //    .Property(l => l.LineaCompraId)
            //    .ValueGeneratedOnAdd();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options){}
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

    }
}
