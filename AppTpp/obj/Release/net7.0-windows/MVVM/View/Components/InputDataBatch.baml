   M S B A M L   `   `   `  ���� A  =AppTpp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AppTpp.MVVM.ViewModelAppTpp.MVVM.ViewModel  0    *AppTpp.MVVM.View.Components.InputDataBatch   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2vm#clr-namespace:AppTpp.MVVM.ViewModel       � DataContext  ,  &AppTpp.MVVM.ViewModel.InputDataBatchVM  .��(� $
��Left=�$	��Top=�.��� $
��1000��$
��30,0q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��40(�$
��Bold"�   	TextStyle#��[  $��Input Data Batch���� $��1��$��	0,20,0,20q����#A9A9A9$��0,0,0,1q��� $��2��$	��100�� �� Orientation$ 
Horizontal=�.+�� $
��0,10q�.+��� $��14(�#��[  $��Bulan���� $	��120��$��30��$��Center=� � Cursor$
 Hand��$��Fonts/#Fira Sans)� �� SelectedValuePath$ Content��  ComboBoxStyle#��[  �� SelectedValue �� *Bulan+ �� Mode$ TwoWay=�.@��� $��Januari�� �� 
IsSelected$
 True���� $��Februari���� $��Maret���� $��April���� $	��Mei���� $
��Juni���� $
��Juli���� $��Agustus���� $��	September���� $��Oktober���� $��November���� $��Desember��� $��10q�.+��� $��14(�#��[  $��Tahun���� $	��130��$��30��$��Center=�$
 Hand��$��Fonts/#Fira Sans)�$ Content��#��[  �� *Tahun+$ TwoWay=�.@��� $
��2024��$
 True���� $
��2025���� $
��2026���� $
��2027���� $
��2028���� $
��2029���� $
��2030���� $��3��$ 
Horizontal=�.+��� $	��120��$��30��$
��0,10q�$
��Left=�  OpacityButton#��[ ���� *ChooseFileCommand+ � 	Resources 	 �� 
TargetType
 �� Property �� Value��%:   '��       �� "	 ��.��� 
 �@��CornerRadius$ 10��.���� #��[  $��Choose File���� $��10q�$��Center=�#��[  ���� *
FileName+�� $��4��$ 
Horizontal=�.+��� $	��120��$��30��$
��0,10q�$
��Left=�$	��Top=����#3081D0$��0q�
�������#��[ ���� *ImportFileCommand+ ��%:   '��       �� "	 ��.��� 
 �@��CornerRadius$ 10������  �� 
TargetType" ��.R���  ��Name$ InnerBorder��#��z�� �� CornerRadius$ 10��._��� $��Center=�$��Center=� �� Triggers P�  P� Property � {� P� Value$ False��. ���  �� 
TargetName$ InnerBorder��
 � �� �#A9A9A9.���� $��SemiBold"�#��[  $��Import Data��� $��20��$��10q�$��Center=�.+��� ���� *SpinnerView+y��� *SpinnerVisibility+�� $��Center=�$��Center=�
��� � �#��[  $ ��✅ Import data berhasil !��y��� *GreenCheckVisibility+�� $��Center=�$��Center=�
���  ��#��[  ���� *ErrorMessage+y��� *RedCrossVisibility+