   M S B A M L   `   `   `  ���� A  =PigzUi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PigzUiPigzUi      PigzUi.MainWindow   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:PigzUi       � Title$  PigzUI��$	��450��$	��487�� � 
ResizeMode$ CanMinimize=�.��� .+��� .@��� -    ��Name$ TabCompress��$��Compress��.��� ���	#FFE5E5E5 � ColumnDefinitions �� $	��16* ��� $	��27* ��� $	��10* ��� $	��37* ��� $��7* ��� $
��384* �.+��� -    ��Name$ ListBoxC��$��6��$��
0,0,115,97q��� -    ��Name$ ButtonCFiles��$��	Add Files��$��5��$
��Left=�$��
280,10,0,0q�$	��Top=�$��78���� -   $ ButtonCFolder��$��
Add Folder��$��5��$
��Left=�$��
280,43,0,0q�$	��Top=�$��78���� -    ��Name$ CheckBoxCRecursive��$"��Recursively
Search
Folders��$��5��$
��Left=�$��
280,73,0,0q�$	��Top=��� -   $ CheckBoxCPreserve��$��Preserve
Original
File��$��5��$
��Left=�$��280,135,0,0q�$	��Top=�	� -    	�Name$ 	RadioFast��$
��Fast��$��1��$
��Left=�$��18��$��
14,345,0,0q�$	��Top=�$	��100��$��5��	� -   $ 	RadioBest��$
��Best��$��3��$
��Left=�$��18��$��
28,345,0,0q�$	��Top=�$	��100��$��3��	� -	   $ RadioCustom��$��Custom��$��5��$
��Left=�$��18��$��
34,345,0,0q�$	��Top=�$	��100���� -
    ��Name$ ComboBoxStrength��$��5��$
��Left=�$��111,343,0,0q�$	��Top=�$��37��$��20��${�False���� $��Compression Strength��$
��Left=�$��62��$��	0,314,0,0q�$	��Top=�$	��251��$��5��$��1���� -   $ ButtonCClear��$��Clear Files��$��5��$
��Left=�$��191,343,0,0q�$	��Top=�$��78���� -   $ 
ButtonCRun��$	��Run��$��5��$
��Left=�$��280,343,0,0q�$	��Top=�$��78���� -   $��TabDecompress��$��
Decompress��.��� ���	#FFE5E5E5 �� $	��21* ��� $	��17* ��� $
��443* �.+��� -   $ ListBoxD��$��
0,0,115,97q�$��3���� -   $ ButtonDFiles��$��	Add Files��$
��Left=�$��
337,10,0,0q�$	��Top=�$��78��$��2���� -   $ CheckBoxDPreserve��$��Preserve
Original
File��$
��Left=�$��337,135,0,0q�$	��Top=�$��2���� -   $ ButtonDClear��$��Clear Files��$
��Left=�$��248,343,0,0q�$	��Top=�$��78��$��2���� -   $ 
ButtonDRun��$	��Run��$
��Left=�$��337,343,0,0q�$	��Top=�$��78��$��2���� -   $ ButtonDFolder��$��
Add Folder��$��2��$
��Left=�$��
337,43,0,0q�$	��Top=�$��78���� -   $ CheckBoxDRecursive��$ ��Recursively
Search
Folders��$��2��$
��Left=�$��
337,73,0,0q�$	��Top=��� -   $ TabSetup��$��Setup��.��� ���	#FFE5E5E5 �� $	��29* ��� $
��765* �.+��� -   	 ��Name$	 TextBoxSCompress��$��1��$
��Left=�$��	76,60,0,0q�
 �� TextWrapping$

 Wrap=�$	��Top=�$	��278��$��19���� -   $ ButtonSFindCompress��$	��...��$��1��$
��Left=�$��
359,60,0,0q�$	��Top=�$��27���� -    ��Name$ LabelSCompress��$��Path to Pigz Executable��$��1��$
��Left=�$��	76,34,0,0q�$	��Top=��� -   $	 TextBoxSDecompress��$��1��$
��Left=�$��
76,145,0,0q�$

 Wrap=�$	��Top=�$	��278��$��19���� -   $ ButtonSFindDecompress��$	��...��$��1��$
��Left=�$��359,145,0,0q�$	��Top=�$��27���� -   $ LabelSDecompress��$��Path to Unpigz Executable��$��1��$
��Left=�$��
76,119,0,0q�$	��Top=