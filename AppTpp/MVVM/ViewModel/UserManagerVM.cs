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

        public RelayCommand? AddUserCommand { get; set; }
        public RelayCommand? EditUserCommand { get; set; }
        public RelayCommand? DeleteUserCommand { get; set; }

        public UserManagerVM()
        {
            if (!IsInDesignMode)
            {
                SpinnerView = new SpinnerMainWindowVM();

                InitializeUsersList();
                AddUserCommand = new RelayCommand(OpenAddUserDialog);
                EditUserCommand = new RelayCommand(OpenEditUserDialog);
                DeleteUserCommand = new RelayCommand(DeleteUser);

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

        private void OpenAddUserDialog(object obj)
        {
            try
            {
                AddUserDialog addUserDialog = new();
                OpenDialog(addUserDialog);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during execute: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenEditUserDialog(object obj)
        {
            try
            {
                EditUserDialog editUserDialog = new();
                OpenDialog(editUserDialog);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during execute: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void DeleteUser(object obj)
        {
            try
            {
                DataDialogService.OpenConfirmationDialog($"Apakah anda ingin menghapus ({_selectedUser?.Nip} - {_selectedUser?.Username}) dari sistem ?");

                await Task.Run(async () =>
                {
                    await Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        if (DataDialogService.Instance.ConfirmationDialogState == false)
                        {
                            return;
                        }
                        else
                        {
                            UserDataService.DeleteUser(DataDialogService.Instance.CurrentUsername);
                            DataDialogService.Instance.InvokeDataSaved();
                        }
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during execute: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static void OpenDialog(Window dialog)
        {
            if (Application.Current.MainWindow != null && Application.Current.MainWindow.IsLoaded)
            {
                dialog.Owner = Application.Current.MainWindow;
            }

            dialog.ShowDialog();
        }

        public override void Dispose()
        {
            DataDialogService.Instance.OnDataSaved -= InitializeUsersList;
            base.Dispose();
        }
    }
}
