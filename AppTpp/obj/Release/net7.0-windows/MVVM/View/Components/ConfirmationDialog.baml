   M S B A M L   `   `   `  ���� A  =AppTpp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AppTpp.MVVM.ViewModelAppTpp.MVVM.ViewModel  4    .AppTpp.MVVM.View.Components.ConfirmationDialog   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2vm#clr-namespace:AppTpp.MVVM.ViewModel       � Title$  
Konfirmasi��#��Z��#��Z�� � AllowsTransparency$
 True�� J� SnapsToDevicePixels$
 True�� � UseLayoutRounding$
 True�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�����  �� Opacity$	 0.4Q� �� Color$ Black�� � DataContext 0  *AppTpp.MVVM.ViewModel.ConfirmationDialogVM  	 � 	Resources	    OpacityButton
 �� BasedOn �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� CornerRadius��%  '��       7   �� 8
   " ��.���  � ��$	 100����  � ��$ 20q���  � �� �#EEEEEE��  � ��$ 0q���  � ��$ Center=���  �@�Cursor$
 Hand����  � �� �� " ��.R��� # z��#��z��#��z��#��z��$ 10��._��� #��z��#��z��.���� $	��350��$��Center=����#CCCCCC$��0q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     	Direction$	 330Q�   Opacity$	 0.5Q�   ShadowDepth$ 3Q�._�� .+��� $��0,50,0,0q�
����������#A9A9A9$��0q�$ 10��._��� $��20q�.+��� $��Center=�$	��Top=�$��20(� �� 
LineHeight$ 30��  	TextStyle#��[  �� TextAlignment$ Center=�$
��Wrap=����� *	Message+�� $��0,30,0,0q�$��Center=�$��Bottom=� �� Orientation$ 
Horizontal=�.+��� -   $��0,0,50,0q����#379237���� *YesButtonCommand+.���� $��16(�$
��Bold"�#��[ $��Ya���� -   ���#CD1818���� *NoButtonCommand+.���� $��16(�$
��Bold"�#��[ $��Tidak��