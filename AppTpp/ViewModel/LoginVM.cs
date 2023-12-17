using AppTpp.Services;
using AppTpp.Utilities;
using System.Windows.Input;

namespace AppTpp.ViewModel
{
    class LoginVM : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _errorMessage;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        public LoginVM()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login(object obj)
        {
            if (IsValidUser())
            {
                MainWindow mainWindow = new();
                mainWindow.Show();
                return;
            }

            ErrorMessage = "* Username atau Password Tidak Valid";
        }

        private bool IsValidUser() => UserDataService.Instance.GetUserLoginData(Username, Password);


    }
}
