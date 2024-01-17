using AppTpp.Core;
using AppTpp.MVVM.Model;
using AppTpp.Services;
using System.Collections.ObjectModel;

namespace AppTpp.MVVM.ViewModel
{
    internal class KelolaDataVM : ViewModelBase
    {
        private ObservableCollection<PegawaiModel>? _pegawai;
        public ObservableCollection<PegawaiModel>? Pegawai
        {
            get { return _pegawai; }
            set
            {
                _pegawai = value;
                OnPropertyChanged(nameof(PegawaiModel));
            }
        }

        public KelolaDataVM()
        {
            Pegawai = new ObservableCollection<PegawaiModel>(PegawaiDataService.GetAllDataPegawai());
        }
    }
}
