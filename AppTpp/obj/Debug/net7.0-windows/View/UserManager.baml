   M S B A M L   `   `   `  ����A  =AppTpp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AppTpp.ViewModelAppTpp.ViewModel  5          AppTpp.View.UserManager   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -vmclr-namespace:AppTpp.ViewModel     5         
Page_Style#��[  5        � DataContext  5      $  AppTpp.ViewModel.UserManagerVM  5   
   .��5      (� $	��Top=�6   .��5   
   � $
��30,0q�6   $��Stretch=�6   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      �� $��40(�5      $
��Bold"�5        	TextStyle#��[ 5      $��User Manager��5      �� 5!      $��1��5"      $��	0,20,0,20q�5#      ���#A9A9A9$��0,0,0,1q�5%      �� 5'      $��2��6    �� Orientation$ 
Horizontal=�6*   .+�5(      �� $	��120��5)      $��30��5*      $��0,30,0,0q�5+      ���#3081D0$��0q�5-      $��SemiBold"�5/      
�������  OpacityButton#��[ 51      ��5.      �� *AddDataCommand+ � 	Resources 53       �� 
TargetType �� Property �� Value��%_   '��       �� 54      " ��6$   .�55   "   ��  �@��CornerRadius$ 10��6A   56      57      .��59      �� #��[ 6$   $��Add New Data��6G   5;      5<      � 5>      $��3��6   .+�5@      �� $��0,15,0,0q�5A      
����������#CCCCCC$��1q�5D       �� CornerRadius$ 5��5E       J� Effect 5G      3  -System.Windows.Media.Effects.DropShadowEffect  5I      	   	Direction$		 330Q�5J   !   
   Opacity$	
 0.5Q�5K   !      ShadowDepth$ 3Q�5L   !   ._�5P      &   System.Windows.Controls.DataGrid  $
��1000��5Q      $��10q�5R         AutoGenerateColumns$ False��5S      $��0q�5T         CanUserAddRows$ False��5U      $��/Fonts/#Fira Sans)�5V      ��5W      �� *Users+ �� IsAsync$
 True��   Columns 5Y      0  *System.Windows.Controls.DataGridTextColumn  5[   "   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5\   %      Header$	 NIP��5^   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5]   %   �� *Nip+5^   %     5_   "   $ * 5`   %   $
 Name��5b   %    5a   %   �� *Name+5b   %     5c   "   $ * 5d   %   $ Jabatan��5f   %    5e   %   �� *	Jabatan+5f   %     5g   "   $ * 5h   %   $ Username��5j   %    5i   %   �� *
Username+5j   %     5k   "   $ * 5l   %   $ 	Privilege��5n   %    5m   %   �� *	Privilege+5n   %   4  .System.Windows.Controls.DataGridTemplateColumn  5p   "   $
 Auto 69   $ Options��6F      CellTemplate 5q   &   �� 5r   *   .R�5t   .   �� $ 
Horizontal=�69   .+�5u   2   �� $��70��5v   5   $��25��5w   5   $��5,0,5,0q�5x   5   ���#FFB534$��0q�5z   5   $��SemiBold"�5{   5   
�������#��[ 5}   5    5   6   ��%_   '��       �� 5�   :   " ��6@   .�5�   >   ��  �@��CornerRadius$ 10��6]   5�   ;   5�   7   .��5�   6   �� #��[ 6@   $
��Edit��6c   5�   3   �� 5�   2   $��70��5�   5   $��25��5�   5   $��5,0,5,0q�5�   5   ���#F44336$��0q�5�   5   $��SemiBold"�5�   5   
�������#��[ 5�   5    5�   6   ��%_   '��       �� 5�   :   " ��6@   .�5�   >   ��  �@��CornerRadius$ 10��6]   5�   ;   5�   7   .��5�   6   �� #��[ 6@   $��Delete��6c   5�   3   �� 5�   2   $��70��5�   5   $��25��5�   5   $��5,0,5,0q�5�   5   ���#A9A9A9$��0q�5�   5   $��SemiBold"�5�   5   
�������#��[ 5�   5    5�   6   ��%_   '��       �� 5�   :   " ��6@   .�5�   >   ��  �@��CornerRadius$ 10��6]   5�   ;   5�   7   .��5�   6   �� #��[ 6@   $��Detail��6c   5�   3   5�   /   5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      