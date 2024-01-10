using AppTpp.MVVM.Model;
using AppTpp.Services;
using AppTpp.Core;
using System;
using System.Windows;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AppTpp.MVVM.ViewModel
{
    internal class EditUserDialogVM : ViewModelBase
    {
        private readonly UserModel _userModel = new();

        public string? Nip
        {
            get { return _userModel.Nip; }
            set { _userModel.Nip = value; OnPropertyChanged(nameof(Nip)); }
        }

        public string? Nama
        {
            get { return _userModel.Name; }
            set { _userModel.Name = value; OnPropertyChanged(nameof(Nama)); }
        }

        public string? Jabatan
        {
            get { return _userModel.Jabatan; }
            set { _userModel.Jabatan = value; OnPropertyChanged(nameof(Jabatan)); }
        }

        public string? Username
        {
            get { return _userModel.Username; }
            set { _userModel.Username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string? Password
        {
            get { return _userModel.Password; }
            set { _userModel.Password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string? Privilege
        {
            get { return _userModel.Privilege; }
            set { _userModel.Privilege = value; OnPropertyChanged(nameof(Privilege)); }
        }

        public RelayCommand SaveCommand { get; }

        public EditUserDialogVM()
        {
            Nip = DataDialogService.Instance.CurrentNip;
            Nama = DataDialogService.Instance.CurrentName;
            Jabatan = DataDialogService.Instance.CurrentJabatan;
            Username = DataDialogService.Instance.CurrentUsername;
            Privilege = DataDialogService.Instance.CurrentPrivilege;

            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private bool CanSave(object obj)
        {
            return !string.IsNullOrEmpty(Nip) &&
                   !string.IsNullOrEmpty(Nama) &&
                   !string.IsNullOrEmpty(Jabatan) &&
                   !string.IsNullOrEmpty(Username) &&
                   !string.IsNullOrEmpty(Password) &&
                   !string.IsNullOrEmpty(Privilege);
        }

        private async void Save(object obj)
        {
            try
            {
                await Task.Run(() => UserDataService.UpdateUser(Nip, Nama, Jabatan, Username, Password, Privilege));
                DataDialogService.Instance.InvokeDataSaved();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                CloseCurrentWindow();
            }
        }

        private void CloseCurrentWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this) window.Close();
            }
        }
    }
}
