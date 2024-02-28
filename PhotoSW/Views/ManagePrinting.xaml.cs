using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.Manage;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;
using DigiPhoto;
using PhotoSW.Views;

namespace PhotoSW.Views
{
    public partial class ManagePrinting : Window, IComponentConnector, IStyleConnector
    {
        private DispatcherTimer _timer;

        public static Timer _printingService;

        public static int _gridSelectedIndex = 0;

      

        public bool PrintJob
        {
            get;
            set;
        }

        public ManagePrinting()
        {
            this.InitializeComponent();
            RobotImageLoader.GetConfigData();
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
            this._timer = new DispatcherTimer();
            this._timer.Interval = TimeSpan.FromSeconds(6.0);
            this._timer.Tick += new EventHandler(this.timer_Tick);
            this.DGPrintingqueue.SelectedCellsChanged += new SelectedCellsChangedEventHandler(this.DGPrintingqueue_SelectedCellsChanged);
            this._timer.Start();
            ManagePrinting._gridSelectedIndex = 0;
        }

        private void DGPrintingqueue_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (4 != 0)
            {
                do
                {
                    bool flag = this.DGPrintingqueue.SelectedIndex == -1;
                    if (false || flag)
                    {
                        return;
                    }
                }
                while (3 == 0);
                ManagePrinting._gridSelectedIndex = this.DGPrintingqueue.SelectedIndex;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    while (!false)
                    {
                        this._timer.Stop();
                        if (!false)
                        {
                            this.GetPrinterQueue();
                            break;
                        }
                    }
                }
                catch (Exception serviceException)
                {
                    if (!false)
                    {
                    }
                    string message;
                    do
                    {
                        message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    }
                    while (false);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (3 == 0)
                {
                }
            }
            finally
            {
                this._timer.Start();
            }
        }

