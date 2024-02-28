using DigiAuditLogger;
using PhotoSW.Common;
using DigiPhoto.DataLayer;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using PhotoSW.Views;
using PhotoSW.DataLayer;

namespace PhotoSW.Manage
{
    public partial class SystemPrinterQueuee : Window, IComponentConnector, IStyleConnector
    {
        

        private DispatcherTimer _objmytimer;



        private ObservableCollection<PhotoSW.ViewModels.PrinterDetails> myprinterdetails
        {
            get;
            set;
        }

        public SystemPrinterQueuee()
        {
            this.InitializeComponent();
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
        }

        private void _objmytimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!false)
                {
                    this._objmytimer.Stop();
                    this.GetPrintersName();
                    if (8 != 0)
                    {
                    }
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
                while (-1 != 0 && false)
                {
                }
            }
            finally
            {
                do
                {
                    this._objmytimer.Start();
                }
                while (false);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    if (!false)
                    {
                      //  AuditLog.AddUserLog(LoginUser.UserId, 39, "Logged out at ");
                        if (false)
                        {
                            goto IL_20;
                        }
                        Login login = new Login();
                        login.Show();
                    }
                    if (false)
                    {
                        goto IL_26;
                    }
                IL_20:
                    base.Close();
                IL_26: ;
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                    while (4 == 0);
                }
            }
            while (false);
        }

        public void GetPrintersName()
		{
			//SystemPrinterQueuee.<>c__DisplayClass3 <>c__DisplayClass = new SystemPrinterQueuee.<>c__DisplayClass3();
			PrintServer printServer = new PrintServer();
			PrintQueueCollection printQueues = printServer.GetPrintQueues(new EnumeratedPrintQueueTypes[]
			{
				EnumeratedPrintQueueTypes.Local,
				EnumeratedPrintQueueTypes.Connections
			});
			this.myprinterdetails = new ObservableCollection<PhotoSW.ViewModels.PrinterDetails>();
			List<AssociatedPrintersInfo> associatedPrintersName = new PrinterBusniess().GetAssociatedPrintersName(LoginUser.SubStoreId);
		    var objprname = (from t in associatedPrintersName
			select t.DG_AssociatedPrinters_Name).Distinct<string>();
			int i = 0;
			if (!false)
			{
				goto IL_121;
			}
			IL_112:
			i++;
			IL_121:
			int arg_134_0 = i;
			bool expr_134;
			do
			{
				expr_134 = ((arg_134_0 = ((arg_134_0 < objprname.Count<string>()) ? 1 : 0)) != 0);
			}
			while (3 == 0);
			bool flag = expr_134;
			bool arg_D7_0;
			bool arg_140_0 = arg_D7_0 = flag;
			PrintQueue printQueue;
			bool expr_D9;
			do
			{
				if (5 != 0)
				{
					if (!arg_140_0)
					{
						goto Block_8;
					}
					printQueue = printQueues.Where(delegate(PrintQueue t)
					{
						bool arg_2D_0;
						bool arg_53_0 = arg_2D_0 = (t.FullName == objprname.ToArray<string>()[i].ToString());
						do
						{
							if (5 != 0)
							{
								bool flag2 = arg_53_0;
								arg_53_0 = (arg_2D_0 = flag2);
							}
						}
						while (3 == 0 || false);
						return arg_2D_0;
					}).FirstOrDefault<PrintQueue>();
					arg_D7_0 = (printQueue == null);
				}
				flag = arg_D7_0;
				expr_D9 = (arg_D7_0 = (arg_140_0 = flag));
			}
			while (7 == 0);
			if (!expr_D9)
			{
				this.myprinterdetails.Add(new PhotoSW.ViewModels.PrinterDetails(printQueue.FullName, this.GetPrintersJobs(printQueue.FullName), this.getPrinterStatus(printQueue.FullName)));
			}
			goto IL_112;
			Block_8:
			this.mylist.ItemsSource = this.myprinterdetails;
			if (!false)
			{
			}
		}

        public string getPrinterStatus(string PrinterName)
        {
            string result = "";
            ManagementScope managementScope = new ManagementScope("\\root\\cimv2");
            managementScope.Connect();
            ManagementObjectSearcher expr_1F4 = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            ManagementObjectSearcher managementObjectSearcher;
            if (!false)
            {
                managementObjectSearcher = expr_1F4;
            }
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            string[] array = new string[]
			{
				"Other",
				"Unknown",
				"Idle",
				"Printing",
				"WarmUp",
				"Stopped Printing",
				"Offline"
			};
            using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator())
            {
                while (true)
                {
                    while (true)
                    {
                        bool arg_172_0;
                        bool expr_19E = arg_172_0 = enumerator.MoveNext();
                        if (3 == 0)
                        {
                            goto IL_171;
                        }
                        if (!expr_19E)
                        {
                            goto Block_9;
                        }
                        ManagementObject managementObject = (ManagementObject)enumerator.Current;
                        string text = managementObject["Name"].ToString().ToLower();
                        int arg_178_0;
                        if (text.Equals(PrinterName.ToLower()))
                        {
                            Console.WriteLine("Printer = " + managementObject["Name"]);
                            if (managementObject["WorkOffline"].ToString().ToLower().Equals("true"))
                            {
                                goto IL_12B;
                            }
                            int num = managementObject["PrinterStatus"].ToInt32(false);
                            string text2 = array[num];
                            if (num == Convert.ToInt32(PrinterStatus.Other))
                            {
                                arg_178_0 = 0;
                                goto IL_177;
                            }
                            int expr_15F = arg_178_0 = num;
                            if (!false)
                            {
                                arg_172_0 = (expr_15F == Convert.ToInt32(PrinterStatus.Offline));
                                goto IL_171;
                            }
                            goto IL_177;
                        }
                        break;
                        break;
                    IL_177:
                        if (arg_178_0 == 0)
                        {
                            if (true)
                            {
                                result = "Error";
                            }
                        }
                        else
                        {
                            if (false)
                            {
                                goto IL_12B;
                            }
                            result = "Online";
                        }
                        break;
                    IL_12B:
                        result = "Offline";
                        break;
                    IL_171:
                        arg_178_0 = ((!arg_172_0) ? 1 : 0);
                        goto IL_177;
                    }
                }
            Block_9: ;
            }
            return result;
        }

        public ObservableCollection<PrinterJobInfo> GetPrintersJobs(string printerName)
        {
            //string printerName;
            PrintQueue printQueue;
            PrintJobInfoCollection printJobInfoCollection;
            DataTable dataTable;
            while (true)
            {
               // printerName = printerName2;
                new ObservableCollection<PrinterJobInfo>();
                PrintServer printServer = new PrintServer();
                PrintQueueCollection printQueues = printServer.GetPrintQueues(new EnumeratedPrintQueueTypes[]
				{
					EnumeratedPrintQueueTypes.Local,
					EnumeratedPrintQueueTypes.Connections
				});
                if (!false)
                {
                    printQueue = (from t in printQueues
                                  where t.FullName == printerName
                                  select t).FirstOrDefault<PrintQueue>();
                }
                printQueue.Refresh();
                printJobInfoCollection = printQueue.GetPrintJobInfoCollection();
                while (true)
                {
                    dataTable = new DataTable();
                    if (-1 == 0)
                    {
                        break;
                    }
                    dataTable.Columns.Add("JobName", typeof(string));
                    dataTable.Columns.Add("JobStatus", typeof(string));
                    dataTable.Columns.Add("JobIdentifier", typeof(int));
                    if (-1 != 0)
                    {
                        goto Block_3;
                    }
                }
            }
        Block_3:
            IEnumerator<PrintSystemJobInfo> enumerator = printJobInfoCollection.GetEnumerator();
            try
            {
                while (true)
                {
                    bool arg_162_0;
                    bool arg_169_0 = arg_162_0 = enumerator.MoveNext();
                    do
                    {
                        if (!false)
                        {
                            bool flag = arg_162_0;
                            arg_169_0 = (arg_162_0 = flag);
                        }
                    }
                    while (false);
                    if (!arg_169_0)
                    {
                        break;
                    }
                    PrintSystemJobInfo current = enumerator.Current;
                    DataRow dataRow;
                    if (!false)
                    {
                        dataRow = dataTable.NewRow();
                    }
                    dataRow["JobName"] = current.Name;
                    dataRow["JobStatus"] = current.JobStatus.ToString();
                    dataRow["JobIdentifier"] = current.JobIdentifier;
                    dataTable.Rows.Add(dataRow);
                }
            }
            finally
            {
                bool arg_175_0 = enumerator == null;
                bool expr_177;
                do
                {
                    bool flag = arg_175_0;
                    expr_177 = (arg_175_0 = flag);
                }
                while (2 == 0);
                if (!expr_177)
                {
                    enumerator.Dispose();
                }
            }
            ObservableCollection<PrinterJobInfo> printerJobInfo = new PrinterBusniess().GetPrinterJobInfo(dataTable, printerName, LoginUser.DigiFolderThumbnailPath);
            printQueue = null;
            return printerJobInfo;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    if (!false)
                    {
                        this.GetPrintersName();
                        if (!false)
                        {
                            this._objmytimer = new DispatcherTimer();
                            this._objmytimer.Interval = new TimeSpan(0, 0, 2);
                            this._objmytimer.Tick += new EventHandler(this._objmytimer_Tick);
                            this._objmytimer.Start();
                        }
                    }
                IL_4A:
                    if (6 == 0)
                    {
                        goto IL_4A;
                    }
                }
                catch (Exception serviceException)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                    while (2 == 0)
                    {
                    }
                }
            }
            while (3 == 0);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!false)
                {
                  //  this._objmytimer.Stop();
                    //if (!false)
                    //{
                        ManageHome manageHome = new ManageHome();
                        manageHome.Show();
                        base.Close();
                  //  }
                }
            }
            catch (Exception serviceException)
            {
                if (4 != 0)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            try
            {
                if (6 != 0)
                {
                    do
                    {
                        bool expr_07 = true;
                        if (!false)
                        {
                            e.CanExecute = expr_07;
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

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                PrintServer printServer = new PrintServer();
                PrintQueueCollection printQueues = printServer.GetPrintQueues(new EnumeratedPrintQueueTypes[]
				{
					EnumeratedPrintQueueTypes.Local,
					EnumeratedPrintQueueTypes.Connections
				});
                PrintQueue printQueue = printQueues.Where(delegate(PrintQueue t)
                {
                    if (false)
                    {
                        goto IL_21;
                    }
                    bool arg_28_0;
                    bool arg_4B_0 = arg_28_0 = (t.FullName == ((PhotoSW.Common.FindCommandParameters)e.Parameter).Text);
                IL_19:
                    if (7 == 0 || 8 == 0)
                    {
                        goto IL_25;
                    }
                    bool flag = arg_4B_0;
                IL_21:
                    arg_4B_0 = (arg_28_0 = flag);
                IL_25:
                    if (!false)
                    {
                        return arg_28_0;
                    }
                    goto IL_19;
                }).FirstOrDefault<PrintQueue>();
                printQueue.Refresh();
                PrintJobInfoCollection printJobInfoCollection = printQueue.GetPrintJobInfoCollection();
                PrintSystemJobInfo printSystemJobInfo = printQueue.GetPrintJobInfoCollection().Where(delegate(PrintSystemJobInfo t)
                {
                    bool result;
                    while (4 != 0)
                    {
                        result = (t.JobIdentifier == ((PhotoSW.Common.FindCommandParameters)e.Parameter).IgnoreCase.ToInt32(false));
                        if (!false)
                        {
                            break;
                        }
                    }
                    return result;
                }).FirstOrDefault<PrintSystemJobInfo>();
                printSystemJobInfo.Cancel();
                printQueue.Refresh();
                PrinterQueueInfo queueDetail = new PrinterBusniess().GetQueueDetail(printSystemJobInfo.Name.ToInt32(false));
                new PrinterBusniess().SetPrinterQueueForReprint(printSystemJobInfo.Name.ToInt32(false));
                new OrderBusiness().SetOrderDetailsForReprint(queueDetail.DG_Orders_LineItems_pkey, LoginUser.SubStoreId);
                AuditLog.AddUserLog(LoginUser.UserId, 63, string.Concat(new string[]
				{
					"Move Print",
					queueDetail.DG_Orders_ProductType_Name.ToString(),
					" ( image no:",
					queueDetail.DG_Photos_RFID.ToString(),
					" of Order No ",
					queueDetail.DG_Orders_Number.ToString(),
					" from substore ",
					LoginUser.SubstoreName
				}));
                this.GetPrintersName();
            }
            catch (Exception serviceException)
            {
                if (5 != 0)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
        }

        private void btnReprint_Click(object sender, RoutedEventArgs e)
        {
            if (7 != 0 && !false)
            {
                try
                {
                    this.ReprintCtrl.SetParent(this);
                    do
                    {
                        UIElement expr_1B = this.ReprintCtrl.dgReprint;
                        Visibility expr_20 = Visibility.Collapsed;
                        if (2 != 0)
                        {
                            expr_1B.Visibility = expr_20;
                        }
                        this.ReprintCtrl.ShowHandlerDialog();
                    }
                    while (false);
                }
                catch (Exception serviceException)
                {
                    if (3 == 0)
                    {
                        goto IL_68;
                    }
                IL_61:
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                IL_68:
                    if (-1 == 0)
                    {
                        goto IL_61;
                    }
                }
            }
        }

       void IStyleConnector.Connect(int connectionId, object target)
        {
            int arg_48_0 = connectionId;
            int expr_4B;
            do
            {
                int num;
                if (4 != 0)
                {
                    num = arg_48_0;
                }
                expr_4B = (arg_48_0 = num);
            }
            while (6 == 0);
            if (expr_4B == 2)
            {
                ((CommandBinding)target).CanExecute += new CanExecuteRoutedEventHandler(this.CommandBinding_CanExecute);
                if (!false)
                {
                    ((CommandBinding)target).Executed += new ExecutedRoutedEventHandler(this.CommandBinding_Executed);
                }
            }
        }
    }
}
