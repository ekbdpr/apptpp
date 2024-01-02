using System.Windows;

namespace AppTpp.MVVM.View.Components
{
    /// <summary>
    /// Interaction logic for UserDataDialog.xaml
    /// </summary>
    public partial class AddDataDialog : Window
    {
        public AddDataDialog()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
