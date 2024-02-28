using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;

namespace PhotoSW.PSControls
{
    public partial class CtrlOpenCloseForm : UserControl, IComponentConnector
    {
        private UIElement _parent;

        private bool _hideRequest = false;

        private string _result;

        private TextBox controlon;

       // private bool _contentLoaded;

        public int OpeningProcMendatory
        {
            get;
            set;
        }

        public int FormTypeID
        {
            get;
            set;
        }

        public DateTime? TransDate
        {
            get;
            set;
        }

        public DateTime? BusinessDate
        {
            get;
            set;
        }

        public DateTime ServerTime
        {
            get;
            set;
        }

        public CtrlOpenCloseForm()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public string ShowHandlerDialog(string message)
        {
            base.Visibility = Visibility.Visible;
            if (3 != 0)
            {
                if (!false)
                {
                    this.OpenClose();
                }
                this._hideRequest = false;
                goto IL_98;
            }
        IL_57:
            bool arg_5C_0 = false;
        IL_58:
            if (!false)
            {
            }
            if (arg_5C_0)
            {
                base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                }));
                goto IL_8F;
            }
            goto IL_AE;
        IL_8F:
            Thread.Sleep(20);
        IL_98:
            string result;
            if (!false)
            {
                bool flag = !this._hideRequest;
                if (4 == 0)
                {
                    goto IL_8F;
                }
                if (flag)
                {
                    if (base.Dispatcher.HasShutdownStarted)
                    {
                        goto IL_57;
                    }
                    if (4 != 0)
                    {
                        arg_5C_0 = !base.Dispatcher.HasShutdownFinished;
                        goto IL_58;
                    }
                    return result;
                }
            }
        IL_AE:
            result = this._result;
            return result;
        }

        private void HideHandlerDialog()
        {
            if (4 != 0)
            {
                this._hideRequest = true;
                do
                {
                    Visibility expr_0E = Visibility.Collapsed;
                    if (!false)
                    {
                        base.Visibility = expr_0E;
                    }
                    if (false)
                    {
                        goto IL_25;
                    }
                }
                while (false);
                this._parent.IsEnabled = true;
            IL_25: ;
            }
        }

        public void OpenClose()
        {
            this.txtMsg.Visibility = Visibility.Hidden;
            if (this.FormTypeID != 1)
            {
                this.grdOpening.Visibility = Visibility.Visible;
                this.grdClosing.Visibility = Visibility.Hidden;
            }
            else if (this.FormTypeID == 1)
            {
                this.grdOpening.Visibility = Visibility.Hidden;
                this.grdClosing.Visibility = Visibility.Visible;
            }
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (3 == 0)
                {
                    return;
                }
                this._result = string.Empty;
                if (!false)
                {
                    this._result = "Opening From";
                    break;
                }
            }
            if (!false)
            {
                this.HideHandlerDialog();
                return;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (3 == 0)
                {
                    return;
                }
                this._result = string.Empty;
                if (!false)
                {
                    this._result = "Closing From";
                    break;
                }
            }
            if (!false)
            {
                this.HideHandlerDialog();
                return;
            }
        }

        private void btnShowhdeForm_Click(object sender, RoutedEventArgs e)
        {
            this._result = string.Empty;
            this.HideHandlerDialog();
        }

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
        //public void InitializeComponent()
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
        //            Uri resourceLocator = new Uri("/DigiPhoto;component/usercontrol/ctrlopencloseform.xaml", UriKind.Relative);
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
        //    switch (connectionId)
        //    {
        //        case 1:
        //            this.grdOpening = (Grid)target;
        //            return;
        //        case 2:
        //            this.btnOpen = (Button)target;
        //            if (!false)
        //            {
        //                this.btnOpen.Click += new RoutedEventHandler(this.btnOpen_Click);
        //                return;
        //            }
        //            goto IL_E6;
        //        case 3:
        //            if (false)
        //            {
        //                goto IL_C7;
        //            }
        //            if (4 != 0)
        //            {
        //                this.grdClosing = (Grid)target;
        //                return;
        //            }
        //            return;
        //        case 4:
        //            if (5 != 0)
        //            {
        //                this.btnClose = (Button)target;
        //                this.btnClose.Click += new RoutedEventHandler(this.btnClose_Click);
        //                goto IL_C7;
        //            }
        //            break;
        //        case 5:
        //            this.msg = (StackPanel)target;
        //            return;
        //        case 6:
        //            this.txtMsg = (TextBlock)target;
        //            return;
        //        case 7:
        //            goto IL_E6;
        //    }
        //    this._contentLoaded = true;
        //IL_C7:
        //    return;
        //IL_E6:
        //    this.btnShowhdeForm = (Button)target;
        //    this.btnShowhdeForm.Click += new RoutedEventHandler(this.btnShowhdeForm_Click);
        //}
    }
}
