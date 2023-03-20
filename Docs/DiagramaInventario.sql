CREATE TABLE [Producto] (
  [ProductoID] int PRIMARY KEY,
  [Nombre] nvarchar(255) NOT NULL,
  [Codigo] int UNIQUE NOT NULL,
  [LineaID] int,
  [TipoID] int,
  [Unidad] int NOT NULL,
  [Caja] int DEFAULT (0),
  [GrupoID] int,
  [Activo] bit DEFAULT (0),
  [IVA] bit DEFAULT (0),
  [Perecible] bit DEFAULT (0),
  [Comentario] text,
  [FechaCaducidad] datetime,
  [Precio] float NOT NULL
)
GO

CREATE TABLE [Linea] (
  [LineaID] int PRIMARY KEY,
  [Nombre] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Tipo] (
  [TipoID] int PRIMARY KEY,
  [Nombre] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Grupo] (
  [GrupoID] int PRIMARY KEY,
  [Nombre] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Proveedor] (
  [ProveedorID] int PRIMARY KEY,
  [EmpresaID] int,
  [RazonSocial] nvarchar(255) NOT NULL,
  [Codigo] int UNIQUE NOT NULL,
  [Contacto] nvarchar(255) NOT NULL,
  [TipoProveedorID] int,
  [Direccion] nvarchar(255) NOT NULL,
  [Telefono] nvarchar(255) NOT NULL,
  [Correo] nvarchar(255) NOT NULL,
  [Plazo] datetime,
  [RUC] nvarchar(255) NOT NULL,
  [ProvinciaID] int,
  [EstadoID] int,
  [TipoPersona] int,
  [PaginaWeb] nvarchar(255)
)
GO

