   M S B A M L   `   `   `  ����E  AE_Shopping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:E_Shopping.UserControlBar.Screen E_Shopping.UserControlBar.Screen  5      S.clr-namespace:E_Shopping.UserControlBar.Screen E_Shopping.UserControlBar.Screen  5      7 clr-namespace:E_Shopping.ConvertE_Shopping.Convert  5	      6    0E_Shopping.UserControlBar.Screen.ShippingAddress   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:E_Shopping.UserControlBar.Screen     5      Cucscreen.clr-namespace:E_Shopping.UserControlBar.Screen     5      4convert clr-namespace:E_Shopping.Convert     5	      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          >�Name$  ShippingAddressUC��5
         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5        
Page_Style#��[ 5       � 	Resources 5      0   *E_Shopping.Convert.ConvertStringToCurrency  currencyconvert��%   &	         5   
   6*   5      .��5      �� ���#F1F1F1 �� CornerRadius$ 	0 0 10 10��6"   ._�5   
   �  � ColumnDefinitions 5      �� 5      6%   �� 5      6%   .+�5      � $��0��6    5      �� 5      $
��auto �6'   66   �� 5       6)   .+�5"      �� $��0��6    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6)   $��
15 30 0 10q�6o   $	��Top=�6�   ��6�   �� *BackToCartCommand+.��5#      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�5$      $��30��5%      $��30��5&      5'      �� 5(      $��1��6    �� Orientation$ Vertical=�6-   $��20 20 20 20q�6D   .+�5-      �� $��Order Summary��6    $��	0 15 0 10q�65   $��30(�6H   $
��Bold"�6V   $��Poppins)�6h   6   �� 5.      
�������$��1q�61   
�������$	��570��6X   $	��510��6e   $ 10��6r   $
��Left=�6�   ._�5/      �� $ Vertical=�6%   .+�50      &   System.Windows.Controls.DataGrid  -   5        $��ShoppingCartdtg��50   8   {�.    CanUserAddRows .  $	��500��6�   $	��200��6�   $��4 4 0 0q�6�   $	��Top=�6�   $
��Left=�6�   	   AutoGenerateColumns	 .  
   CanUserResizeRows
 .     CanUserDeleteRows .  $��Disabled=�6g  ��6O   �� *
listItem+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 51   "   4  .System.Windows.Controls.DataGridTemplateColumn  52   &   ,  &System.Windows.Controls.DataGridColumn   Header$
 Item��6>      Width5  /System.Windows.Controls.DataGridLengthConverter$	 175 6L      
IsReadOnly .    CellTemplate 53   *   �� 54   .   .R�55   2   �� $ 
Horizontal=�6=   $��15 0 0 0q�6V   .+�56   6   �� $
��Left=�6\   $��30��6r   $��30��6}   ��6<   �� *productImage+6�   �� 57   6   
������ $��20��6Y   
������ 
������ $��0q�6�   6�   �� 58   6   $��Center=�6_   ��6A   �� *prodductName+6|   59   3   5:   /   5<   '     5=   &   $ Price��6>   $	 175 6M    .  5>   *   �� 5?   .   .R�5@   2   �� $��Center=�6�   ��6=   �� *productPrice+ �� 	Converter# [ 6�   5A   /   5C   '     5E   &   $ Quantity��6=   $	 150 6O    .  5F   *   �� 5G   .   .R�5H   2   �� ���#F5F7FF$
��Left=�6N   $��70��6i   $��50��6t   $ 10��6�   ._�5I   6   ]� $��70��6@   $��Center=�6L   $
��Left=�6g   .+�5J   :   �� $��15 0 0 0q�6^   $��15��6p   $��14(�6{   $��Poppins)�6�   $��SemiBold"�6�   $��Center=�6�   $
��Left=�6�   ��6D   �� *
quantity+6�   �� 5K   :   $��60��6E   $��50��6P   $��
-10 3 5 -5q�6\   $ Vertical=�6p   $��Right=�6�   $��Center=�6�   .+�5L   >   �� $��increase��6n   {�.  $��16��6W   $��16��6b   $��0 2 0 5q�6~   #��[ 5M   >   .��5N   B     
���   �$��Center=�5P   =   $��Center=�5Q   =   $ 	ChevronUp=�5R   =   $��16��5S   =   $��16��5T   =   5U   ?   �� 5V   >   $��decrease��6n   {�.  $��16��6W   $��16��6b   #��[ 5W   >   .��5X   B     
���   �$��Center=�5Z   =   $��Center=�5[   =   $ ChevronDown=�5\   =   $��16��5]   =   $��16��5^   =   5_   ?   5`   ;   5b   7   5c   3   5e   /   5g   '   5l      �� 5m      
���   �$��1q�6<   6R   �� 5n      $ Vertical=�6)   $��20q�6@   .+�5o   "   �� $��Gift Card / Discount Code��6,   $��0 0 0 10q�6M   $
��Left=�6_   $��15(�6z   $��Medium"�6�   $��Poppins)�6�   6�   ]� 5p   "   $��50��6-   .+�5q   &   �� ���	#FFE8DDDD$
��Left=�6D   $��1q�6Z   $ 5��6n   ._�5r   *   �� .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�62   )	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ 	Gift code��6p   $��10 10 10 10q�6�   $��14(�6�   $��0 0 0 0q�6
  $	��270��6$  
������ ��6�   �� *
giftcode+$ TwoWay=�$ PropertyChanged=�6N  5s   '   �� 5t   &   ���#6B72D6$��1q�6C   $	��130��6W   $��50��6c   $��Right=�6o   $ 5��6�   ._�5u   *   �� $	��130��61   $��50��6=   ���#6B72D6  MaterialDesignFlatButton#��[ 6�   ��6_   �� *ApplyGiftCodeCommand+.��6�   Apply5w   +   5x   '   5y   #   ]� 5z   "   $��
10 20 28 0q�6,   .+�5{   &   �� -   5         ��Name$ 
subtotaltb��5{   0   $��15(�6�   $��Medium"�6�   $��Roboto)�6�   $��Right=�6�   ��6D   �� *Instance.subTotal+# [ $ PropertyChanged=�6  �� 5|   &   $��Subtotal��60   $��15(�6@   $��Medium"�6N   $��Roboto)�6b   $
��Left=�6v   6�   5}   #   �� 5~   "   ���#3C4257$��10 20 40 20q�6B   6Y   ]� 5   "   $��	10 0 28 0q�6,   .+�5�   &   �� -   5        $ 	SaleTaxtb��5�   0   $��15(�6�   $��Medium"�6�   $��Roboto)�6�   $��Right=�6�   ��6C   �� *Instance.saleTax+# [ 6�   �� 5�   &   $��	Sales tax��60   $��15(�6A   $��Medium"�6O   $��Roboto)�6c   $
��Left=�6w   6�   5�   #   �� 5�   "   ���#3C4257$��10 20 40 20q�6B   6Y   ]� 5�   "   $��	10 0 28 0q�6,   .+�5�   &   �� -   5        $ ShippingFeetb��5�   0   $��15(�6�   $��Medium"�6�   $��Roboto)�6�   $��Right=�6�   ��6G   �� *Instance.shippingFee+# [ $ PropertyChanged=�6  �� 5�   &   $��Shipping Fee��60   $��15(�6D   $��Medium"�6R   $��Roboto)�6f   $
��Left=�6z   6�   5�   #   �� 5�   "   ���#3C4257$��10 20 40 20q�6B   6Y   ]� 5�   "   $��	10 0 28 0q�6,   .+�5�   &   �� -   5        $ 
TotalDuetb��5�   0   $��15(�6�   $��Medium"�6�   $��Roboto)�6�   $��Right=�6�   ��6D   �� *Instance.totalDue+# [ $ PropertyChanged=�6  �� 5�   &   $��	Total Due��60   $��15(�6A   $��Medium"�6O   $��Roboto)�6c   $
��Left=�6w   6�   5�   #   5�      5�      5�      5�      5�      � 5�      $��1��6    � RowDefinitions 5�      �� 5�      $
��auto �6$   64   .+�5�      �� -   5         ��Name$ paymentprocess��5�   !   $��0��69   ��6F   �� *Instance.CurrentView+$ TwoWay=�$ PropertyChanged=�6�   5�      5�      5�      5      