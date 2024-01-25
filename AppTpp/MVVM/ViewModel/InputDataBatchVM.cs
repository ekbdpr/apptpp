using AppTpp.Core;
using Microsoft.Win32;
using System.Windows;
using System;
using System.IO;
using AppTpp.Services;
using System.Threading.Tasks;
using AppTpp.Exceptions;

namespace AppTpp.MVVM.ViewModel
{
    internal class InputDataBatchVM : ViewModelBase
    {
        private string? _filePath;

        private string? _fileName;
        public string? FileName
        {
            get { return _fileName; }
            set { _fileName = value; OnPropertyChanged(nameof(FileName)); }
        }

        private string? _bulan;
        public string? Bulan
        {
            get { return _bulan; }
            set { _bulan = value; OnPropertyChanged(nameof(Bulan)); }
        }

        private string? _tahun;
        public string? Tahun
        {
            get { return _tahun; }
            set { _tahun = value; OnPropertyChanged(nameof(Tahun)); }
        }

        private object? _spinnerView;
        public object? SpinnerView
        {
            get { return _spinnerView; }
            set { _spinnerView = value; OnPropertyChanged(nameof(SpinnerView)); }
        }

        private Visibility? _spinnerVisibility;
        public Visibility? SpinnerVisibility
        {
            get { return _spinnerVisibility; }
            set { _spinnerVisibility = value; OnPropertyChanged(nameof(SpinnerVisibility)); }
        }

        private Visibility? _greenCheckVisibility;
        public Visibility? GreenCheckVisibility
        {
            get { return _greenCheckVisibility; }
            set { _greenCheckVisibility = value; OnPropertyChanged(nameof(GreenCheckVisibility)); }
        }

        private Visibility? _redCrossVisibility;
        public Visibility? RedCrossVisibility
        {
            get { return _redCrossVisibility; }
            set { _redCrossVisibility = value; OnPropertyChanged(nameof(RedCrossVisibility)); }
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        public RelayCommand ChooseFileCommand { get; set; }
        public RelayCommand ImportFileCommand { get; set; }

        public InputDataBatchVM()
        {
            //Set default state
            InitialFileState();
            InitialIconState();

            SpinnerView = new SmallSpinnerVM();

            ChooseFileCommand = new RelayCommand(ChooseFile);
            ImportFileCommand = new RelayCommand(ImportFile, CanImport);
        }

        private void InitialIconState()
        {
            SpinnerVisibility = Visibility.Collapsed;
            GreenCheckVisibility = Visibility.Collapsed;
            RedCrossVisibility = Visibility.Collapsed;
        }

        private void InitialFileState()
        {
            FileName = "No File Choosen";
            _isFileUploaded = false;
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

        private bool _isFileUploaded;

        private void ChooseFile(object obj)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls|All Files (*.*)|*.*"
            };

            SaveFileToTempFolder(openFileDialog);
        }

        private void SaveFileToTempFolder(OpenFileDialog openFileDialog)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog.FileName;
                string tempFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
                string destinationPath = Path.Combine(tempFolderPath, Path.GetFileName(selectedFileName));

                _filePath = destinationPath;

                CreateTempFolder(tempFolderPath);

                if (IsFileExists(destinationPath))
                {
                    File.Copy(selectedFileName, destinationPath, true);
                    FileName = Path.GetFileName(selectedFileName);

                    _isFileUploaded = true;
                }
                else
                {
                    return;
                }
            }
        }

        private static void CreateTempFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        private static bool IsFileExists(string fileName)
        {
            if (File.Exists(fileName))
            {
                DataDialogService.OpenConfirmationDialog("Berkas tersebut sudah ada. Apakah Anda ingin menggantinya?");

                if (DataDialogService.Instance.ConfirmationDialogState == false)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CanImport(object arg)
        {
            return _isFileUploaded;
        }

        private async void ImportFile(object obj)
        {
            InitialIconState();

            try
            {
                SpinnerVisibility = Visibility.Visible;
                await Task.Run(() => PegawaiDataService.ImportExcelToDatabase(_filePath, Tahun, ConvertBulanToNumber()));

                GreenCheckVisibility = Visibility.Visible;
                SpinnerVisibility = Visibility.Collapsed;

                InitialFileState();
                DeleteFile();
            }
            catch (DuplicateDataException ex)
            {
                ErrorMessage = ex.Message;

                SpinnerVisibility = Visibility.Collapsed;
                RedCrossVisibility = Visibility.Visible;
            }
        }

        private void DeleteFile()
        {
            File.Delete(_filePath!);
        }
    }
}