CREATE TABLE [TipoProveedor] (
  [TipoProveedorID] int PRIMARY KEY,
  [Nombre] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [TipoPersona] (
  [TipoPersonaID] int PRIMARY KEY,
  [Nombre] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Bodega] (
  [BodegaID] int PRIMARY KEY,
  [EmpresaID] int,
  [Direccion] nvarchar(255) NOT NULL,
  [ProvinciaID] int,
  [EstadoID] int
)
GO

CREATE TABLE [Estado] (
  [EstadoID] int PRIMARY KEY,
  [Estado] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Provincia] (
  [ProvinciaID] int PRIMARY KEY,
  [EstadoID] int,
  [Provincia] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [OrdenCompra] (
  [OrdenCompraID] int PRIMARY KEY,
  [ProveedorID] int,
  [CodProveedor] int NOT NULL,
  [Referencia] nvarchar(255),
  [CondicionPagoID] int,
  [Observacion] text,
  [Fecha] datetime NOT NULL,
  [SubTotal] float NOT NULL,
  [Descuento] float NOT NULL,
  [Impuestos] float NOT NULL,
  [Total] float NOT NULL
)
GO

CREATE TABLE [CondicionPago] (
  [CondicionPagoID] int PRIMARY KEY,
  [Nombre] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Ingreso] (
  [IngresoID] int PRIMARY KEY,
  [CodigoIngreso] int UNIQUE NOT NULL,
  [ProveedorID] int,
  [MotivoID] int,
  [BodegaID] int,
  [TipoIngresoID] int,
  [Fecha] datetime NOT NULL,
  [Descuento] float NOT NULL,
  [Impuestos] float NOT NULL,
  [Total] float NOT NULL
)
GO

CREATE TABLE [IngresoDetalle] (
  [IngresoDetalleID] int PRIMARY KEY,
  [ProductoID] int,
  [IngresoID] int,
  [PrecioBruto] float NOT NULL,
  [Fecha] datetime NOT NULL,
  [Caja] int NOT NULL,
  [Cantidad] int NOT NULL
)
GO

CREATE TABLE [TipoIngreso] (
  [TipoIngresoID] int PRIMARY KEY,
  [Nombre] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Motivo] (
  [MotivoID] int PRIMARY KEY,
  [Nombre] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Salida] (
  [SalidaID] int PRIMARY KEY,
  [Codigo] nvarchar(255) UNIQUE NOT NULL,
  [MotivoID] int,
  [Fecha] datetime NOT NULL,
  [Comentario] text,
  [RequisicionID] int,
  [BodegaID] int
)
GO

CREATE TABLE [Requisicion] (
  [RequisicionID] int PRIMARY KEY,
  [CodigoRequisicion] nvarchar(255) UNIQUE NOT NULL,
  [Fecha] datetime NOT NULL,
  [OrdenCompraID] int,
  [Comentario] nvarchar(255)
)
GO

CREATE TABLE [Empresa] (
  [EmpresaID] int PRIMARY KEY,
  [Correo] nvarchar(255) UNIQUE NOT NULL,
  [Password] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Usuario] (
  [UsuarioID] int PRIMARY KEY,
  [Correo] nvarchar(255) UNIQUE NOT NULL,
  [Password] nvarchar(255) NOT NULL,
  [EmpresaID] int
)
GO

CREATE TABLE [Existencia] (
  [ExistenciaID] int PRIMARY KEY,
  [ProductoID] int,
  [BodegaID] int,
  [Stock] int NOT NULL
)
GO

CREATE TABLE [LineaCompra] (
  [LineaCompraID] int PRIMARY KEY,
  [OrdenCompraID] int,
  [ProductoID] int,
  [DepartamentoID] int,
  [Cantidad] int NOT NULL,
  [Caja] [int],
  [Precio] float NOT NULL,
  [Descuento] float NOT NULL,
  [Total] float NOT NULL
)
GO

CREATE TABLE [LineaSalida] (
  [LineaSalidaID] int PRIMARY KEY,
  [SalidaID] int,
  [Cantidad] int NOT NULL,
  [CostoSalida] float NOT NULL,
  [ProductoID] int
)
GO

CREATE TABLE [Color] (
  [ColorID] int PRIMARY KEY,
  [Nombre] nvarchar(255) NOT NULL,
  [ProductoID] int
)
GO

CREATE TABLE [Marca] (
  [MarcaID] int PRIMARY KEY,
  [Nombre] nvarchar(255) NOT NULL,
  [ProductoID] int
)
GO

CREATE TABLE [Medida] (
  [MedidaID] int PRIMARY KEY,
  [Dimension] nvarchar(255) NOT NULL,
  [ProductoID] int
)
GO

CREATE TABLE [Departamento] (
  [DepartamentoID] int PRIMARY KEY,
  [Nombre] nvarchar(255) NOT NULL
)
GO

ALTER TABLE [Producto] ADD FOREIGN KEY ([LineaID]) REFERENCES [Linea] ([LineaID])
GO

ALTER TABLE [Producto] ADD FOREIGN KEY ([TipoID]) REFERENCES [Tipo] ([TipoID])
GO

ALTER TABLE [Producto] ADD FOREIGN KEY ([GrupoID]) REFERENCES [Grupo] ([GrupoID])
GO

ALTER TABLE [Proveedor] ADD FOREIGN KEY ([EmpresaID]) REFERENCES [Empresa] ([EmpresaID])
GO

ALTER TABLE [Proveedor] ADD FOREIGN KEY ([TipoProveedorID]) REFERENCES [TipoProveedor] ([TipoProveedorID])
GO

ALTER TABLE [Proveedor] ADD FOREIGN KEY ([ProvinciaID]) REFERENCES [Provincia] ([ProvinciaID])
GO

ALTER TABLE [Proveedor] ADD FOREIGN KEY ([EstadoID]) REFERENCES [Estado] ([EstadoID])
GO

ALTER TABLE [Proveedor] ADD FOREIGN KEY ([TipoPersona]) REFERENCES [TipoPersona] ([TipoPersonaID])
GO

ALTER TABLE [Bodega] ADD FOREIGN KEY ([EmpresaID]) REFERENCES [Empresa] ([EmpresaID])
GO

ALTER TABLE [Bodega] ADD FOREIGN KEY ([ProvinciaID]) REFERENCES [Provincia] ([ProvinciaID])
GO

ALTER TABLE [Bodega] ADD FOREIGN KEY ([EstadoID]) REFERENCES [Estado] ([EstadoID])
GO

ALTER TABLE [Provincia] ADD FOREIGN KEY ([EstadoID]) REFERENCES [Estado] ([EstadoID])
GO

ALTER TABLE [OrdenCompra] ADD FOREIGN KEY ([ProveedorID]) REFERENCES [Proveedor] ([ProveedorID])
GO

ALTER TABLE [OrdenCompra] ADD FOREIGN KEY ([CondicionPagoID]) REFERENCES [CondicionPago] ([CondicionPagoID])
GO

ALTER TABLE [Ingreso] ADD FOREIGN KEY ([ProveedorID]) REFERENCES [Proveedor] ([ProveedorID])
GO

ALTER TABLE [Ingreso] ADD FOREIGN KEY ([MotivoID]) REFERENCES [Motivo] ([MotivoID])
GO

ALTER TABLE [Ingreso] ADD FOREIGN KEY ([BodegaID]) REFERENCES [Bodega] ([BodegaID])
GO

ALTER TABLE [Ingreso] ADD FOREIGN KEY ([TipoIngresoID]) REFERENCES [TipoIngreso] ([TipoIngresoID])
GO

ALTER TABLE [IngresoDetalle] ADD FOREIGN KEY ([ProductoID]) REFERENCES [Producto] ([ProductoID])
GO

ALTER TABLE [IngresoDetalle] ADD FOREIGN KEY ([IngresoID]) REFERENCES [Ingreso] ([IngresoID])
GO

ALTER TABLE [Salida] ADD FOREIGN KEY ([MotivoID]) REFERENCES [Motivo] ([MotivoID])
GO

ALTER TABLE [Salida] ADD FOREIGN KEY ([RequisicionID]) REFERENCES [Requisicion] ([RequisicionID])
GO

ALTER TABLE [Salida] ADD FOREIGN KEY ([BodegaID]) REFERENCES [Bodega] ([BodegaID])
GO

ALTER TABLE [Requisicion] ADD FOREIGN KEY ([OrdenCompraID]) REFERENCES [Departamento] ([DepartamentoID])
GO

ALTER TABLE [Usuario] ADD FOREIGN KEY ([EmpresaID]) REFERENCES [Empresa] ([EmpresaID])
GO

ALTER TABLE [Existencia] ADD FOREIGN KEY ([ProductoID]) REFERENCES [Producto] ([ProductoID])
GO

ALTER TABLE [Existencia] ADD FOREIGN KEY ([BodegaID]) REFERENCES [Bodega] ([BodegaID])
GO

ALTER TABLE [LineaCompra] ADD FOREIGN KEY ([OrdenCompraID]) REFERENCES [OrdenCompra] ([OrdenCompraID])
GO

ALTER TABLE [LineaCompra] ADD FOREIGN KEY ([ProductoID]) REFERENCES [Producto] ([ProductoID])
GO

ALTER TABLE [LineaCompra] ADD FOREIGN KEY ([DepartamentoID]) REFERENCES [Departamento] ([DepartamentoID])
GO

ALTER TABLE [LineaSalida] ADD FOREIGN KEY ([SalidaID]) REFERENCES [Salida] ([SalidaID])
GO

ALTER TABLE [LineaSalida] ADD FOREIGN KEY ([ProductoID]) REFERENCES [Producto] ([ProductoID])
GO

ALTER TABLE [Color] ADD FOREIGN KEY ([ProductoID]) REFERENCES [Producto] ([ProductoID])
GO

ALTER TABLE [Marca] ADD FOREIGN KEY ([ProductoID]) REFERENCES [Producto] ([ProductoID])
GO

ALTER TABLE [Medida] ADD FOREIGN KEY ([ProductoID]) REFERENCES [Producto] ([ProductoID])
GO
