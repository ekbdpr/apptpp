using AppTpp.Model;
using AppTpp.Services;
using AppTpp.Utilities;
using AppTpp.View;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace AppTpp.ViewModel
{
    class UserManagerVM : ViewModelBase
    {
        private ObservableCollection<UserModel>? _users;

        public ObservableCollection<UserModel>? Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public ICommand AddDataCommand { get; set; }

        public UserManagerVM()
        {
            Users = new ObservableCollection<UserModel>(UserDataService.GetAllUsers()!);

            AddDataCommand = new RelayCommand(AddData);

            UserDataDialogVM.OnDataSaved += RefreshUsers;
        }

        public static void AddData(object obj)
        {
            try
            {
                UserDataDialog userDataDialog = new UserDataDialog();
                userDataDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefreshUsers()
        {
            Users = new ObservableCollection<UserModel>(UserDataService.GetAllUsers()!);
        }
    }
}
