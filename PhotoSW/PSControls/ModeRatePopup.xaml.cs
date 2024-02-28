using PhotoSW.Common;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using PhotoSW.Views;

namespace PhotoSW.PSControls
{
    public partial class ModalDialog : UserControl, IComponentConnector, IDisposable
    {
        private bool _hideRequest = false;

        private bool _result = false;

        private UIElement _parent;

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(ModalDialog), new UIPropertyMetadata(string.Empty));

        
      

        public string Message
        {
            get
            {
                return (string)base.GetValue(ModalDialog.MessageProperty);
            }
            set
            {
                base.SetValue(ModalDialog.MessageProperty, value);
            }
        }

        public ModalDialog()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
        }

        public void Dispose()
        {
            Window window;
            do
            {
                window = Window.GetWindow(this);
                bool flag;
                do
                {
                    flag = (window == null);
                }
                while (false);
                if (flag)
                {
                    goto IL_42;
                }
            }
            while (false);
            if (!false)
            {
                ((SearchResult)window).grdCotrol.Children.Remove(this);
                //((SearchResult)window).ModalDialog = null;
                if (2 != 0)
                {
                }
            }
        IL_42:
            if (!false)
            {
                GC.SuppressFinalize(this);
            }
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public bool ShowHandlerDialog(string message)
        {
            this.Message = message;
            while (-1 == 0)
            {
            }
            base.Visibility = Visibility.Visible;
            this.txtPassword.Focus();
            this.txtPassword.Password = "";
            this._parent.IsEnabled = false;
            this._hideRequest = false;
            while (true)
            {
                bool arg_78_0;
                bool arg_C7_0 = arg_78_0 = this._hideRequest;
                int arg_C4_0 = 0;
                while (true)
                {
                    int arg_75_0;
                    int expr_C4 = arg_75_0 = arg_C4_0;
                    if (expr_C4 != 0)
                    {
                        goto IL_75;
                    }
                    bool arg_C9_0 = arg_C7_0 == (expr_C4 != 0);
                    bool expr_CA;
                    do
                    {
                    IL_C9:
                        bool flag = arg_C9_0;
                        expr_CA = (arg_C9_0 = flag);
                    }
                    while (false);
                    if (!expr_CA)
                    {
                        goto IL_D3;
                    }
                    if (!base.Dispatcher.HasShutdownStarted)
                    {
                        goto IL_69;
                    }
                    int arg_81_0 = 0;
                    goto IL_80;
                IL_75:
                    int expr_75 = arg_C4_0 = arg_75_0;
                    if (expr_75 != 0)
                    {
                        continue;
                    }
                    arg_C9_0 = ((arg_81_0 = ((arg_78_0 == (expr_75 != 0)) ? 1 : 0)) != 0);
                    if (!false)
                    {
                        goto IL_80;
                    }
                    //goto IL_C9;
                IL_69:
                    arg_C7_0 = (arg_78_0 = base.Dispatcher.HasShutdownFinished);
                    arg_75_0 = 0;
                    goto IL_75;
                IL_D3:
                    if (!false)
                    {
                        goto Block_8;
                    }
                    goto IL_69;
                IL_80:
                    if (arg_81_0 == 0)
                    {
                        goto IL_D3;
                    }
                    break;
                }
                base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                }));
                Thread.Sleep(20);
            }
        Block_8:
            return this._result;
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
            this.PasswordValidate();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                if (8 != 0)
                {
                    this.txtPassword.Password = "";
                    if (!false)
                    {
                        this.txtPassword.Focus();
                    }
                }
                if (!false)
                {
                    this.txbMessage.Text = "";
                }
            }
            while (false);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this._result = false;
            this.HideHandlerDialog();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            while (-1 != 0)
            {
                if (8 != 0)
                {
                    if (7 != 0)
                    {
                        bool flag = e.Key != Key.Return;
                        if (false)
                        {
                            continue;
                        }
                        if (!flag)
                        {
                            goto IL_1E;
                        }
                    }
                    return;
                }
            IL_1E:
                this.PasswordValidate();
                break;
            }
        }

        private void PasswordValidate()
        {
            while (!string.IsNullOrEmpty(this.txtPassword.Password))
            {
                if (!false)
                {
                    int expr_67 = (this.txtPassword.Password == LoginUser.ModPassword) ? 1 : 0;
                    if (!false)
                    {
                        bool flag = expr_67 == 0;
                        if (!false)
                        {
                            if (flag)
                            {
                                goto IL_9F;
                            }
                            this._result = true;
                            this.txbMessage.Text = "";
                            this.HideHandlerDialog();
                            if (false)
                            {
                                goto IL_C2;
                            }
                        }
                        goto IL_CF;
                    IL_9F:
                        this.txbMessage.Text = "Please enter a valid password.";
                        this.txtPassword.Password = "";
                    IL_C2:
                        this.txtPassword.Focus();
                    IL_CF:
                        if (false)
                        {
                            goto IL_9F;
                        }
                    }
                    else
                    {
                    IL_4C: ;
                    }
                    return;
                }
            }
            this.txbMessage.Text = "Please enter a password.";
            if (!false)
            {
            }
            this.txtPassword.Focus();
            //goto IL_4C;
        }

        private void rdbTemporarily_Checked(object sender, RoutedEventArgs e)
        {
            if (4 != 0)
            {
                try
                {
                    this.txtPassword.Focus();
                    while (false)
                    {
                    }
                }
                catch (Exception var_0_1F)
                {
                    if (3 != 0)
                    {
                    }
                    if (6 != 0)
                    {
                    }
                }
            }
        }

        private void rdbPermanantly_Checked(object sender, RoutedEventArgs e)
        {
            this.txtPassword.Focus();
        }

     
    }
}
