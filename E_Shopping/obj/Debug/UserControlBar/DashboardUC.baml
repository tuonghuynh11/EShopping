   M S B A M L   `   `   `  ����E  AE_Shopping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:E_Shopping.ConvertE_Shopping.Convert  5      E'clr-namespace:E_Shopping.UserControlBarE_Shopping.UserControlBar  5      ;"clr-namespace:E_Shopping.ViewModelE_Shopping.ViewModel  5
      3clr-namespace:E_Shopping.ModelE_Shopping.Model  5      E'clr-namespace:E_Shopping.UserControlBarE_Shopping.UserControlBar  5   	   +    %E_Shopping.UserControlBar.DashboardUC   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4convert clr-namespace:E_Shopping.Convert     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      3local'clr-namespace:E_Shopping.UserControlBar  5      +vm"clr-namespace:E_Shopping.ViewModel  5
      *modelclr-namespace:E_Shopping.Model  5      0uc'clr-namespace:E_Shopping.UserControlBar  5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          >�Name$  	Dashboard��5         MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	     
Page_Style#��[ 5        
CategoryVM � DataContext# [ 5       � 	Resources 5       �� 
TargetType �� Property �� Value0   *E_Shopping.Convert.ConvertStringToCurrency  currencyconvert��%q   '��       &	 J     �� 5   
   " ��6   .�5      ��  � ��
 �����6+   5        5   
   6*   5      .��5       ��  �� CornerRadius$ 	0 0 10 10��6   ��5!   
   �� 5"      	 �� ImageSource$	 \Image\christmas.jpg��6   ._�5$   
   �� $��Hidden=�6   .��5%      � 
 � RowDefinitions
 5'      �� 5(      $
��auto �6$   64   �� 5)      $	��250 �6$   63   �� 5*      $	��250 �6$   63   �� 5+      $	��400 �6$   63   �� 5,      $	��400 �6$   63   �� 5-      $	��700 �6$   63   .+�51      �� $��1��6   ._�52      � 
 53      �� 54      $	��210 �6,   6;   �� 55      $��* �6,   .+�57      �� $��0��6!   $��	50,4,50,0q�60   
�������$��2q�6[   $	��210��6p   $	��Top=�6}   $��2��6�   ._�59      �� -   5         ��Name$ Advertisement��59   $   $
��Fill=�6;   5:      �� 5;      $��1��6!   ._�5<      �� $��1��6)   $
��auto��66   $��Center=�6D   $��
10 0 10 10q�6a    �� Orientation$ 
Horizontal=�6u   .+�5=   "   d� -   5         0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5>   !   $��Right=�5?   !   {�. $��15��5@   2   $��15��6>   .��5A   &   '  !MaterialDesignThemes.Wpf.PackIcon  
���   �$��Center=�5C   )      Kind$ 	ArrowBack=�5D   )   $��15��5E   )   $��15��5F   *    J� RenderTransformOrigin$ 3.353,0.692&�65   $��Center=�6Y   z�5H   *   V� 5I   .   .~�5J   2   �� �� 5K   2   �� 5L   2    �� Angle$ 0Q�6B   T� 5M   2   5N   /   5P   '   5Q   #   �� 5R   "   $��. . .��6-   $��15(�6:   $
��Bold"�6H   $��24��6Z   $��5 0 0 0q�6e   6x   d� 5T   "   -   5        $��Right=�5U   !   #��[ 5V   %   {�. $��15��5W   2   $��15��6>   .��5X   &     
���   �$ 
ArrowRight=�5Z   )   $��14��5[   )   $��Center=�5\   )   $��14��5]   *   $ 3.353,0.692&�65   $��Center=�6Y   z�5_   *   V� 5`   .   .~�5a   2   �� �� 5b   2   �� 5c   2   $ 0Q�6B   T� 5d   2   5e   /   5g   '   5h   #   5i      5k      5l      5m      �� 5o      $��2��6   ���#FEFEFE$��	50 0 50 0q�6;   
���  ��$��2q�6`   $ 10 10 10 10��6t   ._�5p      �� $��Visible=�6#   $��Hidden=�6K   .��5q      �� $ Vertical=�6%   .+�5r      �� $��CATEGORY��6$   $��40(�67   $��Black"�6E   6Z   �� 5s      -   5         ��Name$ CategoryList��5s   (   $
��Left=�6e   $	��Top=�6�   ��6�   �� *
CATEGORies+ �� SelectedItem 6�   �� *SelectedCategory+ �� Mode$ TwoWay=���5t   "   �� 5u   &   .R�5v   *   �� $��4 4 4 4q�5w   %   $
��Left=�5x   %   $ 
Horizontal=�5y   %   5z   '   ��5|   "   �� 5}   &    �� DataType   E_Shopping.Model.CATEGORY"  63   .R�5~   *   .   (E_Shopping.UserControlBar.CategoryCardUC  $��8q�6=   5   '   5�      5�      5�      5�      �� 5�      $��3��6   ���#76FAF7$��
50 20 50 0q�6;   $ 10 10 10 10��6O   ._�5�      �� $��Hidden=�6#   $��Hidden=�6J   .��5�      �� $ Vertical=�6%   .+�5�      �� $��TOP-SELLING PRODUCTS��6$   $��40(�6C   $��Black"�6Q   6f   �� 5�      -   5        $ ItemBox��5�   '   $��Center=�6:   $	��Top=�6W   ��6o   �� *Items+ �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=���5�   "   �� 5�   &   .R�5�   *   A�  A� Columns$ 4��66   $��20q�6B   5�   '   ��5�   "   �� 5�   &   .R�5�   *   ��  ��Name$ Border1��61   $ 20��6B   
���  ��
�������._�5�   .   ��  ��Name$ stack��6E   $��20q�69   $ Vertical=�6T   $��Stretch=�6k   $��Stretch=�6�   .+�5�   2   �� $ 	Thumbnail��68   $��Center=�6m   $	��Top=�6�   $
��Fill=�6�   $	��100��6�   $	��100��6�   $	��270��6�   $	��270��6�   ��6K   �� *thumbnailimage+6�   �� 5�   2   $��20(�6U   $
��Bold"�6c   $��Center=�6v   $
��Wrap=�6�   ��6<   �� *	subName+6�   �� 5�   2   $��Center=�6�   ��6<   �� *price+ �� 	Converter# [ 6�   �� 5�   2   $ 
Horizontal=�6=   $��0 5 0 0q�6V   .+�5�   6   �� �� 5�   6    ��Name$ Purchasebtn��6=   -   5        
��� � �$��Order��5�   e   $
��Left=�6u   6�   �� 5�   6   6>   �� 5�   6   �� 5�   6   $ Cartbtn��6=   -   5        $��Add to cart��5�   N   
��� � �$��Right=�6w   6�   �� 5�   6   5�   3   5�   /   5�   +   5�   '   5�      5�      5�      5�      �� 5�      $��4��6   ���#76FAF7$��
50 20 50 0q�6;   $ 10 10 10 10��6O   ._�5�      �� $��Hidden=�6#   $��Hidden=�6J   .��5�      �� $ Vertical=�6%   .+�5�      �� $��LATEST PRODUCTS��6$   $��40(�6>   $��Black"�6L   6a   �� 5�      -	   5        $ NewItemList��5�   '   $��Center=�6>   $	��Top=�6[   ��6s   �� *LatestItems+$ TwoWay=�$ PropertyChanged=���5�   "   �� 5�   &   .R�5�   *   A� $ 4��66   $��30q�6B   5�   '   ��5�   "   �� 5�   &   .R�5�   *   �� $ Border1��61   $ 20��6B   
���  ��
�������._�5�   .   �� $ stack��6E   $��20q�69   $ Vertical=�6T   $��Stretch=�6k   $��Stretch=�6�   .+�5�   2   �� $ 	Thumbnail��68   $��Center=�6m   $	��Top=�6�   $
��Fill=�6�   $	��100��6�   $	��100��6�   $	��270��6�   $	��270��6�   ��6K   �� *thumbnailimage+6�   �� 5�   2   $��20(�6U   $
��Bold"�6c   $��Center=�6v   $
��Wrap=�6�   ��6<   �� *	subName+6�   �� 5�   2   $��Center=�6�   ��6<   �� *price+# [ 6�   �� 5�   2   $ 
Horizontal=�6=   $��0 5 0 0q�6V   .+�5�   6   �� �� 5�   6   $ Purchasebtn��6=   -
   5        
��� � �$��Order��5�   e   $
��Left=�6u   6�   �� 5�   6   6>   �� 5�   6   �� 5�   6   $ Cartbtn��6=   -   5        $��Add to cart��5�   N   
��� � �$��Right=�6w   6�   �� 5�   6   5�   3   5�   /   5�   +   5�   '   5�      5�      5�      5�      �� 5�      $��5��6   ���#76FAF7$��
50 20 50 0q�6;   $ 10 10 10 10��6O   ._�5�      �� $��Hidden=�6#   $��Hidden=�6J   .��5�      �� $ Vertical=�6%   .+�5�      �� $��OTHER PRODUCTS��6$   $��40(�6=   $��Black"�6K   6`   �� 5�      -   5        $ RandomItemList��5�   '   $��Center=�6A   $	��Top=�6^   ��6v   �� *RandomItems+$ PropertyChanged=�$ TwoWay=���5�   "   �� 5�   &   .R�5�   *   A� $ 4��66   $��30q�6B   5�   '   ��5�   "   �� 5�   &   .R�5�   *   �� $ Border1��61   $ 20��6B   
���  ��
�������._�5�   .   �� $ stack��6E   $��20q�69   $ Vertical=�6T   $��Stretch=�6k   $��Stretch=�6�   .+�5�   2   �� $ 	Thumbnail��68   $��Center=�6m   $	��Top=�6�   $
��Fill=�6�   $	��100��6�   $	��100��6�   $	��270��6�   $	��270��6�   ��6K   �� *thumbnailimage+6�   �� 5�   2   $��20(�6U   $
��Bold"�6c   $��Center=�6v   $
��Wrap=�6�   ��6<   �� *	subName+6�   �� 5�   2   $��Center=�6�   ��6<   �� *price+# [ 6�   �� 5�   2   $ 
Horizontal=�6=   $��0 5 0 0q�6V   .+�5�   6   �� �� 5�   6   $ Purchasebtn��6=   -   5        
��� � �$��Order��5�   e   $
��Left=�6u   6�   �� 5�   6   6>   �� 5�   6   �� 5�   6   $ Cartbtn��6=   -   5        $��Add to cart��5�   N   
��� � �$��Right=�6w   6�   �� 5�   6   5�   3   5�   /   5�   +   5�   '   5�      5�      5�      5�      5/     50     51     52     