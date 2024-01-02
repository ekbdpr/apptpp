using System.Windows;

namespace AppTpp.MVVM.View.Components
{
    /// <summary>
    /// Interaction logic for EditDataDialog.xaml
    /// </summary>
    public partial class EditDataDialog : Window
    {
        public EditDataDialog()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
