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

        private object? _spinnerView;
        private Visibility? _spinnerVisibility;
        private Visibility? _contentVisibility;
        private VerticalAlignment? _contentVerticalAlignment;

        public object? SpinnerView
        {
            get { return _spinnerView; }
            set { _spinnerView = value; OnPropertyChanged(); }
        }

        public Visibility? SpinnerVisibility
        {
            get { return _spinnerVisibility; }
            set { _spinnerVisibility = value; OnPropertyChanged(); }
        }

        public Visibility? ContentVisibility
        {
            get { return _contentVisibility; }
            set { _contentVisibility = value; OnPropertyChanged(); }
        }
        public VerticalAlignment? ContentVerticalAlignment
        {
            get { return _contentVerticalAlignment; }
            set { _contentVerticalAlignment = value; OnPropertyChanged(); }
        }


        public ICommand AddDataCommand { get; set; }

        public UserManagerVM()
        {
            SpinnerView = new SpinnerMainWindowVM();

            InitializeUserLogin();
            AddDataCommand = new RelayCommand(AddData);
            UserDataDialogVM.OnDataSaved += RefreshUsers;
        }

        private async void InitializeUserLogin()
        { 
            try
            {
                SpinnerVisibility = Visibility.Visible;
                ContentVisibility = Visibility.Collapsed;
                ContentVerticalAlignment = VerticalAlignment.Center;

                await Task.Run(() =>
                {
                    Users = new ObservableCollection<UserModel>(UserDataService.GetAllUsers()!);
                });
            }
            finally
            {
                SpinnerVisibility = Visibility.Collapsed;
                ContentVisibility = Visibility.Visible;
                ContentVerticalAlignment = VerticalAlignment.Top;
            }

        }

        public static void AddData(object obj)
        {
            try
            {
                UserDataDialog userDataDialog = new UserDataDialog();

                if (App.Current.MainWindow != null && App.Current.MainWindow.IsLoaded)
                {
                    userDataDialog.Owner = App.Current.MainWindow;
                }

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
