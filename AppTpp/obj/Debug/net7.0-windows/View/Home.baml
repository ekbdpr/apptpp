   M S B A M L   `   `   `  ����A  =AppTpp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AppTpp.ViewModelAppTpp.ViewModel  5          AppTpp.View.Home   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -vmclr-namespace:AppTpp.ViewModel     5         
Page_Style#��[  5        � DataContext  5        AppTpp.ViewModel.HomeVM  5   
   .��5      (� $	��Top=�6   .��5   
   � $
��30,0q�6   $��Stretch=�6   .+�5      �  � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   .+�5      �� $��0��5      $��40(�5       $
��Bold"�5!        	TextStyle#��[ 5"      $��Selamat Datang,��5#      �� 5$      $��1��5%      $��50(�5&      $
��Bold"�5'      #��[ 5(      ��5)      �� *Name+ �� StringFormat$ {0} !���� 5*      $��2��5+      $��0,40,0,0q�5,      $��25(�5-      #��[ 5.      $3��-Silahkan memilih menu pada sidebar disamping.��5/      $
��Wrap=�50      �� 51      $��3��52      $��0,10,0,0q�53      $��20(�54      #��[ 55      $���Jika mengalami kendala silahkan lakukan relogin akun anda. Jika masih mengalami kendala yang sama, silahkan menghubungi admin !��56      $
��Wrap=�57      �� 58      $��4��59      $	��500��5:      $��0,50,0,-100q�5;      $��/Images/welcome.png��5<      5>      5@      5B      5D      