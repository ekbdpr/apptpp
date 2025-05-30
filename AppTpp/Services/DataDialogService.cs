﻿using AppTpp.MVVM.View.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppTpp.Services
{
    internal class DataDialogService
    {
        private static DataDialogService _instance = new();
        public static DataDialogService Instance
        {
            get
            {
                _instance ??= new DataDialogService();

                return _instance;
            }
        }

        public string CurrentNip { get; set; } = string.Empty;

        public string CurrentName { get; set; } = string.Empty;

        public string CurrentJabatan { get; set; } = string.Empty;

        public string CurrentUsername { get; set; } = string.Empty;

        public string CurrentPrivilege { get; set; } = string.Empty;

        public bool ConfirmationDialogState { get; set; }
        
        public string ConfirmationDialogMessage { get; set; } = string.Empty;


        private event Action? _onDataSaved;
        public event Action OnDataSaved
        {
            add
            {
                _onDataSaved += value;
            }
            remove
            {
                _onDataSaved -= value;
            }
        }

        public void InvokeDataSaved()
        {
            _onDataSaved?.Invoke();
        }

        public static void OpenConfirmationDialog(string messageText)
        {
            Instance.ConfirmationDialogMessage = messageText;

            ConfirmationDialog confirmationDialog = new();

            if (Application.Current.MainWindow != null && Application.Current.MainWindow.IsLoaded)
            {
                confirmationDialog.Owner = Application.Current.MainWindow;
            }

            confirmationDialog.ShowDialog();
        }
    }
}
