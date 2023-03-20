﻿using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.DAL.Contracts;

namespace DevSys.Gesinv.Logic.Services
{
    public class ProductoService : GenericService<Producto>, IProductoService
    {
        private readonly IProductoRepository _repository;
        public ProductoService(IProductoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Producto> GetColors(int id)
        {
            return await _repository.GetProductoColors(id);
        }

        //public async Task<Producto> ObtenerPorCodigo(int Codigo)
        //{
        //    IEnumerable<Producto> queryProducto = await _repository.GetAll();
        //    Producto producto = queryProducto.Where(producto => producto.Codigo == Codigo).FirstOrDefault();
        //    return producto;
        //}

        //se habia pensado para hacer las busquedas, pero ya se hizo con javascript
        public async Task<Producto> ObtenerPorNombre(string Nombre)
  {
            IEnumerable<Producto> queryProducto = await _repository.GetAll();
            Producto producto = queryProducto.Where(producto => producto.Nombre == Nombre).FirstOrDefault();
            return producto;
        }

        public async Task<Producto> ProductosInactivos(bool Activo)
    {
            IEnumerable<Producto> queryProducto = await _repository.GetAll();
            Producto producto = queryProducto.Where(producto => producto.Activo == Activo).FirstOrDefault();
            return producto;
    }
  }
}

