   M S B A M L   `   `   `  ����M  ITaskManager.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TaskManager.Client.ControlsTaskManager.Client.Controls  5      K*clr-namespace:TaskManager.Client.ConverterTaskManager.Client.Converter  5      1    +TaskManager.Client.Controls.TaskListControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:TaskManager.Client.Controls     5      ;conv*clr-namespace:TaskManager.Client.Converter     5      -   5          � 	Resources  5
      1   +TaskManager.Client.Converter.ColorConverter   colorConverter4   .TaskManager.Client.Converter.ExecutorConverter  executorConverter��%:   &	        &	        5   
   67     5   
   6=   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   .+�5   
   �� $��5q�6   .+�5      �� -   5        $��btn_addTask��5      $��50��6(   $	��100��64   .��6Z   Добавить задачу6k   �� 5      $��5q�6   
�������$��2q�63   ._�5      �� .+�5      	� -   5        $��radio_Planing��5   .   $��20��6"   
�������.��6s    Запланированные6�   	� 5      -   5        $��radio_Executing��5   .   $��20��6"   
�������.��6u   Текущие6~   	� 5      -   5        $��radio_Completed��5   .   $��20��6"   
�������.��6u   Выполненные6�   	� 5      -   5        $��radio_Overdue��5   .   $��20��6"   
�������.��6s   Просроченные6�   	� 5      -   5        $��radio_Canceled��5   "   
�������.��6h   Отмененные6t   5      5      5      �� 5    
   -   5        $��lb_task��5    /   $��0��6   $��1��6   ���	#FF8C8C91��5!      �� 5"      .�5#      ��  �� Property � �� �� Value$ 3q�6D   6P   �� 5$       � ��
 ��  �6S   �� 5%       � ��$ 20(�6=   6J   �� 5&       � ��
 �   �6O   �� 5'       � �� 5(      �� 5)       �� EndPoint$ 0.5,1&�62    �� 
StartPoint$ 0.5,0&�6C   .��5*   "   �  � Color$ 	#FFADBEDA��6/    � Offset$ 0Q�6A   � 5+   "   $ 	#FF668FD6��6/   $ 1Q�6A   5,      5.       �� Triggers 5/      P� 50      	 P� Property	 �@J�IsMouseOver
 P� Value
 . . �52      ��  � �� �	#FFAE79186\   53      P� 54      	 �@��
IsSelected
 . . �55      ��  � ��
 �   �6G   �� 58       � �� �	#FFAE79186\   59      5;      ��5=      �� 5>      .R�5?      � $��3q�6   $��Center=�6&    5@      �� 5A      61   �� 5B      $��10 �6/   6<   �� 5C      61    � RowDefinitions 5E      �� 5F      6.   �� 5G      6.   �� 5H      6.   .+�5J      � .+�5K      �� $��25��6$   $��25��60   $3��-/TaskManager.Client;component/Images/work.png��6;   $��	2,2,-25,2q�6r    K� ZIndex$	 100��6�   6�   �� 5L      $��2q�6%   
���   �._�5M   "   � $	��100��6.   $��30��6:   ��6F   ��  �� Path$	 Lag� �� 	Converter# [   � Value 6�   �� *PersentComplete+6�   5N      5O      � 5P      $��1��6$   .+�5Q      �� $��25��6$   $��25��60   $3��-/TaskManager.Client;component/Images/time.png��6;   $��	2,2,-25,2q�6r   $	 100��6�   6�   �� 5R      $��2q�6%   
���   �._�5S   "   � $	��100��6y   $��30��6�   ��6.   �� $	 Lag�# [   6�   �� $ 
PassedTime� �� Mode$ OneWay=�6�   5T      5U      � 5V      $��0��6$   $��2��61   .+�5W      �� ��6(   �� *Name+6@   �� 5X      ��6(   �� *
Executor+# [ 6r   5Y      � 5[      $��1��6$   $��2��61   .+�5\      �� $��До: ��6(   66   �� 5]      ��6(   �� *
TimeFinish+ �� StringFormat$ {0:dd.MM.yyyy HH:mm}��6m   5^      5_      5`      5b      5c      5d      