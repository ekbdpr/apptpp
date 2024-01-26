using AppTpp.MVVM.Model;
using AppTpp.Services;
using AppTpp.Core;
using Microsoft.Win32;
using System.IO;
using System.Reflection;

namespace AppTpp.MVVM.ViewModel
{
    internal class UserInfoVM : ViewModelBase
    {
        private readonly UserModel _userModel;

        public string Name
        {
            get { return _userModel.Name; }
            set { _userModel.Name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Privilege
        {
            get { return _userModel.Privilege; }
            set { _userModel.Privilege = value; OnPropertyChanged(nameof(Privilege)); }
        }

        public byte[]? ProfileImage
        {
            get { return _userModel.ProfileImage; }
            set { _userModel.ProfileImage = value; OnPropertyChanged(nameof(ProfileImage)); }
        }

        public RelayCommand ChangeProfileImageCommand { get; }

        public UserInfoVM()
        {
            _userModel = new UserModel();
            UpdateUserInfo();

            ChangeProfileImageCommand = new RelayCommand(ChangeProfileImage);
        }

        public void ChangeProfileImage(object obj)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png|All Files (*.*)|*.*"
            };

            UserDataService.Instance.SaveImageToDB(openFileDialog);
            UpdateUserInfo();
        }

        public void UpdateUserInfo()
        {
            Name = UserDataService.Instance.CurrentName;
            Privilege = UserDataService.Instance.CurrentPrivilege;
            ProfileImage = UserDataService.Instance.CurrentProfileImage == null || UserDataService.Instance.CurrentProfileImage.Length == 0 ? GetDefaultProfileImage() : UserDataService.Instance.CurrentProfileImage;
        }

        private static byte[] GetDefaultProfileImage()
        {
            string epath = Assembly.GetExecutingAssembly().Location;
            string filepath = epath[..(epath.LastIndexOf('\\') + 1)] + "Images/avatar.png";
            byte[] defaultImage = File.ReadAllBytes(filepath);

            return defaultImage;
        }
    }
}