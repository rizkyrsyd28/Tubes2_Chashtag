   M S B A M L   `   `   `  ���� C  ?Chashtag, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Chashtag.ViewsChashtag.Views      Chashtag.Views.SideGrid   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:Chashtag.Views       � 	Resources     FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 RoundedButton �� 
TargetType �� 
TargetType ��Name	 �� CornerRadius
 ��Name �� Triggers P� Property P� Value �� 
TargetName  FocusVisual1  OptionMarkFocusVisual ! RadioButton.Static.Background  RadioButton.Static.Border  RadioButton.Static.Glyph $  RadioButton.MouseOver.Background   RadioButton.MouseOver.Border  RadioButton.MouseOver.Glyph " RadioButton.Pressed.Background  RadioButton.Pressed.Border  RadioButton.Pressed.Glyph # RadioButton.Disabled.Background  RadioButton.Disabled.Border  RadioButton.Disabled.Glyph  RadioButtonResize �Name � ColumnDefinitions A�Name J� Opacity��%�  &	        &	 R     &	 g     &	 |     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
     7   7  7  7  7  7  7  7  7  7 	 &	     &	 _    &	 �    &	 �    &	 �    &	 �    &	     &	 !    &	 6    &	 K    &	 `    &	 u    &	 �    &	 �    &	 �    7  7  7  7  7  7  7  7  7  7  7  7  7  7  �� .���  � �� �� .R��� $��2q�$	 1 2R�#��� ��$
 true��$��1���� $ 	#FFDDDDDD���� $ 	#FF707070���� $ 	#FFBEE6FD���� $ 	#FF3C7FB1���� $ 	#FFC4E5F6���� $ 	#FF2C628B���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��$	 10��#��z��#��z��#��z��$
 true��._��� $
 contentPresenter��$|�False��#��z��#��z��$
��True��# z #��z�� P�  �@��IsDefaulted$
 true��. ��� $ border��# � �� � ��P�  �@J�IsMouseOver$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � ��$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � {�$ false��. ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8 	  � ���� .���  � �� �� .R��� $��2q�$	 1 2R�#��� ��$
 true��$��1���� .���  � �� �� .R��� $��14,0,0,0q�$	 1 2R�#��� ��$
 true��$��1���� $ 	#FFFFFFFF���� $ 	#FF707070���� $ 	#FF212121���� $ 	#FFF3F9FF���� $ 	#FF5593FF���� $ 	#FF212121���� $ 	#FFD9ECFF���� $ 	#FF3C77DD���� $ 	#FF212121���� $ 	#FFE6E6E6���� $ 	#FFBCBCBC���� $ 	#FF707070���� " 	�.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � �� �� " 	�.R�� $ templateRoot��
������ $
 True�� �� $
��Auto ��� $��* �.+��� $ radioButtonBorder��$��15��$��15��#��z��#��z��#��z��$		 100��#��z��$��1,5,2,1q�#��z��._�� $ markGrid��$��2q�.+�A� $ 
optionMark��8�� $��6��$��6��$ 0Q��� $
 contentPresenter��$��1��$|�False��#��z��#��z��$
��True��# z #��z�� P�  � ��$
 true��. ��� 8   �@�FocusVisualStyle��  � ��$ 4,-1,0,0q�P�  �@J�IsMouseOver$
 true��. ��� $ radioButtonBorder��8   � ���� $ radioButtonBorder��8   � ���� $ 
optionMark��8   � ��P�  � {�$ false��. ��� $ radioButtonBorder��8   � ���� $ radioButtonBorder��8 	  � ���� $ 
optionMark��8 
  � ��P�  � ��$
 true��. ��� $ radioButtonBorder��8   � ���� $ radioButtonBorder��8   � ���� $ 
optionMark��8   � ��P�  �@d�	IsChecked$
 trueY�. ��� $ 
optionMark�� �@J�Opacity$ 1Q�P�  Z�  �@d�	IsChecked. ��� $ 
optionMark�� �@J�Opacity$
 0.56Q�.��� .+��� $	 20��$��10q����#24283b._�� $��Center=� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+�� $��0��.+��� $��CHashtag��$��Center=�$��Center=� �� Padding$ 0q�$��0q�
�������$��	ExtraBold"�$��40(�� $��1��$��	 0 0 0 40q�.+��� $��Treasure Hunt Solver��$��Center=�$��Center=�$ 0q�$��0q�
�������$��Normal"�$��Italic$�$��20(�� $��2��$��Stretch=� �� $��2* ��� $��2* �.+�� $��0��.+��� -    ��Name$ 
input_file��#��� 
 $��
Input File��$��40��$��90��$��16(�$��25 5 5 5q�$��Stretch=�$��Stretch=�
����������� *OpenFileCommand+� $��1��.+��� -    ��Name$ 	file_name��
�������$��19(�$��Center=�$��5 5 15 5q�$��30��$��WrapWithOverflow=�$��CharacterEllipsis=����� *
FileName+� $��3��$��0 30 0 0q� �� $
��Auto ��� $
��Auto �.+��� -   $ label_algoritma��$��0��$��0 0 0 0 q�$��	Algoritma��
�������$��Center=�$��Center=�$��30(�$��SemiBold"���  �� Orientation$ Vertical=�$��1��$��Center=�.+�	� -    	�Name$	 bfs��#���  $	��BFS��
�������$��20(�$��	0 10 0 10q� d� 	IsChecked �� *isBFS+	� -   $	 dfs��#���  $	��DFS��
�������$��20(�$��0 0 0 10q� �� *isDFS+� $��4��$��Center=�$��0 0 0 20q� �� $
��Auto ��� $
��Auto �.+�� $��0��.+��� -   $ 	tsp_title��
�������$	��TSP��$��19(�$��Center=�$��5 5 5 5q�$��30��� $��1��.+��� -    ��Name$ 	tsp_check��$��Center=�$��Center=�$��0q� �� *isTSP+� $��5��$��Center=�$��0 0 0 20q� �� $
��Auto ��� $
��Auto �.+��� -   $ 
time_delay��$��0��$��
Time Delay��$��13(�
�������$��0 0 0 10q�$
��Left=�� $��1�� �� $
��Auto ��� $��* �.+��� -	    ��Name$ time_sliders��$��0�� � Minimum$ 0Q� � Maximum$	 100Q�$	��180��$��30�� �� TickFrequency$ 1Q� �� TickPlacement$
 None=�$��Center=�  � Value  �� *Time+�� $��1��
�������$	��Top=�$��15(����� *Value+! �� ElementName$! time_sliders��" �� StringFormat$" {0:0}��� $��6��$��10q�.+��� -
   $ 
start_file��#��� 
 $��Find Treasure !��$��45��$��Center=�$��Center=�
�������$��18(�$	��140������ *StartProcess+� $��7��$��8q�.+��� -   $ visual��#��� 
 $��	Visualize��$��40��$��Center=�$��Center=�
�������$��18(�$	��100������ *Visualization+