using System.Windows;

namespace AppTpp.MVVM.View.Components
{
    /// <summary>
    /// Interaction logic for UserDataDialog.xaml
    /// </summary>
    public partial class AddUserDialog : Window
    {
        public AddUserDialog()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
