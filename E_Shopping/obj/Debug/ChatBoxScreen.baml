   M S B A M L   `   `   `  ����E  AE_Shopping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:E_Shopping
E_Shopping  5   	       E_Shopping.ChatBoxScreen   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:E_Shopping     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   
      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	     ChatBoxScreenVM � DataContext# [ 5   	    � Title$ ChatBoxScreen��5   	   $	��800��6   $
��1300��6,   .��5      �� 
�������
��� � �$��2 0 2 2q�68    �� CornerRadius$ 10 10 10 10��6R   $��0q�6m   ._�5   
   � 	 � ColumnDefinitions	 5      �� 5      $	��270 �6#   �� 5      $��* �6#   �� 5      $	��270 �6#   .+�5      � $��1��6   ���	#FFE4E4E4
 � RowDefinitions
 5       �� 5!      $
��auto �6$   64   �� 5"      $��* �6$   61   �� 5#      $
��auto �6$   64   .+�5&      �� $��0��6    �� Orientation$ 
Horizontal=�6*   $	��100��6C   $	��Top=�6P   
������� J� Effect 5'      3  -System.Windows.Media.Effects.DropShadowEffect  5(         
BlurRadius$ 30Q�6+      ShadowDepth$ 1Q�6;   .+�5*      �� $��10��6   $��10��6(   $��Right=�64   $��15q�6P   
��� � �$ 15��6o   $��Center=�6�   �� 5+      $��28(�6s   $��Center=�6�   ��6    �� *person.userName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5,      �� 5.      -   5         ��Name$ MessageList��5.      $��1��60   ��. $
��0 20q�6�   $��Bottom=�6�   $��Hidden=�6�   ��6b   �� *Chat+$ TwoWay=�$ PropertyChanged=���5/      �� 50      .R�52      ]� $	��700��6(   .+�53   "   ��  ��Name$ Receiver��6�   $
��Left=�6�   $ 
Horizontal=�6�   y�6-   �� *visibility2+$ TwoWay=�$ PropertyChanged=�.+�54   &   �� $ 50��6-   $��1q�6?   
�������$��40��6f   $��43��6r   ��55   *   �� 56   .   avatarReceiver�� j� Stretch$
 Fill=�6�    �� ImageSource 6Q   �� *Customer.avatar+$ TwoWay=�$ PropertyChanged=�6�   58   '   �� 59   &   $��3 0 0 0q�6.   
�������$ 
15 15 15 0��6Q   ._�5:   *   �� $��10q�64   $��15(�6@   $
��Wrap=�6N   
�������$��Center=�6u   ��6�   �� *	content+$ TwoWay=�$ PropertyChanged=�6�   5;   '   5<   #   �� 5=   "   $ Sender��6-   $��Right=�6�   $��Right=�6�   $ 
Horizontal=�6�   y�6=   �� *visibility1+$ TwoWay=�$ PropertyChanged=�.+�5>   &   �� $��3 0 0 0q�6.   ���	#FF0072F9$ 
15 15 0 15��6V   ._�5?   *   �� $��10q�64   $��15(�6@   $
��Wrap=�6N   
�������$��Center=�6u   ��6�   �� *	content+$ TwoWay=�$ PropertyChanged=�6�   5@   '   �� 5A   &   $ 50��6-   $��1q�6?   
�������$��40��6f   $��43��6r   ��5B   *   �� 5C   .   avatarSender��$
 Fill=�6�    6O   �� *Assistant.avatar+$ TwoWay=�$ PropertyChanged=�6�   5E   '   5F   #   5H      5J      5L      �� 5M      $��2��6   
�������$��Bottom=�69   ._�5N      � $
��0 10q�6   	 5O      �� 5P      $��* �6/   �� 5Q      $��70 �6/   .+�5T      �� $��0��6!   $��	10 0 10 0q�61    �� Padding$ 1q�6D   ���	#FFF7F1F0$ 5��6g   ._�5U      �� -   5         ��Name$ Message��5U   &   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�67   ���	#FFF7F1F0$��80��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter your message��6�   $��0 0 0 0q�6�    �� TextWrapping$
 Wrap=�6�   $��5q�6�    �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�6  5V      �� 5W      -   5         ��Name$ sendBtn��5W   !   $��1��62   $��Bottom=�6B    * &MaterialDesignFloatingActionMiniButton#��[ 6]   .��5X      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Send=�66   5Y      5Z      5[      5\      �� 5^      $��0��6   ���	#FF0692FD$��1q�6=   $ 	10 0 0 10��6Q   ._�5_      �� $��3q�6   ���	#FF0692FD.+�5`      �� $��20 10q�6   $ 1q�6,   
