﻿using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.Logic.Contracts;
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

        public GenericService(IGenericRepository<T> respository)
        {
            _repository = respository;
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

        public Task<bool> Update(T entity)
        {
            return _repository.Update(entity);
        }
    }

}
