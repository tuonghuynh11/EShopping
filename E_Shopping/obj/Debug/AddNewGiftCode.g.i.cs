﻿#pragma checksum "..\..\AddNewGiftCode.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0DF81E0E2DA735D1A7778BFEAD30CDF168B6F538660014279EB9FE925687BA69"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
using E_Shopping;
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
using System.Windows.Interactivity;
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


namespace E_Shopping {
    
    
    /// <summary>
    /// AddNewGiftCode
    /// </summary>
    public partial class AddNewGiftCode : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\AddNewGiftCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal E_Shopping.AddNewGiftCode changePass;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AddNewGiftCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close_but;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\AddNewGiftCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox newCodetb;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\AddNewGiftCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button generateCode;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\AddNewGiftCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox discountValuetb;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\AddNewGiftCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker expDate;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\AddNewGiftCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addbtn;
        
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
            System.Uri resourceLocater = new System.Uri("/E_Shopping;component/addnewgiftcode.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddNewGiftCode.xaml"
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
            this.changePass = ((E_Shopping.AddNewGiftCode)(target));
            return;
            case 2:
            this.Close_but = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\AddNewGiftCode.xaml"
            this.Close_but.Click += new System.Windows.RoutedEventHandler(this.Close_but_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.newCodetb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.generateCode = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\AddNewGiftCode.xaml"
            this.generateCode.Click += new System.Windows.RoutedEventHandler(this.generateCode_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.discountValuetb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.expDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.addbtn = ((System.Windows.Controls.Button)(target));
            
            #line 129 "..\..\AddNewGiftCode.xaml"
            this.addbtn.Click += new System.Windows.RoutedEventHandler(this.addbtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
