   M S B A M L   `   `   `  ����E  AE_Shopping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:E_Shopping
E_Shopping  5   	       E_Shopping.Feedback   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:E_Shopping     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5          �Name$  feedbackform��5   	      MaterialDesignBody#���   5	      $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � AllowsTransparency . 
������  � WindowStyle$
 None=�5   <     MaterialDesignFont#���  5   	     
FeedBackVM � DataContext# [ 5   	    � WindowStartupLocation$ CenterScreen=�5      $	��600��5   
   $	��500��5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ FeedBack��5   	   .��5@      �� ���	#FF7DD213$��4q�6%   	 �� CornerRadius$	 10��69   ._�5A   
   � -   5        
 �Name$
 	main_grid��5A       � RowDefinitions 5B      �� 5C      $��70 �6    6.   �� 5D      6"    � 	Resources 5F        
clrPrimary �� Color �� 
TargetType  textboxStyle % !MaterialDesignFloatingHintTextBox �� BasedOn �� Property �� Value'  !MaterialDesignThemes.Wpf.PackIcon  	styleIcon  borderStyle��%�  &	       &	 #     7  7  &	     7  &	 �    7  �� 5G      $ 	#FF35A0FE��65   �� 5I      " ��6   8   .�5J      ��  � ��8  64   �� 5K       �@��AcceptsReturn . 66   �� 5L       � ��$	 333��6.   �� 5M       � ��$ 14(�61   �� 5N       � ��$ 8 0 8 8q�60   5O      �� 5Q      "  6   .�5R      ��  � ��$ 20��6/   �� 5S       � ��$ 40��6.   �� 5T       � ��$ Center=�6:   �� 5U       � ��8   63   5W      �� 5Y      " ��6   .�5Z      ��  � ��$ 1q�68   �� 5[       � ��8   64   �� 5\       �@��CornerRadius$ 5��65   �� 5]       � ��$ 0 0 5 0q�6/   5^      5_      .+�5`      � $��0��6   .+�5a      �� $	 7 7 0 0��6   ��5b      �� 5c      .��5d      �  � Color$ 	#FF1CF321��6+    � Offset$ 2Q�6=   � 5e      $ 	#FF2A589A��6+   $ 0Q�6=   5f      5h      �� 5i      $��Center=�5j      $��Center=�5k      
�������$��20(�5m      $��Inter)�6'   $��DemiBold"�5n      REPORT FORM5p      5q      � 5r      $��1��6   .+�5s      �� ���#35a0fe
�������$	 0 0 8 8��6B   $��0,-1,0,-0.2q�6Y   $	��523��6n   $��Bottom=�6{   6�   �� 5t      $��1��6   .+�5u      ��  �� Orientation$ 
Horizontal=�6!   $��
30 16 30 0q�6:   .+�5v      �� #��[ 6!   ._�5w           Kind$ Email=�66   #��[ 6C   5x      �� 5y      -   5         ��Name$ txbEmail��5z      #��[ 5{      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ E-mail��5|      $��8 0 0 0q�5}      $	��384��6*   5      �� 5�      $
��Left=�5�      $��Subject��5�      $��
30 20 30 0q�5�      $	��430��5�      $��80��5�      .��5�      �� -   5        $ 
txbSubject��5�      $
��Left=�5�       �� TextWrapping$
 Wrap=�5�      $	��280��5�       �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�5�       �� 	IsEnabled . $ Subject��5�      $��0,0,0,-4q�6F   $	��417��6X   5�      �� 5�      $
��Left=�5�      $��
Chi tiết��5�      $��
30 15 30 0q�5�      $	��430��5�      $	��190��5�      .��5�      �� -   5        $ txbBody��5�      $
��Left=�5�      $
 Wrap=�5�      $	��280��5�       . $
 Auto=�5�       . $8 2Vui lòng chia sẻ chi tiết nhất có thể...��5�      $��0,0,0,-4q�6c   $	��417��6u   5�      �� 5�      $ 
Horizontal=�6!   $��0 20 0 0q�6:   .+�5�      �� -   5         ��Name$ btnAttachment��5�        MaterialDesignRaisedButton#��[ 5�      $��	30 0 50 0q�5�      $��30��5�      $
��auto��5�      $	��430��5�      $	��0.2q�5�      
���   �+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5�      ���#e4e6eb
���   ���5�      �� *openFileImageDialog+��5�      ��  �� ElementName$ feedbackform����5�      �� 5�   "   $ 
Horizontal=�6-   .+�5�   &     $ LinkVariant=�6>   $��0 2 5 0q�6Q   �� 5�   &   $2��,Thêm ảnh chụp màn hình (đề xuất)��60   5�   #   5�      5�      �� 5�      $ 
Horizontal=�6!   $��Center=�6:   $��
220 50 0 0q�6W   .+�5�      �� -   5        $��HUỶ��5�      #��[ 5�      $��0 0 20 0q�5�      $��50��5�      $	��100��5�      $��2q�5�      ���#35a0fe$ 10��5�      
����������#35a0fe5�      �� 5�      $��GỬI��6!   #��[ 5�      $��50��5�      $	��100��5�      $��2q�5�      ���#35a0fe$ 10��5�      ���#35a0fe��5�      �� *sendEmailReport+��5�      �� $ feedbackform��5�      5�      5�      5�      5�      5�      