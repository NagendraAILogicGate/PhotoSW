using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PhotoSW.PSControls
{
    public partial class Statistics : UserControl, IComponentConnector
    {
        private UIElement _parent;

        private bool _result = false;


        private EventHandler executeMethod;
        public event EventHandler ExecuteMethod
        {
            add
            {
                do
                {
                IL_00:
                    EventHandler eventHandler = this.executeMethod;
                    while (true)
                    {
                    IL_09:
                        EventHandler eventHandler2 = eventHandler;
                        while (true)
                        {
                            EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.executeMethod, value2, eventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (eventHandler == eventHandler2);
                                if (!false)
                                {
                                    arg_39_0 = !expr_31;
                                }
                                if (arg_39_0)
                                {
                                    goto IL_09;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                Block_4: ;
                }
                while (!true);
            }
            remove
            {
                do
                {
                IL_00:
                    EventHandler eventHandler = this.executeMethod;
                    while (true)
                    {
                    IL_09:
                        EventHandler eventHandler2 = eventHandler;
                        while (true)
                        {
                            EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.executeMethod, value2, eventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (eventHandler == eventHandler2);
                                if (!false)
                                {
                                    arg_39_0 = !expr_31;
                                }
                                if (arg_39_0)
                                {
                                    goto IL_09;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                Block_4: ;
                }
                while (!true);
            }
        }

        public static int SucessOrderCounts
        {
            get;
            set;
        }

        public static int ImageFailedCounts
        {
            get;
            set;
        }

        public static int ImageUploadedCounts
        {
            get;
            set;
        }

        public static int TotalOrderCounts
        {
            get;
            set;
        }

        public Statistics()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
        }

        public void ShowPopUp(int SucessOrderCount, int ImageFailedCount, int ImageUploadedCount, int TotalOrderCount)
        {
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public bool ShowPanHandlerDialog()
        {
            base.Visibility = Visibility.Visible;
            TextBlock arg_B8_0 = this.txtSucessOrder;
            int num = Statistics.SucessOrderCounts;
            arg_B8_0.Text = num.ToString();
            TextBlock arg_45_0 = this.txtTotalImageFailed;
            num = Statistics.ImageFailedCounts;
            arg_45_0.Text = num.ToString();
            TextBlock arg_5E_0 = this.txtTotalImageUploaded;
            num = Statistics.ImageUploadedCounts;
            arg_5E_0.Text = num.ToString();
            TextBlock arg_77_0 = this.txtTotalOrderCount;
            num = Statistics.TotalOrderCounts;
            arg_77_0.Text = num.ToString();
            return this._result;
        }

        private void HideHandlerDialog()
        {
            try
            {
                if (6 != 0)
                {
                    do
                    {
                        Visibility expr_07 = Visibility.Collapsed;
                        if (!false)
                        {
                            base.Visibility = expr_07;
                        }
                    }
                    while (5 == 0);
                }
            }
            catch (Exception serviceException)
            {
                do
                {
                    if (true)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
                while (8 == 0);
            }
        }

        protected virtual void OnExecuteMethod()
        {
            while (true)
            {
                bool arg_17_0;
                bool arg_34_0 = arg_17_0 = (this.executeMethod == null);
                do
                {
                    if (2 != 0)
                    {
                        bool flag;
                        if (7 != 0)
                        {
                            flag = arg_34_0;
                        }
                        arg_34_0 = (arg_17_0 = flag);
                    }
                }
                while (false);
                if (arg_17_0)
                {
                    goto IL_2D;
                }
            IL_19:
                if (false)
                {
                    continue;
                }
            this.executeMethod(this, EventArgs.Empty);
            IL_2D:
                if (8 != 0)
                {
                    break;
                }
                goto IL_19;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.HideHandlerDialog();
            this.OnExecuteMethod();
        }

  
    }
}
