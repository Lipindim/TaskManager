   M S B A M L   `   `   `  ����N  JTaskManager.Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:TaskManager.GUI.UserControlsTaskManager.GUI.UserControls  5      .    (TaskManager.GUI.UserControls.TreeControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:TaskManager.GUI.UserControls     5      -   5        
���   �  � 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius � RowDefinitions �� Padding �� EndPoint	 �� 
StartPoint
 � Color � Offset �� Triggers P� Property P� Value �� 
TargetName K� IsItemsHost �� Orientation��%�  'Q�       �� 5   
   " Q�6   .�5      ��  � �� 5      �� 5      " Q�6&   .R�5      �� $��1q�6!   
����  �$ 10��6I   $��2q�6[   ._�5      � $��10q�6#    5   "   �� 5   &   $
��Auto �64   �� 5   &   $��* �64   .+�5   "   �� $��Bd��6)   
�������$	��0.6q�6F   $ 8��6\   $ 3q�6m   $	��200��6y   ��5   &   �� 5   *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5   .   � $
 	#FF5D6E85��6;   $ 1Q�6M   � 5   .   $
 	#FFD7E5F9��6;   $ 0.016Q�6M   5   +   ._�5   &   �� $��PART_Header��67   $��Header��6J   $��Center=�6a   $��Center=�6~   5   #   �� 5    "   $��1��61   5!      5"       5$      P� 5%       �@Q�
IsSelected . . �5&   "   �� $ Bd��6)    � ��
 �   �6U   �� 5'   "   $ Bd��6)    � ��
 � � �6W   �� 5(   "   $ Bd��6)    � ��
 � ���6[   5)      5+      5-      �� 5.       � �� 5/      �� 50      .R�51      �� $��Center=�6%    . $��2q�6U   $ 
Horizontal=�6`   52      54      �� 55       � �� 56      �� 57      .R�58      � $��gridItem��66   $��0q�6   $	��220��6*    59      �� 5:   "   62   �� 5;   "   62   5>      5@      5B      5C      5D      .��5I      � $��3q�6   .+�5K   
   R� -   5        $
��tree��5K      ���	#FFCFD9FD��5N      �� 5O       �� ItemsSource 6+   �� *
ChildUsers+.R�5P      � $��3q�6   $��Center=�6&   $��60��6A   $	��200��6M    � ColumnDefinitions 5Q      �� 5R      $��60 �6/   6<   �� 5S      $��10 �6/   6<   �� 5T      61    5V      �� 5W      6.   �� 5X      6.   .+�5Z      �� $��2��6@   ��6    �� *PictureImage+6S   �� 5[      $
��Wrap=�6$   $��0��6M   $��2��6Z   ��68   �� *FIO+6l   �� 5\      $
��Wrap=�6$   $��1��6N   $��2��6[   ��68   �� *Post+6m   5]      5_      5a      5b      5c      