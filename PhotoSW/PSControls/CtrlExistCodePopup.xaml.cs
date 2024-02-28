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
    public partial class CtrlExistCodePopup : UserControl, IComponentConnector
    {
        public bool IsToOverwrite = false;

        private bool _hideRequest = false;

        private bool _result = false;

        private UIElement _parent;

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(CtrlExistCodePopup), new UIPropertyMetadata(string.Empty));

       

        public string Message
        {
            get
            {
                return (string)base.GetValue(CtrlExistCodePopup.MessageProperty);
            }
            set
            {
                base.SetValue(CtrlExistCodePopup.MessageProperty, value);
            }
        }

        public CtrlExistCodePopup()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this._result = false;
            this.HideHandlerDialog();
        }

        public bool ShowHandlerDialog(string message)
        {
            this.MessageTextBlock.Text = message;
            base.Visibility = Visibility.Visible;
            this._parent.IsEnabled = false;
            this._hideRequest = false;
            while (true)
            {
            IL_A3:
                int arg_AA_0 = this._hideRequest ? 1 : 0;
                while (arg_AA_0 == 0)
                {
                    int arg_67_0;
                    arg_AA_0 = (base.Dispatcher.HasShutdownStarted ? (arg_67_0 = 0) : (arg_67_0 = ((!base.Dispatcher.HasShutdownFinished) ? 1 : 0)));
                    if (4 != 0)
                    {
                        if (arg_67_0 == 0)
                        {
                            break;
                        }
                        base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                        {
                        }));
                        Thread.Sleep(20);
                        goto IL_A3;
                    }
                }
                break;
            }
            return this._result;
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsToOverwrite = (this.rdbOverwriteimg.IsChecked == true);
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
