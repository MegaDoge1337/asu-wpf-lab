   M S B A M L   `   `   `  ����F  BWillberries, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Willberries.UI.OrdersWillberries.UI.Orders  5   	   &     Willberries.UI.Orders.OrdersList   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Willberries.UI.Orders     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Willberries��5	   	   $	��450��6   $	��800��6*      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowState$ 	Maximized=�6;   .��5      #  MaterialDesignThemes.Wpf.Card  $��32q�6   .��5   
   ]� .+�5      �� $	��Top=�6    �� Orientation$ 
Horizontal=�6.   .+�5      �� -   5        $��AddNewOrder_Btn��5      $#��+ Добавить заказ��6J     MaterialDesignFlatButton#��[ 6e   6�   �� 5      -   5        $!��RefreshOrdersCollection_Btn��5      $'��!↺ Обновить список��6c   #��[ 6   6�   �� 5      -   5        $��
GoBack_Btn��5      $E��?Вернуться на панель управления   ❯��6@   #��[ 6m   6�   5      �� 5      $	��Top=�6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��OrdersDataGrid��5         AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$

 ИД��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	OrderId+  5      $
 Заказчик��6-    6?   �� *OrderCustomer+  5      $
 
Товар��6-    6<   �� *OrderProduct+  5      $
 Количество��6-    6A   �� *OrderQuantity+  5      $
 Дата��6-    6;   �� *	OrderDate+��5!      �� 5"       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    .�5#      -   5        5$      5&      5'      5(      5)      5*      