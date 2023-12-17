using AppTpp.Model;
using AppTpp.Services;
using AppTpp.Utilities;
using Microsoft.Win32;
using System.Windows.Input;

namespace AppTpp.ViewModel
{
    internal class UserInfoVM : ViewModelBase
    {
        private readonly UserModel _userModel;

        public string Name
        {
            get { return _userModel.Name; }
            set { _userModel.Name = value; OnPropertyChanged(); }
        }

        public string Privilege
        {
            get { return _userModel.Privilege; }
            set { _userModel.Privilege = value; OnPropertyChanged(); }
        }

        public ICommand ChangeImageCommand { get; }

        public UserInfoVM()
        {
            _userModel = new UserModel();

            Name = UserDataService.Instance.CurrentUsername;
            Privilege = UserDataService.Instance.CurrentPrivilege;

            ChangeImageCommand = new RelayCommand(OpenFileDialog);
        }

        public static void OpenFileDialog(object obj)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png|All Files (*.*)|*.*"
            };
            openFileDialog.ShowDialog();
        }
    }
}
