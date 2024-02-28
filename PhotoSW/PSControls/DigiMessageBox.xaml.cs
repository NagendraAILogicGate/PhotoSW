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
    public partial class DigiMessageBox : UserControl, IComponentConnector
    {
        public enum DialogType
        {
            Confirm,
            OK
        }

        private bool _hideRequest = false;

        private bool _result = false;

        private UIElement _parent;

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(DigiMessageBox), new UIPropertyMetadata(string.Empty));

       // private bool _contentLoaded;

        public string Message
        {
            get
            {
                return (string)base.GetValue(DigiMessageBox.MessageProperty);
            }
            set
            {
                base.SetValue(DigiMessageBox.MessageProperty, value);
            }
        }

        public DigiMessageBox()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public bool ShowHandlerDialog(string message, DigiMessageBox.DialogType objDialogType)
        {
            this.MessageTextBlock.Text = message;
            bool expr_0A = objDialogType != DigiMessageBox.DialogType.OK;
            bool flag;
            if (!false)
            {
                flag = expr_0A;
            }
            if (!false)
            {
                if (!flag)
                {
                    this.btnCancel.Visibility = Visibility.Collapsed;
                    this.btnOk.Content = "Ok";
                    goto IL_74;
                }
                if (8 == 0)
                {
                    goto IL_C5;
                }
            }
            this.btnCancel.Visibility = Visibility.Visible;
            if (false)
            {
                goto IL_FB;
            }
            this.btnOk.Content = "Yes";
        IL_74:
            this.Message = message;
            base.Visibility = Visibility.Visible;
            this._parent.IsEnabled = false;
            this._hideRequest = false;
            goto IL_FF;
        IL_C5:
            goto IL_10F;
        IL_FB:
            if (8 == 0)
            {
                goto IL_116;
            }
        IL_FF:
            flag = !this._hideRequest;
            int arg_119_0;
            if (flag)
            {
                int arg_C0_0;
                if (!base.Dispatcher.HasShutdownStarted)
                {
                    arg_119_0 = (arg_C0_0 = ((!base.Dispatcher.HasShutdownFinished) ? 1 : 0));
                    if (!false)
                    {
                    }
                }
                else
                {
                    arg_119_0 = (arg_C0_0 = 0);
                }
                if (false)
                {
                    return arg_119_0 != 0;
                }
                flag = (arg_C0_0 != 0);
                if (flag)
                {
                    base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                    }));
                    Thread.Sleep(20);
                    goto IL_FB;
                }
            }
        IL_10F:
            bool result = this._result;
        IL_116:
            arg_119_0 = (result ? 1 : 0);
            return arg_119_0 != 0;
        }

        private void HideHandlerDialog()
        {
            if (4 != 0)
            {
                this._hideRequest = true;
                do
                {
                    Visibility expr_0E = Visibility.Hidden;
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

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this._result = true;
            this.HideHandlerDialog();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this._result = false;
            this.HideHandlerDialog();
        }

    }
}
