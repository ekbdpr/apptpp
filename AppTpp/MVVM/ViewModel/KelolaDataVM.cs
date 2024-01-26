using AppTpp.Core;
using AppTpp.MVVM.Model;
using AppTpp.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace AppTpp.MVVM.ViewModel
{
    internal class KelolaDataVM : ViewModelBase
    {
        private ObservableCollection<PegawaiModel> _pegawai = new();
        public ObservableCollection<PegawaiModel> Pegawai
        {
            get { return _pegawai; }
            set
            {
                _pegawai = value;
                OnPropertyChanged(nameof(Pegawai));
            }
        }

        private ObservableCollection<PegawaiModel> currentPegawai = new();

        private PegawaiModel _selectedPegawai = new();

        public PegawaiModel SelectedPegawai
        {
            get { return _selectedPegawai; }
            set { _selectedPegawai = value; OnPropertyChanged(nameof(SelectedPegawai)); }
        }

        private string _bulan = string.Empty;
        public string Bulan
        {
            get { return _bulan; }
            set { _bulan = value; OnPropertyChanged(nameof(Bulan)); }
        }

        private string _tahun = string.Empty;
        public string Tahun
        {
            get { return _tahun; }
            set { _tahun = value; OnPropertyChanged(nameof(Tahun)); }
        }

        private string _dataCountMessage = string.Empty;
        public string DataCountMessage
        {
            get { return _dataCountMessage; }
            set { _dataCountMessage = value; OnPropertyChanged(nameof(DataCountMessage)); }
        }

        private readonly int itemsPerPage = 10;
        private int startIndex = 0;
        private int currentPageCountPegawai = 0;

        private int _currentPage = 1;
        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); }
        }

        public RelayCommand SearchFilteredPegawaiCommand { get; set; }
        public RelayCommand EditPegawaiCommand { get; set; }
        public RelayCommand DeletePegawaiCommand { get; set; }
        public RelayCommand NextPageCommand { get; set; }
        public RelayCommand PrevPageCommand { get; set; }

        public KelolaDataVM()
        {
            SearchFilteredPegawaiCommand = new RelayCommand(SearchFilteredPegawai);

            EditPegawaiCommand = new RelayCommand(EditPegawai);
            DeletePegawaiCommand = new RelayCommand(DeletePegawai);

            NextPageCommand = new RelayCommand(NextPage, CanNextPage);
            PrevPageCommand = new RelayCommand(PrevPage, CanPrevPage);
        }

        private string ConvertBulanToNumber()
        {
            return Bulan switch
            {
                "Januari" => "01",
                "Februari" => "02",
                "Maret" => "03",
                "April" => "04",
                "Mei" => "05",
                "Juni" => "06",
                "Juli" => "07",
                "Agustus" => "08",
                "September" => "09",
                "Oktober" => "10",
                "November" => "11",
                "Desember" => "12",
                _ => "0",
            };
        }

        private void SearchFilteredPegawai(object obj)
        {
            CurrentPage = 1;
            InitializePegawaiList();
        }

        private void EditPegawai(object obj)
        {
            throw new NotImplementedException();
        }

        private void DeletePegawai(object obj)
        {
            throw new NotImplementedException();
        }

        private void InitializePegawaiList()
        {
            try
            {
                var data = PegawaiDataService.GetAllDataPegawai(Tahun, ConvertBulanToNumber());
                currentPegawai = data != null ? new ObservableCollection<PegawaiModel>(data) : new ObservableCollection<PegawaiModel>();

                Console.WriteLine(currentPegawai[1].Name);

                startIndex = (CurrentPage - 1) * itemsPerPage;
                currentPageCountPegawai = Math.Min(startIndex + itemsPerPage, currentPegawai.Count);

                Pegawai = new ObservableCollection<PegawaiModel>(currentPegawai.Skip(startIndex).Take(itemsPerPage));

                LoadDataCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during execute: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private bool CanNextPage(object arg)
        {
            if (currentPageCountPegawai >= currentPegawai.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void NextPage(object obj)
        {
            CurrentPage++;

            InitializePegawaiList();
            LoadDataCount();
        }

        private bool CanPrevPage(object arg)
        {
            if (CurrentPage <= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void PrevPage(object obj)
        {
            CurrentPage--;

            InitializePegawaiList();
            LoadDataCount();
        }

        private void LoadDataCount()
        {
            string showDataCount = (currentPageCountPegawai).ToString();
            string allDataCount = currentPegawai.Count.ToString();

            DataCountMessage = $"{showDataCount} dari {allDataCount} pegawai";
        }
    }
}
