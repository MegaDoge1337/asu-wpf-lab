   M S B A M L   `   `   `  ����F  BWillberries, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Willberries.UI.ProductsWillberries.UI.Products  5   	   )    #Willberries.UI.Products.EditProduct   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Willberries.UI.Products     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Willberries��5	   	   $	��500��6   $	��600��6*      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowState$ Normal=�6;    � WindowStartupLocation$ CenterScreen=�6P   .��5      #  MaterialDesignThemes.Wpf.Card  $��25q�6   .��5   
   �� $��100,90,100,30q�6   $��Center=�6,   $��Center=�6I   .+�5      �� -   5        $��Header��5   S    $  MaterialDesignHeadline6TextBlock#���  6   $��Center=�6a   .,Редактировать запись (ID:6�   �� 5      -   5        $��ProductTitle��5   �   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Название товара��6    % !MaterialDesignFloatingHintTextBox#��[ 6G   
���� ��
���� ��$��5q�6�   �� 5      -   5        $��ProductDescription��5   �   $# Описание товара��6   #��[ 6G   
���� ��
���� ��$��5q�6�   �� 5      -   5        $��ProductCode��5   �   $ Код товара��6   #��[ 6B   
���� ��
���� ��$��5q�6�   �� 5      -   5        $��ProductPrice��5   �   $% Стоимость товара��6   #��[ 6H   
���� ��
���� ��$��5q�6�   �� 5      -   5        $��SelectedDeliveryMethod��5   G   $! Метод доставки��6     MaterialDesignComboBox#��[ 6e   $��5 10 5 5q�6�   
���� ��
���� ��6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� -   5        $��UpdateDeliveryMethod��5        MaterialDesignFlatButton#��[ 65   
���� ��$��2��6{   $��Изменить��6�   $��5q�6�   6�   �� 5      -   5        $��DeleteDeliveryMethod��5      #��[ 65   
���� ��$��2��6{   $��Удалить��6�   $��5q�6�   6�   5      5      5      5      