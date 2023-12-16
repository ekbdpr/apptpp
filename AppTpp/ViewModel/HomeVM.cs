using AppTpp.Model;
using AppTpp.Services;
using AppTpp.Utilities;
using System.Windows;

namespace AppTpp.ViewModel
{
    internal class HomeVM : ViewModelBase
    {
        private readonly UserModel _userModel;

        public string Username
        {
            get { return _userModel.Name; }
            set { _userModel.Name = value; OnPropertyChanged(); }
        }
        
        public HomeVM()
        {
            _userModel = new UserModel();
            Username = UserDataService.Instance.CurrentUsername;
        }
    }
}
