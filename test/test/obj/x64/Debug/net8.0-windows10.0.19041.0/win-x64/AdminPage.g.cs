﻿#pragma checksum "C:\School\Github\BoekBaas-Native\test\test\AdminPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "00BDEE923C63B6234AD4F8CA557BD4B9FB9D8A9B9EBB7873FD5FBEA0260C13A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test
{
    partial class AdminPage : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2501")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // AdminPage.xaml line 15
                {
                    this.BookList = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListView>(target);
                    ((global::Microsoft.UI.Xaml.Controls.ListView)this.BookList).SelectionChanged += this.BookList_SelectionChanged;
                }
                break;
            case 3: // AdminPage.xaml line 45
                {
                    this.TitleInput = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 4: // AdminPage.xaml line 46
                {
                    this.AuthorInput = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 5: // AdminPage.xaml line 48
                {
                    this.YearInput = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.DatePicker>(target);
                }
                break;
            case 6: // AdminPage.xaml line 50
                {
                    this.Borrowable = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.CheckBox>(target);
                }
                break;
            case 7: // AdminPage.xaml line 53
                {
                    this.GenreComboBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ComboBox>(target);
                }
                break;
            case 8: // AdminPage.xaml line 62
                {
                    this.ISBNInput = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 9: // AdminPage.xaml line 75
                {
                    this.GenreNameInput = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 10: // AdminPage.xaml line 78
                {
                    global::Microsoft.UI.Xaml.Controls.Button element10 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element10).Click += this.AddGenre_Click;
                }
                break;
            case 11: // AdminPage.xaml line 66
                {
                    global::Microsoft.UI.Xaml.Controls.Button element11 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element11).Click += this.AddBook_Click;
                }
                break;
            case 12: // AdminPage.xaml line 67
                {
                    global::Microsoft.UI.Xaml.Controls.Button element12 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element12).Click += this.UpdateBook_Click;
                }
                break;
            case 13: // AdminPage.xaml line 68
                {
                    global::Microsoft.UI.Xaml.Controls.Button element13 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element13).Click += this.DeleteBook_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }


        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2501")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

