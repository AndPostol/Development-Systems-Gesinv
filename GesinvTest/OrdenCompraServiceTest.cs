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
    public class OrdenCompraServiceTest
    {
        private static IOrdenCompraService _ordenCompraService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IOrdenCompraRepository> _ordenCompraRepository = new OrdenCompraRepositoryMock()._ordenCompraRepository;

            _ordenCompraService = new OrdenCompraService(_ordenCompraRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionOrdenCompra()
        {
            //Arrancar
            OrdenCompra _ordenCompra = new OrdenCompra()
            {
                OrdenCompraId = 10,
                ProveedorId = 6,
                Referencia = "Si",
                CondicionPagoId = 3,
                Observacion = "Aprobado",
                SubTotal = 20,
                Descuento = 10,
                Impuestos = 10,
                Total = 33,
                BodegaId = 1,
                Fecha = DateTime.Now,

            };

            //Actuar
            bool resultado = await _ordenCompraService.Create(_ordenCompra);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateOrdenCompra()
        {
            //Arrancar
            OrdenCompra _ordenCompra = new OrdenCompra()
            {
                OrdenCompraId = 10,
                ProveedorId = 6,
                Referencia = "Si",
                CondicionPagoId = 3,
                Observacion = "Pendiente",
                SubTotal = 20,
                Descuento = 5,
                Impuestos = 3,
                Total = 23,
                BodegaId = 1,
                //Fecha = 2022-08-05 00:00:00.0000000,

            };

            //Actuar
            bool resultado = await _ordenCompraService.Update(_ordenCompra);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetOrdenCompra()
        {
            //Arrancar
            int id = 10;

            //Actuar
            var resultado = await _ordenCompraService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async void valida_DeleteOrdenCompra()
        {
            //Arrancar
            int id = 10;

            //Actuar
            bool resultado = await _ordenCompraService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        //[TestMethod]
        //public async void valida_GetOrdenesDeCompras()
        //{

        //}

        //No se como hacer prueba de metodo Registrar
        
    }
}
