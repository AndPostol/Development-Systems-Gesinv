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
    public class DepartamentoServiceTest
    {
        private static IGenericService<Departamento> _departamentoService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IGenericRepository<Departamento>> _genericRepository = new GenericRepositoryMock<Departamento>()._genericRepository;

            _departamentoService = new DepartamentoService(_genericRepository.Object);
        }

        [TestMethod]
        public async void valida_CreacionDepartamento()
        {
            //Arrancar
            Departamento _departamento = new Departamento()
            {
                DepartamentoId = 4,
                Nombre = "Operaciones Espaciales",
            };

            //Actuar
            bool resultado = await _departamentoService.Create(_departamento);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_UpdateColor()
        {
            //Arrancar
            Departamento _departamento = new Departamento()
            {
                DepartamentoId = 4,
                Nombre = "Operaciones Espaciales",
            };

            //Actuar
            bool resultado = await _departamentoService.Update(_departamento);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_DeleteDepartamento()
        {
            //Arrancar
            int id = 4;

            //Actuar
            bool resultado = await _departamentoService.Delete(id);

            //Asegurar
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async void valida_GetDepartamento()
        {
            //Arrancar
            int id = 4;

            //Actuar
            var resultado = await _departamentoService.GetById(id);

            //Asegurar
            Assert.IsNotNull(resultado);
        }

        //[TestMethod]
        //public async void valida_GetDepartamentos()
        //{

        //}
    }
}
