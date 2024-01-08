using AppTpp.Core;
using Microsoft.Win32;
using System.Windows;
using System;
using System.IO;

namespace AppTpp.MVVM.ViewModel
{
    internal class InputDataBatchVM : ViewModelBase
    {
        private string? fileName;
        public string? FileName
        {
            get { return fileName; }
            set { fileName = value; OnPropertyChanged(nameof(FileName)); }
        }

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

                if (!Directory.Exists(tempFolderPath))
                {
                    Directory.CreateDirectory(tempFolderPath);
                }

                string destinationPath = Path.Combine(tempFolderPath, Path.GetFileName(selectedFileName));

                File.Copy(selectedFileName, destinationPath, true);
                FileName = Path.GetFileName(selectedFileName);
            }
        }

        private void ImportFile(object obj)
        {

        }

    }
}
