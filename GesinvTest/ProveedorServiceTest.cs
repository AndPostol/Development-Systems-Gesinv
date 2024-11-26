using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Logic.Services;
using DevSys.Gesinv.Models;
using DevSys.Gesinv.Unit.Test.MockRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DevSys.Gesinv.Unit.Test
{
    [TestClass]
    public class ProveedorServiceTest
    {
        private static IGenericService<Proveedor> _proveedorService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<Proveedor>> _genericRepository = new GenericRepositoryMock<Proveedor>()._genericRepository;

            _proveedorService = new ProveedorService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionProveedor()
        {
            //Arrancar
            Proveedor _proveedor = new Proveedor()
            {
                ProveedorId = 8,
                RazonSocial = "Juridico",
                Contacto = "Andres Apostol",
                EmpresaId = 2,
                TipoProveedorId = 3,
                Direccion = "Esquina Veroes",
                Telefono = "0426-8967825",
                Correo = "alan@gmail.com",
                Plazo = DateTime.Now,
                Ruc = "J-45236985",
                ProvinciaId = 5,
                EstadoId = 6,
                PaginaWeb = "www.mabe.com.ve",
                TipoPersonaId = 7,
            };

            //Actuar
            bool resultado = await _proveedorService.Create(_proveedor);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateProveedor()
        {
            //Arrancar
            Proveedor _proveedor = new Proveedor()
            {
                ProveedorId = 8,
                RazonSocial = "Juridico",
                Contacto = "Andres Apostol",
                EmpresaId = 2,
                TipoProveedorId = 3,
                Direccion = "Esquina Veroes",
                Telefono = "0426-8967825",
                Correo = "alan@gmail.com",
                Plazo = DateTime.Now,
                Ruc = "J-45236985",
                ProvinciaId = 5,
                EstadoId = 6,
                PaginaWeb = "www.mabe.com.ve",
                TipoPersonaId = 7,
            };

            //Actuar
            bool resultado = await _proveedorService.Update(_proveedor);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetProveedor()
        {
            //Arrancar
            int id = 8;

            //Actuar
            var resultado = await _proveedorService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async void valida_DeleteProveedor()
        {
            //Arrancar
            int id = 8;

            //Actuar
            bool resultado = await _proveedorService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        //[TestMethod]
        //public async void valida_GetProveedores()
        //{

        //}
    }
}
