   M S B A M L   `   `   `  ����E  AE_Shopping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:E_Shopping
E_Shopping  5   	   ;"clr-namespace:E_Shopping.ViewModelE_Shopping.ViewModel  5      3clr-namespace:E_Shopping.ModelE_Shopping.Model  5	   	   E'clr-namespace:E_Shopping.UserControlBarE_Shopping.UserControlBar  5   	       E_Shopping.Dashboard   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:E_Shopping     5   	   1vm"clr-namespace:E_Shopping.ViewModel     5      0modelclr-namespace:E_Shopping.Model     5	   	   6uc'clr-namespace:E_Shopping.UserControlBar     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ 	Dashboard��5   	   $	��800��6   $
��1300��6(     
CategoryVM � DataContext# [ 5   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%T   '��       �� 5      " ��6   .�5      ��  � ��
 �����6/   5      5      ��5      �� 5   
    �� ImageSource$ Image\christmas.jpg��6   69   .��5       �� .��5!   
   � 	 � RowDefinitions	 5#      �� 5$      $
��auto �6    60   �� 5%      $	��250 �6    6/   �� 5&      $	��350 �6    6/   �� 5'      $	��500 �6    6/   �� 5(      $	��500 �6    6/   �� 5)      6"   .+�5,      �� $��1��6   ._�5-      � 	 5.      �� 5/      $	��210 �6(   67   �� 50      $��* �6(   .+�52      �� $��0��6   $��	50,4,50,0q�6,   
�������$��2q�6W   
 �� CornerRadius$
 10 10 10 10��6k   $	��210��6�   $	��Top=�6�   $��2��6�   ._�54      �� -   5         ��Name$ Advertisement��54   #   $
��Fill=�6;   55      �� 56      $��1��6   ._�57      �� $��1��6%   $
��auto��62   $��Center=�6@   $��
10 0 10 10q�6]    �� Orientation$ 
Horizontal=�6q   .+�58      d� -   5         0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 59   !   $��Right=�5:   !   {�. $��15��5;   2   $��15��6>   .��5<   "   '  !MaterialDesignThemes.Wpf.PackIcon  
���   �$��Center=�5>   )      Kind$ 	ArrowBack=�5?   )   $��15��5@   )   $��15��5A   *    J� RenderTransformOrigin$ 3.353,0.692&�65   $��Center=�6Y   z�5C   &   V� 5D   *   .~�5E   .   �� �� 5F   .   �� 5G   .    �� Angle$ 0Q�6>   T� 5H   .   5I   +   5K   #   5L      �� 5M      $��. . .��6)   $��15(�66   $
��Bold"�6D   $��24��6V   $��5 0 0 0q�6a   6t   d� 5O      -   5        $��Right=�5P   !   #��[ 5Q   %   {�. $��15��5R   2   $��15��6>   .��5S   "     
���   �$ 
ArrowRight=�5U   )   $��14��5V   )   $��Center=�5W   )   $��14��5X   *   $ 3.353,0.692&�65   $��Center=�6Y   z�5Z   &   V� 5[   *   .~�5\   .   �� �� 5]   .   �� 5^   .   $ 0Q�6>   T� 5_   .   5`   +   5b   #   5c      5d      5f      5g      5h      �� 5j      $��2��6   ���	#FF91D6C2$��	50 0 50 0q�69   
���  ��$��2q�6^   $
 10 10 10 10��6r   ._�5k      �� $��Visible=�6   $��Hidden=�6G   .��5l      �� $ Vertical=�6!   .+�5m      �� $��DANH MỤC SẢN PHẨM��6    $��40(�6<   $��Black"�6J   6_   �� 5n      ��6'   �� *
CATEGORies+ 5o       �� DataType   E_Shopping.Model.CATEGORY.   (E_Shopping.UserControlBar.CategoryCardUC��%T   (��       5p   +   *, +)�� 6   "  6+   .R�5q   "     $��8q�65   5r      5s      ��5t      �� 5u      .R�5v   "   �� $��4 4 4 4q�5w   %   $
��Left=�5x   %   $ 
Horizontal=�5y   %   5z      5|      5}      5~      5      �� 5�      $��3��6   ���	#FF91D6C2$��	50 0 50 0q�69   ._�5�      �� -   5         ��Name$ ItemBox��5�      $
��Left=�6,   $	��Top=�6G   ��6_   �� *Items+��5�      �� 5�      .R�5�      A�  A� Columns$ 5��6*   5�      ��5�      �� 5�      .R�5�      �� 
���  ��
�������._�5�      �� $ Vertical=�6)   $��Stretch=�6@   $��Stretch=�6\   .+�5�   "   �� $��Center=�6E   $	��Top=�6b   $
��Fill=�6z   $	��100��6�   $	��100��6�   $	��270��6�   $	��270��6�   ��6(   �� *	ImageData+6�   �� 5�   "   $��Bottom=�6C   $��Center=�6^   $
��Wrap=�6{   ��6,   �� *name+6{   �� 5�   "   ��6,   �� *price+	10000đ6K   �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   ��  ��Name$ Purchasebtn��6-   -   5        
��� � �$��Order��5�   U   $
��Left=�6e   6�   �� 5�   &   6.   �� 5�   *   �� 5�   &   $ Cartbtn��6-   -   5        $��Add to cart��5�   >   
��� � �$��Right=�6g   6�   5�   #   5�      5�      5�      5�      5�      �� 5�      $��4��6   $��	50 0 50 0q�6#   ��5�      �� 5�       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5�      �  � Color$ Black��6'   � 5�      $ 	#FF37C8C8��6'    � Offset$ 1Q�69   5�      ._�5�      �  � ColumnDefinitions 5�      �� 5�      $	��500 �6+   69   �� 5�      $	��800 �6+   69   .+�5�      �� $��0��6   ��5�      �� 5�      $ Image/ad2.jpg��6)    j� Stretch$
 Fill=�6E   5�      5�      �� 5�      $��1��6   ._�5�      �� $��50(�6(   $��Italic$�66   $��Black"�6I   
��� � �#!"Không có gì là không thể"6�   5�      5�      5�      5�      5�      5�      