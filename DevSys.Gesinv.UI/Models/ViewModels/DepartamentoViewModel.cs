﻿using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class DepartamentoViewModel
    {

        public int DepartamentoId { get; set; }
        public string Nombre { get; set; } = null!;


        public static DepartamentoViewModel ToViewModel(Departamento model) 
        {
            DepartamentoViewModel viewModel = new DepartamentoViewModel() 
            {
                DepartamentoId = model.DepartamentoId,
                Nombre = model.Nombre
            };
            return viewModel;
        }

        public static Departamento ToModel(DepartamentoViewModel modelView) 
        {
            Departamento model = new Departamento() 
            {
                DepartamentoId = modelView.DepartamentoId,
                Nombre = modelView.Nombre
            };
            return model;
        }

        public static List<DepartamentoViewModel> ToViewModelList(IEnumerable<Departamento> lstModel) 
        {
            List<DepartamentoViewModel> lstViewModel = new List<DepartamentoViewModel>();
            foreach (var model in lstModel)
            {
                lstViewModel.Add(ToViewModel(model));
            }
            return lstViewModel;
        }
    }
}