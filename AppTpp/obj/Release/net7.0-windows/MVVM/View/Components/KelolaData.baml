   M S B A M L   `   `   `  ���� A  =AppTpp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AppTpp.MVVM.ViewModelAppTpp.MVVM.ViewModel  ,    &AppTpp.MVVM.View.Components.KelolaData   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2vm#clr-namespace:AppTpp.MVVM.ViewModel       � DataContext  (  "AppTpp.MVVM.ViewModel.KelolaDataVM  .��(� $	��Top=�.��� $
��1024��$
��1024��$
��30,0q�$��Stretch=�.+��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��40(�$
��Bold"�   	TextStyle#��[  $��Kelola Data Pegawai���� $��1��$��	0,20,0,20q����#A9A9A9$��0,0,0,1q��� $��2��$��2��$	��500�� K� ZIndex$ 1������ *SpinnerView+y��� *SpinnerVisibility+�� $��2��$	��100�� �� Orientation$ 
Horizontal=�.+�� $
��0,10q�.+��� $��14(�#��[  $��Bulan���� $	��120��$��30��$��Center=� � Cursor$
 Hand��$��Fonts/#Fira Sans)� �� SelectedValuePath$ Content��  ComboBoxStyle#��[  �� SelectedValue �� *Bulan+ �� Mode$ TwoWay=�.@��� $��Pilih Bulan��${�False�� �� 
IsSelected$
 True���� $��Januari���� $��Februari���� $��Maret���� $��April���� $	��Mei���� $
��Juni���� $
��Juli���� $��Agustus���� $��	September���� $��Oktober���� $��November���� $��Desember��� $��10q�.+��� $��14(�#��[  $��Tahun���� $	��130��$��30��$��Center=�$
 Hand��$��Fonts/#Fira Sans)�$ Content��#��[  �� *Tahun+$ TwoWay=�.@��� $��Pilih Tahun��${�False��$
 True���� $
��2024���� $
��2025���� $
��2026���� $
��2027���� $
��2028���� $
��2029���� $
��2030���� $��70��$��30�����#3081D0$��0q�
�������  OpacityButton#��[ ���� *SearchFilteredPegawaiCommand+	 � 	Resources	 
 �� 
TargetType �� Property �� Value��%:   '��       �� "
 ��.���  �@��CornerRadius$ 10��.���� $��SemiBold"�#��[  $��Search��� $��3��y��� *ContentVisibility+.+��� $��0,15,0,0q�
����������#CCCCCC$��1q� �� CornerRadius$ 5�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     	Direction$	 330Q�   Opacity$	 0.5Q�   ShadowDepth$ 3Q�._�&   System.Windows.Controls.DataGrid  $
��1000��$��10q�   AutoGenerateColumns$ False��$��0q�   CanUserAddRows$ False��   CanUserDeleteRows$ False��   CanUserReorderColumns$ False��   CanUserResizeColumns$ False��   CanUserResizeRows$ False��   CanUserSortColumns$ False��   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * $��/Fonts/#Fira Sans)�   
IsReadOnly$
 True������ *	Pegawai+ �� IsAsync$
 True��$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedPegawai+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width$
 1.5*     Header$	  NIP��1  +System.Windows.Controls.DataGridBoundColumn!   Binding! �� *Nip+  $
 1.5* $
  Nama��! �� *Name+"   ElementStyle" �� .���  � ��$
 Wrap=�  $
 1.5* $  	Kd Satker��! �� *
KdSatker+  $ 1.75* $  No.Rek��! �� *Norek+  $
 0.7* $  
Kd Pangkat��! �� *	KdPangkat+" �� .���  �@��TextAlignment$ Center=�  $
 0.5* $  Piwp1��! �� *Piwp1+" �� .���  �@��TextAlignment$ Center=�  $
 2.5* $  	Nama SKPD��! �� *
NamaSkpd+" �� .���  � ��$
 Wrap=�  $  Pagu TPP Beban Kerja��! �� *	PaguTpp+  $  Pagu TPP Kondisi Kerja��! �� *	PaguTpp+4  .System.Windows.Controls.DataGridTemplateColumn  $
 Auto $  Options��#   CellTemplate# �� .R��� $ 
Horizontal=�.+��� $��70��$��25��$��5,0,5,0q����#FFB534$��0q�
�������#��[ ���� $ �� RelativeSource$ �� % �� AncestorType"% >�& �� Mode$& FindAncestor=�' �� Path$$' DataContext.EditPegawaiCommand�	 ��%:   '��       �� "
 ��.���  �@��CornerRadius$ 10��.���� $��SemiBold"�#��[  $
��Edit���� $��70��$��25��$��5,0,5,0q����#CD1818$��0q�
�������#��[ ���� $ �� "% >�$& FindAncestor=�$&'  DataContext.DeletePegawaiCommand�	 ��%:   '��       �� "
 ��.���  �@��CornerRadius$ 10��.���� $��SemiBold"�#��[  $��Delete���� $��4��$��5,5,12,0q�$��Right=�$ 
Horizontal=�.+��� $��Center=�#��[  ���� *DataCountMessage+� $
��10,0q�.+��� $��20��$��20�����#222831$��0q�$	��〈��$
 Hand�����#EEEEEE#��[ ���� *PrevPageCommand+	 ��%:   '��       �� "
 ��.���  �@��CornerRadius$ 20������ ( �� 
TargetType"( ��.R��� ) ��Name$) InnerBorder��* �� Padding$* 0,0,2,3q�#��z��$ 10��._��� $��Center=�$��Center=�+ �� Triggers+ P� , P� Property, � {�- P� Value$- False��. ��� . �� 
TargetName$. InnerBorder�� � �� �#A9A9A9�� $��Center=����� *CurrentPage+� $��10,0,0,0q�.+��� $��20��$��20�����#222831$��0q�$	��〉��$
 Hand�����#EEEEEE#��[ ���� *NextPageCommand+	 ��%:   '��       �� "
 ��.���  �@��CornerRadius$ 20������ "( ��.R��� $) InnerBorder��$* 2,0,0,3q�#��z��$ 10��._��� $��Center=�$��Center=�+ P� , � {�$- False��. ��� $. InnerBorder�� � �� �#A9A9A9