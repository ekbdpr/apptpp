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

        private string? _dataCountMessage;
        public string? DataCountMessage
        {
            get { return _dataCountMessage; }
            set { _dataCountMessage = value; OnPropertyChanged(nameof(DataCountMessage)); }
        }

        private readonly int itemsPerPage = 10;
        private int startIndex;
        private int endIndex;

        private int _currentPage = 1;
        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); }
        }

        public RelayCommand NextPageCommand { get; set; }
        public RelayCommand PrevPageCommand { get; set; }

        public KelolaDataVM()
        {
            InitializePegawaiList();

            NextPageCommand = new RelayCommand(NextPage, CanNextPage);
            PrevPageCommand = new RelayCommand(PrevPage, CanPrevPage);
        }

        private void InitializePegawaiList()
        {
            currentPegawai = new ObservableCollection<PegawaiModel>(PegawaiDataService.GetAllDataPegawai());

            startIndex = (CurrentPage - 1) * itemsPerPage;
            endIndex = Math.Min(startIndex + itemsPerPage - 1, currentPegawai.Count - 1);

            Pegawai = new ObservableCollection<PegawaiModel>(currentPegawai.Skip(startIndex).Take(endIndex));

            LoadDataCount();
        }

        private bool CanNextPage(object arg)
        {
            if (endIndex + 1 >= currentPegawai!.Count)
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
            string showDataCount = (endIndex + 1).ToString();
            string allDataCount = currentPegawai!.Count.ToString();

            DataCountMessage = $"{showDataCount} dari {allDataCount} pegawai";
        }
    }
}
