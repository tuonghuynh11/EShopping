   M S B A M L   `   `   `  ����E  AE_Shopping, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:E_Shopping.UserControlBarE_Shopping.UserControlBar  5      ,    &E_Shopping.UserControlBar.ControlBarUC   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:E_Shopping.UserControlBar     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6X   -   5        $��ucControlBar��5         MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5      
������   ControlBarVM � DataContext# [ 5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *MouseMoveWindowCommand+   CommandParameter 6O   ��  �� ElementName$ ucControlBar��5      .��5      �� 	 �� Orientation$	 Vertical=�6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  
   Mode$
 Standard=�5      $��0��5      $��20��5         CornerRadius$ 	10 10 0 0��5      .��5!      ]� ��6   �� *
Background+$ ucControlBar��.+�5"      �� $��2 2 5 2q�6   $	 
Horizontal=�6.   $��16��6H   $��Right=�6T   .+�5$      �� -   5         ��Name$ btnMinimize��5$      $��0q�5%      $��-��5&      
�������$��20(�5(      $��
Montserrat)�5)       � Cursor$
 Hand��5*      ��5+      �� *MinimizeWindowCommand+��5,      �� $ ucControlBar����5/      �� 50       �� 
TargetType" ��6$   .�51   "   ��  �� Property � �� �� Value �#28AEED6?    �� Triggers 52   "   P� 53   &    P� Property �@J�IsMouseOver P� Value . . �54   *   ��  � �� �#278BEF6G   55   '   57      ��59      �� 5:       �� 
TargetType" ��6.   .R�5;   "   �� $��15��6)   $��15��64    �� CornerRadius$ 9��5<   )   #��z��5=   )   ._�5>   &   �� $��Center=�67   $��Center=�5?   7   5@   #   5A      5C      �� 5D      $��15��6    
������ 
������ 
������ $��0q�6w   6�   �� 5E      -   5        $ btnClose��5E      $��0q�5F      $��X��5G      
�������$��15(�5I      $��
Montserrat)�5J      $
 Hand��5K      $��16��5M   S   $��16��6_   ��5L      �� *CloseWindowCommand+��5M      �� $ ucControlBar����5O      �� 5P      " ��6$   .�5Q   "   ��  � �� �#DA34AE6?    5R   "   P� 5S   &    �@J�IsMouseOver . . �5T   *   ��  � �� �#C62DAE6G   5U   '   5W      ��5Y      �� 5Z      " ��6.   .R�5[   "   �� $��15��6)   $��15��64   $ 9��5\   )   #��z��5]   )   ._�5^   &   �� $��Center=�67   $��Center=�5_   7   5`   #   5a      5c      5e      �� 5h      $	 
Horizontal=�6   .+�5j      �� $��Center=�5k      $��16 0 0 0q�5l      $
��Bold"�5n      ��5m      �� *Tag+$ ucControlBar��5q      5r      5u      5v      � 5y   
   $��65��6   ���#f2d94e � ColumnDefinitions 5{      �� 5|      $	��300 �6#   61   �� 5}      $	��600 �6#   61   �� 5~      6&   .+�5�      � $��0��6   .+�5�      �� $��65��6   $��100 0q�6&   
������ $��0q�6N   
������ ��6|   �� *	IconClick+��6�   �� $ ucControlBar����5�      �� 5�      $��/Icon/ShopGo.png��6    5�      5�      �� 5�      $��1��6   $	��600��6%   $��	0 10 0 10q�61   
�������$ 10��6W   $��Center=�6i   ._�5�      �� $	 
Horizontal=�6   $
��Left=�5�      $	��600��5�      .+�5�      �� $
��Left=�6   $��10 0 0 0q�68     MaterialDesignToolButton#���  6J   .��5�      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�5�   !    J� Opacity$	 .56Q�5�   !   5�      �� 5�      -   5         ��Name$ 	SearchBox��5�      $��1��5�      $��Center=�5�   #   $��8 0 0 0q�5�   #   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Build a search bar��5�   #   .	  (MaterialDesignThemes.Wpf.TextFieldAssist 	  DecorationVisibility$ Hidden=�5�   #   $��0q�5�   #   $	��520��5�   #   $��Center=�5�   #   ��5�      �� *
SearchWD+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6k    J� InputBindings 5�      �� 5�      
 �� Key$ Enter��6�     �� Command  6)   �� *SearchCommand+! �� CommandParameter! 6K   �� $ ucControlBar��6�   .��5�   1   5�      �� 5�      #���  5�      $��Right=�5�      $��2��5�      ��5�      �� *SearchCommand+��5�      �� $ ucControlBar��.��5�        $ 
