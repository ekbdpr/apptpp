   M S B A M L   `   `   `  ���� A  =AppTpp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AppTpp.ViewModelAppTpp.ViewModel      AppTpp.View.Home   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -vmclr-namespace:AppTpp.ViewModel        
Page_Style#��[    � DataContext    AppTpp.ViewModel.HomeVM  .��(� $	��Top=�.��� $
��30,0q�$��Stretch=�.+��  � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��$��40(�$
��Bold"�  	TextStyle#��[ $��Selamat Datang,���� $��1��$��50(�$
��Bold"�#��[ ���� *Name+ �� StringFormat$ {0} !���� $��2��$��0,40,0,0q�$��25(�#��[ $3��-Silahkan memilih menu pada sidebar disamping.��$
��Wrap=��� $��3��$��0,10,0,0q�$��20(�#��[ $���Jika mengalami kendala silahkan lakukan relogin akun anda. Jika masih mengalami kendala yang sama, silahkan menghubungi admin !��$
��Wrap=��� $��4��$	��500��$��0,50,0,-100q�$��/Images/welcome.png��