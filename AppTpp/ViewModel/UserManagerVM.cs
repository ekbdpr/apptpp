using AppTpp.Model;
using AppTpp.Services;
using AppTpp.Utilities;
using AppTpp.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AppTpp.ViewModel
{
    class UserManagerVM : ViewModelBase
    {
        private ObservableCollection<UserModel> _users;

        public ObservableCollection<UserModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public ICommand AddDataCommand { get; set; }

        public UserManagerVM()
        {
            Users = new ObservableCollection<UserModel>(UserDataService.GetAllUsers());

            AddDataCommand = new RelayCommand(AddData);
        }

        public static void AddData(object obj)
        {
            UserDataDialog userDataDialog = new();
            userDataDialog.Show();
        }
    }
}
