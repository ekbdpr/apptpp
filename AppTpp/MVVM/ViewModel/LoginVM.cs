using AppTpp.Services;
using AppTpp.Utilities;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppTpp.MVVM.ViewModel
{
    class LoginVM : ViewModelBase
    {
        private string? _username;
        private string? _password;
        private string? _errorMessage;
        private object? _spinner;
        private Visibility? _loading;

        public string? Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        public string? Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public string? ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public Visibility? Loading
        {
            get { return _loading; }
            set { _loading = value; OnPropertyChanged(); }
        }

        public object? Spinner
        {
            get { return _spinner; }
            set { _spinner = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

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
                            MainWindow? mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                            mainWindow ??= new MainWindow();

                            mainWindow.Show();

                            foreach (Window window in Application.Current.Windows)
                            {
                                if (window.DataContext == this) window.Close();
                            }
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
    }
}
