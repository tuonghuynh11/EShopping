   M S B A M L   `   `   `  ����E  AE_Shopping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:E_Shopping.UserControlBarE_Shopping.UserControlBar  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
   W   7    1E_Shopping.UserControlBar.ManageProductForOwnerUC   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:E_Shopping.UserControlBar     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      3system&clr-namespace:System;assembly=mscorlib  6W   -   5        $��manageProductForOwner��5         
Page_Style#��[  5        MaterialDesignBody#���  5      $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	   
������ .��5      ��  �� CornerRadius$ 10��6   ���#f5f2f2._�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      6"   .+�5       � $��0��6   5"      � 5#      $��1��6    � ColumnDefinitions 5$      �� 5%      $	��400 �6'   65   �� 5&      6)   .+�5(      � $��0��6   .+�5)      #  MaterialDesignThemes.Wpf.Card  $��30q�6*   .��5*      �  5+      �� 5,   "   $
��auto �60   6@   �� 5-   "   $
��auto �60   6@   �� 5.   "   $
��auto �60   6@   �� 5/   "   $
��auto �60   6@   �� 50   "   $
��auto �60   6@   �� 51   "   $
��auto �60   6@   .+�53      �� $��0��6$   $��30(�61   $��10q�6?   .��6K   FILTER AND SORT6\   �� 54      $��20(�6'   $��
20 0 20 20q�65   $��1��6I   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Category��55   '   $��72��56   '   $	��350��57   '    & "MaterialDesignFloatingHintComboBox#��[ 59   '   ��56   5   �� *
ListCate+ �� SelectedValue 58   &   �� *SelectedCate+ �� Mode$ TwoWay=���5:   "   �� 5;   &   .R�5<   *   $� 5=   '   5?      �� 5@      $��2��6$   $��20(�61   $��
10 0 10 10q�6?   .��6S   SORT:6Z   �� 5A      $��3��6)   $��
20 0 20 20q�66   .+�5B   "   	� -   5         	�Name$ az_name��5B   M   	 	� 	GroupName$
	 sort��6.   $��20(�6?   
 d� 	IsChecked
 6^   �� *
AZCheked+.��6}   	Name: A-Z6�   	� 5C   "   -   5        $ za_name��5C   M   $
	 sort��6.   $��20(�6?   
 6^   �� *
ZACheked+.��6}   	Name: Z-A6�   	� 5D   "   -   5        $ highlow_price��5D   M   $
	 sort��6.   $��20(�6?   
 6d   �� *HighLowCheked+.��6�   Price: High-Low6�   	� 5E   "   -   5        $ lowhigh_price��5E   M   $
	 sort��6.   $��20(�6?   
 6d   �� *LowHighCheked+.��6�   Price: Low-High6�   5G      �� 5H      $��4��6%     MaterialDesignRaisedButton#��[ 5I   !   $	��200��5J   !   $��20(�6-   $��20 0 0 0q�6;    � ToolTip$ FILTER and SORT��5K   !   ���#b6d7a8$
��Left=�6P   ��5H   2   �� *SortCommand+.��5K   k   _FILTER and SORT5M      �� 5N      $��5��6%   #��[ 5O   !   $	��250��5P   !   $��20(�6-   $��0 20 0 0q�6;   $ Add Product��5Q   !   ���#9fc5e8$��Center=�6L   ��5N   2   �� *AddProductCommand+.��5Q   i   _Add Product5S      5T      5W      5X      � 5Y      $��1��6   .+�5Z        $��
0 30 30 30q�6*   ���#e3dfdf.��5[      �  5\      �� 5]   "   62   �� 5^   "   $��65 �60   6>   .+�5�      �� $��0��6'    �� SelectionMode$ Extended=�6]   $��Disabled=�5�   X   $��Disabled=�6�    �� SelectedItem 5�   4   �� *SelectedProduct+��5�   '   �� *ListProduct+$ TwoWay=���5�   "   �� 5�   &   .R�5�   *   �  � Orientation$ 
Horizontal=�64   5�   '   ��5�   "   �� 5�   &   .R�5�   *     $	��280��6>   $	��195��5�   -   .��5�   .   �  5�   2   �� 5�   6   $
��auto �5�   5   �� 5�   6   $��* �5�   5   �� 5�   6   $
��Auto �5�   5   .+�5�   2   �� $
��Fill=�68   $	��180��5�   3   ��5�   3   �� *thumbnailimage+5�   3   �� 5�   2   $��1��5�   7   $��8 20 8 0q�5�   7   .+�5�   6   �� ��6A   �� *id+�� 5�   6   $
��Bold"�5�   9   ��6K   �� *name+5�   7   5�   3   �� 5�   2   $��Right=�5�   3   $��2��5�   3    �� Orientation$ 
Horizontal=�5�   3   $��8q�5�   3   .+�5�   6   �� #��[ 5�   =   $��65��5�   =   $��15(�6H   $
 Edit��5�   =   ���#ffd966$
��Left=�6a   ��5�   9   ��  �� RelativeSource ��  �� AncestorType" >� �� Mode$ FindAncestor=� �� Path$ DataContext.EditCommand�.��5�   |   _Edit5�   7   �� 5�   6   #��[ 5�   =   $��80��5�   =   $��15(�6H   $��	10 0 15 0q�6V   $ Delete��5�   =   ���#fb6e6e$
��Left=�6c   ��5�   i   ��  �� " >�$ FindAncestor=�$ DataContext.DeleteCommand�.��5�   ~   	_Delete5�   7   5�   3   5�   /   5�   +   5�   '   5�      �� 5�      $��1��6)   $ 
Horizontal=�66   $��Center=�6O   .+�5�   "   �� $��40��6)   ���#878787  MaterialDesignFlatButton#��[ 5�   !   $��60��5�   !   $��11(�6,   $
 Back��5�   !   ���#878787��5�   ;   �� *BackCommand+.��5�   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$  ArrowLeftDropCircleOutline=�6>   $��30��6`   $��30��6k   5�   #   �� 5�   "   -   5         ��Name$ CbPage��5�   6   $��5 0 5 13q�5�   +   $ Page Number��5�   '   $	��120��5�   '   $��15(�5�   (   #��[ 5�   '   ��5�   6   �� *
ListPage+ 5�   '   �� *SelectedPage+$ TwoWay=���5�   &   �� 5�   *   .R�5�   .   $� 5�   +   .  (System.Windows.Interactivity.Interaction   Triggers 5�   &   /  )System.Windows.Interactivity.EventTrigger  5�   *      	EventName$ SelectionChanged��69   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�   .   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6D   �� *SelectionChangedCommand+   CommandParameter 6p   ��  �� ElementName$ CbPage��5�   +   5�   #   �� 5�   "   $��40��6)   ���#878787#��[ 5�   !   $��60��5�   !   $��11(�6,   $
 Back��5�   !   ���#878787��5�   ;   �� *NextCommand+.��5�   &     $! ArrowRightDropCircleOutline=�6>   $��30��6a   $��30��6l   5�   #   5�      5      5     5     5     5     5     5     