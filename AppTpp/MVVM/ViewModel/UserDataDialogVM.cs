using AppTpp.Services;
using AppTpp.Utilities;
using System;
using System.Windows;
using System.Windows.Input;

namespace AppTpp.MVVM.ViewModel
{
    internal class UserDataDialogVM : ViewModelBase
    {
        private string? _nip { get; set; }
        private string? _nama { get; set; }
        private string? _jabatan { get; set; }
        private string? _username { get; set; }
        private string? _password { get; set; }

        private string? _privilege { get; set; }

        public string? Nip
        {
            get { return _nip; }
            set { _nip = value; OnPropertyChanged(nameof(Nip)); }
        }

        public string? Nama
        {
            get { return _nama; }
            set { _nama = value; OnPropertyChanged(nameof(Nama)); }
        }

        public string? Jabatan
        {
            get { return _jabatan; }
            set { _jabatan = value; OnPropertyChanged(nameof(Jabatan)); }
        }

        public string? Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string? Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string? Privilege
        {
            get { return _privilege; }
            set { _privilege = value; OnPropertyChanged(nameof(Privilege)); }
        }

        public ICommand SaveCommand { get; }

        public UserDataDialogVM()
        {
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

        public static event Action? OnDataSaved;

        private void Save(object obj)
        {
            try
            {
                UserDataService.InsertNewUser(Nip, Nama, Jabatan, Username, Password, Privilege);
                OnDataSaved?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this) window.Close();
                }
            }
        }
    }
}
