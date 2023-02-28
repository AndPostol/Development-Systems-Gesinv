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
        // Me parece que el table no va en este repo porque ya trabajamos con tablas especificas
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
                    //_dbContext.OrdenCompra.Add(entidad);
                    //double subtotal = 0f;
                    //double total = 0f;
                    //foreach (LineaCompra linea in entidad.LineaCompra)
                    //{
                    //    Producto producto =  await _dbContext.Producto.FindAsync(linea.ProductoId);
                    //    double descuento = producto.Precio * (linea.Descuento / 100); 
                    //    subtotal += ((producto.Precio * linea.Cantidad) + descuento);

                    //}
                    //total = subtotal + (subtotal * .19);
                    //if (total == entidad.Total) 
                    //{
                    //     await _dbContext.AddAsync(entidad);
                    //}
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
