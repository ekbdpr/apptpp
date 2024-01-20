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

        private ObservableCollection<PegawaiModel>? currentData;

        private int _currentPage = 1;
        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); }
        }

        private string? _dataCountMessage;
        public string? DataCountMessage
        {
            get { return _dataCountMessage; }
            set { _dataCountMessage = value; OnPropertyChanged(nameof(DataCountMessage)); }
        }

        private readonly int itemsPerPage = 10;

        public RelayCommand NextPageCommand { get; set; }
        public RelayCommand PrevPageCommand { get; set; }

        public KelolaDataVM()
        {
            LoadData();
            LoadDataCount();

            NextPageCommand = new RelayCommand(NextPage, CanNextPage);
            PrevPageCommand = new RelayCommand(PrevPage, CanPrevPage);
        }

        private void LoadData()
        {
            currentData = new ObservableCollection<PegawaiModel>(PegawaiDataService.GetAllDataPegawai());

            int startIndex = (CurrentPage - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage - 1, currentData.Count - 1);

            Pegawai = new ObservableCollection<PegawaiModel>(currentData.Skip(startIndex).Take(endIndex));
        }

        private bool CanNextPage(object obj)
        {
            if (Math.Min(((CurrentPage - 1) * itemsPerPage) + itemsPerPage, currentData!.Count) >= currentData.Count)
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

            LoadData();
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

            LoadData();
            LoadDataCount();
        }

        private void LoadDataCount()
        {
            string showDataCount = Math.Min(((CurrentPage - 1) * itemsPerPage) + itemsPerPage, currentData!.Count).ToString();
            string currentDataCount = currentData.Count.ToString();

            DataCountMessage = $"{showDataCount} dari {currentDataCount} pegawai";
        }
    }
}
