   M S B A M L   `   `   `  ����E  AE_Shopping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:E_Shopping
E_Shopping  5   	   ;"clr-namespace:E_Shopping.ViewModelE_Shopping.ViewModel  5   	   E'clr-namespace:E_Shopping.UserControlBarE_Shopping.UserControlBar  5	   	   S.clr-namespace:E_Shopping.UserControlBar.Screen E_Shopping.UserControlBar.Screen  5
   	       E_Shopping.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:E_Shopping     5   	   1vm"clr-namespace:E_Shopping.ViewModel     5   	   6uc'clr-namespace:E_Shopping.UserControlBar     5	   	   CucScreen.clr-namespace:E_Shopping.UserControlBar.Screen     5
   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5        $��
mainWindow��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    
 MainVM � DataContext# [ 5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   $	��800��5   	   $
��1300��5   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
MainWindow��5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
   	   	EventName$	 Loaded��6   .  (System.Windows.Interactivity.TriggerBase
   Actions.
 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *Instance.LoadedWindowCommand+   CommandParameter 6V   ��  �� ElementName$ 
mainWindow��5       .��5"      � .+�5#   
   �  � RowDefinitions 5$      �� 5%      $
��auto �6    60   �� 5&      6"   .+�5)      ,   &E_Shopping.UserControlBar.ControlBarUC  -   5          Name$ 
ControlBar��5)   -   $��0��6    6C   �� 5,      $��1��6   
�������
��� � �$��2 0 2 2q�6L    �� CornerRadius$ 	0 0 10 10��6f   $��0q�6   ._�5-      �� -   5         ��Name$ Pages��5-   !   ��60   �� *Instance.CurrentView+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5/      50      �� 52   
   -   5         ��Name$ chatBtn��52       , (MaterialDesignFloatingActionAccentButton#��[ 6"   $��
20 0 38 52q�54      $��50��55      $��50��56      $��Right=�57      $��Bottom=�58      y�53      �� *Instance.ChatVisibility+$ TwoWay=�$ PropertyChanged=�.��5:      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Wechat=�5;      $��24��6'   $��24��63   5<      &   MaterialDesignThemes.Wpf.Flipper  5=   
   -   5          Name$ chatFlipper��5=   "   $y�	Collapsed=�67   $��Right=�6O   $��Bottom=�6k   $	��270��6�   $	��350��6�   $��	0 0 20 20q�6�      FrontContent 5>      �� 5?      -   5        #��[ 5?         FlipCommand#��Z 5@      
��� ���$��20q�5B      $��50��5C      $��50��5D      $��Start��5E      $��Right=�5F      $��Bottom=�5G      5J         BackContent 5L      � 5M      $	��306��6   $	��270��6%   
������� 5N      �� 5O      $
��Auto �6)   �� 5P      $��* �6(   .+�5R      (	  "MaterialDesignThemes.Wpf.ColorZone	  $��6q�6/   ���	#FF8888F4.��5S      ��  �� Orientation$ 
Horizontal=�6%   .+�5T      �� -   5         & "MaterialDesignToolForegroundButton#��[ 5T   %   #��Z 5U   %   $
��Left=�5V   %   .��5W   "     $ 	ArrowLeft=�5X   %   $��Right=�5Y   %   5Z      �� 5[      $��8 0 0 0q�6(   $��Center=�5\   (   
Shop Owner5^      5_      5`      � 5a      $��1��6   $��0 6 0 0q�5b      $��Center=�5c      $	��Top=�5d      $	��252��5e       5f      �� 5g      $��* �6,   �� 5h      $
��auto �6-   .+�5j      �� $��0��6!   $��0 2 0 2q�6.   $	��200��6?   
�������._�5l      �� -   5         ��Name$ MessageList��5l   '   $��Hidden=�6�   ��6=   �� *Instance.chatBox+$ TwoWay=�$ PropertyChanged=���5m   "   �� 5n   &   .R�5o   *   �� $ Vertical=�65   .+�5p   .   �� $ 
Horizontal=�69   .+�5q   2   �� $ 50��69   $��1q�6K   
�������$��30��6r   $��33��6~   ��5r   6   �� 5s   :   
avatar�� j� Stretch$
 Fill=�6�    �� ImageSource 6U   �� *Sender.avatar+$ TwoWay=�$ PropertyChanged=�6�   5u   3   �� 5v   2   $��3 0 0 0q�6<   $��Center=�6M   ��6h   �� *	content+$ TwoWay=�$ PropertyChanged=�6�   5w   /   5y   +   5{   '   5}      5~      �� 5�      $��1��6%   $ 
Horizontal=�62   .+�5�      �� ���	#FFE8DDDD$��40��6<   $��1q�6H   $ 5��6\   ._�5�   "   �� -	   5         ��Name$ 	messageTb��5�   *   .
  (MaterialDesignThemes.Wpf.TextFieldAssist 
  DecorationVisibility$ Hidden=�6=   )  #MaterialDesignThemes.Wpf.HintAssist    Hint$  Enter your message��6{   $��5 0 5 0q�6�   $��14(�6�   $��50��6�   $��0 0 0 0q�6�   $	��200��6�   $��Center=�6  $��Center=�6  
������ 6W  5�      �� 5�      -
   5        $ sendBtn��5�   %   $��0 0 0 0q�66   
������ $��5 0 0 0 q�6j   $��24��6|   $��24��6�   
������  + 'MaterialDesignFloatingActionLightButton#��[ 6�   .��5�   "     $
 Send=�5�   %   $��24��5�   %   $��24��5�   %   5�      5�      5�      5�      5�      5�      5�      