
CREATE PROCEDURE sp_InformeIngreso(
	 @motivo int = null,
	 @fechaInicio date= null,
	 @fechaFin date= null,
	 @bodega int = null,
	 @proveedor int = null,
	 @tipoProducto int = null
)
AS
BEGIN
	SELECT prod.ProductoId, prod.Nombre, ing.MotivoId, ing.Fecha, det.Cantidad, det.PrecioBruto FROM [Ingreso] as ing 
	INNER JOIN [IngresoDetalle] as det ON ing.IngresoId = det.IngresoId 
	INNER JOIN [Producto] as prod ON det.ProductoId = prod.ProductoId
	WHERE (@fechaInicio is null or @fechaInicio <= ing.Fecha)
	AND (@fechaFin is null or @fechaFin >= ing.Fecha)
	AND (@motivo is null or ing.MotivoId = @motivo)
	AND (@bodega is null or ing.BodegaId = @bodega)
	AND (@proveedor is null or ing.ProveedorId = @proveedor)
	AND (@tipoProducto is null or prod.TipoId = @tipoProducto)
END
GO
