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
    public class ReporteServiceTest
    {
        private static IReporteService _reporteService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            //Mock<IReporteService> _reporteRepository = new ReporteRepositoryMock()._reporteRepository;

            //ME DA ESTE ERROR
            //Cannot implicitly convert type 'type' to 'type'bThe compiler requires an explicit conversion.
            //For example, you may need to cast an r-value to be the same type as an l-value.Or, you must
            //provide conversion routines to support certain operator overloads.

            //_reporteService = new ReporteService((IReporteRepository)_reporteRepository.Object);
        }
    }
}
