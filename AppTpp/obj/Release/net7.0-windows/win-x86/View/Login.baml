   M S B A M L   `   `   `  ���� A  =AppTpp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AppTpp.ViewModelAppTpp.ViewModel      AppTpp.Login   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -vmclr-namespace:AppTpp.ViewModel       � Title$  Login��$	��400��$	��500�� � AllowsTransparency$
 True��
������  � Icon$ /dashboard-logo.ico�� � 
ResizeMode$ NoResize=� J� SnapsToDevicePixels$
 True��   
windowLoad#��[   � UseLayoutRounding$
 True�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � DataContext   AppTpp.ViewModel.LoginVM  .����  	 Login#��[ ._���   Login_Border#��[ ._���   Login_Container#��[ .+���   
Login_Logo#��[ ��   
Login_Text#��[ $��Username����   Login_UserBox#��[ ���� *
Username+�� #��[ $��Password����   Login_PasswordBox#��[ ���� *
Password+��   Login_ErrorMessage#��[ ���� *ErrorMessage+��  	 Login_ButtonContainer#��[	 .+���  
 Login_LoginButton#��[
 ���� *LoginCommand+.����   	TextStyle#��[ $��Login���� -     Login_KeluarButton#��[ .���� #��[ $��Keluar����   Login_ExtraMessage#��[ $K��ELupa Password ? Silahkan menghubungi Admin di 081XXXXXXXXX (WhatsApp)��