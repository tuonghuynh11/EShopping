   M S B A M L   `   `   `  ����E  AE_Shopping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:E_Shopping.PopUpE_Shopping.PopUp  5   	   !    E_Shopping.PopUp.RateProduc   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:E_Shopping.PopUp     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MaterialDesignBody#���   5	      $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	   $	��350��5   	   $	��350��6    � Title$ 
RateProduc��5   	    � 	Resources 5        CustomRatingBarStyle �� 
TargetType(  "MaterialDesignThemes.Wpf.RatingBar �� Property	 �� Value��%T   &	       �� 5   
   "  6-   .�5      ��  � ��
	 � ���6+   5      5      .��5      �� 
�������
 �� CornerRadius$
 10��6    $��1q�62   
���   �._�5    
   �  � RowDefinitions 5!      �� 5"      $
��auto �6    60   �� 5#      $��75 �6    6.   �� 5$      6"   �� 5%      6"   �� 5&      6"   .+�5(      �� -   5         ��Name$ border��5(      $��0��6%   
�������$
 	10 10 0 0��6F   ._�5)      �� $��/Icon/succeed.png��6   $	��200��63   $��90��6?   $	��Top=�6K   $��0 10 0 0q�6c   6w   5*      �� 5+      -   5         ��Name$ content��5+      $��1��6)    �� TextAlignment$ Center=�66   $��Center=�6M   
���   �$��Center=�6}   $��5 0 5 0q�6�   $��Thanks for the Rating��6�   $��WrapWithOverflow=�6�   $��24(�6�   $��Regular"�6�   6    5,      -   5          Name$ 	RatingBar��5,   '   $��2��6:   
�������$��Center=�6b   $��Center=�6}      Value$ 3Q�6�   $��30(�6�    � LayoutTransform 5-      �� 5.       �� ScaleX$	 1.4Q�6%    �� ScaleY$	 1.4Q�62   6A   50      �� 51      -   5        $ describeRatelb��51      $��	10 0 10 0q�60   $��3��6C   $
��Wrap=�6P   $>��8That's great, to hear you are satisfied with the product��6d   
�������$��Center=�6�   $��Center=�6�   53      ]� 55      $��4��6   $��	20 0 20 0q�6%   .+�56      �� -   5         ��Name$ 
rateNowbtn��56      $��Right=�6-   $��Rate Now��6D   $��15(�6W   
�������
��� ���$��Center=�6�   $	��0.5q�6�   
���   �$��25��6�   $��
10 0 10 10q�6�   $	��100��6�   6  �� 57      -   5        $ rateLaterbtn��57      $
��Left=�6/   $��No Later��6E   $��15(�6X   
�������
�������$��Center=�6�   $	��0.5q�6�   
���   �$��25��6�   $��
10 0 10 10q�6�   $��90��6�   $
��Left=�6  6:  58      59      5;      5=      