        private void GetPrinterQueue()
        {
            if (3 != 0)
            {
                this.DGPrintingqueue.ItemsSource = null;
                PrinterBusniess expr_A8 = new PrinterBusniess();
                PrinterBusniess printerBusniess;
                if (!false)
                {
                    printerBusniess = expr_A8;
                }
                this.DGPrintingqueue.ItemsSource = printerBusniess.GetPrinterQueueForUpdown(LoginUser.SubStoreId);
                if (3 != 0)
                {
                    if (ManagePrinting._gridSelectedIndex <= this.DGPrintingqueue.Items.Count - 1 || false)
                    {
                        this.DGPrintingqueue.SelectedIndex = ManagePrinting._gridSelectedIndex;
                        if (8 != 0)
                        {
                            if (3 != 0)
                            {
                                return;
                            }
                            goto IL_85;
                        }
                    }
                    ManagePrinting._gridSelectedIndex = 0;
                IL_85:
                    this.DGPrintingqueue.SelectedIndex = ManagePrinting._gridSelectedIndex;
                }
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    AuditLog.AddUserLog(LoginUser.UserId, 39, "Logged out at ");
                    do
                    {
                        Login login = new Login();
                        login.Show();
                        base.Hide();
                    }
                    while (false);
                }
                catch (Exception serviceException)
                {
                    while (true)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                        while (!false)
                        {
                            if (5 != 0)
                            {
                                goto Block_6;
                            }
                        }
                    }
                Block_6: ;
                }
                while (false)
                {
                }
            }
            while (6 == 0);
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                try
                {
                    if (!false)
                    {
                        this._timer.Stop();
                        ManagePrinting._gridSelectedIndex = this.DGPrintingqueue.SelectedIndex;
                        int arg_2C_0 = ManagePrinting._gridSelectedIndex;
                        while (arg_2C_0 >= 1)
                        {
                            int expr_3E = arg_2C_0 = ManagePrinting._gridSelectedIndex - 1;
                            if (4 != 0 && 3 != 0)
                            {
                                ManagePrinting._gridSelectedIndex = expr_3E;
                                break;
                            }
                        }
                        new Button();
                        if (false)
                        {
                        }
                        Button button = (Button)sender;
                        PrinterBusniess printerBusniess = new PrinterBusniess();
                        printerBusniess.SetPrintQueueIndex(button.CommandParameter.ToInt32(false), "Up");
                    }
                }
                catch (Exception serviceException)
                {
                    string message;
                    do
                    {
                        message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    }
                    while (!true);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    ManagePrinting._gridSelectedIndex = 0;
                }
                while (6 == 0)
                {
                }
            }
            finally
            {
                this.GetPrinterQueue();
                if (!false)
                {
                    this.DGPrintingqueue.SelectedIndex = ManagePrinting._gridSelectedIndex;
                    this._timer.Start();
                }
            }
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int arg_6F_0;
                int arg_73_0;
                do
                {
                    this._timer.Stop();
                    int expr_C7 = arg_6F_0 = this.DGPrintingqueue.SelectedIndex;
                    if (8 == 0)
                    {
                        goto IL_6F;
                    }
                    ManagePrinting._gridSelectedIndex = expr_C7;
                    int expr_29 = arg_73_0 = ManagePrinting._gridSelectedIndex;
                    if (false)
                    {
                        goto IL_73;
                    }
                    if (expr_29 < 0 || this.DGPrintingqueue.Items.Count <= 1)
                    {
                        goto IL_6D;
                    }
                }
                while (3 == 0);
                arg_6F_0 = ((ManagePrinting._gridSelectedIndex == this.DGPrintingqueue.Items.Count - 1) ? 1 : 0);
                goto IL_6E;
            IL_6D:
                arg_6F_0 = 1;
            IL_6E:
            IL_6F:
                bool flag = arg_6F_0 != 0;
                arg_73_0 = (flag ? 1 : 0);
            IL_73:
                if (arg_73_0 == 0)
                {
                    ManagePrinting._gridSelectedIndex++;
                }
                Button button = new Button();
                button = (Button)sender;
                PrinterBusniess printerBusniess = new PrinterBusniess();
                printerBusniess.SetPrintQueueIndex(button.CommandParameter.ToInt32(false), "Down");
            }
            catch (Exception serviceException)
            {
                string message;
                do
                {
                    message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                }
                while (false);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            finally
            {
                this.GetPrinterQueue();
                if (!false)
                {
                    this.DGPrintingqueue.SelectedIndex = ManagePrinting._gridSelectedIndex;
                    if (!false)
                    {
                        this._timer.Start();
                    }
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
            {
            ManageHome manageHome = new ManageHome();
            manageHome.Show();
            base.Close();
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManageHome manageHome = new ManageHome();
            manageHome.Show();
            base.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.GetPrinterQueue();
            this.DGPrintingqueue.SelectedIndex = ManagePrinting._gridSelectedIndex;
        }

        private void btnReprint_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                while (true)
                {
                    this.ReprintCtrl.SetParent(this);
                    UIElement expr_14 = this.ReprintCtrl.dgReprint;
                    Visibility expr_19 = Visibility.Collapsed;
                    if (7 != 0)
                    {
                        expr_14.Visibility = expr_19;
                    }
                    if (3 != 0)
                    {
                        if (true)
                        {
                            if (!false)
                            {
                                break;
                            }
                        }
                    }
                }
                this.ReprintCtrl.ShowHandlerDialog();
            }
            while (7 == 0);
        }

         void IStyleConnector.Connect(int connectionId, object target)
        {
            while (true)
            {
                int arg_16_0 = connectionId;
                if (false)
                {
                    goto IL_16;
                }
                if (4 != 0)
                {
                    arg_16_0 = connectionId - 14;
                    goto IL_16;
                }
            IL_5A:
                if (!false)
                {
                    if (true)
                    {
                        break;
                    }
                    continue;
                }
            IL_23:
                goto IL_5A;
            IL_16:
                switch (arg_16_0)
                {
                    case 0:
                        ((Button)target).Click += new RoutedEventHandler(this.btnUp_Click);
                        break;
                    case 1:
                        if (!false)
                        {
                            ((Button)target).Click += new RoutedEventHandler(this.btnDown_Click);
                        }
                        break;
                }
                goto IL_23;
            }
        }
    }
}