Microphone=�5�   !   $	 .56Q�5�   !   $��8 0 0 0q�5�   !   5�      5�      5�      �� 5�      $��2��6   $	 
Horizontal=�6)   $��0 0 40 0q�6B   $��Center=�6U   $��Right=�6p   .+�5�      �� -   5        " ��Name$" CartNote��5�      $��0 0 30 0q�6+   $ 5��6=   
����� �$��33��6a   $��33��6m   ��5�      �� 5�      # �� ImageSource$# \Image\cart.png��6%   6E    5�      d� 5�      $ d� MouseAction$$ 	LeftClicke�6'     6?   �� *	CartClick+! 6]   �� $ ucControlBar��5�      �� 5�      -   5        $" ChatIcon��5�      $��0 0 30 0q�6+   $ 5��6=   
����� �$��33��6a   $��33��6m    5�      d� 5�      $$ 	LeftClicke�6'     6?   �� *PartyInTheUSA+! 6a   �� $ ucControlBar��._�5�        $
 Chat=�6.   $��Center=�6:   ���	#FFADA5BB$��33��6n   $��Center=�6z   $��33��6�   6�   5�      �� 5�      -   5        $" FeedBackIcon��5�      $��0 0 30 0q�6/   $ 5��6A   $��33��6S   $��33��6_    5�      d� 5�      $$ 	LeftClicke�6'     6?   �� *FeedBackClick+! 6a   �� $ ucControlBar��._�5�        
�������$ Feedback=�6A   $	 .56Q�6Q   $��Center=�6_   $��33��6|   $��Center=�6�   $��33��6�   6�   5�      � 5�      $��0 0 20 0q�6   % � RowDefinitions% 5�      �� 5�      6*   .+�5�      '
  !MaterialDesignThemes.Wpf.PopupBox
  -   5        & 
 Name$& notifipopup��5�   .   ' 
  PlacementMode$' BottomAndAlignRightEdges=�6d   ( 
  	StaysOpen( . $��Right=�6�   $��Center=�6�   $��0 0 0 0q�6�   ) � ToolTip) 6C   �� *NotifyPopUp+* 
  ToggleContent* 5�        5�      $
 Bell=�66   ���	#FFC8BDC5$��25��6Y   $��25��6e   $��0 0 0 0q�6q   + 
  PopupContent.+ 5�      �� -	   5        $��lvUsers��5�   #   $	��300��62   $��Hidden=�6>   ��6�   �� *
