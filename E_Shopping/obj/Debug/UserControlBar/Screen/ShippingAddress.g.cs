﻿#pragma checksum "..\..\..\..\UserControlBar\Screen\ShippingAddress.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2CFFF8BFCECAEBA9A6E18EB4BFF2ECDE456A284EA471E2D98EE74F6DC420B24E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using E_Shopping.Convert;
using E_Shopping.UserControlBar.Screen;
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


namespace E_Shopping.UserControlBar.Screen {
    
    
    /// <summary>
    /// ShippingAddress
    /// </summary>
    public partial class ShippingAddress : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\UserControlBar\Screen\ShippingAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal E_Shopping.UserControlBar.Screen.ShippingAddress ShippingAddressUC;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\UserControlBar\Screen\ShippingAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ShoppingCartdtg;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\..\UserControlBar\Screen\ShippingAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock subtotaltb;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\UserControlBar\Screen\ShippingAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SaleTaxtb;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\UserControlBar\Screen\ShippingAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ShippingFeetb;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\..\UserControlBar\Screen\ShippingAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TotalDuetb;
        
        #line default
        #line hidden
        
        
        #line 244 "..\..\..\..\UserControlBar\Screen\ShippingAddress.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl paymentprocess;
        
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
            System.Uri resourceLocater = new System.Uri("/E_Shopping;component/usercontrolbar/screen/shippingaddress.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControlBar\Screen\ShippingAddress.xaml"
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
            this.ShippingAddressUC = ((E_Shopping.UserControlBar.Screen.ShippingAddress)(target));
            return;
            case 2:
            this.ShoppingCartdtg = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.subtotaltb = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.SaleTaxtb = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.ShippingFeetb = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.TotalDuetb = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.paymentprocess = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
