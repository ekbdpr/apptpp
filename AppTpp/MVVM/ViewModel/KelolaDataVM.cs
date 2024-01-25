using AppTpp.Core;
using AppTpp.MVVM.Model;
using AppTpp.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

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
                OnPropertyChanged(nameof(Pegawai));
            }
        }

        private ObservableCollection<PegawaiModel>? currentPegawai;

        private PegawaiModel? _selectedPegawai;

        public PegawaiModel? SelectedPegawai
        {
            get { return _selectedPegawai; }
            set { _selectedPegawai = value; OnPropertyChanged(nameof(SelectedPegawai)); }
        }

        private string? _dataCountMessage;
        public string? DataCountMessage
        {
            get { return _dataCountMessage; }
            set { _dataCountMessage = value; OnPropertyChanged(nameof(DataCountMessage)); }
        }

        private readonly int itemsPerPage = 10;
        private int startIndex;
        private int currentPageCountPegawai;

        private int _currentPage = 1;
        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); }
        }

        public RelayCommand EditPegawaiCommand { get; set; }
        public RelayCommand DeletePegawaiCommand { get; set; }
        public RelayCommand NextPageCommand { get; set; }
        public RelayCommand PrevPageCommand { get; set; }

        public KelolaDataVM()
        {
            InitializePegawaiList();

            EditPegawaiCommand = new RelayCommand(EditPegawai);
            DeletePegawaiCommand = new RelayCommand(DeletePegawai);

            NextPageCommand = new RelayCommand(NextPage, CanNextPage);
            PrevPageCommand = new RelayCommand(PrevPage, CanPrevPage);
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
            currentPegawai = new ObservableCollection<PegawaiModel>(PegawaiDataService.GetAllDataPegawai());

            startIndex = (CurrentPage - 1) * itemsPerPage;
            currentPageCountPegawai = Math.Min(startIndex + itemsPerPage, currentPegawai.Count);

            Pegawai = new ObservableCollection<PegawaiModel>(currentPegawai.Skip(startIndex).Take(itemsPerPage));

            LoadDataCount();
        }

        private bool CanNextPage(object arg)
        {
            if (currentPageCountPegawai >= currentPegawai!.Count)
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
            string allDataCount = currentPegawai!.Count.ToString();

            DataCountMessage = $"{showDataCount} dari {allDataCount} pegawai";
        }
    }
}
