﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5B30E07DC043D8C31CD1769A8A7ADE5AB8E470A9"
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
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 425 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newBook;
        
        #line default
        #line hidden
        
        
        #line 426 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newAuthor;
        
        #line default
        #line hidden
        
        
        #line 427 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox selectGenres;
        
        #line default
        #line hidden
        
        
        #line 433 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchedText;
        
        #line default
        #line hidden
        
        
        #line 434 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SearchPlaceholder;
        
        #line default
        #line hidden
        
        
        #line 449 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox radio_btn;
        
        #line default
        #line hidden
        
        
        #line 450 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel panel;
        
        #line default
        #line hidden
        
        
        #line 451 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton status1;
        
        #line default
        #line hidden
        
        
        #line 452 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton status2;
        
        #line default
        #line hidden
        
        
        #line 457 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button confirm;
        
        #line default
        #line hidden
        
        
        #line 459 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scroll;
        
        #line default
        #line hidden
        
        
        #line 460 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid kafelki;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/app;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.newBook = ((System.Windows.Controls.Button)(target));
            
            #line 425 "..\..\..\MainWindow.xaml"
            this.newBook.Click += new System.Windows.RoutedEventHandler(this.add_book);
            
            #line default
            #line hidden
            return;
            case 2:
            this.newAuthor = ((System.Windows.Controls.Button)(target));
            
            #line 426 "..\..\..\MainWindow.xaml"
            this.newAuthor.Click += new System.Windows.RoutedEventHandler(this.newAuthor_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.selectGenres = ((System.Windows.Controls.ComboBox)(target));
            
            #line 427 "..\..\..\MainWindow.xaml"
            this.selectGenres.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SearchedText = ((System.Windows.Controls.TextBox)(target));
            
            #line 433 "..\..\..\MainWindow.xaml"
            this.SearchedText.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.searchChange);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SearchPlaceholder = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            
            #line 435 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.przeciagnij);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 437 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.close_btn);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 444 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.min_btn);
            
            #line default
            #line hidden
            return;
            case 9:
            this.radio_btn = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 10:
            this.panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 11:
            this.status1 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 12:
            this.status2 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 13:
            this.confirm = ((System.Windows.Controls.Button)(target));
            
            #line 457 "..\..\..\MainWindow.xaml"
            this.confirm.Click += new System.Windows.RoutedEventHandler(this.confirm_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.scroll = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 15:
            this.kafelki = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

