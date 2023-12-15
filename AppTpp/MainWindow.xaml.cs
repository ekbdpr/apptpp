using System.Windows;
using System.Windows.Media.Animation;

namespace AppTpp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnDataPegawai_Click(object sender, RoutedEventArgs e)
        {
            if (menuDataPegawai.Visibility == Visibility.Hidden)
            {
                menuDataPegawai.Visibility = Visibility.Visible;
                ((Storyboard)btnDataPegawai.Resources["ToggleOpenMenu"]).Begin();
            }
            else
            {
                menuDataPegawai.Visibility = Visibility.Hidden;
                ((Storyboard)btnDataPegawai.Resources["ToggleCloseMenu"]).Begin();
            }
        }

        private void btnUnduhTpp_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation tppOpenAnimation;

            Storyboard toggleOpenMenuStoryboard = (Storyboard)btnUnduhTpp.Resources["ToggleOpenMenu"];
            tppOpenAnimation = (DoubleAnimation)toggleOpenMenuStoryboard.Children[0];

            if (menuDataTpp.Visibility == Visibility.Hidden)
            {
                if (menuDataPegawai.Visibility == Visibility.Hidden)
                {
                    tppOpenAnimation.From = -177;
                    tppOpenAnimation.To = -118;
                }

                if (menuDataPegawai.Visibility == Visibility.Visible)
                {
                    tppOpenAnimation.From = -59;
                    tppOpenAnimation.To = 0;
                }

                menuDataTpp.Visibility = Visibility.Visible;
                ((Storyboard)btnUnduhTpp.Resources["ToggleOpenMenu"]).Begin();
            }
            else
            {
                menuDataTpp.Visibility = Visibility.Hidden;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
