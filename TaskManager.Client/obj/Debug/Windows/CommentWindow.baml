   M S B A M L   `   `   `  ����M  ITaskManager.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TaskManager.ClientTaskManager.Client  5   	   &     TaskManager.Client.CommentWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:TaskManager.Client     5   	   -   5          � Title$-  'Добавить комментарий��5   	   $	��250��6&   $	��350��63   
���   � � 
ResizeMode$ NoResize=�6R    � WindowStartupLocation$ CenterScreen=�6h   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��60 �6   .+�5   
   �� -   5        $��tb_text��5      $��15q�6!    �� TextWrapping$
 Wrap=�6-   6C   �� 5   
   $��1��6   
���   �._�5      � $��Center=�6   $��Center=�63   .+�5      �� -   5        $��btn_save��5      $	��100��6)   $
��10 0q�65   $��30��6D   ��5      �� 5       �� EndPoint$	 0,1&�6.    �� 
StartPoint$	 0,0&�6=   .��5      �  � Color$ 	#FFD0F5BF��6+    � Offset$ 0Q�6=   � 5      $ 	#FF537244��6+   $ 1Q�6=   5      .��5   )   Сохранить5      �� 5      -   5        $	��100��5      $
��10 0q�6%   ��5      �� 5      $	 0,1&�6.   $	 0,0&�6=   .��5      � $ 	#FFF3BEB6��6+   $ 0Q�6=   � 5      $ 	#FFA05346��6+   $ 1Q�6=   5      .��5   )   Отмена5       5!      5"      5#      5$      