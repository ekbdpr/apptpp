   M S B A M L   `   `   `  ����A  =AppTpp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AppTpp.ViewModelAppTpp.ViewModel  5          AppTpp.Login   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -vmclr-namespace:AppTpp.ViewModel     5        � Title$  Login��5      $	��400��5	      $	��500��5
       � AllowsTransparency$
 True��5      
������  � Icon$ /dashboard-logo.ico��5       � 
ResizeMode$ NoResize=�5       J� SnapsToDevicePixels$
 True��5         
windowLoad#��[  5       � UseLayoutRounding$
 True��5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       � DataContext 5        AppTpp.ViewModel.LoginVM  5   
   .��5      ��  	 Login#��[ 6   ._�5   
   ��   Login_Border#��[ 6   ._�5      ��   Login_Container#��[ 6   .+�5!      ��   
Login_Logo#��[ 6   �� 5$        
Login_Text#��[ 6   $��Username��6@   �� 5%        Login_UserBox#��[ 6   ��6A   �� *
Username+�� 5(      #��[ 6   $��Password��6@   �� 5)        Login_PasswordBox#��[ 6   ��6E   �� *
Password+�� 5,        Login_ErrorMessage#��[ 6   ��6H   �� *ErrorMessage+�� 5.       	 Login_ButtonContainer#��[	 6   .+�51      ��  
 Login_LoginButton#��[
 6>   ��6   �� *LoginCommand+.��52      ��   	TextStyle#��[ 6$   $��Login��6G   53      �� 56      -   5          Login_KeluarButton#��[ 56   7   .��57      �� #��[ 6$   $��Keluar��6G   58      5:      �� 5=        Login_ExtraMessage#��[ 6   $K��ELupa Password ? Silahkan menghubungi Admin di 081XXXXXXXXX (WhatsApp)��6H   5?      5A      5C      5E      