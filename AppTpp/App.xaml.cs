﻿using AppTpp.MVVM.View;
using System.Windows;

namespace AppTpp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Login login = new();
            login.Show();

            base.OnStartup(e);
        }
    }
}
