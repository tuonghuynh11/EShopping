   M S B A M L   `   `   `  ����E  AE_Shopping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:E_Shopping.UserControlBar.Screen E_Shopping.UserControlBar.Screen  5      7 clr-namespace:E_Shopping.ConvertE_Shopping.Convert  5	      5    /E_Shopping.UserControlBar.Screen.DeliveryOption   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:E_Shopping.UserControlBar.Screen     5      4convert clr-namespace:E_Shopping.Convert     5	      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      -   5          >�Name$  DeliveryOptionsUC��5         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5        
Page_Style#��[ 5       � 	Resources 5      0   *E_Shopping.Convert.ConvertStringToCurrency  currencyconvert��%   &	         5   
   6*   5      .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      6   .+�5   
   � $��0��6   $��
20 0 20 0 q�6    � ColumnDefinitions 5      �� 5      6%   �� 5      6%   �� 5       6%   �� 5!      6%   �� 5"      6%   .+�5$      �� $��0 35 0 0q�6   ���	#FF45AB20$��Shipping��6A   $��22(�6Q   $��Medium"�6_   $��Roboto)�6s   6�   �� 5%      $��1��6    �� Orientation$ 
Horizontal=�6)   $��
-10 20 0 0q�6B   .+�5&      �� $��/Icon/lineselect.png��6   $��30��67   $��0 0 5 0q�6B   6U   �� 5'      $��/Icon/check.png��6   $��30��62   6?   �� 5(      $��/Icon/lineselect.png��6   $��30��67   $��5 0 0 0q�6B   6U   5)      �� 5+      $��2��6   $��0 35 0 0q�6(   ���	#FF45AB20$��Delivery��6Q   $��22(�6a   $��Medium"�6o   $��Roboto)�6�   6�   �� 5,      $��3��6   $ 
Horizontal=�6)   $��
-10 20 0 0q�6B   .+�5-      �� $��/Icon/line1.png��6   $��30��62   $��0 0 5 0q�6=   6P   �� 5.      $��/Icon/nocheck.png��6   $��30��64   6A   �� 5/      $��/Icon/line1.png��6   $��30��62   $��5 0 0 0q�6=   6P   50      �� 51      $��4��6   $��0 35 0 0q�6(   ���#585858$��Payment��6O   $��22(�6^   $��Medium"�6l   $��Roboto)�6�   6�   52      � 53   
   $��1��6   $��0 0 20 0q�6    54      �� 55      $	��310 �6    6/   �� 56      $
��auto �6    60   .+�58      �� $��0��6   
������� �� CornerRadius$ 10��66   ._�59      �� $ Vertical=�6   .+�5:      �� $��Delivery Options��6    $��
20 25 0 10q�68   $��30(�6L   $
��Bold"�6Z   $��Poppins)�6l   6�   ]� 5;      $��
20 10 0 20q�6    .+�5<      �� ���	#FF3DCE3D$��10 12 34 10q�6�   $��Right=�6�   $��Center=�6�   $��15(�6  $��Regular"�6   $��Poppins)�65  ��6$   �� *standardDeliveryPrice+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� 	Converter#
 [ 6L  	� 5=      -   5         	�Name$ freeshiprdbtn��5=   &    	� 	GroupName$ delivery��6=   $
��Left=�6�    d� 	IsChecked 6R   �� *standardDelivery+$ TwoWay=�$	 PropertyChanged=�6�   �� 5>      $ ��Standard 5-7 Business Days��6$   $��
10 12 0 10q�6F   $
��Left=�6Z   $��Center=�6p   $��15(�6�   $��Regular"�6�   $��Poppins)�6�   6�   5?      ]� 5@      $��	20 0 0 20q�6    .+�5A      �� $��10 12 34 10q�6�   $��Right=�6�   $��Center=�6�   $��15(�6�   $��Regular"�6
  $��Poppins)�6  ��6$   �� *businessDeliveryPrice+$ TwoWay=�$	 PropertyChanged=�#
 [ 66  	� 5B      -   5        $ expressshiprdbtn��5B   &   $ delivery��6�   $
��Left=�6�    6@   �� *businessDelivery+$ TwoWay=�$	 PropertyChanged=�6�   �� 5C      $��2-4 Business Days��6$   $��
10 12 0 10q�6=   $
��Left=�6Q   $��Center=�6g   $��15(�6�   $��Regular"�6�   $��Poppins)�6�   6�   5D      ]� 5E      $��20 0 0 0q�6    .+�5F      �� $��10 12 34 10q�6�   $��Right=�6�   $��Center=�6�   $��15(�6�   $��Regular"�6	  $��Poppins)�6  ��6$   �� *sameDayDeliveryPrice+$ TwoWay=�$	 PropertyChanged=�#
 [ 65  	� 5G      -   5        $ SuperExpressShiprdbtn��5G   &   $ delivery��6�   $
��Left=�6�    6E   �� *sameDayDelivery+$ TwoWay=�$	 PropertyChanged=�6�   �� 5H      $��Same day delivery��6$   $��
10 12 0 10q�6=   $
��Left=�6Q   $��Center=�6g   $��15(�6�   $��Regular"�6�   $��Poppins)�6�   6�   5I      5J      5K      ]� 5L      $��1��6   $��0 0 0 0q�6%   .+�5M      �� $��Right=�6   $��Right=�60   $	��Top=�6L   $	��200��6d   $��0 10 0 0q�6q   $ 10��6�   
���  ��$��2q�6�   ._�5N      �� -   5         ��Name$ continuebtn��5N      $��30��62   $��Continue��6>   
������ $��0q�6j   $��20(�6~   $��Poppins)�6�   $��SemiBold"�6�   ��6�   �� *ContinueMakePaymentCommand+��6�   ��  �� ElementName$ DeliveryOptionsUC��6$  5O      �� 5P      -   5         ��Name$ borderbackbtn��5P      $
��Left=�6�   $	��Top=�6�   $	��200��6�   $��-230 10 0 0q�6�   $ 10��6�   ���#A2A6B0
������ $��2q�6  y�60   �� *backButtonVisibility+$	 PropertyChanged=�._�5Q      �� -   5        $ backbtn��5Q      $��30��6.   $
��Back��6:   
������ $��0q�6b   $��20(�6v   $��Poppins)�6�   $��SemiBold"�6�   ���#A2A6B0��6�   �� *BackToShipingDetailCommand+��6�   �� $ DeliveryOptionsUC��61  5R      5S      5U      5W      5X      