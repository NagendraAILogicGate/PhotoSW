using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;


namespace PhotoSW.PSControls
{
    public partial class KeyBoard : UserControl, IComponentConnector
    {
        //internal KeyBoard UserControl;

        //internal Grid LayoutRoot;

        //internal Grid AlfaKeyboard;

        //internal RowDefinition NumberKeys;

        //internal Grid FunctionKeys;

        //internal Button btnShowNum;

        //internal Button btnWindows;

        //internal Grid NumKeyboard;

        //internal Button btnShowAlfa;

        //private bool _contentLoaded;

        public KeyBoard()
        {
         //  InitializeComponentCustom();
          //this.InitializeComponent();
         // InitializeComponentCustom();
            //InitializeComponentsCustom();
        }

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
        //public void InitializeComponentCustom()
        //{
        //    bool arg_09_0 = this._contentLoaded;
        //    bool expr_09;
        //    do
        //    {
        //        expr_09 = (arg_09_0 = !arg_09_0);
        //    }
        //    while (false);
        //    bool flag = expr_09;
        //    while (true)
        //    {
        //        if (!flag)
        //        {
        //            goto IL_14;
        //        }
        //    IL_1A:
        //        this._contentLoaded = true;
        //        while (6 != 0)
        //        {
        //            Uri resourceLocator = new Uri("/DigiPhoto;component/usercontrol/keyboard.xaml", UriKind.Relative);
        //            if (!false)
        //            {
        //                Application.LoadComponent(this, resourceLocator);
        //                if (-1 != 0)
        //                {
        //                    return;
        //                }
        //                goto IL_14;
        //            }
        //        }
        //        continue;
        //    IL_14:
        //        if (6 != 0)
        //        {
        //            break;
        //        }
        //        goto IL_1A;
        //    }
        //}

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        //void IComponentConnector.Connect(int connectionId, object target)
        //{
        //    if (!false)
        //    {
        //        if (8 == 0)
        //        {
        //        }
        //        switch (connectionId)
        //        {
        //            case 1:
        //                this.UserControl = (KeyBoard)target;
        //                if (!false)
        //                {
        //                    return;
        //                }
        //                goto IL_94;
        //            case 2:
        //                break;
        //            case 3:
        //                goto IL_80;
        //            case 4:
        //                this.NumberKeys = (RowDefinition)target;
        //                return;
        //            case 5:
        //                if (6 != 0)
        //                {
        //                    this.FunctionKeys = (Grid)target;
        //                }
        //                return;
        //            case 6:
        //                this.btnShowNum = (Button)target;
        //                return;
        //            case 7:
        //                this.btnWindows = (Button)target;
        //                return;
        //            case 8:
        //                this.NumKeyboard = (Grid)target;
        //                return;
        //            case 9:
        //                this.btnShowAlfa = (Button)target;
        //                goto IL_EB;
        //            default:
        //                if (7 == 0)
        //                {
        //                    goto IL_EB;
        //                }
        //                if (false)
        //                {
        //                    goto IL_80;
        //                }
        //                if (!false)
        //                {
        //                    this._contentLoaded = true;
        //                    return;
        //                }
        //                break;
        //        }
        //        this.LayoutRoot = (Grid)target;
        //        return;
        //    IL_80:
        //        this.AlfaKeyboard = (Grid)target;
        //    IL_94:
        //    IL_EB: ;
        //    }
        //}
    }
}
