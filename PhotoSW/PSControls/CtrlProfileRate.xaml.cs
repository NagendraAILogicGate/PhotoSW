using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;

namespace PhotoSW.PSControls
{
    public partial class CtrlProfileRate : UserControl, IComponentConnector
    {
        private CurrencyExchangeBussiness _objCurrencyBusiness = null;

        private UIElement _parent;

        private bool _hideRequest = false;

        private string _result;

        private TextBox controlon;

        public static readonly DependencyProperty MessageProfileRateFormProperty = DependencyProperty.Register("MessageProfileRateForm", typeof(string), typeof(ModalDialog), new UIPropertyMetadata(string.Empty));

        public long ProfileID
        {
            get;
            set;
        }

        public CtrlProfileRate()
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
            if (true)
            {
                base.Visibility = Visibility.Visible;
            }
            this.FillGrid(this.ProfileID);
            this._hideRequest = false;
            string result;
            while (true)
            {
                bool arg_A5_0 = this._hideRequest;
                while (true)
                {
                IL_A4:
                    int arg_A5_1 = 0;
                    while (true)
                    {
                        bool flag = (arg_A5_0 ? 1 : 0) == arg_A5_1;
                        while (true)
                        {
                            if (flag)
                            {
                                bool arg_5C_0;
                                if (!base.Dispatcher.HasShutdownStarted)
                                {
                                    int expr_4A = (arg_A5_0 = base.Dispatcher.HasShutdownFinished) ? 1 : 0;
                                    int expr_50 = arg_A5_1 = 0;
                                    if (expr_50 != 0)
                                    {
                                        break;
                                    }
                                    arg_5C_0 = (expr_4A == expr_50);
                                }
                                else
                                {
                                    arg_5C_0 = false;
                                }
                                if (!false)
                                {
                                }
                                flag = arg_5C_0;
                                bool expr_5D = arg_A5_0 = flag;
                                if (3 == 0)
                                {
                                    goto IL_A4;
                                }
                                if (expr_5D)
                                {
                                    goto IL_66;
                                }
                            }
                            result = this._result;
                            if (!false)
                            {
                                return result;
                            }
                        }
                    }
                }
            IL_66:
                base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                }));
                if (5 != 0)
                {
                    Thread.Sleep(20);
                }
            }
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this._result = string.Empty;
            this.HideHandlerDialog();
        }

        public void FillGrid(long ProfileID)
        {
            do
            {
                List<RateDetailInfo> itemsSource;
                do
                {
                    this._objCurrencyBusiness = new CurrencyExchangeBussiness();
                    itemsSource = new List<RateDetailInfo>();
                    List<RateDetailInfo> expr_4C = this._objCurrencyBusiness.GetProfilerateDetailList(ProfileID);
                    if (!false)
                    {
                        itemsSource = expr_4C;
                    }
                }
                while (3 == 0);
                this.dgRateDetail.ItemsSource = itemsSource;
            }
            while (7 == 0);
        }


    }
}
