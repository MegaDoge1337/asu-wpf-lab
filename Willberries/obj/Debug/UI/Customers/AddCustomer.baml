   M S B A M L   `   `   `  ����F  BWillberries, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Willberries.UI.CustomersWillberries.UI.Customers  5   	   *    $Willberries.UI.Customers.AddCustomer   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Willberries.UI.Customers     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Willberries��5	   	   $	��500��6   $	��600��6*      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowState$ Normal=�6;    � WindowStartupLocation$ CenterScreen=�6P   .��5      #  MaterialDesignThemes.Wpf.Card  $��20q�6   .��5   
   �� $��90,100,100,30q�6   $��Center=�6,   $��Center=�6I   .+�5      �� -   5        $��Header��5   S    $  MaterialDesignHeadline6TextBlock#���  6   $��Center=�6a   20Добавить нового заказчика6�   �� 5      -   5        $��CustomerCode��5   �   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Код заказчика��6    % !MaterialDesignFloatingHintTextBox#��[ 6E   
���� ��
���� ��$��5q�6�   �� 5      -   5        $��CustomerTitle��5   �   $ Название��6   #��[ 6@   
���� ��
���� ��$��5q�6�   �� 5      -   5        $��CustomerAddress��5   �   $ 
Адрес��6   #��[ 6=   
���� ��
���� ��$��5q�6�   �� 5      -   5        $��CustomerPhone��5   �   $ Телефон��6   #��[ 6?   
���� ��
���� ��$��5q�6�   �� 5      -   5        $��CustomerDelegate��5   �   $  Представитель��6   #��[ 6E   
���� ��
���� ��$��5q�6�   �� 5      -   5        $��AddNewProduct��5        MaterialDesignFlatButton#��[ 6*   
���� ��$��2��6p   $��Добавить��6}   $��5q�6�   6�   5      5      5      