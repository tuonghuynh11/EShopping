   M S B A M L   `   `   `  ����E  AE_Shopping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:E_Shopping.UserControlBar.Screen E_Shopping.UserControlBar.Screen  5      6    0E_Shopping.UserControlBar.Screen.ShippingDetails   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:E_Shopping.UserControlBar.Screen     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      -   5          >�Name$  ShippingDetailUC��5         MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5        
Page_Style#��[ 5      .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      6   .+�5   
   � $��0��6   $��
20 0 20 0 q�6    � ColumnDefinitions 5      �� 5      6%   �� 5      6%   �� 5      6%   �� 5      6%   �� 5      6%   .+�5      �� $��0 35 0 0q�6   ���	#FF45AB20$��Shipping��6A   $��22(�6Q   $��Medium"�6_   $��Roboto)�6s   6�   �� 5       $��1��6    �� Orientation$ 
Horizontal=�6)   $��
-10 20 0 0q�6B   .+�5!      �� $��/Icon/line1.png��6   $��30��62   $��0 0 5 0q�6=   6P   �� 5"      $��/Icon/nocheck.png��6   $��30��64   6A   �� 5#      $��/Icon/line1.png��6   $��30��62   $��5 0 0 0q�6=   6P   5$      �� 5&      $��2��6   $��0 35 0 0q�6(   ���#585858$��Delivery��6O   $��22(�6_   $��Medium"�6m   $��Roboto)�6�   6�   �� 5'      $��3��6   $ 
Horizontal=�6)   $��
-10 20 0 0q�6B   .+�5(      �� $��/Icon/line1.png��6   $��30��62   $��0 0 5 0q�6=   6P   �� 5)      $��/Icon/nocheck.png��6   $��30��64   6A   �� 5*      $��/Icon/line1.png��6   $��30��62   $��5 0 0 0q�6=   6P   5+      �� 5,      $��4��6   $��0 35 0 0q�6(   ���#585858$��Payment��6O   $��22(�6^   $��Medium"�6l   $��Roboto)�6�   6�   5-      � 5.   
   $��1��6   $��0 0 20 0q�6    5/      �� 50      $	��310 �6    6/   �� 51      $	��260 �6    6/   �� 52      $
��auto �6    60   .+�54      �� $��0��6   
������� �� CornerRadius$ 10��66   ._�55      �� $ Vertical=�6   .+�56      ]� .+�57      �� $��Right=�6!   $��0q�68   $��20��6D   
���  ��
������ 
������ $��Bottom=�6�   $��Use profile infomation?��6�   $��
20 5 20 10q�6�   $��14(�6�   $
��Bold"�6�   $��Poppins)�6  ��6  �� *UseProfileInformationCommand+��6L  ��  �� ElementName$ ShippingDetailUC��6�  �� 58      $��Contact Details��6$   $��	20 5 0 10q�6;   $��30(�6N   $
��Bold"�6\   $��Poppins)�6n   6�   59      ]� 5:      $��20 0 0 0q�6    .+�5;      �� $ Vertical=�6%   $
��Left=�6<   .+�5<      �� $��First Name(*)��6(   $��0 0 0 10q�6=   $
��Left=�6O   $��15(�6j   $��Medium"�6x   $��Poppins)�6�   6�   �� 5=      ���#F9F9F9���	#FFE8DDDD$
��Left=�6R   $��2q�6h   $ 5��6|   $	��286��6�   ._�5>   "   �� -   5         ��Name$ contactfirstNametb��5>   *   .  (MaterialDesignThemes.Wpf.TextFieldAssist	   DecorationVisibility$	 Hidden=�6�   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Your first name��6�   $��10 10 10 10q�6  $��14(�6  $��0 0 0 0q�6$  $	��270��6>  
������ ��6F   �� *
firstNanme+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6h  5?      5@      �� 5A      $ Vertical=�6%   $��Right=�6<   $��	10 0 20 0q�6S   .+�5B      �� $��Last Name(*)��6(   $��0 0 0 10q�6<   $
��Left=�6N   $��15(�6i   $��Medium"�6w   $��Poppins)�6�   6�   �� 5C      ���#F9F9F9���	#FFE8DDDD$
��Left=�6R   $��2q�6h   $ 5��6|   ._�5D   "   �� -   5        $ contactlastNametb��5D   *   $	 Hidden=�6�   $
 Your last name��6�   $��10 10 10 10q�6�   $��14(�6  $��0 0 0 0q�6"  $	��270��6<  
������ ��6E   �� *	lastNanme+$ TwoWay=�$ PropertyChanged=�6g  5E      5F      5G      �� 5H      $ Vertical=�6!   $��
20 10 20 0q�68   .+�5I      �� $��Email��6$   $��0 0 0 10q�61   $
��Left=�6C   $��15(�6^   $��Medium"�6l   $��Poppins)�6�   6�   �� 5J      ���#F9F9F9���	#FFE8DDDD$
��Left=�6N   $��2q�6d   $ 5��6x   ._�5K      �� -   5        $ contactEmailtb��5K   &   $	 Hidden=�6�   $
 
Your email��6�   $��10 10 10 10q�6�   $��14(�6  $��0 0 0 0q�6  
������ ��6>   �� *email+$ TwoWay=�$ PropertyChanged=�6M  5L      5M      �� 5N      $ Vertical=�6!   $��
20 10 20 0q�68   .+�5O      �� $��Phone(*)��6$   $��0 0 0 10q�64   $
��Left=�6F   $��15(�6a   $��Medium"�6o   $��Poppins)�6�   6�   �� 5P      ���#F9F9F9���	#FFE8DDDD$
��Left=�6N   $��2q�6d   $ 5��6x   ._�5Q      �� -   5        $ contactphonetb��5Q   &   $	 Hidden=�6�   $
 Your phone number��6�   $��10 10 10 10q�6�   $��14(�6  $��0 0 0 0q�6!  
������ ��6>   �� *phoneNumber+$ TwoWay=�$ PropertyChanged=�6Z  5R      5S      5T      5U      �� 5V      $��1��6   $��0 20 0 0q�6#   
�������$ 10��6H   ._�5W      �� $ Vertical=�6   .+�5X      �� $��Shipping Details��6    $��	20 5 0 10q�68   $��30(�6K   $
��Bold"�6Y   $��Poppins)�6k   6�   �� 5Y      $ Vertical=�6!   $��	20 0 20 0q�68   .+�5Z      �� $��
Address(*)��6$   $��0 0 0 10q�66   $
��Left=�6H   $��15(�6c   $��Medium"�6q   $��Poppins)�6�   6�   �� 5[      ���#F9F9F9���	#FFE8DDDD$
��Left=�6N   $��2q�6d   $ 5��6x   ._�5\      �� -   5        $ shippingAddresstb��5\   &   $	 Hidden=�6�   $
 Your address��6�   $��10 10 10 10q�6�   $��14(�6  $��0 0 0 0q�6  
������ ��6A   �� *	address+$ TwoWay=�$ PropertyChanged=�6T  5]      5^      �� 5_      $ Vertical=�6!   $��
20 10 20 0q�68   .+�5`      �� $
��Note��6$   $��0 0 0 10q�60   $
��Left=�6B   $��15(�6]   $��Medium"�6k   $��Poppins)�6   6�   �� 5a      ���#F9F9F9���	#FFE8DDDD$
��Left=�6N   $��2q�6d   $ 5��6x   ._�5b      �� -   5        $ shippingnotetb��5b   &   $	 Hidden=�6�   $
 Note for shop��6�   $��10 10 10 10q�6�   $��14(�6  $��0 0 0 0q�6  
������ ��6>   �� *note+$ TwoWay=�$ PropertyChanged=�6O  5c      5d      5e      5g      �� 5h      $��Right=�6   $	��Top=�61   $	��200��6I   $��2��6U   $��0 10 0 0q�6b   $ 10��6t   
���  ��$��2q�6�   ._�5i      �� -   5         ��Name$ continuebtn��5i      $��30��6.   $��Continue��6:   
������ $��0q�6f   $��20(�6z   $��Poppins)�6�   $��SemiBold"�6�   ��6�   �� *ContinueToDeliveryOptions+��6�   �� $ ShippingDetailUC��6  5j      5k      5l      5m      