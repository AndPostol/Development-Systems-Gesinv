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
CREATE PROCEDURE sp_InformeProveedor(
	 @fechaInicio date = null,
	 @fechaFin date = null,
	 @ruc varchar = null,
	 @codigo int = null,
	 @razonSocial varchar = null,
	 @producto int = null
)
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
	prov.ProveedorId,
	prov.RazonSocial,
	oc.OrdenCompraId,
	prod.ProductoId,
	prod.Nombre,
	oc.Fecha,
	lineaOC.Cantidad,
	prod.Precio

	FROM [Proveedor] AS prov
	INNER JOIN [OrdenCompra] AS oc ON oc.ProveedorId = prov.ProveedorId
	INNER JOIN [LineaCompra] AS lineaOC ON lineaOC.OrdenCompraId = oc.OrdenCompraId
	INNER JOIN [Producto] AS prod ON prod.ProductoId = lineaOC.ProductoId
	WHERE (@fechaInicio is null or @fechaInicio <= oc.Fecha)
	AND (@fechaFin is null or @fechaFin >= oc.Fecha)
	AND (@ruc is null or @ruc = prov.Ruc)
	AND (@codigo is null or @codigo = prov.ProveedorId)
	AND (@razonSocial is null or @razonSocial = prov.RazonSocial)
	AND (@producto is null or @producto = prod.ProductoId)
END
GO
