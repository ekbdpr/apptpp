   M S B A M L   `   `   `  ���� A  =AppTpp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AppTpp.MVVM.ViewModelAppTpp.MVVM.ViewModel  -    'AppTpp.MVVM.View.Components.UserManager   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2vm#clr-namespace:AppTpp.MVVM.ViewModel       � DataContext  )  #AppTpp.MVVM.ViewModel.UserManagerVM  .��(� $	��Top=�.��� $
��1024��$
��1024��$
��30,0q�$��Stretch=�.+��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��40(�$
��Bold"�   	TextStyle#��[  $��User Manager���� $��1��$��	0,20,0,20q����#A9A9A9$��0,0,0,1q��� $��2��$��2��$	��500�� K� ZIndex$ 1������ *SpinnerView+y��� *SpinnerVisibility+�� $��2�� �� Orientation$ 
Horizontal=�y��� *ContentVisibility+.+��� $	��120��$��30��$��0,30,0,0q����#3081D0$��0q�
�������  OpacityButton#��[ ���� *AddUserCommand+ � 	Resources  �� 
TargetType �� Property �� Value��%:   '��       �� " ��.���  �@��CornerRadius$ 10��.���� $��SemiBold"�#��[  $��Add New Data��� $��3��y��� *ContentVisibility+.+��� $��0,15,0,0q�
����������#CCCCCC$��1q� �� CornerRadius$ 5��	 J� Effect	 3  -System.Windows.Media.Effects.DropShadowEffect  
   	Direction$	
 330Q�   Opacity$	 0.5Q�   ShadowDepth$ 3Q�._�&   System.Windows.Controls.DataGrid  $
��1000��$��10q�   AutoGenerateColumns$ False��$��0q�   CanUserAddRows$ False��   CanUserDeleteRows$ False��   CanUserReorderColumns$ False��   CanUserResizeColumns$ False��   CanUserResizeRows$ False��   CanUserSortColumns$ False��$��/Fonts/#Fira Sans)�   
IsReadOnly$
 True������ *Users+ �� IsAsync$
 True�� �� SelectedItem �� *SelectedUser+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    Header$	 NIP��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Nip+  $ * $
 Name�� �� *Name+  $ * $ Jabatan�� �� *	Jabatan+  $ * $ Username�� �� *
Username+  $ * $ 	Privilege�� �� *	Privilege+4  .System.Windows.Controls.DataGridTemplateColumn  $
 Auto $ Options��   CellTemplate �� .R��� $ 
Horizontal=�.+��� $��70��$��25��$��5,0,5,0q����#FFB534$��0q�
�������#��[ ����  �� RelativeSource ��  �� AncestorType" >� �� Mode$ FindAncestor=� �� Path$! DataContext.EditUserCommand� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��.���� $��SemiBold"�#��[  $
��Edit���� $��70��$��25��$��5,0,5,0q����#CD1818$��0q�
�������#��[ ����  �� " >�$ FindAncestor=�$# DataContext.DeleteUserCommand� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��.���� $��SemiBold"�#��[  $��Delete���� $��4��$��5,5,12,0q�$��Right=�$ 
Horizontal=�.+��� $��Center=�#��[  ���� *DataCountMessage+� $
��10,0q�.+��� $��20��$��20�����#222831$��0q�$	��〈��  � Cursor$
  Hand�����#EEEEEE#��[ ���� *PrevPageCommand+ ��%:   '��       �� " ��.���  �@��CornerRadius$ 20������ ! �� 
TargetType"! ��.R��� " ��Name$" InnerBorder��# �� Padding$# 0,0,2,3q�#��z��$ 10��._��� $��Center=�$��Center=�$ �� Triggers$ P� % P� Property% � {�& P� Value$& False��. ��� ' �� 
TargetName$' InnerBorder�� � �� �#A9A9A9�� $��Center=����� *CurrentPage+� $��10,0,0,0q�.+��� $��20��$��20�����#222831$��0q�$	��〉��$
  Hand�����#EEEEEE#��[ ���� *NextPageCommand+ ��%:   '��       �� " ��.���  �@��CornerRadius$ 20������ "! ��.R��� $" InnerBorder��$# 2,0,0,3q�#��z��$ 10��._��� $��Center=�$��Center=�$ P� % � {�$& False��. ��� $' InnerBorder�� � �� �#A9A9A9