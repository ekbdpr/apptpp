﻿using AppTpp.MVVM.Model;
using AppTpp.Services;
using AppTpp.Utilities;
using System;
using System.Windows;
using System.Windows.Input;

namespace AppTpp.MVVM.ViewModel
{
    internal class UserDataDialogVM : ViewModelBase
    {
        private readonly UserModel _userModel = new();

        public long? Nip
        {
            get { return _userModel.Nip; }
            set { _userModel.Nip = value; OnPropertyChanged(nameof(Nip)); }
        }

        public string? Nama
        {
            get { return _userModel.Name; }
            set { _userModel.Name = value; OnPropertyChanged(nameof(Nama)); }
        }

        public string? Jabatan
        {
            get { return _userModel.Jabatan; }
            set { _userModel.Jabatan = value; OnPropertyChanged(nameof(Jabatan)); }
        }

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

        public string? Privilege
        {
            get { return _userModel.Privilege; }
            set { _userModel.Privilege = value; OnPropertyChanged(nameof(Privilege)); }
        }

        public ICommand SaveCommand { get; }

        public UserDataDialogVM()
        {
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private bool CanSave(object obj)
        {
            string? nipStr = Nip.ToString();

            return !string.IsNullOrEmpty(nipStr) &&
                   !string.IsNullOrEmpty(Nama) &&
                   !string.IsNullOrEmpty(Jabatan) &&
                   !string.IsNullOrEmpty(Username) &&
                   !string.IsNullOrEmpty(Password) &&
                   !string.IsNullOrEmpty(Privilege);
        }

        public static event Action? OnDataSaved;

        private void Save(object obj)
        {
            try
            {
                UserDataService.InsertNewUser(Nip, Nama, Jabatan, Username, Password, Privilege);
                OnDataSaved?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this) window.Close();
                }
            }
        }
    }
}