using Castle.Core.Internal;
using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.DAL.DataContext;
using DevSys.Gesinv.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.DAL.Repositories
{
    public class IngresoRepository : GenericRepository<Ingreso>, IIngresoRepository
    {
        private readonly DbInventarioContext _dbContext;

        public IngresoRepository(DbInventarioContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    
        public async Task<Ingreso> Registrar(Ingreso ingreso)
        {
            Ingreso ingresoEncontrado = new Ingreso();
            using (var transaction = _dbContext.Database.BeginTransaction()) { 
                try
                {
                    ingresoEncontrado = await _dbContext.Ingreso.FindAsync(ingreso.IngresoId);
                    ingresoEncontrado.OrdenCompraId = ingreso.OrdenCompraId;
                    ingresoEncontrado.MotivoId = ingreso.MotivoId;
                    ingresoEncontrado.ProveedorId  = ingreso.ProveedorId;
                    ingresoEncontrado.BodegaId = ingreso.BodegaId;
                    ingresoEncontrado.TipoIngresoId = ingreso.TipoIngresoId;
                    ingresoEncontrado.Fecha = ingreso.Fecha;
                    ingresoEncontrado.Confirmado= ingreso.Confirmado;

                    foreach (IngresoDetalle detalle in ingresoEncontrado.IngresoDetalle)
                    {
                        Existencia? registrada = _dbContext.Existencia.
                            Where(e => e.ProductoId == detalle.ProductoId && e.BodegaId == ingresoEncontrado.BodegaId).FirstOrDefault();
                        if (registrada != null)
                        {
                            registrada.Stock = registrada.Stock + detalle.Cantidad;
                        }
                        else
                        {
                            Existencia nuevaExistencia = new Existencia() {
                                BodegaId = ingreso.BodegaId,
                                ProductoId = detalle.ProductoId,
                                Stock = detalle.Cantidad
                            };
                            _dbContext.Existencia.Add(nuevaExistencia);
                        }
                    }
                    
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return ingresoEncontrado;
        }
    }
}
