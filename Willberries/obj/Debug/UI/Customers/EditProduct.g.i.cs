﻿#pragma checksum "..\..\..\..\UI\Customers\EditProduct.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AA21439FF8C2BE4AF20C28C56CBDD02FCA8152B9D49805F31EF8626D63F0E56E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Willberries.UI.Products;


namespace Willberries.UI.Products {
    
    
    /// <summary>
    /// EditProduct
    /// </summary>
    public partial class EditProduct : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\UI\Customers\EditProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Header;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\UI\Customers\EditProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProductTitle;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\UI\Customers\EditProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProductDescription;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\UI\Customers\EditProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProductCode;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\UI\Customers\EditProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProductPrice;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\UI\Customers\EditProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SelectedDeliveryMethod;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\UI\Customers\EditProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateDeliveryMethod;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\UI\Customers\EditProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteDeliveryMethod;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Willberries;component/ui/customers/editproduct.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Customers\EditProduct.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Header = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.ProductTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.ProductDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ProductCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ProductPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.SelectedDeliveryMethod = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.UpdateDeliveryMethod = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\UI\Customers\EditProduct.xaml"
            this.UpdateDeliveryMethod.Click += new System.Windows.RoutedEventHandler(this.UpdateDeliveryMethod_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DeleteDeliveryMethod = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\UI\Customers\EditProduct.xaml"
            this.DeleteDeliveryMethod.Click += new System.Windows.RoutedEventHandler(this.DeleteDeliveryMethod_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

