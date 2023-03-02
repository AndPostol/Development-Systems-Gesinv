using DevSys.Gesinv.Models;

namespace DevSys.Gesinv.UI.Models.ViewModels
{
    public class BodegaViewModel
    {
        public int BodegaId { get; set; }
        public string Direccion { get; set; }

        public static BodegaViewModel ConvertToViewModel(Bodega bodega)
        {
            BodegaViewModel bodegaViewModel = new BodegaViewModel()
            {
                BodegaId = bodega.BodegaId,
                Direccion = bodega.Direccion,
            };
            return bodegaViewModel;
        }

        public static Bodega ConvertToModel(BodegaViewModel bodegaViewModel)
        {
            Bodega bodega = new Bodega()
            {
                BodegaId = bodegaViewModel.BodegaId,
                Direccion = bodegaViewModel.Direccion,
            };
            return bodega;
        }

        public static List<BodegaViewModel> ListViewModel(IEnumerable<Bodega> lstModel)
        {
            List<BodegaViewModel> listViewModel = new List<BodegaViewModel>();
            foreach (var model in lstModel)
            {
                listViewModel.Add(ConvertToViewModel(model));
            }
            return listViewModel;
        }
    }
}
