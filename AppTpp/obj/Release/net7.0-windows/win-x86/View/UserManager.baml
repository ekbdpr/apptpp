   M S B A M L   `   `   `  ���� A  =AppTpp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AppTpp.ViewModelAppTpp.ViewModel      AppTpp.View.UserManager   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -vmclr-namespace:AppTpp.ViewModel        
Page_Style#��[    � DataContext  $  AppTpp.ViewModel.UserManagerVM  .��(� $	��Top=�.��� $
��30,0q�$��Stretch=�.+��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��40(�$
��Bold"�  	TextStyle#��[ $��User Manager���� $��1��$��	0,20,0,20q����#A9A9A9$��0,0,0,1q��� $��2�� �� Orientation$ 
Horizontal=�.+��� $	��120��$��30��$��0,30,0,0q����#3081D0$��0q�$��SemiBold"�
�������  OpacityButton#��[ ���� *AddDataCommand+ � 	Resources  �� 
TargetType �� Property �� Value��%:   '��       �� " ��.���  �@��CornerRadius$ 10��.���� #��[ $��Add New Data��� $��3��.+��� $��0,15,0,0q�
����������#CCCCCC$��1q� �� CornerRadius$ 5�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  	   	Direction$		 330Q�
   Opacity$	
 0.5Q�   ShadowDepth$ 3Q�._�&   System.Windows.Controls.DataGrid  $
��1000��$��10q�   AutoGenerateColumns$ False��$��0q�   CanUserAddRows$ False��$��/Fonts/#Fira Sans)����� *Users+ �� IsAsync$
 True��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    Header$	 NIP��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Nip+  $ * $
 Name�� �� *Name+  $ * $ Jabatan�� �� *	Jabatan+  $ * $ Username�� �� *
Username+  $ * $ 	Privilege�� �� *	Privilege+4  .System.Windows.Controls.DataGridTemplateColumn  $
 Auto $ Options��   CellTemplate �� .R��� $ 
Horizontal=�.+��� $��70��$��25��$��5,0,5,0q����#FFB534$��0q�$��SemiBold"�
�������#��[  ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��.���� #��[ $
��Edit���� $��70��$��25��$��5,0,5,0q����#F44336$��0q�$��SemiBold"�
�������#��[  ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��.���� #��[ $��Delete���� $��70��$��25��$��5,0,5,0q����#A9A9A9$��0q�$��SemiBold"�
�������#��[  ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��.���� #��[ $��Detail��