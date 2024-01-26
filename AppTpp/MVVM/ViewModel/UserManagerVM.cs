using AppTpp.MVVM.Model;
using AppTpp.Services;
using AppTpp.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using AppTpp.MVVM.View.Components;
using System.Linq;

namespace AppTpp.MVVM.ViewModel
{
    class UserManagerVM : ViewModelBase
    {
        private ObservableCollection<UserModel> _users = new();
        public ObservableCollection<UserModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private ObservableCollection<UserModel> currentUsers = new();

        private object _spinnerView = new();
        public object? SpinnerView
        {
            get { return _spinnerView; }
            set { _spinnerView = value ?? new(); OnPropertyChanged(nameof(SpinnerView)); }
        }

        private Visibility _spinnerVisibility = Visibility.Collapsed;
        public Visibility SpinnerVisibility
        {
            get { return _spinnerVisibility; }
            set { _spinnerVisibility = value; OnPropertyChanged(nameof(SpinnerVisibility)); }
        }

        private Visibility _contentVisibility = Visibility.Collapsed;
        public Visibility ContentVisibility
        {
            get { return _contentVisibility; }
            set { _contentVisibility = value; OnPropertyChanged(nameof(ContentVisibility)); }
        }

        private UserModel _selectedUser = new();
        public UserModel SelectedUser
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

        private string _dataCountMessage = string.Empty;
        public string DataCountMessage
        {
            get { return _dataCountMessage; }
            set { _dataCountMessage = value; OnPropertyChanged(nameof(DataCountMessage)); }
        }

        private readonly int itemsPerPage = 10;
        private int startIndex = 0;
        private int currentPageCountUsers = 0;

        private int _currentPage = 1;
        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); }
        }

        public RelayCommand? AddUserCommand { get; set; }
        public RelayCommand? EditUserCommand { get; set; }
        public RelayCommand? DeleteUserCommand { get; set; }
        public RelayCommand? NextPageCommand { get; set; }
        public RelayCommand? PrevPageCommand { get; set; }

        public UserManagerVM()
        {
            if (!IsInDesignMode)
            {
                SpinnerView = new SpinnerMainWindowVM();

                InitializeUserList();

                AddUserCommand = new RelayCommand(OpenAddUserDialog);
                EditUserCommand = new RelayCommand(OpenEditUserDialog);
                DeleteUserCommand = new RelayCommand(DeleteUser);

                NextPageCommand = new RelayCommand(NextPage, CanNextPage);
                PrevPageCommand = new RelayCommand(PrevPage, CanPrevPage);

                DataDialogService.Instance.OnDataSaved += InitializeUserList;
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

        private async void InitializeUserList()
        {
            try
            {
                SpinnerVisibility = Visibility.Visible;
                ContentVisibility = Visibility.Collapsed;

                currentUsers = new ObservableCollection<UserModel>(UserDataService.GetAllUsers());

                startIndex = (CurrentPage - 1) * itemsPerPage;
                currentPageCountUsers = Math.Min(startIndex + itemsPerPage, currentUsers.Count);

                await Task.Run(() => Users = new ObservableCollection<UserModel>(currentUsers.Skip(startIndex).Take(itemsPerPage)));
            }
            finally
            {
                LoadDataCount();
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
                DataDialogService.OpenConfirmationDialog($"Apakah anda ingin menghapus ({_selectedUser.Nip} - {_selectedUser.Username}) dari sistem ?");

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
                            LoadDataCount();
                        }
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during execute: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanNextPage(object arg)
        {
            if (currentPageCountUsers >= currentUsers.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void NextPage(object obj)
        {
            CurrentPage++;
            InitializeUserList();
            LoadDataCount();
        }

        private bool CanPrevPage(object arg)
        {
            if (CurrentPage <= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void PrevPage(object obj)
        {
            CurrentPage--;
            InitializeUserList();
            LoadDataCount();
        }

        private void LoadDataCount()
        {
            string showDataCount = (currentPageCountUsers).ToString();
            string allDataCount = currentUsers.Count.ToString();

            DataCountMessage = $"{showDataCount} dari {allDataCount} pegawai";
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
            DataDialogService.Instance.OnDataSaved -= InitializeUserList;
            base.Dispose();
        }
    }
}