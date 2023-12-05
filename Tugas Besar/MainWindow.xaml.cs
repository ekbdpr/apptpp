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

namespace Tugas_Besar
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

            menuDataPegawai.Visibility = Visibility.Collapsed;
            menuDataTpp.Visibility = Visibility.Collapsed;

            tampilanInput.Visibility = Visibility.Collapsed;
            tampilanKelolaData.Visibility = Visibility.Collapsed;
            tampilanLihatLaporan.Visibility = Visibility.Collapsed;
            tampilanFormatArip.Visibility = Visibility.Collapsed;
            tampilanFormatSimgaji.Visibility = Visibility.Collapsed;
        }

        private void btnDataPegawai_Click(object sender, RoutedEventArgs e)
        {
            if(menuDataPegawai.Visibility == Visibility.Collapsed ) 
            {
                menuDataPegawai.Visibility= Visibility.Visible;
                menuDataTpp.Visibility = Visibility.Collapsed;

                ((Storyboard)btnDataPegawai.Resources["ToggleOpenMenu"]).Begin();
            } else
            {
                menuDataPegawai.Visibility= Visibility.Collapsed;
                ((Storyboard)btnDataPegawai.Resources["ToggleCloseMenu"]).Begin();
            }    
        }

        private void btnUnduhTpp_Click(object sender, RoutedEventArgs e)
        {
            if(menuDataTpp.Visibility == Visibility.Collapsed )
            {
                menuDataTpp.Visibility = Visibility.Visible;
                menuDataPegawai.Visibility = Visibility.Collapsed;
            } else
            {
                menuDataTpp.Visibility = Visibility.Collapsed;
            }            
        }

        private void btnInputData_Click(object sender, RoutedEventArgs e)
        {
            tampilanInput.Visibility = Visibility.Visible;

            tampilanKelolaData.Visibility = Visibility.Collapsed;
            tampilanLihatLaporan.Visibility = Visibility.Collapsed;
            tampilanFormatArip.Visibility = Visibility.Collapsed;
            tampilanFormatSimgaji.Visibility = Visibility.Collapsed;
        }

        private void btnHapusData_Click(object sender, RoutedEventArgs e)
        {
            tampilanKelolaData.Visibility = Visibility.Visible;

            tampilanInput.Visibility = Visibility.Collapsed;
            tampilanLihatLaporan.Visibility = Visibility.Collapsed;
            tampilanFormatArip.Visibility = Visibility.Collapsed;
            tampilanFormatSimgaji.Visibility = Visibility.Collapsed;
        }

        private void btnLihatLaporan_Click(object sender, RoutedEventArgs e)
        {
            tampilanLihatLaporan.Visibility = Visibility.Visible;

            tampilanInput.Visibility = Visibility.Collapsed;
            tampilanKelolaData.Visibility = Visibility.Collapsed;
            tampilanFormatArip.Visibility = Visibility.Collapsed;
            tampilanFormatSimgaji.Visibility = Visibility.Collapsed;
        }

        private void btnArip_Click(object sender, RoutedEventArgs e)
        {
            tampilanFormatArip.Visibility = Visibility.Visible;

            tampilanInput.Visibility = Visibility.Collapsed;
            tampilanKelolaData.Visibility = Visibility.Collapsed;
            tampilanLihatLaporan.Visibility = Visibility.Collapsed;
            tampilanFormatSimgaji.Visibility = Visibility.Collapsed;
        }

        private void btnSimgaji_Click(object sender, RoutedEventArgs e)
        {
            tampilanFormatSimgaji.Visibility = Visibility.Visible;

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
