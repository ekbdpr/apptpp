   M S B A M L   `   `   `  ���� A  =AppTpp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AppTpp.ViewAppTpp.View  3clr-namespace:AppTpp.ViewModelAppTpp.ViewModel       AppTpp.View.UserDataDialog   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:AppTpp.View     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -vmclr-namespace:AppTpp.ViewModel       � Title$  Add New Data��#��Z��#��Z�� � AllowsTransparency$
 True�� J� SnapsToDevicePixels$
 True��   
windowLoad#��[   � UseLayoutRounding$
 True�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�����  �� Opacity$	 0.4Q� �� Color$ Black�� � DataContext '  !AppTpp.ViewModel.UserDataDialogVM  	 � 	Resources	 
 �� 
TargetType �� Property �� Value �� 	Resources��%o   '��       �� "
 ��.���  � ��$ 5q� ���� '��       "
 ��.���  �@��CornerRadius$ 10��.���� $	��600��$��Center=����#222831 �� CornerRadius$ 10��._��� ���#CCCCCC$��0q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     	Direction$	 330Q�   Opacity$	 0.5Q�   ShadowDepth$ 3Q�._�� .+��� $
��15,5q�$��16(�
�������  	TextStyle#��[ $��Add New Data���� $��0,30,0,0q�
����������#A9A9A9$��0q�$ 	0 0 10 10��._��� $��30q�.+��� $��0,0,0,10q� �� Orientation$ 
Horizontal=�.+��� $	��200��$��16(�#��[ $	��NIP���� $	��340��$��Fonts/#Fira Sans)�$��16(����� *Nip+ �� Mode$ TwoWay=��� $��0,0,0,10q�$ 
Horizontal=�.+��� $	��200��$��16(�#��[ $
��Nama���� $	��340��$��Fonts/#Fira Sans)�$��16(����� *Nama+$ TwoWay=��� $��0,0,0,10q�$ 
Horizontal=�.+��� $	��200��$��16(�#��[ $��Jabatan���� $	��340��$��Fonts/#Fira Sans)�$��16(����� *	Jabatan+$ TwoWay=��� $��0,0,0,10q�$ 
Horizontal=�.+��� $	��200��$��16(�#��[ $��Username���� -    ��Name$ UsernameTextBox��$	��340��$��Fonts/#Fira Sans)�$��16(����� *
Username+$ TwoWay=��� $��0,0,0,10q�$ 
Horizontal=�.+��� $	��200��$��16(�#��[ $��Password���� -   $ PasswordBox��$	��340��$��Fonts/#Fira Sans)�$��16(����� *
Password+$ TwoWay=��� $��0,0,0,20q�$ 
Horizontal=�.+��� $	��200��$��16(�#��[ $��	Privilege���� 
�������$��1q�$ 10��._��� $	��338��$��Center=�$��0q� � Cursor$
 Hand��$��Fonts/#Fira Sans)�$��16(� �� SelectedValuePath$ Content��  ComboBoxStyle#���   �� SelectedValue �� *	Privilege+$ TwoWay=�.@��� $��--- Pilih salah satu ---�� �� 
IsSelected$
 True���� $��Admin���� $��	Bendahara���� $��Pimpinan���� $��Right=�$ 
Horizontal=�.+��� $��80��$��30��$��0,0,10,0q����#3081D0$��0q�  OpacityButton#��[ ���� *SaveCommand+	 ��%:   '��       �� "
 ��.���  �@��CornerRadius$ 10��.���� $��16(�
�������#��[ $
��Save���� -   $��80��$��30�����#A9A9A9$��0q�#��[ 	 ��%:   '��       �� "
 ��.���  �@��CornerRadius$ 10��.���� $��16(�
�������#��[ $��Cancel��