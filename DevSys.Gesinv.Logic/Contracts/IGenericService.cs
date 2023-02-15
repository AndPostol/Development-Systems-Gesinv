using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.Logic.Contracts
{
    public interface IGenericService<T>
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
}
