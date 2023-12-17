using AppTpp.Model;
using AppTpp.Services;
using AppTpp.Utilities;

namespace AppTpp.ViewModel
{
    internal class HomeVM : ViewModelBase
    {
        private readonly UserModel _userModel;

        public string Name
        {
            get { return _userModel.Name; }
            set { _userModel.Name = value; OnPropertyChanged(); }
        }
        
        public HomeVM()
        {
            _userModel = new UserModel();

            Name = UserDataService.Instance.CurrentUsername;
        }
    }
}
