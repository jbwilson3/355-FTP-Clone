﻿#pragma checksum "..\..\..\Add.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D17BB20690F40D8A2830C3F53C15F283"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace networking2 {
    
    
    /// <summary>
    /// Add
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class Add : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serverTB;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox usernameTB;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordTB;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addBT;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ServerLB;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label UsernameLB;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PasswordLB;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelBT;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label connNameLB;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox connNameTB;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/networking2;component/add.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Add.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\Add.xaml"
            ((networking2.Add)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.serverTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.usernameTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.passwordTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.addBT = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Add.xaml"
            this.addBT.Click += new System.Windows.RoutedEventHandler(this.addBT_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ServerLB = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.UsernameLB = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.PasswordLB = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.cancelBT = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Add.xaml"
            this.cancelBT.Click += new System.Windows.RoutedEventHandler(this.cancelBT_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.connNameLB = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.connNameTB = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

