﻿using DevSys.Gesinv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.Logic.Contracts
{
    public interface IReporteService
    {
        Task<List<ReporteIngreso>> obtenerReporteProveedores(
            string? fechaInicio,
            string? fechaFin,
            string? ruc,
            int? codigo,
            string? razonSocial,
            int? productoId);
    }
}
