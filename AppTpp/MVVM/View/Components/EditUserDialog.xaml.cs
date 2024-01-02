using System.Windows;

namespace AppTpp.MVVM.View.Components
{
    /// <summary>
    /// Interaction logic for EditDataDialog.xaml
    /// </summary>
    public partial class EditUserDialog : Window
    {
        public EditUserDialog()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
