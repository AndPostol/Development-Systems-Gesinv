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
    public class LineaCompraServiceTest
    {
        private static IGenericService<LineaCompra> _lineaCompraService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<LineaCompra>> _genericRepository = new GenericRepositoryMock<LineaCompra>()._genericRepository;

            _lineaCompraService = new LineaCompraService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionLineaCompra()
        {
            //Arrancar
            LineaCompra _lineaCompra = new LineaCompra()
            {
                LineaCompraId = 6,
                OrdenCompraId = 2,
                ProductoId = 1,
                DepartamentoId = 2,
                Cantidad = 20,
                Caja = 10,
                Precio = 15.5,
                Descuento = 6,
                Total = 230,
            };

            //Actuar
            bool resultado = await _lineaCompraService.Create(_lineaCompra);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateLineaCompra()
        {
            //Arrancar
            LineaCompra _lineaCompra = new LineaCompra()
            {
                LineaCompraId = 6,
                OrdenCompraId = 5,
                ProductoId = 3,
                DepartamentoId = 2,
                Cantidad = 50,
                Caja = 5,
                Precio = 10.25,
                Descuento = 12,
                Total = 530,
            };

            //Actuar
            bool resultado = await _lineaCompraService.Update(_lineaCompra);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetLineaCompra()
        {
            //Arrancar
            int id = 6;

            //Actuar
            var resultado = await _lineaCompraService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async void valida_DeleteLineaCompra()
        {
            //Arrancar
            int id = 6;

            //Actuar
            bool resultado = await _lineaCompraService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }


        //[TestMethod]
        //public async void valida_GetLineasDeCompra()
        //{

        //}
    }
}
