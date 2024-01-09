using AppTpp.Core;
using Microsoft.Win32;
using System.Windows;
using System;
using System.IO;
using AppTpp.Services;

namespace AppTpp.MVVM.ViewModel
{
    internal class InputDataBatchVM : ViewModelBase
    {
        private string? _fileName;
        public string? FileName
        {
            get { return _fileName; }
            set { _fileName = value; OnPropertyChanged(nameof(FileName)); }
        }

        private string? _filePath;

        public RelayCommand ChooseFileCommand { get; set; }
        public RelayCommand ImportFileCommand { get; set; }

        public InputDataBatchVM()
        {
            FileName = "No File Choosen";

            ChooseFileCommand = new RelayCommand(ChooseFile);
            ImportFileCommand = new RelayCommand(ImportFile);
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
                CheckFileExists(destinationPath);

                File.Copy(selectedFileName, destinationPath, true);
                FileName = Path.GetFileName(selectedFileName);
            }
        }

        private static void CheckFolderExists(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        private static void CheckFileExists(string fileName)
        {
            if (File.Exists(fileName))
            {
                MessageBoxResult result = MessageBox.Show("The file already exists. Do you want to replace it?", "Replace File", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }
        }

        private void ImportFile(object obj)
        {
            ExcelFilesService.Instance.ImportExcelToDatabase(_filePath);
        }

    }
}
