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
    public partial class ImportProduct : UserControl, IComponentConnector
    {
        private bool _hideRequest = false;

        private string _result = string.Empty;

        private UIElement _parent;

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("ImportProductMessage", typeof(string), typeof(ImportProduct), new UIPropertyMetadata(string.Empty));

       

        public string Message
        {
            get
            {
                return (string)base.GetValue(ImportProduct.MessageProperty);
            }
            set
            {
                base.SetValue(ImportProduct.MessageProperty, value);
            }
        }

        public ImportProduct()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
            this.txbMessage.IsVisibleChanged += new DependencyPropertyChangedEventHandler(this.txbMessage_IsVisibleChanged);
        }

        private void txbMessage_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (4 != 0)
            {
                do
                {
                    bool flag = !this.txbMessage.IsVisible;
                    if (false || flag)
                    {
                        return;
                    }
                }
                while (3 == 0);
                this.txbMessage.Focus();
            }
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public string ShowHandlerDialog(string message)
        {
            if (4 != 0)
            {
                this._result = string.Empty;
                if (!false)
                {
                    this.Message = message;
                }
                base.Visibility = Visibility.Visible;
                this.txbMessage.Focus();
                this._parent.IsEnabled = true;
                this.txbMessage.Focus();
                this._hideRequest = false;
                goto IL_CD;
            }
        IL_8F:
            bool flag;
            string result;
            if (!flag)
            {
                if (7 != 0)
                {
                    goto IL_E0;
                }
                return result;
            }
            else
            {
                base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                }));
                Thread.Sleep(20);
            }
        IL_CD:
            bool arg_88_0;
            bool arg_D7_0 = arg_88_0 = this._hideRequest;
            int arg_D4_0 = 0;
            int expr_85;
            do
            {
                int arg_85_0;
                int expr_D4 = arg_85_0 = arg_D4_0;
                if (expr_D4 == 0)
                {
                    flag = ((arg_D7_0 ? 1 : 0) == expr_D4);
                    if (!flag)
                    {
                        goto IL_E0;
                    }
                    if (base.Dispatcher.HasShutdownStarted)
                    {
                        goto IL_8C;
                    }
                    arg_D7_0 = (arg_88_0 = base.Dispatcher.HasShutdownFinished);
                    arg_85_0 = 0;
                }
                expr_85 = (arg_D4_0 = arg_85_0);
            }
            while (expr_85 != 0);
            bool arg_8E_0 = (arg_88_0 ? 1 : 0) == expr_85;
            goto IL_8D;
        IL_8C:
            arg_8E_0 = false;
        IL_8D:
            flag = arg_8E_0;
            goto IL_8F;
        IL_E0:
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

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            bool arg_93_0;
            bool expr_89 = arg_93_0 = (this.txbMessage.Text.Trim() != "");
            if (-1 != 0)
            {
                arg_93_0 = !expr_89;
            }
            bool flag = arg_93_0;
            if (flag || -1 == 0)
            {
                goto IL_50;
            }
            this._result = this.txbMessage.Text;
            this.HideHandlerDialog();
        IL_48:
        IL_49:
            if (!false)
            {
                return;
            }
        IL_50:
            MessageBox.Show("Please enter image number");
            this.txbMessage.Focus();
            if (5 == 0)
            {
                goto IL_48;
            }
            if (8 == 0)
            {
                goto IL_49;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                if (8 != 0)
                {
                    this.txbMessage.Text = string.Empty;
                    if (!false)
                    {
                        break;
                    }
                }
            }
            if (5 != 0)
            {
                this.txbMessage.Focus();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this._result = "Close";
            this.HideHandlerDialog();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

    }
}
