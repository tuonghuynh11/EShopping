   M S B A M L   `   `   `  ����E  AE_Shopping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:E_Shopping
E_Shopping  5   	   "    E_Shopping.UserAccountDetail   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:E_Shopping     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��userAccountDetail��5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency .  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � Title$ UserAccountDetail��5   	   $	��350��6#   $	��600��60   .��5      ��  �� CornerRadius$ 10��6   ���#f5f2f2$��2q�64   
���   �._�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      6"   �� 5      $
��auto �6    60   .+�5      � $��0��6   .+�5      �� -   5        	 ��Name$	 	Close_but��5      $��20��6,   $��20��68   $��Center=�6C   $��Right=�5       $��0 0 5 0q�65   ��6F   Z� ��5!      �� *CloseCommand+��5"      �� 
 �� ElementName$
 userAccountDetail����5#      �� 5$       �� ImageSource$ /Image/x_icon.png��6%   5'      5(      � 5)      $��1��6    � ColumnDefinitions 5*      �� 5+      6)   �� 5,      6)   .+�5.      �� $��0��6   .+�5/      �� $��Detail Information��6   $��25(�69   $��20 0 0 0q�6G   �� 50      -   5         ��Name$ ID��50   D   $��
20 10 20 5q�6    �� 
IsReadOnly . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ID��51      ���#eeffe8 % !MaterialDesignFloatingHintTextBox#��[ 52      �� 53      -   5        $ Username��53   D   $��
20 15 20 5q�6    . $ Username��54      ���#eeffe8#��[ 55      �� 57      -   5        $
 Name��57   D   $��
20 15 20 5q�6    . $
 Name��58      ���#eeffe8#��[ 59      �� 5:      -   5        $ Gender��5:   D   $��
20 15 20 5q�6    . $ Gender��5;      ���#eeffe8#��[ 5<      5=      �� 5>      $��1��6   .+�5?      �� -   5        $ phoneNum��5?   D   $��
20 48 20 5q�6    . $ Phone number��5@      ���#eeffe8#��[ 5A      �� 5B      -   5        $ email��5B   D   $��
20 15 20 5q�6    . $ Email��5C      ���#eeffe8#��[ 5D      �� 5E      -	   5        $	 Dob��5E   D   $��
20 15 20 5q�6    . $ Date of birth��5F      ���#eeffe8#��[ 5G      �� 5H      -
   5        $ Address��5H   D   $��
20 15 20 5q�6    . $ Address��5I      ���#eeffe8#��[ 5J      5L      5M      �� 5N      $��2��6    �� Orientation$ 
Horizontal=�6&   $��30 10 10 10q�6?   .+�5O      �� -   5        $	 UnbanBTT��5O      $y�Hidden=�6+     MaterialDesignRaisedButton#��[ 5P   !   $	��150��5Q   !   $��20(�6-   $��0 0 0 0q�6;    � ToolTip$ Unban��5R   !   ���#9fc5e8.��6]   Unban5T      �� 5U      -   5        $	 AuthoBTT��5U      #��[ 5V   !   $	��150��5W   !   $��20(�6-   $��45 0 0 0q�6;   $ 	Authorize��5X   !   ���#b6d7a8.��6_   
_Authorize5Z      �� 5[      -   5        $	 BanBtt��5[      $y�Hidden=�6)   #��[ 5\   !   $	��150��5]   !   $��20(�6-   $��40 0 0 0q�5^   !   $	 Ban��5_   !   ���#f89090.��6[   _Ban5a      5b      5c      5d      5e      