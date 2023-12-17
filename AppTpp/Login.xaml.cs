using System.Windows;


namespace AppTpp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsMainWindowOpen())
            {
                this.Close();
            }

            return;
        }

        private static bool IsMainWindowOpen()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is MainWindow)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
