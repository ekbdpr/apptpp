using AppTpp.MVVM.Model;
using AppTpp.Services;
using AppTpp.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AppTpp.MVVM.View;
using System;

namespace AppTpp.MVVM.ViewModel
{
    class LoginVM : ViewModelBase
    {
        private readonly UserModel _userModel = new();

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

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        private Visibility? _loading;
        public Visibility? Loading
        {
            get { return _loading; }
            set { _loading = value; OnPropertyChanged(nameof(Loading)); }
        }

        private object? _spinner;
        public object? Spinner
        {
            get { return _spinner; }
            set { _spinner = value; OnPropertyChanged(nameof(Spinner)); }
        }

        public RelayCommand LoginCommand { get; }

        public LoginVM()
        {
            Spinner = new SpinnerVM();

            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        private bool _isLoading;

        private bool CanLogin(object obj)
        {
            Loading = _isLoading ? Visibility.Visible : Visibility.Collapsed;
            return !_isLoading;
        }

        private async void Login(object obj)
        {
            _isLoading = true;

            try
            {
                Loading = Visibility.Visible;

                await Task.Run(() =>
                {
                    if (IsValidUser())
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            OpenMainWindow();
                            CloseCurrentWindow();
                        });
                    }
                    else
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            ErrorMessage = "* Username atau Password Tidak Valid";
                        });
                    }
                });
            }
            catch
            {
                ErrorMessage = "* Gagal Menghubungkan ke Server. Periksa Koneksi Internet Anda";
            }
            finally
            {
                Loading = Visibility.Collapsed;
                _isLoading = false;
            }
        }

        private bool IsValidUser() => UserDataService.Instance.GetUserLoginData(Username, Password) && UserDataService.Instance.GetUserPhoto(Username);

        private static void OpenMainWindow()
        {
            MainWindow? mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            mainWindow ??= new MainWindow();

            mainWindow.Show();
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
