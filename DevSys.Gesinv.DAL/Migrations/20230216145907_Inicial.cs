using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSys.Gesinv.DAL.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CondicionPago",
                columns: table => new
                {
                    CondicionPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicionPago", x => x.CondicionPagoId);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado1 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    GrupoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.GrupoId);
                });

            migrationBuilder.CreateTable(
                name: "Linea",
                columns: table => new
                {
                    LineaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linea", x => x.LineaId);
                });

            migrationBuilder.CreateTable(
                name: "Motivo",
                columns: table => new
                {
                    MotivoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivo", x => x.MotivoId);
                });

            migrationBuilder.CreateTable(
                name: "Tipo",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoIngreso",
                columns: table => new
                {
                    TipoIngresoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIngreso", x => x.TipoIngresoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPersona",
                columns: table => new
                {
                    TipoPersonaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersona", x => x.TipoPersonaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoProveedor",
                columns: table => new
                {
                    TipoProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProveedor", x => x.TipoProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "Requisicion",
                columns: table => new
                {
                    RequisicionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoRequisicion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrdenCompraId = table.Column<int>(type: "int", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisicion", x => x.RequisicionId);
                    table.ForeignKey(
                        name: "FK_Requisicion_Departamento_OrdenCompraId",
                        column: x => x.OrdenCompraId,
                        principalTable: "Departamento",
                        principalColumn: "DepartamentoId");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaId");
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoId = table.Column<int>(type: "int", nullable: true),
                    Provincia1 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.ProvinciaId);
                    table.ForeignKey(
                        name: "FK_Provincia_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "EstadoId");
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    LineaId = table.Column<int>(type: "int", nullable: true),
                    TipoId = table.Column<int>(type: "int", nullable: true),
                    Unidad = table.Column<int>(type: "int", nullable: false),
                    Caja = table.Column<int>(type: "int", nullable: true),
                    GrupoId = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    Iva = table.Column<bool>(type: "bit", nullable: true),
                    Perecible = table.Column<bool>(type: "bit", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCaducidad = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Producto_Grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "GrupoId");
                    table.ForeignKey(
                        name: "FK_Producto_Linea_LineaId",
                        column: x => x.LineaId,
                        principalTable: "Linea",
                        principalColumn: "LineaId");
                    table.ForeignKey(
                        name: "FK_Producto_Tipo_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tipo",
                        principalColumn: "TipoId");
                });

            migrationBuilder.CreateTable(
                name: "Bodega",
                columns: table => new
                {
                    BodegaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaId = table.Column<int>(type: "int", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodega", x => x.BodegaId);
                    table.ForeignKey(
                        name: "FK_Bodega_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaId");
                    table.ForeignKey(
                        name: "FK_Bodega_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "EstadoId");
                    table.ForeignKey(
                        name: "FK_Bodega_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "ProvinciaId");
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoProveedorId = table.Column<int>(type: "int", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plazo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ruc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaId = table.Column<int>(type: "int", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: true),
                    TipoPersona = table.Column<int>(type: "int", nullable: true),
                    PaginaWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPersonaNavigationTipoPersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.ProveedorId);
                    table.ForeignKey(
                        name: "FK_Proveedor_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaId");
                    table.ForeignKey(
                        name: "FK_Proveedor_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "EstadoId");
                    table.ForeignKey(
                        name: "FK_Proveedor_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "ProvinciaId");
                    table.ForeignKey(
                        name: "FK_Proveedor_TipoPersona_TipoPersonaNavigationTipoPersonaId",
                        column: x => x.TipoPersonaNavigationTipoPersonaId,
                        principalTable: "TipoPersona",
                        principalColumn: "TipoPersonaId");
                    table.ForeignKey(
                        name: "FK_Proveedor_TipoProveedor_TipoProveedorId",
                        column: x => x.TipoProveedorId,
                        principalTable: "TipoProveedor",
                        principalColumn: "TipoProveedorId");
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ColorId);
                    table.ForeignKey(
                        name: "FK_Color_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.MarcaId);
                    table.ForeignKey(
                        name: "FK_Marca_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "Medida",
                columns: table => new
                {
                    MedidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dimension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medida", x => x.MedidaId);
                    table.ForeignKey(
                        name: "FK_Medida_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "Existencia",
                columns: table => new
                {
                    ExistenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: true),
                    BodegaId = table.Column<int>(type: "int", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Existencia", x => x.ExistenciaId);
                    table.ForeignKey(
                        name: "FK_Existencia_Bodega_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodega",
                        principalColumn: "BodegaId");
                    table.ForeignKey(
                        name: "FK_Existencia_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "Salida",
                columns: table => new
                {
                    SalidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotivoId = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequisicionId = table.Column<int>(type: "int", nullable: true),
                    BodegaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salida", x => x.SalidaId);
                    table.ForeignKey(
                        name: "FK_Salida_Bodega_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodega",
                        principalColumn: "BodegaId");
                    table.ForeignKey(
                        name: "FK_Salida_Motivo_MotivoId",
                        column: x => x.MotivoId,
                        principalTable: "Motivo",
                        principalColumn: "MotivoId");
                    table.ForeignKey(
                        name: "FK_Salida_Requisicion_RequisicionId",
                        column: x => x.RequisicionId,
                        principalTable: "Requisicion",
                        principalColumn: "RequisicionId");
                });

            migrationBuilder.CreateTable(
                name: "Ingreso",
                columns: table => new
                {
                    IngresoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoIngreso = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: true),
                    MotivoId = table.Column<int>(type: "int", nullable: true),
                    BodegaId = table.Column<int>(type: "int", nullable: true),
                    TipoIngresoId = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descuento = table.Column<double>(type: "float", nullable: false),
                    Impuestos = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingreso", x => x.IngresoId);
                    table.ForeignKey(
                        name: "FK_Ingreso_Bodega_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodega",
                        principalColumn: "BodegaId");
                    table.ForeignKey(
                        name: "FK_Ingreso_Motivo_MotivoId",
                        column: x => x.MotivoId,
                        principalTable: "Motivo",
                        principalColumn: "MotivoId");
                    table.ForeignKey(
                        name: "FK_Ingreso_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "ProveedorId");
                    table.ForeignKey(
                        name: "FK_Ingreso_TipoIngreso_TipoIngresoId",
                        column: x => x.TipoIngresoId,
                        principalTable: "TipoIngreso",
                        principalColumn: "TipoIngresoId");
                });

            migrationBuilder.CreateTable(
                name: "OrdenCompra",
                columns: table => new
                {
                    OrdenCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(type: "int", nullable: true),
                    CodProveedor = table.Column<int>(type: "int", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondicionPagoId = table.Column<int>(type: "int", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Descuento = table.Column<double>(type: "float", nullable: false),
                    Impuestos = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenCompra", x => x.OrdenCompraId);
                    table.ForeignKey(
                        name: "FK_OrdenCompra_CondicionPago_CondicionPagoId",
                        column: x => x.CondicionPagoId,
                        principalTable: "CondicionPago",
                        principalColumn: "CondicionPagoId");
                    table.ForeignKey(
                        name: "FK_OrdenCompra_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "ProveedorId");
                });

            migrationBuilder.CreateTable(
                name: "LineaSalida",
                columns: table => new
                {
                    LineaSalidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalidaId = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CostoSalida = table.Column<double>(type: "float", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaSalida", x => x.LineaSalidaId);
                    table.ForeignKey(
                        name: "FK_LineaSalida_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId");
                    table.ForeignKey(
                        name: "FK_LineaSalida_Salida_SalidaId",
                        column: x => x.SalidaId,
                        principalTable: "Salida",
                        principalColumn: "SalidaId");
                });

            migrationBuilder.CreateTable(
                name: "IngresoDetalle",
                columns: table => new
                {
                    IngresoDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: true),
                    IngresoId = table.Column<int>(type: "int", nullable: true),
                    PrecioBruto = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Caja = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngresoDetalle", x => x.IngresoDetalleId);
                    table.ForeignKey(
                        name: "FK_IngresoDetalle_Ingreso_IngresoId",
                        column: x => x.IngresoId,
                        principalTable: "Ingreso",
                        principalColumn: "IngresoId");
                    table.ForeignKey(
                        name: "FK_IngresoDetalle_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "LineaCompra",
                columns: table => new
                {
                    LineaCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenCompraId = table.Column<int>(type: "int", nullable: true),
                    ProductoId = table.Column<int>(type: "int", nullable: true),
                    DepartamentoId = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Caja = table.Column<int>(type: "int", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Descuento = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaCompra", x => x.LineaCompraId);
                    table.ForeignKey(
                        name: "FK_LineaCompra_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "DepartamentoId");
                    table.ForeignKey(
                        name: "FK_LineaCompra_OrdenCompra_OrdenCompraId",
                        column: x => x.OrdenCompraId,
                        principalTable: "OrdenCompra",
                        principalColumn: "OrdenCompraId");
                    table.ForeignKey(
                        name: "FK_LineaCompra_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bodega_EmpresaId",
                table: "Bodega",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega_EstadoId",
                table: "Bodega",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega_ProvinciaId",
                table: "Bodega",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Color_ProductoId",
                table: "Color",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Existencia_BodegaId",
                table: "Existencia",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Existencia_ProductoId",
                table: "Existencia",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_BodegaId",
                table: "Ingreso",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_MotivoId",
                table: "Ingreso",
                column: "MotivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_ProveedorId",
                table: "Ingreso",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_TipoIngresoId",
                table: "Ingreso",
                column: "TipoIngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoDetalle_IngresoId",
                table: "IngresoDetalle",
                column: "IngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoDetalle_ProductoId",
                table: "IngresoDetalle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaCompra_DepartamentoId",
                table: "LineaCompra",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaCompra_OrdenCompraId",
                table: "LineaCompra",
                column: "OrdenCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaCompra_ProductoId",
                table: "LineaCompra",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaSalida_ProductoId",
                table: "LineaSalida",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaSalida_SalidaId",
                table: "LineaSalida",
                column: "SalidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Marca_ProductoId",
                table: "Marca",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medida_ProductoId",
                table: "Medida",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompra_CondicionPagoId",
                table: "OrdenCompra",
                column: "CondicionPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompra_ProveedorId",
                table: "OrdenCompra",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_GrupoId",
                table: "Producto",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_LineaId",
                table: "Producto",
                column: "LineaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_TipoId",
                table: "Producto",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_EmpresaId",
                table: "Proveedor",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_EstadoId",
                table: "Proveedor",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_ProvinciaId",
                table: "Proveedor",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_TipoPersonaNavigationTipoPersonaId",
                table: "Proveedor",
                column: "TipoPersonaNavigationTipoPersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_TipoProveedorId",
                table: "Proveedor",
                column: "TipoProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Provincia_EstadoId",
                table: "Provincia",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicion_OrdenCompraId",
                table: "Requisicion",
                column: "OrdenCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Salida_BodegaId",
                table: "Salida",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Salida_MotivoId",
                table: "Salida",
                column: "MotivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Salida_RequisicionId",
                table: "Salida",
                column: "RequisicionId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpresaId",
                table: "Usuario",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Existencia");

            migrationBuilder.DropTable(
                name: "IngresoDetalle");

            migrationBuilder.DropTable(
                name: "LineaCompra");

            migrationBuilder.DropTable(
                name: "LineaSalida");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Medida");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Ingreso");

            migrationBuilder.DropTable(
                name: "OrdenCompra");

            migrationBuilder.DropTable(
                name: "Salida");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "TipoIngreso");

            migrationBuilder.DropTable(
                name: "CondicionPago");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Bodega");

            migrationBuilder.DropTable(
                name: "Motivo");

            migrationBuilder.DropTable(
                name: "Requisicion");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.DropTable(
                name: "Linea");

            migrationBuilder.DropTable(
                name: "Tipo");

            migrationBuilder.DropTable(
                name: "TipoPersona");

            migrationBuilder.DropTable(
                name: "TipoProveedor");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
