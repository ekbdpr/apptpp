using AppTpp.Core;
using Microsoft.Win32;
using System.Windows;
using System;
using System.IO;
using AppTpp.Services;
using System.Threading.Tasks;

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

        public RelayCommand ChooseFileCommand { get; set; }
        public RelayCommand ImportFileCommand { get; set; }

        public InputDataBatchVM()
        {
            SetDefaultFileName();
            SpinnerView = new SmallSpinnerVM();

            SpinnerVisibility = Visibility.Collapsed;
            GreenCheckVisibility = Visibility.Collapsed;

            ChooseFileCommand = new RelayCommand(ChooseFile);
            ImportFileCommand = new RelayCommand(ImportFile);
        }

        private void SetDefaultFileName()
        {
            FileName = "No File Choosen";
        }

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

                CheckFolderExists(tempFolderPath);

                if (CheckFileExists(destinationPath))
                {
                    File.Copy(selectedFileName, destinationPath, true);
                    FileName = Path.GetFileName(selectedFileName);
                }
                else
                {
                    return;
                }
            }
        }

        private static void CheckFolderExists(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        private static bool CheckFileExists(string fileName)
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

        private async void ImportFile(object obj)
        {
            try
            {
                SpinnerVisibility = Visibility.Visible;
                await Task.Run(() => ExcelFilesService.ImportExcelToDatabase(_filePath));

                GreenCheckVisibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during execute: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                SpinnerVisibility = Visibility.Collapsed;

                SetDefaultFileName();
                DeleteFile();
            }
        }

        private void DeleteFile()
        {
            File.Delete(_filePath!);
        }
    }
}
