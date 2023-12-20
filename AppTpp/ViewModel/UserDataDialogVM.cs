using AppTpp.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppTpp.ViewModel
{
    internal class UserDataDialogVM : ViewModelBase
    {
        private string _username { get; set; }
        private string _password { get; set; }
        private string _nama { get; set; }
        private string _privilege { get; set; }

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string Nama
        {
            get { return _nama; }
            set { _nama = value; OnPropertyChanged(nameof(Nama)); }
        }

        public string Privilege
        {
            get { return _privilege; }
            set { _privilege = value; OnPropertyChanged(nameof(Privilege)); }
        }

        public ICommand SaveCommand { get; }

        public UserDataDialogVM()
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save(object obj)
        {
            Debug.WriteLine(Username);
            Debug.WriteLine(Password);
            Debug.WriteLine(Nama);
            Debug.WriteLine(Privilege);

            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this) window.Close();
            }

        }
    }
}
