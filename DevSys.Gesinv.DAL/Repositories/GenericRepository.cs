using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbInventarioContext _dbContext;
        private DbSet<T> table;

        public GenericRepository()
        {
            _dbContext = new DbInventarioContext();
            table = _dbContext.Set<T>();
        }
        public GenericRepository(DbInventarioContext dbContext)
        {
            _dbContext = dbContext;
            table = _dbContext.Set<T>();

        }

        public async Task<bool> Create(T entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            T existe = table.Find(id);
            table.Remove(existe);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await table.FindAsync(id);
        }

        //public Task<T> GetLastId()
        //{
        //    ();
        //}


        //public Task<IEnumerable<T>> GetName(string name)
        //{
        //    return await table.Where;
        //}

        public async Task<bool> Update(T entity)
        {
            table.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true; // Preguntar esto a chala 
        }


    }

}
