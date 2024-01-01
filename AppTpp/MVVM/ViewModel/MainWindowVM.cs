using AppTpp.Core;
using System.Windows.Input;

namespace AppTpp.MVVM.ViewModel
{
    class MainWindowVM : ViewModelBase
    {
        private object? _currentview;
        public object? Currentview
        {
            get { return _currentview; }
            set { _currentview = value; OnPropertyChanged(nameof(Currentview)); }
        }

        private object? _userInfoView;
        public object? UserInfoView
        {
            get { return _userInfoView; }
            set { _userInfoView = value; OnPropertyChanged(nameof(UserInfoView)); }
        }

        public RelayCommand HomeCommand { get; set; }
        public RelayCommand InputDataBatchCommand { get; set; }
        public RelayCommand KelolaDataCommand { get; set; }
        public RelayCommand LihatLaporanCommand { get; set; }
        public RelayCommand FormatAripCommand { get; set; }
        public RelayCommand FormatSimgajiCommand { get; set; }
        public RelayCommand BendaharaCommand { get; set; }
        public RelayCommand UserManagerCommand { get; set; }

        private void Home(object obj) => Currentview = new HomeVM();
        private void InputDataBatch(object obj) => Currentview = new InputDataBatchVM();
        private void KelolaData(object obj) => Currentview = new KelolaDataVM();
        private void LihatLaporan(object obj) => Currentview = new LihatLaporanVM();
        private void FormatArip(object obj) => Currentview = new FormatAripVM();
        private void FormatSimgaji(object obj) => Currentview = new FormatSimgajiVM();
        private void Bendahara(object obj) => Currentview = new BendaharaVM();
        private void UserManager(object obj) => Currentview = new UserManagerVM();


        public MainWindowVM()
        {
            HomeCommand = new RelayCommand(Home);
            InputDataBatchCommand = new RelayCommand(InputDataBatch);
            KelolaDataCommand = new RelayCommand(KelolaData);
            LihatLaporanCommand = new RelayCommand(LihatLaporan);
            FormatAripCommand = new RelayCommand(FormatArip);
            FormatSimgajiCommand = new RelayCommand(FormatSimgaji);
            BendaharaCommand = new RelayCommand(Bendahara);
            UserManagerCommand = new RelayCommand(UserManager);

            Currentview = new HomeVM();
            UserInfoView = new UserInfoVM();
        }
    }
}
