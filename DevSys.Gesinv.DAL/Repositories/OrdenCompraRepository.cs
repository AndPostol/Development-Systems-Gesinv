using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.DAL.DataContext;
using DevSys.Gesinv.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.DAL.Repositories
{
    public class OrdenCompraRepository : GenericRepository<OrdenCompra>, IOrdenCompraRepository
    {
        private readonly DbInventarioContext _dbContext;
        public OrdenCompraRepository(DbInventarioContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrdenCompra> Registrar(OrdenCompra entidad)
        {
            OrdenCompra OCGenerada = entidad;
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                
                try
                {
                    // Si agrego la entidad aqui ya se le asigna un id el entity
                    Random rand = new Random();
                    List<IngresoDetalle> listIngresoDetalle = new List<IngresoDetalle>();
                    double subtotal = 0f;
                    double total = 0f;
                    foreach (LineaCompra linea in entidad.LineaCompra)
                    {
                        Producto producto = await _dbContext.Producto.FindAsync(linea.ProductoId);
                        if (producto == null)
                        {
                            //linea.Producto.Codigo = rand.Next(1, 1000);
                            linea.Producto.Activo = false;
                            linea.Producto.Iva = false;
                            linea.Producto.Perecible = false;
                            _dbContext.Producto.Add(linea.Producto);
                            _dbContext.SaveChanges();
                            producto = linea.Producto;

                        }
                        //double descuento = producto.Precio * (linea.Descuento / 100);
                        //subtotal += ((producto.Precio * linea.Cantidad) + descuento);

                        // Registramos las lineas ingreso detalles
                        listIngresoDetalle.Add(new IngresoDetalle() { 
                            ProductoId = producto.ProductoId,
                            PrecioBruto = linea.Total,
                            Caja = 0,
                            Cantidad= linea.Cantidad
                        });

                    }
                    OCGenerada.Ingreso = new Ingreso() {
                        //CodigoIngreso = rand.Next(1,1000),
                        ProveedorId = OCGenerada.ProveedorId,
                        Fecha = OCGenerada.Fecha,
                        Descuento = OCGenerada.SubTotal,
                        Impuestos= OCGenerada.Impuestos,
                        Total= subtotal,
                        IngresoDetalle=listIngresoDetalle
                    };

                    await _dbContext.OrdenCompra.AddAsync(OCGenerada);
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex )
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return OCGenerada;
        }

    }
}
