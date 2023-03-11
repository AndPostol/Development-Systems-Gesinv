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
    public class SalidaRepository : GenericRepository<Salida>, ISalidaRepository
    {
        private readonly DbInventarioContext _dbContext;

        public SalidaRepository(DbInventarioContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Salida> Registrar(Salida salida)
        {
            Salida salidaGenerada = salida;
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {

                    foreach (LineaSalida linea in salida.LineaSalida)
                    {
                        Existencia? registrada = await _dbContext.Existencia.
                            Where(e => e.ProductoId == linea.ProductoId && e.BodegaId == salida.BodegaId)
                            .FirstOrDefaultAsync();
                        if (registrada != null)
                        {
                            if (registrada.Stock < linea.Cantidad)
                            {
                                Console.WriteLine("No hay suficiente Inventario para esta orden");
                            }
                            else 
                            {
                                registrada.Stock = registrada.Stock - linea.Cantidad;
                            }
                        }
                        else
                        {
                            Existencia nuevaExistencia = new Existencia()
                            {
                                BodegaId = salida.BodegaId,
                                ProductoId = linea.ProductoId,
                                Stock = linea.Cantidad
                            };
                            _dbContext.Existencia.Add(nuevaExistencia);
                        }
                    }
                    _dbContext.Salida.Add(salidaGenerada);
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return salidaGenerada;
        }
    }
}
