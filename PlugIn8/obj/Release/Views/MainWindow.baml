   M S B A M L   `   `   `  ����   PlugIn8>    8Attribute_and_Type_Definition_Management_Tool.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � Title$  Title��$	��585��$	��585��$	��595��$	��550�� � 
ResizeMode$ CanResizeWithGrip=� � WindowStartupLocation$ CenterScreen=�.��� ����  �� EndPoint$ 0.5,1&� � MappingMode$ RelativeToBoundingBox=� �� 
StartPoint$ 0.5,0&�.���  � Color$ White��� $ 
WhiteSmoke�� � Offset$ 1Q� � ColumnDefinitions �� $
��Auto ��� $��* �	 � RowDefinitions	 �� $
��459* ��� $
��106* �.+��� $��0��$��0��$��1��$��14,13,14.4,12.2q�$	��350��$	��500��$��0q�$��2��$
��Left=�
 J� 	AllowDrop
 . ��. .@��� $��title��.��� ���#FFFFFF$��0,0,2.8,-0.4q� 	 �� �� $��0* �.+�&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��   CanUserSortColumns .     AutoGenerateColumns .     EnableRowVirtualization .    RowDetailsVisibilityMode$ VisibleWhenSelected=�
�������
�������$��0��$��1��$��Center=�$��1,5,-1,0q�$	��Top=�$	��538�� �� SelectedItem �� *MySelectedItem+ �� Mode$ TwoWay=����� *MyGrid+ � ContextMenu �� -   
�������$
��1.35q�.@�m� $��Available Attribute�� m� Command �� *
CmdAddAttr+ m� Icon �� $��14��$��16������ *Icon+   RowStyle ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"  .���  �� Property � �� �� Value �� *
ColorSet+$ TwoWay=���  � �� �� *	FontSet+$ TwoWay=���  � �� �� *
FontSize+$ TwoWay=���  � ��$ SemiCondensed&�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
Attributes��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Attributes+$ TwoWay=�  $ *  �� *Desc+$ TwoWay=�   HeaderStyle �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  � ��$ Stretch=� � $��0q� �� $��* ��� $��16 �.+��� $��0��$�� ���� -   $	��1.5q�$��+��
�����F�$��
0,0,25,0.2q�$��Right=�$��2��$
��20.5�� J� RenderTransformOrigin$ 0.185,0.526&� � 	Resources ��%9   '��       �� " ��.���  �@��CornerRadius$ 3������ $ 0.5,1&�$ RelativeToBoundingBox=�$ 0.5,0&�.��� $ #FFFFFF��� $ 	#FFD4D4D4��$ 2Q��� -   $	��1.5q�
�������$��-��$��0,0,0.2,0.2q�$��Right=�$��2��$
��20.5�� ��%9   '��       �� " ��.���  �@��CornerRadius$ 3������ $ 0.5,1&�$ RelativeToBoundingBox=�$ 0.5,0&�.��� $ #FFFFFF��� $ 	#FFD4D4D4��$ 2Q��� -     ��Name$  Combo��$	��Top=�$��27��$	��442��$��
15,5.8,0,0q�! �� Text$! Please Select��" �� 
IsEditable" . # �� StaysOpenOnEdit# .  $ �� IsTextSearchCaseSensitive$ .  $
��Left=�$��1��$��2��$	��487������ *Type+$ TwoWay=� �� *	SelType+$ TwoWay=�% �� UpdateSourceTrigger$% PropertyChanged=����� .R��� & �� Orientation$& 
Horizontal=�.+��� $
��Left=����� *
TypeName+�� -   $
��Left=�$	��Top=�$��Search��$��2q����	#FFA3D9F6$��508,6.8,0,0q�$��58��$��24��$ 0.326,0.017&�$��2��$��1������ *CmdAdd+ ��%9   '��       �� " ��.���  �@��CornerRadius$ 3������ $ 0.5,1&�$ 0.5,0&�.��� $ #FFFFFF��� $ 	#FFCCE6F4��$
 0.84Q��� $
��Back��
�������$
��1.35q�$
��Left=�$��
14,0,0,9.6q�$��Bottom=�$��85��$��27��$ 0.913,-0.448&�$��1��$��1������ *	CmdBack+ ��%9   '��       �� " ��.���  �@��CornerRadius$ 3������ $ 0.5,1&�$ 0.5,0&�.��� $ #FFFFFF��� $ 	#FFD4D4D4��$
 0.84Q