using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace AppTpp.MVVM.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            PasswordBox.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "/Fonts/#password");
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            PasswordBox.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "/Fonts/#Fira Sans");
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "/Fonts/#password");
        }
    }
}
