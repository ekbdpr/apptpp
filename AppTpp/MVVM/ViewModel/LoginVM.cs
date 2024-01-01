using AppTpp.MVVM.Model;
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
        private readonly UserModel _userModel = new();
        private string? _errorMessage;
        private object? _spinner;
        private Visibility? _loading;

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

        public string? ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        public Visibility? Loading
        {
            get { return _loading; }
            set { _loading = value; OnPropertyChanged(nameof(Loading)); }
        }

        public object? Spinner
        {
            get { return _spinner; }
            set { _spinner = value; OnPropertyChanged(nameof(Spinner)); }
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
