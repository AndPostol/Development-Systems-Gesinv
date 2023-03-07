using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.DAL.Repositories;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.Logic.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private IGenericRepository<T> _repository;
        private IingresoRepository respository;
        private IGenericRepository<Proveedor> respository1;

        public GenericService(IGenericRepository<T> respository)
        {
            _repository = respository;
        }

        public GenericService(IingresoRepository respository)
        {
            this.respository = respository;
        }

        public GenericService(IGenericRepository<Proveedor> respository1)
        {
            this.respository1 = respository1;
        }

        public async Task<bool> Create(T entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> Update(T entity)
        {
            return await _repository.Update(entity);
        }
    }

}
