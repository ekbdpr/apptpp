using AppTpp.MVVM.Model;
using AppTpp.Services;
using AppTpp.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using AppTpp.MVVM.View.Components;

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

        private Visibility? _contentVisibility;
        public Visibility? ContentVisibility
        {
            get { return _contentVisibility; }
            set { _contentVisibility = value; OnPropertyChanged(nameof(ContentVisibility)); }
        }

        private UserModel? _selectedUser;
        public UserModel? SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));

                if (_selectedUser != null)
                {
                    DataDialogService.Instance.CurrentNip = _selectedUser.Nip;
                    DataDialogService.Instance.CurrentName = _selectedUser.Name;
                    DataDialogService.Instance.CurrentJabatan = _selectedUser.Jabatan;
                    DataDialogService.Instance.CurrentUsername = _selectedUser.Username;
                    DataDialogService.Instance.CurrentPrivilege = _selectedUser.Privilege;
                }
            }
        }

        public RelayCommand? AddDataCommand { get; set; }
        public RelayCommand? EditDataCommand { get; set; }

        public UserManagerVM()
        {
            if (!IsInDesignMode)
            {
                SpinnerView = new SpinnerMainWindowVM();

                InitializeUsersList();
                AddDataCommand = new RelayCommand(OpenAddDataDialog);
                EditDataCommand = new RelayCommand(OpenEditDataDialog);

                DataDialogService.Instance.OnDataSaved += InitializeUsersList;
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

        private async void InitializeUsersList()
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

        public static void OpenAddDataDialog(object obj)
        {
            try
            {
                AddDataDialog addDataDialog = new();

                if (Application.Current.MainWindow != null && Application.Current.MainWindow.IsLoaded)
                {
                    addDataDialog.Owner = Application.Current.MainWindow;
                }

                addDataDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void OpenEditDataDialog(object obj)
        {
            try
            {
                EditDataDialog editDataDialog = new();

                if (Application.Current.MainWindow != null && Application.Current.MainWindow.IsLoaded)
                {
                    editDataDialog.Owner = Application.Current.MainWindow;
                }

                editDataDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public override void Dispose()
        {
            DataDialogService.Instance.OnDataSaved -= InitializeUsersList;
            base.Dispose();
        }
    }
}
