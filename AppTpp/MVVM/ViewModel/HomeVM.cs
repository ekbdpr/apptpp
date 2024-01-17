using AppTpp.MVVM.Model;
using AppTpp.Services;
using AppTpp.Core;

namespace AppTpp.MVVM.ViewModel
{
    internal class HomeVM : ViewModelBase
    {
        private readonly UserModel _userModel = new();

        public string? Name
        {
            get { return _userModel.Name; }
            set { _userModel.Name = value; OnPropertyChanged(nameof(Name)); }
        }

        public HomeVM()
        {
            Name = UserDataService.Instance.CurrentName;
        }
    }
}