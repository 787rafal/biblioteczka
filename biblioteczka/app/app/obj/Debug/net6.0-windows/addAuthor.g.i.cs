﻿#pragma checksum "..\..\..\addAuthor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8FF2A78F3D2AE533BB7D4D9CA45F9E230487DF49"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Themes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using app;


namespace app {
    
    
    /// <summary>
    /// addAuthor
    /// </summary>
    public partial class addAuthor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\..\addAuthor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchedText2;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\addAuthor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchedText1;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\addAuthor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock date;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\addAuthor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock name;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\addAuthor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock sname;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/app;component/addauthor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\addAuthor.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 28 "..\..\..\addAuthor.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.przeciagnij);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 30 "..\..\..\addAuthor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.min_btn);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 33 "..\..\..\addAuthor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.close_btn);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SearchedText2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 46 "..\..\..\addAuthor.xaml"
            this.SearchedText2.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.firstNameChange);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SearchedText1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 47 "..\..\..\addAuthor.xaml"
            this.SearchedText1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.lastNameChange);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 48 "..\..\..\addAuthor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.add_autor);
            
            #line default
            #line hidden
            return;
            case 7:
            this.date = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.name = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.sname = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

