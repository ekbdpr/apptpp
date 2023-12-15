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

        private void BtnDataPegawai_Click(object sender, RoutedEventArgs e)
        {
            if (menuDataPegawai.Visibility == Visibility.Hidden)
            {
                BtnDataPegawaiOpemAnimation();
            }
            else
            {
                BtnDataPegawaiCloseAnimation();
            }
        }

        private void BtnUnduhTpp_Click(object sender, RoutedEventArgs e)
        {
            if (menuDataTpp.Visibility == Visibility.Hidden)
            {
                BtnUnduhTppOpenAnimation();
            }
            else
            {
                BtnUnduhTppCloseAnimation();
            }
        }

        private void BtnDataPegawaiOpemAnimation()
        {
            Storyboard toggleOpenMenuStoryboard = (Storyboard)btnDataPegawai.Resources["ToggleOpenMenu"];

            DoubleAnimation bendaharaOpenAnimation = (DoubleAnimation)toggleOpenMenuStoryboard.Children[5];
            DoubleAnimation userManagerOpenAnimation = (DoubleAnimation)toggleOpenMenuStoryboard.Children[6];

            if (menuDataTpp.Visibility == Visibility.Hidden)
            {
                bendaharaOpenAnimation.From = -236;
                bendaharaOpenAnimation.To = -118;

                userManagerOpenAnimation.From = -236;
                userManagerOpenAnimation.To = -118;
            }

            if (menuDataTpp.Visibility == Visibility.Visible)
            {
                bendaharaOpenAnimation.From = -118;
                bendaharaOpenAnimation.To = 0;

                userManagerOpenAnimation.From = -118;
                userManagerOpenAnimation.To = 0;
            }

            menuDataPegawai.Visibility = Visibility.Visible;
            ((Storyboard)btnDataPegawai.Resources["ToggleOpenMenu"]).Begin();
        }

        private void BtnDataPegawaiCloseAnimation()
        {            
            Storyboard toggleCloseMenuStoryboard = (Storyboard)btnDataPegawai.Resources["ToggleCloseMenu"];

            DoubleAnimation bendaharaCloseAnimation = (DoubleAnimation)toggleCloseMenuStoryboard.Children[5];
            DoubleAnimation userManagerCloseAnimation = (DoubleAnimation)toggleCloseMenuStoryboard.Children[6];

            if (menuDataTpp.Visibility == Visibility.Hidden)
            {
                bendaharaCloseAnimation.From = -118;
                bendaharaCloseAnimation.To = -236;

                userManagerCloseAnimation.From = -118;
                userManagerCloseAnimation.To = -236;
            }

            if (menuDataTpp.Visibility == Visibility.Visible)
            {
                bendaharaCloseAnimation.From = 0;
                bendaharaCloseAnimation.To = -118;

                userManagerCloseAnimation.From = 0;
                userManagerCloseAnimation.To = -118;
            }

            menuDataPegawai.Visibility = Visibility.Hidden;
            ((Storyboard)btnDataPegawai.Resources["ToggleCloseMenu"]).Begin();
        }

        private void BtnUnduhTppOpenAnimation()
        {
            Storyboard toggleOpenMenuStoryboard = (Storyboard)btnUnduhTpp.Resources["ToggleOpenMenu"];

            DoubleAnimation tppOpenAnimation = (DoubleAnimation)toggleOpenMenuStoryboard.Children[0];
            DoubleAnimation bendaharaOpenAnimation = (DoubleAnimation)toggleOpenMenuStoryboard.Children[2];
            DoubleAnimation userManagerOpenAnimation = (DoubleAnimation)toggleOpenMenuStoryboard.Children[3];

            if (menuDataPegawai.Visibility == Visibility.Hidden)
            {
                tppOpenAnimation.From = -177;
                tppOpenAnimation.To = -118;

                bendaharaOpenAnimation.From = -236;
                bendaharaOpenAnimation.To = -118;

                userManagerOpenAnimation.From = -236;
                userManagerOpenAnimation.To = -118;
            }

            if (menuDataPegawai.Visibility == Visibility.Visible)
            {
                tppOpenAnimation.From = -59;
                tppOpenAnimation.To = 0;

                bendaharaOpenAnimation.From = -118;
                bendaharaOpenAnimation.To = 0;

                userManagerOpenAnimation.From = -118;
                userManagerOpenAnimation.To = 0;
            }

            menuDataTpp.Visibility = Visibility.Visible;
            ((Storyboard)btnUnduhTpp.Resources["ToggleOpenMenu"]).Begin();
        }

        private void BtnUnduhTppCloseAnimation()
        {
            Storyboard toggleCloseMenuStoryboard = (Storyboard)btnUnduhTpp.Resources["ToggleCloseMenu"];

            DoubleAnimation bendaharaCloseAnimation = (DoubleAnimation)toggleCloseMenuStoryboard.Children[2];
            DoubleAnimation userManagerCloseAnimation = (DoubleAnimation)toggleCloseMenuStoryboard.Children[3];

            if (menuDataPegawai.Visibility == Visibility.Hidden)
            {
                bendaharaCloseAnimation.From = -118;
                bendaharaCloseAnimation.To = -236;

                userManagerCloseAnimation.From = -118;
                userManagerCloseAnimation.To = -236;
            }

            if (menuDataPegawai.Visibility == Visibility.Visible)
            {
                bendaharaCloseAnimation.From = 0;
                bendaharaCloseAnimation.To = -118;

                userManagerCloseAnimation.From = 0;
                userManagerCloseAnimation.To = -118;
            }

            menuDataTpp.Visibility = Visibility.Hidden;
            ((Storyboard)btnUnduhTpp.Resources["ToggleCloseMenu"]).Begin();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
