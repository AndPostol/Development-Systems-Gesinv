using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.DAL.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<bool> Create(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(int id);
        //Task<IQueryable<TEntity>> GetName(string name);
    }
}
