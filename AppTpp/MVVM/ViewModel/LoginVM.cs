using AppTpp.MVVM.Model;
using AppTpp.Services;
using AppTpp.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AppTpp.MVVM.View;

namespace AppTpp.MVVM.ViewModel
{
    class LoginVM : ViewModelBase
    {
        private readonly UserModel _userModel = new();

        public string Username
        {
            get { return _userModel.Username; }
            set { _userModel.Username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get { return _userModel.Password; }
            set { _userModel.Password = value; OnPropertyChanged(nameof(Password)); }
        }

        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        private Visibility _loading;
        public Visibility Loading
        {
            get { return _loading; }
            set { _loading = value; OnPropertyChanged(nameof(Loading)); }
        }

        private object _spinner = new();
        public object Spinner
        {
            get { return _spinner; }
            set { _spinner = value; OnPropertyChanged(nameof(Spinner)); }
        }

        public RelayCommand LoginCommand { get; }

        public LoginVM()
        {
            //Set default state
            Loading = Visibility.Collapsed;

            Spinner = new SpinnerVM();

            LoginCommand = new RelayCommand(Login);
        }

        private async void Login(object obj)
        {
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
            }
        }

        private bool IsValidUser() => UserDataService.Instance.GetUserLoginData(Username, Password) && UserDataService.Instance.GetUserPhoto(Username);

        private static void OpenMainWindow()
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault() ?? new();
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
