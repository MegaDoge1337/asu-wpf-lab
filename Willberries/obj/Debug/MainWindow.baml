   M S B A M L   `   `   `  ����F  BWillberries, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WillberriesWillberries  5   	       Willberries.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Willberries     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Willberries��5	   	   $	��450��6   $	��800��6*      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowState$ 	Maximized=�6;   .��5      � .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��32q�6   .��5      �� $��100,100,100,30q�6   $��Center=�61   $��Center=�6N   .+�5      �� -   5        $
��Logo��5   W    $  MaterialDesignHeadline4TextBlock#���  6   
���� ��$��Center=�6w    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 0Q�6+      
BlurRadius$ 0Q�6;   6L   Willberries5      �� 5      -   5        $��Header��5   W    $  MaterialDesignSubtitle2TextBlock#���  6   $��Center=�6e   Авторизация6�   �� 5      -   5        $��Login��5   �   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��6    % !MaterialDesignFloatingHintTextBox#��[ 6A   
���� ��
���� ��$��5q�6�   G� 5      -   5        $��Password��5   �   $ Пароль��6    ) %MaterialDesignFloatingHintPasswordBox#��[ 6F   
���� ��
���� ��$��5q�6�   �� 5      -   5        $��MakeAuth��5        MaterialDesignFlatButton#��[ 6)   
���� ��$��2��6o   $��
Войти��6|   $��5q�6�   6�   �� 5      -   5        $��OpenDashboard��5      #��[ 6.   
���� ��$��2��6t   $6��0Открыть панель управления��6�   $��5q�6�   $y�Hidden=�6�   �� 5      -   5        $
��Exit��5      #��[ 6%   
���� ��$��2��6k   $%��Завершить работу��6x   $��5q�6�   $y�Hidden=�6�   5       5!      5"      5#      