Notifies+$ TwoWay=�$ PropertyChanged=�, �� View, 5�      �� 5�   "   .P�5�   &   �� $��Notifications��65   - �� Width$	- 300��6M   . �� HeaderContainerStyle. 5�   *   �� 5�   .   " ��64   .�5�   2   ��  � ��$ Center=�6_   �� 5�   2    � ��$ Center=�6]   �� 5�   2    � ��$ Center=�6V   �� 5�   2    � ��$ 25(�6M   �� 5�   2    � ��
 � ���6O   �� 5�   2    � ��
 �����6O   �� 5�   2    �@J�IsHitTestVisible .  6U   5�   /   / �� CellTemplate/ 5�   *   �� 5�   .   .R�5�   2   �� $
��Wrap=�6<   ��6P   �� *NOTIFY+5�   /   5�   '   5�   #   0 �� 
GroupStyle0 5�      (  "System.Windows.Controls.GroupStyle  5�   "   1   ContainerStyle1 5�   &   �� 5�   *   " ��60   .�5�   .   ��  � �� 5�   2   �� 5�   6   .R�5�   :   9� 2 9� 
IsExpanded2 . ��5�   >   �� 5�   B   $	 
Horizontal=�6M   .+�5�   F   �� $
��Bold"�6f   
���  ��$��18(�6�   $��Bottom=�6�   ��6P   �� *Name+6�   �� 5�   F   $�� (��6P   $��18(�6Z   
�������$��Italic$�6|   $��Bottom=�6�   6�   �� 5�   F   $��20(�6l   
��� � �$
��Bold"�6�   $��Italic$�6�   $��0,0,0,0q�6�   $��Bottom=�6�   ��6P   �� *	ItemCount+6�   �� 5�   F   $��)��6P   $��18(�6Y   
�������$��Italic$�6{   $��Bottom=�6�   6�   5�   C   .��5�   >   �� 5�   ;   5   7   5  /   5  +   5  #   5     5     %  MaterialDesignThemes.Wpf.Badged  5	     -
   5        3  Name$3 numberofnotifies��5	  x   4   BadgeForeground
4 �����5   BadgeBackground
5 �  ��$	��Top=�6�   $��Right=�6�   $��
0 10 14 10q�6�   6   Badge6 6,   �� *	Uncheck+$ PropertyChanged=�$ TwoWay=�5
     5     �� 5     $ 50��6   $��1q�6+   
�������$��30��6R   $��33��6^   ��5     �� 5     -   5        
avatar��7 j� Stretch$
7 Fill=�5  �   # 6%   �� *Avatar+$ TwoWay=�$ PropertyChanged=�6�   5     �� 5     -   5        8 ��Name$8 
UserNamelb��5     $��Center=�6-   $��5q�6H   ��6S   �� *
UserName+$ TwoWay=�$ PropertyChanged=�6�   �� 5     -   5        9 ��Name$9 
Accountcbb��5     $��Center=�6/   $��Center=�6L   $ Hidden=�6g   $��17��6�   $��0 0 0 0q�6�   
�������
������ .@�5     �� -   5        : ��Name$: 
ProfileCmb��5  #   .��5     �� $	 
Horizontal=�6%   .+�5     �� $��/Image/personalinfo.png��6$   $
��Fill=�6E   $��20��6T   6b   �� 5     $��Profile��6(   5     5     �� 5     -   5        $: 
BillingCmb��5  #   .��5     �� $	 
Horizontal=�6%   .+�5     �� $��/Image/billing.png��6$   $
��Fill=�6@   $��20��6O   6]   �� 5      $��History��6(   5!     5"     �� 5#     .��5$     �� $	 
Horizontal=�6%   .+�5%     �� $��/Image/setting.png��6$   $
��Fill=�6@   $��20��6O   6]   �� 5&     $��Confirm Order��6(   5'     5(     �� 5*     .��5+     �� $	 
Horizontal=�6%   .+�5,     �� $��/Image/contact.png��6$   $
��Fill=�6@   $��20��6O   6]   �� 5-     $��Chat with customer��6(   5.     5/     �� 51     .��52     �� $	 
Horizontal=�6%   .+�53     �� $��Change Pass��6(   54     55     �� 56     -   5        $: cmbAccountList��56  #   .��57     �� $	 
Horizontal=�6%   .+�58     �� $��List of accounts��6(   59     5:     �� 5<     -   5        $: cmbItemList��5<  #   .��5=     �� $	 
Horizontal=�6%   .+�5>     �� $��Product management��6(   5?     5@     �� 5A     -   5        $: cmbUnConfirmed��5A  #   .��5B     �� $	 
Horizontal=�6%   .+�5C     �� $��
Statistics��6(   5D     5E     �� 5F     -   5        $: 	cmbFinish��5F  #   .��5G     �� $	 
Horizontal=�6%   .+�5H     �� $��Finish Orders��6(   5I     5J     �� 5K     -   5        $: cmbManageGiftCode��5K  #   .��5L     �� $	 
Horizontal=�6%   .+�5M     �� $��Manage GiftCodes��6(   5N     5O     �� 5P     .��5Q     �� $	 
Horizontal=�6%   .+�5R     �� $��/Image/logout.png��6$   $
��Fill=�6?   $��20��6N   6\   �� 5S     $��Log out��6(   5T     5U     5W     5X     5[     5]     5^     