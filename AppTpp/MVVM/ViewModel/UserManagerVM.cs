using AppTpp.MVVM.Model;
using AppTpp.Services;
using AppTpp.Core;
using AppTpp.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppTpp.MVVM.ViewModel
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

        public object? SpinnerView
        {
            get { return _spinnerView; }
            set { _spinnerView = value; OnPropertyChanged(nameof(SpinnerView)); }
        }

        public Visibility? SpinnerVisibility
        {
            get { return _spinnerVisibility; }
            set { _spinnerVisibility = value; OnPropertyChanged(nameof(SpinnerVisibility)); }
        }

        public Visibility? ContentVisibility
        {
            get { return _contentVisibility; }
            set { _contentVisibility = value; OnPropertyChanged(nameof(ContentVisibility)); }
        }

        public ICommand? AddDataCommand { get; set; }

        public UserManagerVM()
        {
            if (!IsInDesignMode)
            {
                SpinnerView = new SpinnerMainWindowVM();

                InitializeUserLogin();
                AddDataCommand = new RelayCommand(AddData);
                UserDataDialogVM.OnDataSaved += RefreshUsers;
            }
        }
        private static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor
                    .FromProperty(prop, typeof(FrameworkElement))
                    .Metadata.DefaultValue;
            }
        }

        private async void InitializeUserLogin()
        {
            try
            {
                SpinnerVisibility = Visibility.Visible;
                ContentVisibility = Visibility.Collapsed;

                await Task.Run(() => Users = new ObservableCollection<UserModel>(UserDataService.GetAllUsers()!));
            }
            finally
            {
                SpinnerVisibility = Visibility.Collapsed;
                ContentVisibility = Visibility.Visible;
            }
        }

        public static void AddData(object obj)
        {
            try
            {
                UserDataDialog userDataDialog = new UserDataDialog();

                if (Application.Current.MainWindow != null && Application.Current.MainWindow.IsLoaded)
                {
                    userDataDialog.Owner = Application.Current.MainWindow;
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
