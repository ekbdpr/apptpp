using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            tampilanInput.Visibility = Visibility.Collapsed;
            tampilanKelolaData.Visibility = Visibility.Collapsed;
            tampilanLihatLaporan.Visibility = Visibility.Collapsed;
            tampilanFormatArip.Visibility = Visibility.Collapsed;
            tampilanFormatSimgaji.Visibility = Visibility.Collapsed;
        }

        private void btnDataPegawai_Click(object sender, RoutedEventArgs e)
        {
            if(menuDataPegawai.Visibility == Visibility.Hidden ) 
            {
                menuDataPegawai.Visibility= Visibility.Visible;
                ((Storyboard)btnDataPegawai.Resources["ToggleOpenMenu"]).Begin();
            } else
            {
                menuDataPegawai.Visibility= Visibility.Hidden;
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
                if(menuDataPegawai.Visibility == Visibility.Hidden)
                {
                    tppOpenAnimation.From = -177;
                    tppOpenAnimation.To = -118;
                }

                if(menuDataPegawai.Visibility == Visibility.Visible)
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

        private void btnInputData_Click(object sender, RoutedEventArgs e)
        {
            tampilanInput.Visibility = Visibility.Visible;

            tampilanUtama.Visibility = Visibility.Collapsed;
            tampilanKelolaData.Visibility = Visibility.Collapsed;
            tampilanLihatLaporan.Visibility = Visibility.Collapsed;
            tampilanFormatArip.Visibility = Visibility.Collapsed;
            tampilanFormatSimgaji.Visibility = Visibility.Collapsed;
        }

        private void btnHapusData_Click(object sender, RoutedEventArgs e)
        {
            tampilanKelolaData.Visibility = Visibility.Visible;

            tampilanUtama.Visibility = Visibility.Collapsed;
            tampilanInput.Visibility = Visibility.Collapsed;
            tampilanLihatLaporan.Visibility = Visibility.Collapsed;
            tampilanFormatArip.Visibility = Visibility.Collapsed;
            tampilanFormatSimgaji.Visibility = Visibility.Collapsed;
        }

        private void btnLihatLaporan_Click(object sender, RoutedEventArgs e)
        {
            tampilanLihatLaporan.Visibility = Visibility.Visible;

            tampilanUtama.Visibility = Visibility.Collapsed;
            tampilanInput.Visibility = Visibility.Collapsed;
            tampilanKelolaData.Visibility = Visibility.Collapsed;
            tampilanFormatArip.Visibility = Visibility.Collapsed;
            tampilanFormatSimgaji.Visibility = Visibility.Collapsed;
        }

        private void btnArip_Click(object sender, RoutedEventArgs e)
        {
            tampilanFormatArip.Visibility = Visibility.Visible;

            tampilanUtama.Visibility = Visibility.Collapsed;
            tampilanInput.Visibility = Visibility.Collapsed;
            tampilanKelolaData.Visibility = Visibility.Collapsed;
            tampilanLihatLaporan.Visibility = Visibility.Collapsed;
            tampilanFormatSimgaji.Visibility = Visibility.Collapsed;
        }

        private void btnSimgaji_Click(object sender, RoutedEventArgs e)
        {
            tampilanFormatSimgaji.Visibility = Visibility.Visible;

            tampilanUtama.Visibility = Visibility.Collapsed;
            tampilanInput.Visibility = Visibility.Collapsed;
            tampilanKelolaData.Visibility = Visibility.Collapsed;
            tampilanLihatLaporan.Visibility = Visibility.Collapsed;
            tampilanFormatArip.Visibility = Visibility.Collapsed;
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
