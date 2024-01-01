using AppTpp.Utilities;
using System.Windows.Input;

namespace AppTpp.MVVM.ViewModel
{
    class MainWindowVM : ViewModelBase
    {
        private object? _currentview;
        private object? _userInfoView;

        public object? Currentview
        {
            get { return _currentview; }
            set { _currentview = value; OnPropertyChanged(nameof(Currentview)); }
        }

        public object? UserInfoView
        {
            get { return _userInfoView; }
            set { _userInfoView = value; OnPropertyChanged(nameof(UserInfoView)); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand InputDataBatchCommand { get; set; }
        public ICommand KelolaDataCommand { get; set; }
        public ICommand LihatLaporanCommand { get; set; }
        public ICommand FormatAripCommand { get; set; }
        public ICommand FormatSimgajiCommand { get; set; }
        public ICommand BendaharaCommand { get; set; }
        public ICommand UserManagerCommand { get; set; }

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