�������$ 5��6K   ._�5a      ]� .+�5b      �� -   5        $
��Left=�5b   &   $ Hidden=�6<   $��5q�6y   $	��170��6�   $��Center=�6�   $��Center=�6�   $��0 0 0 0q�6�   $ SEARCH��6�   
���   �6%  �� 5c      $
��Left=�6%   $��0 0 0 0q�6;   $
��auto��6M   $
��auto��6Z   
������ 
������ .��5d   "     
���   �$��0q�6M   $ Search=�6X   6h   5e      5f      5g      �� 5h      -   5        $ userChatList��5h      ��65   �� *listUserChat+$ TwoWay=�$ PropertyChanged=���5i      �� 5j      .R�5k   "   � $��Center=�6'   $��5q�6D   	 5l   &   �� 5m   *   $��50 �6;   �� 5n   *   $	��150 �6;   �� 5o   *   $	��50* �6;   .+�5r   &   �� $��50��6-   $��50��68   $ 25��6D   
�������$	��0.6q�6j   ��5s   *   �� 5t   .   
avatarUser�� 6M   �� *Customer.avatar+$ TwoWay=�$ PropertyChanged=�5v   '   �� 5w   &   $��10��6-   $��10��68   $��Bottom=�6D   $��5q�6_   $��Right=�6j   $ 15��6�   
������6�   �� 5y   &   $��1��61   .+�5z   *   ��  ��Name$ UserName��64   $��15(�6F   $
��10 0q�6�   ��6T   �� *Customer.userName+$ TwoWay=�$ PropertyChanged=�6�   �� 5{   *   $ lastMessage��64   $��12(�6I   $
��10 0q�6�   $��CharacterEllipsis=�6�    J� Opacity$	 0.6Q�6�   ��6W   �� *	content+$ TwoWay=�$ PropertyChanged=�6�   5|   '   5}   #   5      5�      5�      5�      �� 5�      $��2��6   
����������	#FF0692FD$��2 0 0 0q�6P   $ 	0 10 10 0��6j   ._�5�      �� .+�5�      �� -   5        $��Right=�5�      $��10q�69     MaterialDesignFlatButton#��[ 6E   .��5�        $ Close=�62   5�      �� 5�      $	��150��6   $	��150��6)   $ 80��66   $��1q�6H   
���������5�      �� 5�       6)   �� *person.avatar+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      -   5        $ UserName��5�       $��Center=�62   $��	10 20 0 0q�6�   
���������6O   �� *person.userName+$ TwoWay=�$ PropertyChanged=�6�   �� 5�      $��20q�6!   .+�5�      �� $ 
Horizontal=�6%   $	��0 3q�6>   .+�5�        $ Location=�66   
�������6F   �� 5�      $
��10 0q�6y   
���������6(   �� *person.address+$ TwoWay=�$ PropertyChanged=�6�   5�      �� 5�      $ 
Horizontal=�6%   $	��0 3q�6>   .+�5�        $ 	Cellphone=�66   
�������6G   �� 5�      $
��10 0q�6}   
���������6(   �� *person.phoneNumber+$ TwoWay=�$ PropertyChanged=�6�   5�      �� 5�      $ 
Horizontal=�6%   $	��0 3q�6>   .+�5�        $ Email=�66   
�������6C   �� 5�      $
��10 0q�6w   
���������6(   �� *person.email+$ TwoWay=�$ PropertyChanged=�6�   5�      5�      5�      5�      5�      5�      5�      