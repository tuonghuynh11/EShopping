   M S B A M L   `   `   `  ����E  AE_Shopping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:E_Shopping
E_Shopping  5   	   ;"clr-namespace:E_Shopping.ViewModelE_Shopping.ViewModel  5   	   E'clr-namespace:E_Shopping.UserControlBarE_Shopping.UserControlBar  5	   	   S.clr-namespace:E_Shopping.UserControlBar.Screen E_Shopping.UserControlBar.Screen  5
   	       E_Shopping.MainScreen   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:E_Shopping     5   	   1vm"clr-namespace:E_Shopping.ViewModel     5   	   6uc'clr-namespace:E_Shopping.UserControlBar     5	   	   CucScreen.clr-namespace:E_Shopping.UserControlBar.Screen     5
   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	      MaterialDesignBody#���   5   
   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   $	��800��5   	   $
��1300��5   	    � AllowsTransparency . 
������  � Title$ 
MainScreen��5   	   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      6"   .+�5!      ,   &E_Shopping.UserControlBar.ControlBarUC  -   5          Name$ 
ControlBar��5!   +   $��0��6   6A   �� 5$      $��1��6   
�������
��� � �$��2 0 2 2q�6L    �� CornerRadius$ 	0 0 10 10��6f   $��0q�6   ._�5%      �� -   5        	 ��Name$	 Pages��5%   !   ��60   �� *Instance.CurrentView+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5'      5(      &   MaterialDesignThemes.Wpf.Flipper  5*   
   -   5        $��Right=�5*   !   $��Bottom=�6=   $	��270��6X   $	��350��6d   $��	0 0 20 20q�6q      FrontContent 5+      �� 5,       , (MaterialDesignFloatingActionAccentButton#��[ 6      FlipCommand#��Z 5-      $��20q�5.      $��50��5/      $��50��50      $��Right=�51      $��Bottom=�52      .��54      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Wechat=�55      $��24��6'   $��24��63   56         BackContent 58      � 59      $	��306��6   $	��270��6$   
������� 5:      �� 5;      $
��Auto �6)   �� 5<      $��* �6(   .+�5>      (  "MaterialDesignThemes.Wpf.ColorZone  $��6q�6/   ���	#FF8888F4.��5?      ��  �� Orientation$ 
Horizontal=�6%   .+�5@      ��  & "MaterialDesignToolForegroundButton#��[ 6%   #��Z 5A   %   $
��Left=�5B   %   .��5C   "     $ 	ArrowLeft=�5D   %   $��Right=�5E   %   5F      �� 5G      $��8 0 0 0q�6(   $��Center=�5H   (   
Shop Owner5J      5K      5L      � 5M      $��1��6   $��0 6 0 0q�5N      $��Center=�5O      $	��Top=�5P      $	��252��5Q       5R      �� 5S      $��* �6,   �� 5T      $
��auto �6-   .+�5V      �� $��0��6!   $��0 2 0 2q�6.   $	��200��6?   
�������._�5X      �� -   5         ��Name$ MessageList��5X   '   $��Hidden=�6�   ��6<   �� *	chatBox+$
 TwoWay=�$ PropertyChanged=���5Y   "   �� 5Z   &   .R�5[   *   �� $ Vertical=�65   .+�5\   .   �� $ 
Horizontal=�69   .+�5]   2   �� $ 50��69   $��1q�6K   
�������$��30��6r   $��33��6~   ��5^   6   �� 5_   :   
avatar�� j� Stretch$
 Fill=�6�    �� ImageSource 6U   �� *Sender.avatar+$
 TwoWay=�$ PropertyChanged=�6�   5a   3   �� 5b   2   $��3 0 0 0q�6<   $��Center=�6M   ��6h   �� *	content+$
 TwoWay=�$ PropertyChanged=�6�   5c   /   5e   +   5g   '   5i      5j      �� 5l      $��1��6%   $ 
Horizontal=�62   .+�5m      �� ���	#FFE8DDDD$��40��6<   $��1q�6H   $ 5��6\   ._�5n   "   �� -   5         ��Name$ 	messageTb��5n   *   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�6=   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter your message��6{   $��5 0 5 0q�6�   $��14(�6�   $��50��6�   $��0 0 0 0q�6�   $	��200��6�   $��Center=�6  $��Center=�6  
������ 6W  5o      �� 5p      -   5         ��Name$ sendBtn��5p   %   $��0 0 0 0q�66   
������ $��5 0 0 0 q�6j   $��24��6|   $��24��6�   
������  + 'MaterialDesignFloatingActionLightButton#��[ 6�   .��5q   "     $
 Send=�5r   %   $��24��5s   %   $��24��5t   %   5u      5v      5w      5x      5z      5{      5|      