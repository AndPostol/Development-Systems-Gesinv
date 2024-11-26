-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE sp_InformeSalida(
	@fechaInicio date= null,
	@fechaFin date= null,
	@bodega int = null,
	@proveedor int = null,
	@tipoProducto int = null
) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
		prod.ProductoId,
		prod.Nombre,
		sal.MotivoId,
		ing.Fecha as Ingreso,
		sal.Fecha as Salida,
		prov.TipoProveedorId as TipoProveedor,
		prov.RazonSocial,
		linea.Cantidad,
		stock.Stock,
		linea.CostoSalida
	FROM [Salida] AS sal
	INNER JOIN [LineaSalida] AS linea ON sal.SalidaId = linea.SalidaId
	INNER JOIN [Producto] AS prod ON prod.ProductoId = linea.ProductoId
	INNER JOIN [Existencia] AS stock ON stock.ProductoId = prod.ProductoId
	INNER JOIN [IngresoDetalle] AS ingDet ON ingDet.ProductoId = prod.ProductoId
	INNER JOIN [Ingreso] AS ing ON ing.IngresoId = ingDet.IngresoId
	INNER JOIN [Proveedor] AS prov ON prov.ProveedorId = ing.ProveedorId
	WHERE (@fechaInicio is null or @fechaInicio <= sal.Fecha)
		AND (@fechaFin is null or @fechaFin >= sal.Fecha)
		AND (@bodega is null or @bodega = stock.BodegaId)
		AND (@proveedor is null or @proveedor = ing.ProveedorId)
		AND (@tipoProducto is null or @tipoProducto = prod.TipoId)
END
GO
