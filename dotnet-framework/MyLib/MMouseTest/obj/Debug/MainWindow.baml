   M S B A M L   `   `   `  ����E  AMMouseTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MMouseTest
MMouseTest  5   	       MMouseTest.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MMouseTest     5   	     � Title$  
MainWindow��5   	   $��484.999��6   $��552.491��6-   .��5	      � $��0,0,5.5,2.5q�6   .+�5
   
   �� -   5         ��Name$ 
winNameBox��5
      $��	70,10,0,0q�6&    �� TextWrapping$
 Wrap=�69   $��网易云音乐��6M    J� RenderTransformOrigin$ -0.097,-1.545&�6Z   $��33��6�   $	��Top=�6�   $
��Left=�6�   $	��155��6�   �� 5   
   -   5         ��Name$ label��5      $��窗体名：
��6   $��	10,10,0,0q�68   $
��Bold"�6K   $
��Left=�6]   $��33��6x   $	��Top=�6�   �� 5   
   -   5        $ 
label_Copy��5      $��
左边：
��6$   $��	15,78,0,0q�67   $
��Bold"�6J   $
��Left=�6\   $��33��6w   $	��Top=�6�   �� 5   
   -   5        $ leftText��5      $��	75,78,0,0q�6$   $
 Wrap=�67   $�� ��6K   $ -0.097,-1.545&�6S   $��16(�6y   $
��Left=�6�   $��75��6�   $��33��6�   $	��Top=�6�   �� 5   
   -   5        $ label_Copy1��5      $��
顶上：
��6%   $��
15,132,0,0q�68   $
��Bold"�6L   $
��Left=�6^   $��33��6y   $	��Top=�6�   �� 5   
   -   5        $ topText��5      $��
75,132,0,0q�6#   $
 Wrap=�67   $�� ��6K   $ -0.097,-1.545&�6S   $��16(�6y   $��33��6�   $	��Top=�6�   $
��Left=�6�   $��75��6�   �� 5   
   -   5        $ label_Copy2��5      $��
右边：
��6%   $��
15,189,0,0q�68   $
��Bold"�6L   $
��Left=�6^   $��33��6y   $	��Top=�6�   �� 5   
   -   5        $ 	rightText��5      $��
75,189,0,0q�6%   $
 Wrap=�69   $�� ��6M   $ -0.097,-1.545&�6U   $��16(�6{   $
��Left=�6�   $��75��6�   $��33��6�   $	��Top=�6�   �� 5   
   -	   5        $ label_Copy3��5      $��
底部：
��6%   $��
15,247,0,0q�68   $
��Bold"�6L   $
��Left=�6^   $��33��6y   $	��Top=�6�   �� 5   
   -
   5        $ 
bottomText��5      $��
75,247,0,0q�6&   $
 Wrap=�6:   $�� ��6N   $ -0.097,-1.545&�6V   $��16(�6|   $
��Left=�6�   $��75��6�   $��33��6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ 	GetPosBtn��5      $��	GetPosBtn��6$   $��
234,10,0,0q�68   $	��Top=�6L   $ -0.4,-0.947&�6d   $��25��6�   $
��Left=�6�   $��75��6�   � 5   
   $
��Left=�6   $	��205��6*   $��	10,75,0,0q�67   $	��Top=�6J   $	��140��6b   �� 5   
   -   5        $ label_Copy4��5      $��左边偏差：
��6%   $��
340,78,0,0q�6:   $
��Bold"�6N   $
��Left=�6`   $��33��6{   $	��Top=�6�   �� 5   
   -   5        $ leftOffsetText��5      $��
402,78,0,0q�6*   $
 Wrap=�6>   $	��160��6R   $ -0.097,-1.545&�6]   $��16(�6�   $
��Left=�6�   $��78��6�   $��33��6�   $	��Top=�6�   �� 5   
   -   5        $ label_Copy5��5      $��顶上偏差：
��6%   $��340,132,0,0q�6:   $
��Bold"�6O   $
��Left=�6a   $��33��6|   $	��Top=�6�   �� 5   
   -   5        $ topOffsetText��5      $��402,132,0,0q�6)   $
 Wrap=�6>   $��0��6R   $ -0.097,-1.545&�6[   $��16(�6�   $
��Left=�6�   $��78��6�   $��33��6�   $	��Top=�6�   �� 5   
   -   5        $ label_Copy6��5      $��右边偏差：
��6%   $��340,189,0,0q�6:   $
��Bold"�6O   $
��Left=�6a   $��33��6|   $	��Top=�6�   �� 5   
   -   5        $ rightOffsetText��5      $��402,189,0,0q�6+   $
 Wrap=�6@   $��0��6T   $ -0.097,-1.545&�6]   $��16(�6�   $
��Left=�6�   $��78��6�   $��33��6�   $	��Top=�6�   �� 5   
   -   5        $ label_Copy7��5      $��底部偏差：
��6%   $��340,247,0,0q�6:   $
��Bold"�6O   $
��Left=�6a   $��33��6|   $	��Top=�6�   �� 5   
   -   5        $ bottomOffsetText��5      $��402,247,0,0q�6,   $
 Wrap=�6A   $	��-45��6U   $ -0.097,-1.545&�6`   $��16(�6�   $
��Left=�6�   $��78��6�   $��33��6�   $	��Top=�6�   � 5   
   $
��Left=�6   $	��205��6*   $��
300,75,0,0q�67   $	��Top=�6K   $	��180��6c   .+�5      �� -   5         ��Name$ 	leftCheck��5      $�� ��6*   $
��Left=�65   $��	10,10,0,0q�6P   $	��Top=�6c   $��17��6{   $��20��6�   $ 1.2,0.4&�6�   �� 5       -   5        $ topCheck��5       $�� ��6)   $
��Left=�64   $��	10,63,0,0q�6O   $	��Top=�6b   $��17��6z   $��20��6�   $ 1.2,0.4&�6�   �� 5!      -   5        $ 
rightCheck��5!      $�� ��6+   $
��Left=�66   $��
10,121,0,0q�6Q   $	��Top=�6e   $��17��6}   $��20��6�   $ 1.2,0.4&�6�   �� 5"      -   5        $ bottomCheck��5"      $�� ��6,   $
��Left=�67   $��10,178,0,10q�6R   $��20��6g   $ 1.2,0.4&�6r   5#      �� 5$   
   -   5        $ MoveClickBtn��5$      $��	MoveClick��6'   $��
328,10,0,0q�6;   $	��Top=�6O   $ -0.4,-0.947&�6g   $��25��6�   $
��Left=�6�   $	��196��6�   �� 5%   
   -   5        $ label_Copy8��5%      $��电脑大小：
��6%   $��301,332,0,0q�6:   $
��Bold"�6O   $
��Left=�6a   $��33��6|   $	��Top=�6�   �� 5&   
   -   5        $ 	computerW��5&      $��363,332,0,0q�6%   $
 Wrap=�6:   $
��1280��6N   $ -0.097,-1.545&�6Z   $��16(�6�   $
��Left=�6�   $��78��6�   $��33��6�   $	��Top=�6�   �� 5'   
   -   5        $ 	computerH��5'      $��446,332,0,0q�6%   $
 Wrap=�6:   $	��800��6N   $ -0.097,-1.545&�6Y   $��16(�6   $
��Left=�6�   $��78��6�   $��33��6�   $	��Top=�6�   5(      5)      