using AppTpp.MVVM.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;

namespace AppTpp.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeAnimations();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void InitializeAnimations()
        {
            Storyboard toggleOpenMenuDataPegawaiStoryboard = new();
            Storyboard toggleCloseMenuDataPegawaiStoryboard = new();

            Storyboard toggleOpenMenuUnduhTppStoryboard = new();
            Storyboard toggleCloseMenuUnduhTppStoryboard = new();

            //Open Menu Data Pegawai Animations
            CreateDoubleAnimation(menuDataPegawai, "(Button.RenderTransform).(TranslateTransform.Y)", -59, 0, TimeSpan.FromSeconds(0.2), toggleOpenMenuDataPegawaiStoryboard);
            CreateDoubleAnimation(menuDataPegawai, "Opacity", 0, 1, TimeSpan.FromSeconds(0.5), toggleOpenMenuDataPegawaiStoryboard);
            CreateDoubleAnimation(btnLihatLaporan, "(RadioButton.RenderTransform).(TranslateTransform.Y)", -118, 0, TimeSpan.FromSeconds(0.2), toggleOpenMenuDataPegawaiStoryboard);
            CreateDoubleAnimation(btnUnduhTpp, "(Button.RenderTransform).(TranslateTransform.Y)", -118, 0, TimeSpan.FromSeconds(0.2), toggleOpenMenuDataPegawaiStoryboard);
            CreateDoubleAnimation(menuUnduhTpp, "(Button.RenderTransform).(TranslateTransform.Y)", -118, 0, TimeSpan.FromSeconds(0.2), toggleOpenMenuDataPegawaiStoryboard);
            CreateDoubleAnimation(btnBendahara, "(Button.RenderTransform).(TranslateTransform.Y)", -236, -118, TimeSpan.FromSeconds(0.2), toggleOpenMenuDataPegawaiStoryboard);
            CreateDoubleAnimation(btnUserManager, "(Button.RenderTransform).(TranslateTransform.Y)", -236, -118, TimeSpan.FromSeconds(0.2), toggleOpenMenuDataPegawaiStoryboard);

            //Close Menu Data Pegawai Animations
            CreateDoubleAnimation(menuDataPegawai, "(Button.RenderTransform).(TranslateTransform.Y)", 0, -59, TimeSpan.FromSeconds(0.2), toggleCloseMenuDataPegawaiStoryboard);
            CreateDoubleAnimation(menuDataPegawai, "Opacity", 1, 0, TimeSpan.FromSeconds(0.5), toggleCloseMenuDataPegawaiStoryboard);
            CreateDoubleAnimation(btnLihatLaporan, "(RadioButton.RenderTransform).(TranslateTransform.Y)", 0, -118, TimeSpan.FromSeconds(0.2), toggleCloseMenuDataPegawaiStoryboard);
            CreateDoubleAnimation(btnUnduhTpp, "(Button.RenderTransform).(TranslateTransform.Y)", 0, -118, TimeSpan.FromSeconds(0.2), toggleCloseMenuDataPegawaiStoryboard);
            CreateDoubleAnimation(menuUnduhTpp, "(Button.RenderTransform).(TranslateTransform.Y)", 0, -118, TimeSpan.FromSeconds(0.2), toggleCloseMenuDataPegawaiStoryboard);
            CreateDoubleAnimation(btnBendahara, "(Button.RenderTransform).(TranslateTransform.Y)", -118, -236, TimeSpan.FromSeconds(0.2), toggleCloseMenuDataPegawaiStoryboard);
            CreateDoubleAnimation(btnUserManager, "(Button.RenderTransform).(TranslateTransform.Y)", -118, -236, TimeSpan.FromSeconds(0.2), toggleCloseMenuDataPegawaiStoryboard);

            //Open Menu Unduh Tpp Animations
            CreateDoubleAnimation(menuUnduhTpp, "(Button.RenderTransform).(TranslateTransform.Y)", -59, 0, TimeSpan.FromSeconds(0.2), toggleOpenMenuUnduhTppStoryboard);
            CreateDoubleAnimation(menuUnduhTpp, "Opacity", 0, 1, TimeSpan.FromSeconds(0.5), toggleOpenMenuUnduhTppStoryboard);
            CreateDoubleAnimation(btnBendahara, "(Button.RenderTransform).(TranslateTransform.Y)", -236, -118, TimeSpan.FromSeconds(0.2), toggleOpenMenuUnduhTppStoryboard);
            CreateDoubleAnimation(btnUserManager, "(Button.RenderTransform).(TranslateTransform.Y)", -236, -118, TimeSpan.FromSeconds(0.2), toggleOpenMenuUnduhTppStoryboard);

            //Close Menu Unduh Tpp Animations
            CreateDoubleAnimation(menuUnduhTpp, "(Button.RenderTransform).(TranslateTransform.Y)", 0, -59, TimeSpan.FromSeconds(0.2), toggleCloseMenuUnduhTppStoryboard);
            CreateDoubleAnimation(menuUnduhTpp, "Opacity", 1, 0, TimeSpan.FromSeconds(0.5), toggleCloseMenuUnduhTppStoryboard);
            CreateDoubleAnimation(btnBendahara, "(Button.RenderTransform).(TranslateTransform.Y)", -118, -236, TimeSpan.FromSeconds(0.2), toggleCloseMenuUnduhTppStoryboard);
            CreateDoubleAnimation(btnUserManager, "(Button.RenderTransform).(TranslateTransform.Y)", -118, -236, TimeSpan.FromSeconds(0.2), toggleCloseMenuUnduhTppStoryboard);

            Storyboard.SetTargetName(menuDataPegawai, menuDataPegawai.Name);
            Storyboard.SetTargetName(btnLihatLaporan, btnLihatLaporan.Name);
            Storyboard.SetTargetName(btnUnduhTpp, btnUnduhTpp.Name);
            Storyboard.SetTargetName(menuUnduhTpp, menuUnduhTpp.Name);
            Storyboard.SetTargetName(btnBendahara, btnBendahara.Name);
            Storyboard.SetTargetName(btnUserManager, btnUserManager.Name);

            Resources.Add("ToggleOpenDataPegawaiMenu", toggleOpenMenuDataPegawaiStoryboard);
            Resources.Add("ToggleCloseDataPegawaiMenu", toggleCloseMenuDataPegawaiStoryboard);

            Resources.Add("ToggleOpenUnduhTppMenu", toggleOpenMenuUnduhTppStoryboard);
            Resources.Add("ToggleCloseUnduhTppMenu", toggleCloseMenuUnduhTppStoryboard);
        }

        private static void CreateDoubleAnimation(FrameworkElement target, string property, double from, double to, TimeSpan duration, Storyboard storyboard)
        {
            DoubleAnimation doubleAnimation = new()
            {
                From = from,
                To = to,
                Duration = duration
            };

            Storyboard.SetTarget(doubleAnimation, target);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(property));

            storyboard.Children.Add(doubleAnimation);
        }


        private void BtnDataPegawai_Click(object sender, RoutedEventArgs e)
        {
            if (menuDataPegawai.Visibility == Visibility.Hidden)
            {
                BtnDataPegawaiOpenAnimation();
            }
            else
            {
                BtnDataPegawaiCloseAnimation();
            }
        }

        private void BtnUnduhTpp_Click(object sender, RoutedEventArgs e)
        {
            if (menuUnduhTpp.Visibility == Visibility.Hidden)
            {
                BtnUnduhTppOpenAnimation();
            }
            else
            {
                BtnUnduhTppCloseAnimation();
            }
        }

        private void BtnDataPegawaiOpenAnimation()
        {
            Storyboard toggleOpenMenuDataPegawaiStoryboard = (Storyboard)Resources["ToggleOpenDataPegawaiMenu"];

            DoubleAnimation bendaharaOpenAnimation = (DoubleAnimation)toggleOpenMenuDataPegawaiStoryboard.Children[5];
            DoubleAnimation userManagerOpenAnimation = (DoubleAnimation)toggleOpenMenuDataPegawaiStoryboard.Children[6];

            if (menuUnduhTpp.Visibility == Visibility.Hidden)
            {
                bendaharaOpenAnimation.From = -236;
                bendaharaOpenAnimation.To = -118;

                userManagerOpenAnimation.From = -236;
                userManagerOpenAnimation.To = -118;
            }

            if (menuUnduhTpp.Visibility == Visibility.Visible)
            {
                bendaharaOpenAnimation.From = -118;
                bendaharaOpenAnimation.To = 0;

                userManagerOpenAnimation.From = -118;
                userManagerOpenAnimation.To = 0;
            }

            menuDataPegawai.Visibility = Visibility.Visible;
            toggleOpenMenuDataPegawaiStoryboard.Begin();
        }

        private void BtnDataPegawaiCloseAnimation()
        {
            Storyboard toggleCloseMenuDataPegawaiStoryboard = (Storyboard)Resources["ToggleCloseDataPegawaiMenu"];

            DoubleAnimation bendaharaCloseAnimation = (DoubleAnimation)toggleCloseMenuDataPegawaiStoryboard.Children[5];
            DoubleAnimation userManagerCloseAnimation = (DoubleAnimation)toggleCloseMenuDataPegawaiStoryboard.Children[6];

            if (menuUnduhTpp.Visibility == Visibility.Hidden)
            {
                bendaharaCloseAnimation.From = -118;
                bendaharaCloseAnimation.To = -236;

                userManagerCloseAnimation.From = -118;
                userManagerCloseAnimation.To = -236;
            }

            if (menuUnduhTpp.Visibility == Visibility.Visible)
            {
                bendaharaCloseAnimation.From = 0;
                bendaharaCloseAnimation.To = -118;

                userManagerCloseAnimation.From = 0;
                userManagerCloseAnimation.To = -118;
            }

            menuDataPegawai.Visibility = Visibility.Hidden;
            toggleCloseMenuDataPegawaiStoryboard.Begin();
        }

        private void BtnUnduhTppOpenAnimation()
        {
            Storyboard toggleOpenMenuUnduhTppStoryboard = (Storyboard)Resources["ToggleOpenUnduhTppMenu"];

            DoubleAnimation tppOpenAnimation = (DoubleAnimation)toggleOpenMenuUnduhTppStoryboard.Children[0];
            DoubleAnimation bendaharaOpenAnimation = (DoubleAnimation)toggleOpenMenuUnduhTppStoryboard.Children[2];
            DoubleAnimation userManagerOpenAnimation = (DoubleAnimation)toggleOpenMenuUnduhTppStoryboard.Children[3];

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

            menuUnduhTpp.Visibility = Visibility.Visible;
            toggleOpenMenuUnduhTppStoryboard.Begin();
        }

        private void BtnUnduhTppCloseAnimation()
        {
            Storyboard toggleCloseMenuUnduhTppStoryboard = (Storyboard)Resources["ToggleCloseUnduhTppMenu"];

            DoubleAnimation bendaharaCloseAnimation = (DoubleAnimation)toggleCloseMenuUnduhTppStoryboard.Children[2];
            DoubleAnimation userManagerCloseAnimation = (DoubleAnimation)toggleCloseMenuUnduhTppStoryboard.Children[3];

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

            menuUnduhTpp.Visibility = Visibility.Hidden;
            toggleCloseMenuUnduhTppStoryboard.Begin();
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
