using ClosedXML.Excel;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DigiAuditLogger;
using PhotoSW.Common;
using DigiPhoto.DataLayer;
using PhotoSW.ExtensionMethods;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.Data;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Xceed.Wpf.Toolkit;
using PhotoSW.Views;
using DigiPhoto;
using SAPBusinessObjects.WPF.Viewer;

namespace PhotoSW.Manage.Reports
{
    public partial  class ActivityReport : Window, IComponentConnector
    {
        public class TryCatch
        {
            public static void BeginTryCatch(Action<ActivityReport.CommandArgs> function, ActivityReport.CommandArgs obj)
            {
                do
                {
                    if (-1 != 0)
                    {
                        try
                        {
                            if (4 != 0)
                            {
                                function(obj);
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                        }
                        if (5 == 0)
                        {
                            continue;
                        }
                    }
                }
                while (false);
            }

            public static void BeginTryCatch(Action<object> function, object obj)
            {
                do
                {
                    if (-1 != 0)
                    {
                        try
                        {
                            if (4 != 0)
                            {
                                function(obj);
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                        }
                        if (5 == 0)
                        {
                            continue;
                        }
                    }
                }
                while (false);
            }

            public static void BeginTryCatch(Action function)
            {
                try
                {
                    if (8 == 0)
                    {
                        goto IL_09;
                    }
                IL_05:
                    function();
                IL_09:
                    if (false)
                    {
                        goto IL_05;
                    }
                }
                catch (Exception ex)
                {
                    do
                    {
                        if (-1 != 0)
                        {
                            System.Windows.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                        }
                    }
                    while (false);
                }
            }
        }

        public class CommandArgs
        {
            public object CommandParameters
            {
                get;
                set;
            }

            public object OriginalArgs
            {
                get;
                set;
            }

            public object OriginalSource
            {
                get;
                set;
            }
        }

        private ReportBusiness reportBusiness = null;

        private Dictionary<string, string> lstPhotographerList;

        private Dictionary<string, string> lstLocationList;

        private Dictionary<string, string> lstReportTypeList;

        private Dictionary<string, string> lstsubstoreList;

        private Dictionary<string, string> lststoreList;

        private bool sendMailFlag = false;

        private ReportDocument report = new ReportDocument();

        private string filename = string.Empty;

        private bool isIPPrintTrackingRpt = false;

        private DateTime FromDt = DateTime.Now;

        private DateTime ToDt = DateTime.Now;

        private DataTable dtDataToExport;

        private SaveFileDialog dlg = new SaveFileDialog();

        private DataTable _sourceTable;


        private PropertyChangedEventHandler propertyChangedSource;
        public event PropertyChangedEventHandler PropertyChangedSource
        {
            add
            {
                do
                {
                IL_00:
                    PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedSource;
                    while (true)
                    {
                    IL_09:
                        PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
                        while (true)
                        {
                            PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChangedSource, value2, propertyChangedEventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (propertyChangedEventHandler == propertyChangedEventHandler2);
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
                    PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedSource;
                    while (true)
                    {
                    IL_09:
                        PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
                        while (true)
                        {
                            PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChangedSource, value2, propertyChangedEventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (propertyChangedEventHandler == propertyChangedEventHandler2);
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
        private PropertyChangedEventHandler propertyChanged;
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                do
                {
                IL_00:
                    PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChanged;
                    while (true)
                    {
                    IL_09:
                        PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
                        while (true)
                        {
                            PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChanged, value2, propertyChangedEventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (propertyChangedEventHandler == propertyChangedEventHandler2);
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
                    PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChanged;
                    while (true)
                    {
                    IL_09:
                        PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
                        while (true)
                        {
                            PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChanged, value2, propertyChangedEventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (propertyChangedEventHandler == propertyChangedEventHandler2);
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

        private static DataTable ReportSource
        {
            get;
            set;
        }

        private List<ReportTypeDetails> ReportTypeDetail
        {
            get;
            set;
        }

        public DataTable SourceTable
        {
            get
            {
                return this._sourceTable;
            }
            set
            {
                this._sourceTable = value;
                this.NotifyPropertyChanged("SourceTable");
            }
        }

        public ActivityReport()
        {
            this.InitializeComponent();
            this.FillUserCombo();
            this.FillLocation();
            this.FillSubStoreCombo();
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
            this.FillReportTypeCombo();
            this.ActivityReportviewer.ShowCopyButton = false;
            this.ActivityReportviewer.ShowLogo = false;
            this.ActivityReportviewer.ShowToggleSidePanelButton = false;
            this.ActivityReportviewer.ShowOpenFileButton = false;
            this.ActivityReportviewer.ShowExportButton = false;
            this.ActivityReportviewer.ShowPrintButton = false;
            this.ActivityReportviewer.ShowStatusbar = true;
            this.ActivityReportviewer.ToggleSidePanel = Constants.SidePanelKind.None;
            this.dtFrom.Value = new DateTime?(DateTime.Now.Date.Add(new TimeSpan(6, 0, 0)));
            this.dtTo.Value = new DateTime?(DateTime.Now.Date.Add(new TimeSpan(23, 0, 0)));
            this.dtFrom1.Value = new DateTime?(DateTime.Now.Date.Add(new TimeSpan(6, 0, 0)));
            this.dtTo1.Value = new DateTime?(DateTime.Now.Date.Add(new TimeSpan(23, 0, 0)));
            this.ActivityReportviewer.Owner = this;
            this.sendMailFlag = false;
            this.MailPopUp.SetParent(this.emailPopUp);
            this.FillProductCombo();
        }

        private void FillReportTypeCombo()
        {
            while (true)
            {
                while (true)
                {
                    this.ReportTypeDetail = new ConfigBusiness().GetReport();
                    while (!false)
                    {
                        this.cmbReportType.Items.Clear();
                        do
                        {
                            if (8 != 0)
                            {
                                this.cmbReportType.ItemsSource = RobotImageLoader.GetReports();
                            }
                        }
                        while (3 == 0);
                        if (2 == 0)
                        {
                            break;
                        }
                        if (6 != 0)
                        {
                            goto Block_4;
                        }
                    }
                }
            }
        Block_4:
            this.cmbReportType.SelectedValue = "0";
        }

        private void FillUserCombo()
        {
            try
            {
                if (4 == 0)
                {
                    goto IL_31;
                }
                UserBusiness userBusiness = new UserBusiness();
            IL_09:
                ItemsControl expr_0B = this.cmbPhotographer;
                IEnumerable expr_46 = userBusiness.GetUserDetailsByUserId(1);
                if (!false)
                {
                    expr_0B.ItemsSource = expr_46;
                }
            IL_1A:
                if (2 == 0)
                {
                    goto IL_09;
                }
                if (8 != 0)
                {
                    this.cmbPhotographer.SelectedValue = "0";
                }
            IL_31:
                if (7 == 0)
                {
                    goto IL_1A;
                }
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
        }

        private void FillLocation()
        {
            this.lstLocationList = new Dictionary<string, string>();
            if (3 != 0)
            {
                this.lstLocationList.Add("--Select--", "0");
            }
            do
            {
                try
                {
                    LocationBusniess locationBusniess = new LocationBusniess();
                    this.lstLocationList = locationBusniess.GetLocationList(LoginUser.StoreId).ToDictionary((LocationInfo o) => o.DG_Location_pkey.ToString(), (LocationInfo o) => o.DG_Location_Name);
                    this.cmbLocation.ItemsSource = this.lstLocationList;
                    this.cmbLocation.SelectedValue = "0";
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
            while (3 == 0);
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            ManageHome manageHome = new ManageHome();
            manageHome.Show();
            base.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login;
            do
            {
                int arg_2F_0 = LoginUser.UserId;
                do
                {
                    arg_2F_0 = (AuditLog.AddUserLog(arg_2F_0, 39, "Logged out at ") ? 1 : 0);
                }
                while (2 == 0 || false);
                login = new Login();
            }
            while (false);
            login.Show();
            do
            {
                base.Close();
            }
            while (8 == 0);
        }

        private DataTable DataTableFromIEnumerable(IEnumerable ien)
        {
            DataTable result;
            if (!false)
            {
                DataTable dataTable = new DataTable();
               // using (IEnumerator enumerator = ien.GetEnumerator())
                IEnumerator enumerator = ien.GetEnumerator();
                try
                {
                    while (true)
                    {
                        bool flag = enumerator.MoveNext();
                        int arg_D8_0;
                        bool expr_15A = (arg_D8_0 = (flag ? 1 : 0)) != 0;
                        if (false)
                        {
                            goto IL_D8;
                        }
                        if (!expr_15A)
                        {
                            break;
                        }
                        object current = enumerator.Current;
                        Type type = current.GetType();
                        PropertyInfo[] properties = type.GetProperties();
                        int arg_FF_0;
                        int expr_4E = arg_FF_0 = dataTable.Columns.Count;
                        if (false)
                        {
                            goto IL_FF;
                        }
                        flag = (expr_4E != 0);
                        PropertyInfo[] array;
                        int num;
                        if (!flag)
                        {
                            array = properties;
                            num = 0;
                            goto IL_DA;
                        }
                        goto IL_EF;
                    IL_12E:
                        int arg_AF_0;
                        bool expr_134 = (arg_AF_0 = ((num < array.Length) ? 1 : 0)) != 0;
                        if (false)
                        {
                            goto IL_AB;
                        }
                        DataRow dataRow;
                        if (!expr_134)
                        {
                            dataTable.Rows.Add(dataRow);
                            continue;
                        }
                        PropertyInfo propertyInfo = array[num];
                        object value = propertyInfo.GetValue(current, null);
                        dataRow[propertyInfo.Name] = value;
                        goto IL_127;
                    IL_FF:
                        num = arg_FF_0;
                        goto IL_12E;
                    IL_127:
                        num++;
                        goto IL_12E;
                    IL_DA:
                        if (6 == 0)
                        {
                            goto IL_B1;
                        }
                        if (num >= array.Length)
                        {
                            goto IL_EF;
                        }
                        if (false)
                        {
                            goto IL_127;
                        }
                        propertyInfo = array[num];
                        Type type2 = propertyInfo.PropertyType;
                        if (type2.IsGenericType)
                        {
                            arg_AF_0 = ((!(type2.GetGenericTypeDefinition() == typeof(Nullable<>))) ? 1 : 0);
                            goto IL_AB;
                        }
                        goto IL_AD;
                    IL_D8:
                        num = arg_D8_0;
                        goto IL_DA;
                    IL_B1:
                        if (!flag)
                        {
                            type2 = Nullable.GetUnderlyingType(type2);
                        }
                        dataTable.Columns.Add(propertyInfo.Name, type2);
                        arg_D8_0 = num + 1;
                        goto IL_D8;
                    IL_AE:
                        flag = (arg_AF_0 != 0);
                        goto IL_B1;
                    IL_AB:
                        goto IL_AE;
                    IL_EF:
                        if (6 != 0)
                        {
                            dataRow = dataTable.NewRow();
                            array = properties;
                            arg_FF_0 = 0;
                            goto IL_FF;
                        }
                    IL_AD:
                        arg_AF_0 = 1;
                        goto IL_AE;
                    }
                }
                catch
                {
                }
                result = dataTable;
            }
            return result;
        }

        private void FillSubStoreCombo()
        {
            try
            {
                if (4 != 0)
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    dictionary.Add("--Select--", "--Select--");
                    StoreSubStoreDataBusniess storeSubStoreDataBusniess = new StoreSubStoreDataBusniess();
                    this.cmbsubstore.ItemsSource = storeSubStoreDataBusniess.GetSubstoreDataDir(dictionary);
                }
                this.cmbsubstore.SelectedValue = "--Select--";
            }
            catch (Exception serviceException)
            {
                if (false)
                {
                    goto IL_87;
                }
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
            IL_79:
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            IL_7F:
                if (!false && false)
                {
                    goto IL_79;
                }
            IL_87:
                if (6 == 0)
                {
                    goto IL_7F;
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                try
                {
                    ActivityReport.ReportSource = null;
                    this.isIPPrintTrackingRpt = false;
                    BusyWindow busyWindow = new BusyWindow();
                  //  busyWindow.Show();
                    this.SearchButtonCode();
                    bool arg_44_0 = this.isIPPrintTrackingRpt;
                    bool expr_45;
                    do
                    {
                        bool flag = arg_44_0;
                        expr_45 = (arg_44_0 = flag);
                    }
                    while (false);
                    if (!expr_45)
                    {
                        this.ActivityReportviewer.ViewerCore.ReportSource = this.report;
                        this.ActivityReportviewer.Focusable = true;
                        this.ActivityReportviewer.Focus();

                    }
                    busyWindow.Hide();
                    this.sendMailFlag = true;
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void SearchButtonCode()
        {
            bool isFromDate = false;
            bool isToDate = false;
            DateTime fromDt = DateTime.Now;
            DateTime toDt = DateTime.Now;
            if (this.dtFrom.Text != null)
            {
                isFromDate = true;
                if (7 == 0)
                {
                    return;
                }
                this.FromDt = this.dtFrom.Value.Value;
            }
            if (this.dtTo.Text != null)
            {
                isToDate = true;
                this.ToDt = this.dtTo.Value.Value;
            }
            bool flag = this.dtFrom1.Text == null;
            bool arg_472_0;
            bool arg_368_0;
            bool expr_A2 = arg_368_0 = (arg_472_0 = flag);
            if (false)
            {
                goto IL_46B;
            }
            if (!expr_A2)
            {
                isFromDate = true;
                fromDt = this.dtFrom1.Value.Value;
            }
            if (this.dtTo1.Text != null)
            {
                isToDate = true;
                toDt = this.dtTo1.Value.Value;
            }
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (this.cmbReportType.SelectedValue.ToString() == "0")
            {
                this.ReportActivity(isFromDate, isToDate, this.FromDt, this.ToDt, baseDirectory);
                return;
            }
            flag = !(this.cmbReportType.SelectedValue.ToString() == "1");
            bool arg_160_0 = flag;
        IL_160:
            int arg_368_1;
            if (!arg_160_0)
            {
                this.ReportProductSummary(this.FromDt, this.ToDt, baseDirectory);
            }
            else
            {
                bool arg_199_0 = this.cmbReportType.SelectedValue.ToString() == "2";
                int arg_199_1 = 0;
                while ((arg_199_0 ? 1 : 0) == arg_199_1)
                {
                    if (this.cmbReportType.SelectedValue.ToString() == "3")
                    {
                        this.ReportTaking(isFromDate, isToDate, this.FromDt, this.ToDt, baseDirectory);
                        return;
                    }
                    if (this.cmbReportType.SelectedValue.ToString() == "4")
                    {
                        this.ReportOperationAudit(this.FromDt, this.ToDt, baseDirectory);
                        goto IL_238;
                    }
                    int expr_254 = (arg_199_0 = (this.cmbReportType.SelectedValue.ToString() == "6")) ? 1 : 0;
                    int expr_25A = arg_199_1 = 0;
                    if (expr_25A == 0)
                    {
                        if (expr_254 != expr_25A)
                        {
                            this.ReportLocationPerformance(this.FromDt, this.ToDt, fromDt, toDt, baseDirectory);
                            return;
                        }
                        if (8 == 0)
                        {
                            goto IL_44D;
                        }
                        if (this.cmbReportType.SelectedValue.ToString() == "5")
                        {
                            this.ReportPhotoGrapherPerformance(this.FromDt, this.ToDt, fromDt, toDt, baseDirectory);
                            return;
                        }
                        if (this.cmbReportType.SelectedValue.ToString() == "7")
                        {
                            this.ReportFinancialaudit(this.FromDt, this.ToDt, baseDirectory);
                            return;
                        }
                        if (this.cmbReportType.SelectedValue.ToString() == "8")
                        {
                            this.ReportOrderDiscount(this.FromDt, this.ToDt, fromDt, toDt, baseDirectory);
                            return;
                        }
                        arg_368_0 = (this.cmbReportType.SelectedValue.ToString() == "8");
                        arg_368_1 = 0;
                        goto IL_368;
                    }
                }
                this.ReportOperatorPerformance(this.FromDt, this.ToDt, fromDt, toDt, baseDirectory);
            }
        IL_238:
            return;
        IL_368:
            flag = ((arg_368_0 ? 1 : 0) == arg_368_1);
            if (!false)
            {
                if (!flag)
                {
                    this.ReportsOrderDiscount(this.FromDt, this.ToDt, fromDt, toDt, baseDirectory);
                }
                else
                {
                    if (!(this.cmbReportType.SelectedValue.ToString() == "9"))
                    {
                        flag = !(this.cmbReportType.SelectedValue.ToString() == "10");
                        if (!false)
                        {
                            if (!flag)
                            {
                                this.ReportStorePaymentSummary(this.FromDt, this.ToDt, baseDirectory);
                                return;
                            }
                            if (this.cmbReportType.SelectedValue.ToString() == "11")
                            {
                                this.ReportIPPrintTracking(this.FromDt, this.ToDt, baseDirectory);
                                goto IL_44D;
                            }
                            arg_472_0 = (arg_368_0 = (this.cmbReportType.SelectedValue.ToString() == "12"));
                            goto IL_46B;
                        }
                    }
                    this.ReportPrintLog(this.FromDt, this.ToDt, baseDirectory);
                }
            }
        IL_44D:
            return;
        IL_46B:
            int expr_46C = arg_368_1 = 0;
            if (expr_46C != 0)
            {
                goto IL_368;
            }
            bool expr_472 = arg_160_0 = ((arg_472_0 ? 1 : 0) == expr_46C);
            if (2 == 0)
            {
                goto IL_160;
            }
            if (!expr_472)
            {
                this.ReportIPContentTracking(this.FromDt, this.ToDt, baseDirectory);
            }
        }

        private void ReportIPPrintTracking(DateTime FromDt, DateTime ToDt, string ApplicationPath)
        {
            try
            {
                this.SourceTable = new DataTable();
                bool value = this.chkChecked.IsChecked.Value;
                ReportBusiness reportBusiness = new ReportBusiness();
                DataSet dataForIPPrintTracking = reportBusiness.GetDataForIPPrintTracking(FromDt, ToDt, ((KeyValuePair<string, string>)this.cmbsubstore.SelectedItem).Key.ToInt32(false), this.cmbPackages.SelectedValue.ToInt32(false));
                TaxBusiness taxBusiness = new TaxBusiness();
                if (dataForIPPrintTracking.Tables.Count > 0 && dataForIPPrintTracking.Tables[0].Rows.Count > 0)
                {
                    string text = "Order Date,Order No,Site,Package,Sell Price,Payment Mode,DG_Orders_LineItems_pkey";
                    int num = 0;
                    if (!false)
                    {
                        dataForIPPrintTracking.Tables[0].Columns.Remove("DG_Orders_LineItems_pkey");
                        DataRow dataRow;
                        if (7 != 0)
                        {
                            dataRow = dataForIPPrintTracking.Tables[0].NewRow();
                            dataRow[5] = "Total";
                        }
                        if (!false)
                        {
                            foreach (DataColumn dataColumn in dataForIPPrintTracking.Tables[0].Columns)
                            {
                                int count = dataForIPPrintTracking.Tables[0].Columns.Count;
                                if (!text.Contains(dataColumn.ColumnName))
                                {
                                    dataRow[num] = dataForIPPrintTracking.Tables[0].Compute("sum([" + dataColumn.ColumnName + "])", "");
                                    if (dataColumn.ColumnName.ToLower() != "total")
                                    {
                                        dataColumn.ColumnName += "(No of Images)";
                                    }
                                }
                                num++;
                            }
                            dataForIPPrintTracking.Tables[0].Rows.Add(dataRow);
                        }
                        this.dtDataToExport = new DataTable();
                        this.dtDataToExport = dataForIPPrintTracking.Tables[0];
                        ActivityReport.ReportSource = this.dtDataToExport;
                        this.gridReport.ItemsSource = this.dtDataToExport.DefaultView;
                        this.gridReport.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    this.gridReport.ItemsSource = null;
                    System.Windows.MessageBox.Show("No record found");
                    this.gridReport.Visibility = Visibility.Collapsed;
                    this.dtDataToExport = null;
                }
                this.isIPPrintTrackingRpt = true;
                this.filename = "IP Print Tracking Report";
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void ReportIPContentTracking(DateTime FromDt, DateTime ToDt, string ApplicationPath)
        {
            try
            {
                DataTable expr_142 = new DataTable();
                if (!false)
                {
                    this.SourceTable = expr_142;
                }
                DataTable dataTable;
                if (!false)
                {
                    if (false)
                    {
                    }
                    if (false)
                    {
                    }
                    bool value = this.chkChecked.IsChecked.Value;
                    ReportBusiness reportBusiness = new ReportBusiness();
                    DataSet dataForIPContentTracking = reportBusiness.GetDataForIPContentTracking(FromDt, ToDt, ((KeyValuePair<string, string>)this.cmbsubstore.SelectedItem).Key.ToInt32(false), this.cmbPackages.SelectedValue.ToInt32(false));
                    TaxBusiness taxBusiness = new TaxBusiness();
                    if (dataForIPContentTracking.Tables[0].Rows.Count <= 0)
                    {
                        this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
                        goto IL_139;
                    }
                    this.report.Load(ApplicationPath + "\\Reports\\IPContentTrackingReport.rpt");
                    dataTable = dataForIPContentTracking.Tables[0];
                    this.report.SetDataSource(dataTable);
                    this.SetDBLogonReports(this.report);
                }
                ActivityReport.ReportSource = dataTable;
                this.filename = "IP Content Tracking Report";
                this.report.Refresh();
            IL_139: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                do
                {
                    if (6 != 0)
                    {
                    }
                }
                while (2 == 0);
            }
        }

        private void ReportStorePaymentSummary(DateTime FromDt, DateTime ToDt, string ApplicationPath)
        {
            this.reportBusiness = new ReportBusiness();
            List<PaymentSummaryInfo> paymentSummary = this.reportBusiness.GetPaymentSummary(FromDt, ToDt, LoginUser.StoreName.ToString());
            int arg_5E_0;
            int arg_5A_0;
            int expr_49 = arg_5A_0 = (arg_5E_0 = paymentSummary.Count);
            if (-1 != 0)
            {
                if (5 == 0)
                {
                    goto IL_5E;
                }
                arg_5A_0 = ((expr_49 <= 0) ? 1 : 0);
            }
            bool flag = arg_5A_0 != 0;
            arg_5E_0 = (flag ? 1 : 0);
        IL_5E:
            if (arg_5E_0 == 0)
            {
                if (false)
                {
                    goto IL_C7;
                }
                this.report.Load(ApplicationPath + "\\Reports\\Payment.rpt");
                if (3 != 0)
                {
                    DataTable dataSource = this.DataTableFromIEnumerable(paymentSummary);
                    this.report.SetDataSource(dataSource);
                   // this.SetDBLogonReports(this.report);
                    ActivityReport.ReportSource = new ConfigBusiness().ParseListIntoPaymentDataTable(paymentSummary);
                }
            }
            else
            {
                this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
                if (!false)
                {
                    return;
                }
            }
        IL_B0:
            this.filename = "Payment Summary Report";
            this.report.Refresh();
        IL_C7:
            if (false)
            {
                goto IL_B0;
            }
        }

        private void ReportPrintLog(DateTime FromDt, DateTime ToDt, string ApplicationPath)
        {
            this.reportBusiness = new ReportBusiness();
            DateTime dateTime = FromDt;
            DateTime dateTime2 = ToDt;
            DataSet dataForPrintingLog = this.reportBusiness.GetDataForPrintingLog(dateTime, dateTime2, ((KeyValuePair<string, string>)this.cmbsubstore.SelectedItem).Key.ToInt32(false));
            DataSet dataForPrintingSummary = this.reportBusiness.GetDataForPrintingSummary(dateTime, dateTime2, ((KeyValuePair<string, string>)this.cmbsubstore.SelectedItem).Key.ToInt32(false));
            do
            {
                DataSet printSummaryDetail = this.reportBusiness.GetPrintSummaryDetail(dateTime, dateTime2, ((KeyValuePair<string, string>)this.cmbsubstore.SelectedItem).Key.ToInt32(false));
                if (dataForPrintingLog.Tables.Count <= 0)
                {
                    goto IL_1BC;
                }
                //  this.report.Load(ApplicationPath + "\\Reports\\PrintLogReport.rpt");
                this.report.Load(ApplicationPath + "\\Reports\\crptPrintLogReport1.rpt");
              //  TextObject textObject = (TextObject)this.report.ReportDefinition.Sections["Section2"].ReportObjects["txtDate"];
              //  textObject.Text = "From " + FromDt.ToString("dd MMM yyyy hh:mm tt") + " to  " + ToDt.ToString("dd MMM yyyy hh:mm tt");
                this.report.SetDataSource(dataForPrintingLog.Tables[0]);
               // this.report.Subreports[1].SetDataSource(dataForPrintingSummary.Tables[0]);
                this.report.Subreports[0].SetDataSource(printSummaryDetail.Tables[0]);
                
                this.filename = "Printing Report";
            }
            while (-1 == 0);
            return;
        IL_1BC:
            this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
        }

        private void ReportsOrderDiscount(DateTime FromDt, DateTime ToDt, DateTime FromDt1, DateTime ToDt1, string ApplicationPath)
        {
            DataSet orderDetailReport;
            if (!false)
            {
                bool value = this.chkChecked.IsChecked.Value;
                ReportBusiness reportBusiness = new ReportBusiness();
                orderDetailReport = reportBusiness.GetOrderDetailReport(FromDt, ToDt, LoginUser.UserName.ToString(), LoginUser.StoreName.ToString());
                if (orderDetailReport.Tables.Count <= 0 || orderDetailReport.Tables[0].Rows.Count <= 0)
                {
                    this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
                    return;
                }
                this.report.Load(ApplicationPath + "\\Reports\\OrderDiscountReport.rpt");
            }
            this.report.SetDataSource(orderDetailReport.Tables[0]);
            this.filename = "Order Detailed Report";
        }

        private void ReportOrderDiscount(DateTime FromDt, DateTime ToDt, DateTime FromDt1, DateTime ToDt1, string ApplicationPath)
        {
            DataSet orderDetailReport;
            bool expr_C4;
            while (true)
            {
                while (true)
                {
                    while (8 != 0)
                    {
                        bool value = this.chkChecked.IsChecked.Value;
                        if (-1 != 0)
                        {
                          //  this.report.Load(ApplicationPath + "\\Reports\\OrderDiscountReport.rpt");
                            this.report.Load(ApplicationPath + "\\Reports\\crptOrderDiscountReport.rpt");
                            ReportBusiness reportBusiness = new ReportBusiness();
                            if (2 != 0)
                            {
                                orderDetailReport = reportBusiness.GetOrderDetailReport(FromDt, ToDt, LoginUser.UserName.ToString(), LoginUser.StoreName.ToString());
                                bool arg_C2_0;
                                if (orderDetailReport.Tables.Count > 0)
                                {
                                    int arg_B6_0 = orderDetailReport.Tables[0].Rows.Count;
                                    int arg_B6_1 = 0;
                                    int expr_B6;
                                    int expr_B9;
                                    do
                                    {
                                        expr_B6 = (arg_B6_0 = ((arg_B6_0 > arg_B6_1) ? 1 : 0));
                                        expr_B9 = (arg_B6_1 = 0);
                                    }
                                    while (expr_B9 != 0);
                                    arg_C2_0 = (expr_B6 == expr_B9);
                                }
                                else
                                {
                                    arg_C2_0 = true;
                                }
                                bool flag = arg_C2_0;
                                bool arg_152_0;
                                expr_C4 = (arg_152_0 = flag);
                                if (8 != 0)
                                {
                                    goto Block_5;
                                }
                            }
                        }
                    }
                    goto IL_103;
                }
            }
        Block_5:
            if (expr_C4)
            {
                goto IL_103;
            }
            this.report.SetDataSource(orderDetailReport.Tables[0]);
        IL_E7:
            this.SetDBLogonForSubreports(this.report);
            this.filename = "Order Detailed Report";
            return;
        IL_103:
            this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
            if (6 == 0)
            {
                goto IL_E7;
            }
        }

        private void ReportFinancialaudit(DateTime FromDt, DateTime ToDt, string ApplicationPath)
        {
            bool arg_36_0 = this.chkChecked.IsChecked.Value;
            ReportBusiness reportBusiness = new ReportBusiness();
            DataSet financialAuditData = reportBusiness.GetFinancialAuditData(LoginUser.UserName.ToString(), LoginUser.StoreName.ToString(), FromDt, ToDt, ((KeyValuePair<string, string>)this.cmbsubstore.SelectedItem).Key.ToInt32(false));
            TaxBusiness taxBusiness = new TaxBusiness();
            List<TaxDetailInfo> reportTaxDetail = taxBusiness.GetReportTaxDetail(FromDt, ToDt, ((KeyValuePair<string, string>)this.cmbsubstore.SelectedItem).Key.ToInt32(false));
            if (financialAuditData.Tables.Count > 0 && financialAuditData.Tables[0].Rows.Count > 0)
            {
                //this.report.Load(ApplicationPath + "\\Reports\\Financialauditreport.rpt");
                this.report.Load(ApplicationPath + "\\Reports\\crptFinancialauditreport.rpt");
               // TextObject textObject = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["txtDate"];
              //  textObject.Text = "From " + FromDt.ToString("dd MMM yyyy hh:mm tt") + " to  " + ToDt.ToString("dd MMM yyyy hh:mm tt");
                this.report.SetDataSource(financialAuditData.Tables[0]);
               // this.SetDBLogonForSubreports(this.report);
                this.filename = "Financial Audit Report";
            }
            else
            {
                this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
            }
        }

        private void ReportPhotoGrapherPerformance(DateTime FromDt, DateTime ToDt, DateTime FromDt1, DateTime ToDt1, string ApplicationPath)
        {
            if (!true)
            {
            }
            int arg_C6_0;
            DataSet photographerPerformanceReports;
            if ((arg_C6_0 = 0) == 0)
            {
                bool value = this.chkChecked.IsChecked.Value;
               // this.report.Load(ApplicationPath + "\\Reports\\PhotoGrapherPerformanceReport.rpt");
                this.report.Load(ApplicationPath + "\\Reports\\crptPhotoGrapherPerformanceReport.rpt");
                ReportBusiness reportBusiness = new ReportBusiness();
                photographerPerformanceReports = reportBusiness.GetPhotographerPerformanceReports(FromDt, ToDt, FromDt1, ToDt1, LoginUser.StoreName.ToString(), LoginUser.UserName.ToString(), value);
                int arg_9C_0 = photographerPerformanceReports.Tables.Count;
                int arg_9C_1 = 0;
                bool arg_C2_0;
                while (arg_9C_0 > arg_9C_1)
                {
                    int expr_B0 = arg_9C_0 = photographerPerformanceReports.Tables[0].Rows.Count;
                    int expr_B6 = arg_9C_1 = 0;
                    if (expr_B6 == 0)
                    {
                        arg_C2_0 = (expr_B0 <= expr_B6);
                    IL_C1:
                        bool flag = arg_C2_0;
                        arg_C6_0 = (flag ? 1 : 0);
                        goto IL_C6;
                    }
                }
                arg_C2_0 = true;
                //goto IL_C1;
            }
        IL_C6:
            if (arg_C6_0 == 0)
            {
               // this.report.SetDataSource(photographerPerformanceReports.Tables[0]);
                this.filename = "Photographer Performance Report";
            }
            else
            {
                this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
            }
        }

        private void ReportLocationPerformance(DateTime FromDt, DateTime ToDt, DateTime FromDt1, DateTime ToDt1, string ApplicationPath)
        {
            if (4 == 0)
            {
            }
            while (true)
            {
            IL_31:
                bool? isChecked = this.chkChecked.IsChecked;
                while (true)
                {
                    bool value = isChecked.Value;
                    ReportBusiness reportBusiness = new ReportBusiness();
                    DataSet locationPerformanceReports = reportBusiness.GetLocationPerformanceReports(FromDt, ToDt, FromDt1, ToDt1, LoginUser.StoreName.ToString(), LoginUser.UserName.ToString(), value, (this.cmbsubstore.SelectedIndex > 0) ? this.cmbsubstore.SelectedValue.ToString() : string.Empty, ((KeyValuePair<string, string>)this.cmbsubstore.SelectedItem).Key.ToInt32(false));
                    while (true)
                    {
                        TaxBusiness taxBusiness = new TaxBusiness();
                        List<TaxDetailInfo> reportTaxDetail = taxBusiness.GetReportTaxDetail(FromDt, ToDt, ((KeyValuePair<string, string>)this.cmbsubstore.SelectedItem).Key.ToInt32(false));
                        if (locationPerformanceReports.Tables.Count > 0 && locationPerformanceReports.Tables[0].Rows.Count > 0)
                        {
                            goto IL_123;
                        }
                        if (false)
                        {
                            goto IL_31;
                        }
                        if (4 != 0)
                        {
                            this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
                            goto IL_280;
                        }
                        goto IL_123;
                    IL_22D:
                       // this.report.Subreports[0].SetDataSource(reportTaxDetail);
                        this.filename = "Site Performance Report";
                        if (!false)
                        {
                            goto IL_280;
                        }
                        continue;
                    IL_1E8:
                        if (4 != 0)
                        {
                            goto IL_22D;
                        }
                        goto IL_1EE;
                    IL_1CB:
                        goto IL_1E8;
                    IL_123:
                        DataTable source = locationPerformanceReports.Tables[0];
                       // this.report.Load(ApplicationPath + "\\Reports\\LocationPerformance.rpt");
                        this.report.Load(ApplicationPath + "\\Reports\\crptLocationPerformance.rpt");
                        if (this.cmbsubstore.SelectedIndex > 0)
                        {
                            
                            IEnumerable<DataRow> source2 = source.AsEnumerable().Where(delegate(DataRow sd)
                            {
                                if (false)
                                {
                                    goto IL_21;
                                }
                                bool arg_28_0;
                                bool arg_4B_0 = arg_28_0 = (sd.Field<string>("DG_SubStore_Name") == this.cmbsubstore.SelectedValue.ToString());
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
                            });
                            if (source2.Count<DataRow>() <= 0)
                            {
                                this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
                                goto IL_1E8;
                            }
                            DataTable dataTable = source2.CopyToDataTable<DataRow>();
                            if (2 != 0)
                            {
                                ActivityReport.ReportSource = new ConfigBusiness().CreateReportData(dataTable, PhotoSW.DataLayer. ReportTypes.SitePerformanceReport);
                                this.report.SetDataSource(dataTable);
                                goto IL_1CB;
                            }
                            goto IL_1CB;
                        }
                    IL_1EE:
                        this.report.SetDataSource(locationPerformanceReports.Tables[0]);
                   // ActivityReport.ReportSource = new ConfigBusiness().CreateReportData(locationPerformanceReports.Tables[0], PhotoSW.DataLayer.ReportTypes.SitePerformanceReport);
                        if (-1 != 0)
                        {
                            goto IL_22D;
                        }
                        break;
                    IL_280:
                        if (2 != 0)
                        {
                            return;
                        }
                        goto IL_1CB;
                    }
                }
            }
        }

        private void ReportOperationAudit(DateTime FromDt, DateTime ToDt, string ApplicationPath)
        {
            ReportBusiness reportBusiness = new ReportBusiness();
            DataSet auditTrail;
            bool arg_80_0;
            if (-1 != 0)
            {
                auditTrail = reportBusiness.GetAuditTrail(FromDt, ToDt, ((KeyValuePair<string, string>)this.cmbsubstore.SelectedItem).Key.ToInt32(false));
                if (!true)
                {
                    return;
                }
                if (auditTrail.Tables.Count <= 0 && !false)
                {
                    arg_80_0 = true;
                    goto IL_7F;
                }
            }
            arg_80_0 = (auditTrail.Tables[0].Rows.Count <= 0);
        IL_7F:
            if (!arg_80_0)
            {
                do
                {
                    if (!false)
                    {
                        this.report.Load(ApplicationPath + "\\Reports\\OperationAuditTrail.rpt");
                        TextObject textObject = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["txtDate"];
                        textObject.Text = "From " + FromDt.ToString("dd MMM yyyy hh:mm tt") + " to  " + ToDt.ToString("dd MMM yyyy hh:mm tt");
                    }
                    this.report.SetDataSource(auditTrail.Tables[0]);
                    this.filename = "Operation Audit Trail Report";
                }
                while (false);
            }
            else
            {
                this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
            }
        }

        private void ReportTaking(bool IsFromDate, bool IsToDate, DateTime FromDt, DateTime ToDt, string ApplicationPath)
        {
            ReportBusiness reportBusiness = new ReportBusiness();
            DataSet takingReport = reportBusiness.GetTakingReport(IsFromDate, IsToDate, new DateTime?(FromDt), new DateTime?(ToDt), Convert.ToInt32(this.cmbPhotographer.SelectedValue), ((KeyValuePair<string, string>)this.cmbsubstore.SelectedItem).Key.ToInt32(false));
            bool arg_97_0;
            if (takingReport != null && takingReport.Tables.Count > 0)
            {
                int arg_8B_0 = takingReport.Tables[0].Rows.Count;
                do
                {
                    arg_97_0 = ((arg_8B_0 = ((arg_8B_0 <= 0) ? 1 : 0)) != 0);
                }
                while (false);
            }
            else
            {
                arg_97_0 = true;
            }
            if (!arg_97_0)
            {
                DataTable dataTable = takingReport.Tables[0];
                dataTable.Columns.Add(new DataColumn("StoreName"));
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    dataRow["StoreName"] = LoginUser.StoreName;
                }
                //this.report.Load(ApplicationPath + "\\Reports\\TakingReports.rpt");
                this.report.Load(ApplicationPath + "\\Reports\\crptTakingReports.rpt");
               // TextObject textObject = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["txtDate"];
              //  textObject.Text = "From " + FromDt.ToString("dd MMM yyyy hh:mm tt") + " to  " + ToDt.ToString("dd MMM yyyy hh:mm tt");
                this.report.SetDataSource(dataTable);
              //  ActivityReport.ReportSource = new ConfigBusiness().CreateReportData(dataTable, PhotoSW.DataLayer.ReportTypes.TakingReport);
              //  this.SetDBLogonForSubreports(this.report);
                this.filename = "Taking Report ";
            }
            else
            {
                this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
            }
        }

        private void ReportOperatorPerformance(DateTime FromDt, DateTime ToDt, DateTime FromDt1, DateTime ToDt1, string ApplicationPath)
        {
            DataSet operatorReports;
            if (!false)
            {
                if (8 == 0)
                {
                    goto IL_DC;
                }
                if (false)
                {
                    goto IL_F6;
                }
                if (false)
                {
                    return;
                }
                bool value = this.chkChecked.IsChecked.Value;
                ReportBusiness reportBusiness = new ReportBusiness();
                operatorReports = reportBusiness.GetOperatorReports(3, FromDt, ToDt, FromDt1, ToDt1, LoginUser.StoreName.ToString(), LoginUser.UserName.ToString(), value);
            }
            bool arg_BB_0;
            if (operatorReports.Tables.Count > 0)
            {
                arg_BB_0 = (operatorReports.Tables[0].Rows.Count <= 0);
            }
            else
            {
                if (-1 == 0)
                {
                    goto IL_104;
                }
                arg_BB_0 = true;
            }
            bool flag = arg_BB_0;
            if (-1 == 0)
            {
                goto IL_11C;
            }
            if (!flag)
            {
                //this.report.Load(ApplicationPath + "\\Reports\\OperatorPerformanceReport.rpt");
                this.report.Load(ApplicationPath + "\\Reports\\crptOperatorPerformanceReport.rpt");
                goto IL_DC;
            }
        IL_104:
            this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
        IL_11C:
            return;
        IL_DC:
            this.report.SetDataSource(operatorReports.Tables[0]);
        IL_F6:
            this.filename = "Operator Performance Report";
        }

        private void ReportProductSummary(DateTime FromDt, DateTime ToDt, string ApplicationPath)
        {
            
            bool flag = false;
            //this.report.Load(ApplicationPath + "\\Reports\\ProductSummary.rpt");
            this.report.Load(ApplicationPath + "\\Reports\\crptProductSummary.rpt");
            ProductBusiness productBusiness = new ProductBusiness();
            DataSet productSummary = productBusiness.GetProductSummary(FromDt, ToDt, LoginUser.StoreName.ToString(), LoginUser.UserName.ToString(), ((KeyValuePair<string, string>)this.cmbsubstore.SelectedItem).Key.ToInt32(false));
            List<TaxDetailInfo> reportTaxDetail;
            bool flag2;
            do
            {
                TaxBusiness taxBusiness = new TaxBusiness();
                reportTaxDetail = taxBusiness.GetReportTaxDetail(FromDt, ToDt, ((KeyValuePair<string, string>)this.cmbsubstore.SelectedItem).Key.ToInt32(false));
                int arg_FC_0;
                int expr_AB = arg_FC_0 = productSummary.Tables.Count;
                int arg_FC_1;
                int expr_B1 = arg_FC_1 = 0;
                if (expr_B1 == 0)
                {
                    if (expr_AB <= expr_B1 || productSummary.Tables[0].Rows.Count <= 0)
                    {
                        goto IL_216;
                    }
                    ReportParams reportParams = new ReportBusiness().FetchReportFormatDetails(1);
                    arg_FC_0 = ((this.cmbsubstore.SelectedIndex > 0) ? 1 : 0);
                    arg_FC_1 = 0;
                }
                bool arg_FE_0 = arg_FC_0 == arg_FC_1;
                bool expr_106;
                do
                {
                    flag2 = arg_FE_0;
                    if (6 == 0)
                    {
                        goto IL_214;
                    }
                    expr_106 = (arg_FE_0 = flag2);
                }
                while (false);
                if (!expr_106)
                {
                    DataTable source = productSummary.Tables[0];
                    IEnumerable<DataRow> source2 = source.AsEnumerable().Where(delegate(DataRow product)
                    {
                        if (false)
                        {
                            goto IL_21;
                        }
                        bool arg_28_0;
                        bool arg_4B_0 = arg_28_0 = (product.Field<string>("PS_SubStore_Name") == this.cmbsubstore.SelectedValue.ToString());
                    IL_19:
                        if (7 == 0 || 8 == 0)
                        {
                            goto IL_25;
                        }
                        bool flag3 = arg_4B_0;
                    IL_21:
                        arg_4B_0 = (arg_28_0 = flag3);
                    IL_25:
                        if (!false)
                        {
                            return arg_28_0;
                        }
                        goto IL_19;
                    });
                    flag2 = (source2.Count<DataRow>() <= 0);
                    if (!flag2)
                    {
                        if (false)
                        {
                            goto IL_1EB;
                        }
                        DataTable dataTable = source2.CopyToDataTable<DataRow>();
                        ActivityReport.ReportSource = new ConfigBusiness().CreateReportData(dataTable, PhotoSW.DataLayer.ReportTypes.ProductionSummaryReport);
                        this.report.SetDataSource(dataTable);
                       // this.report.SetDataSource(source);
                    }
                    else
                    {
                        flag = true;
                        this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
                    }
                }
                else
                {
                    this.report.SetDataSource(productSummary.Tables[0]);
                    if (6 == 0)
                    {
                        return;
                    }
                    ActivityReport.ReportSource = new ConfigBusiness().CreateReportData(productSummary.Tables[0], PhotoSW.DataLayer.ReportTypes.ProductionSummaryReport);
                }
            }
            while (2 == 0);
            flag2 = flag;
        IL_1EB:
            if (!flag2)
            {
                this.report.Subreports[0].SetDataSource(reportTaxDetail);
            }
            this.filename = "Product Summary Report";
        IL_214:
            return;
        IL_216:
            if (!false)
            {
                this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
            }
        }

        private void ReportActivity(bool IsFromDate, bool IsToDate, DateTime FromDt, DateTime ToDt, string ApplicationPath)
        {
            while (true)
            {
                new AuditLog();
                if (5 != 0)
                {
                    ActivityBusiness activityBusiness = new ActivityBusiness();
                    new DataSet();
                    DataSet activityReport = activityBusiness.GetActivityReport(new DateTime?(FromDt), new DateTime?(ToDt), new int?(this.cmbPhotographer.SelectedValue.ToInt32(false)));
                    int arg_7F_0;
                    int arg_82_0;
                    if (activityReport.Tables.Count > 0)
                    {
                        arg_82_0 = (arg_7F_0 = activityReport.Tables[0].Rows.Count);
                        goto IL_7B;
                    }
                    bool arg_8B_0 = true;
                IL_87:
                    if (!false)
                    {
                    }
                    bool flag = arg_8B_0;
                    bool expr_8C = (arg_7F_0 = (arg_82_0 = (flag ? 1 : 0))) != 0;
                    if (true)
                    {
                        if (!expr_8C)
                        {
                          //  this.report.Load(ApplicationPath + "\\Reports\\ActivityReports.rpt");
                            this.report.Load(ApplicationPath + "\\Reports\\crptActivityReport.rpt");
                            this.report.SetDataSource(activityReport.Tables[0]);
                           // this.report.Database.Tables["dtActivity"].SetDataSource(activityReport.Tables[0]);
                            goto IL_C2;
                        }
                        this.report.Load(ApplicationPath + "\\Reports\\Temp.rpt");
                        goto IL_100;
                    }
                IL_7B:
                    int arg_82_1;
                    int expr_7C = arg_82_1 = 0;
                    if (expr_7C == 0)
                    {
                        arg_82_0 = ((arg_7F_0 > expr_7C) ? 1 : 0);
                        arg_82_1 = 0;
                    }
                    arg_8B_0 = (arg_82_0 == arg_82_1);
                    goto IL_87;
                }
                goto IL_C3;
            IL_100:
                if (!false)
                {
                    break;
                }
                continue;
            IL_C3:
                this.report.ReportOptions.EnableSaveDataWithReport = true;
                this.filename = "Activity Report";
                if (-1 != 0)
                {
                    goto IL_100;
                }
            IL_C2:
                goto IL_C3;
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.dlg.FileName = this.filename;
                this.dlg.DefaultExt = ".xls";
                string fileName = "";
                if (5 != 0)
                {
                    this.dlg.Filter = "Excel documents (.xls)|*.xls";
                    bool flag = this.IsEnabledExportToAnyDrive();
                    bool arg_5A_0 = flag;
                    bool expr_12A;
                    while (true)
                    {
                        if (!arg_5A_0)
                        {
                            this.dlg.FileOk += new CancelEventHandler(this.dlg_FileOk);
                            DriveInfo driveInfo = DriveInfo.GetDrives().Where(delegate(DriveInfo drive)
                            {
                                bool result;
                                while (8 != 0)
                                {
                                    bool arg_36_0;
                                    if (drive.DriveType == DriveType.Removable)
                                    {
                                        arg_36_0 = drive.IsReady;
                                        if (2 != 0)
                                        {
                                        }
                                    }
                                    else
                                    {
                                        if (5 == 0 || false)
                                        {
                                            continue;
                                        }
                                        arg_36_0 = false;
                                    }
                                    result = arg_36_0;
                                    break;
                                }
                                return result;
                            }).FirstOrDefault<DriveInfo>();
                            if (driveInfo == null)
                            {
                                break;
                            }
                            this.dlg.InitialDirectory = driveInfo.Name;
                        }
                        if (!(this.dlg.ShowDialog() == true))
                        {
                            goto IL_171;
                        }
                         fileName = this.dlg.FileName;
                        expr_12A = (arg_5A_0 = !(this.cmbReportType.SelectedValue.ToString() == "11"));
                        if (4 != 0)
                        {
                            goto Block_9;
                        }
                    }
                    System.Windows.MessageBox.Show("No removable device found.");
                    return;
                Block_9:
                    if (!expr_12A)
                    {
                        if (this.dtDataToExport != null)
                        {
                            //string fileName;
                            ActivityReport.ExportToExcel(this.dtDataToExport, fileName + "x");
                        }
                    }
                    else
                    {
                       // string fileName;
                        this.report.ExportToDisk(ExportFormatType.Excel, fileName);
                    }
                }
            IL_171: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            finally
            {
                this.dlg.FileOk -= new CancelEventHandler(this.dlg_FileOk);
            }
        }

        private void ExportToCSV(string filePath)
        {
            StreamWriter streamWriter;
            while (true)
            {
            IL_01:
                while (this.gridReport.HasItems)
                {
                    if (!false)
                    {
                        this.gridReport.SelectAllCells();
                        this.gridReport.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                        while (true)
                        {
                            ApplicationCommands.Copy.Execute(null, this.gridReport);
                            while (true)
                            {
                                this.gridReport.UnselectAllCells();
                                string value = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                                streamWriter = new StreamWriter(filePath);
                                streamWriter.WriteLine(value);
                                if (false)
                                {
                                    goto IL_01;
                                }
                                if (5 == 0)
                                {
                                    break;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                }
                return;
            }
        Block_4:
            if (7 != 0)
            {
                streamWriter.Close();
            }
        }

        public static void ExportToExcel(DataTable dt, string filePath)
        {
            int num = 2;
            XLWorkbook expr_226 = new XLWorkbook();
            XLWorkbook xLWorkbook;
            if (!false)
            {
                xLWorkbook = expr_226;
            }
            IXLWorksheet iXLWorksheet = xLWorkbook.Worksheets.Add("Sheet 1");
            int num2 = 1;
            foreach (DataColumn dataColumn in dt.Columns)
            {
                iXLWorksheet.Cell(1, num2).Value = dataColumn.ToString();
                IXLRange iXLRange = iXLWorksheet.Range(iXLWorksheet.Cell(1, num2).Address, iXLWorksheet.Cell(1, dt.Columns.Count).Address);
                iXLRange.Style.Font.Bold = true;
                iXLRange.Style.Font.FontSize = 10.0;
                num2++;
            }
            foreach (DataRow dataRow in dt.Rows)
            {
                if (4 != 0)
                {
                    int num3 = 1;
                    foreach (DataColumn dataColumn in dt.Columns)
                    {
                        string value = dataRow[dataColumn].ToString();
                        iXLWorksheet.Cell(num, num3).SetValue<string>(value);
                        num3++;
                    }
                    num++;
                }
            }
            if (File.Exists(filePath))
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("'" + filePath + "' already exists.\nDo you want to replace it?", "Save As", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    xLWorkbook.SaveAs(filePath);
                }
            }
            else
            {
                xLWorkbook.SaveAs(filePath);
            }
        }

        private void ExportToPDF(DataTable dt, string filePath)
        {
            Font expr_322 = FontFactory.GetFont("Arial", 9f, 1, Color.BLACK);
            Font font;
            if (!false)
            {
                font = expr_322;
            }
            font.IsBold();
            Font font2 = FontFactory.GetFont("Arial", 8f, Color.BLACK);
            Document document = new Document(PageSize.A4);
            PdfWriter instance = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create, FileAccess.Write));
            document.Open();
            iTextSharp.text.Image image = null;
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DEILogo.jpg");
            if (File.Exists(path))
            {
                image = iTextSharp.text.Image.GetInstance(path);
                image.SpacingAfter = 20f;
            }
            Paragraph paragraph = new Paragraph(string.Concat(new object[]
			{
				"For the Period ",
				this.FromDt,
				" to ",
				this.ToDt
			}), FontFactory.GetFont("Arial", 9f, Color.BLACK));
            paragraph.SpacingAfter = 20f;
            Paragraph element = new Paragraph(LoginUser.SubstoreName + " - IP PRINT TRACKING REPORT", FontFactory.GetFont("Arial", 12f, 1, Color.BLACK));
            int num = 6;
            int num2 = 0;
            int num3 = num;
            int num4 = 0;
            int num5 = 1;
            while (true)
            {
                int arg_165_0;
                int expr_306 = arg_165_0 = ((num5 > dt.Columns.Count) ? 1 : 0);
                int arg_165_1;
                int expr_309 = arg_165_1 = 0;
                if (expr_309 == 0)
                {
                    if (expr_306 != expr_309)
                    {
                        break;
                    }
                    arg_165_0 = num3;
                    arg_165_1 = dt.Columns.Count;
                }
                if (arg_165_0 > arg_165_1)
                {
                    num3 = dt.Columns.Count;
                }
                PdfPTable pdfPTable = new PdfPTable(num3 - num2);
                document.NewPage();
                if (image != null)
                {
                    document.Add(image);
                }
                document.Add(element);
                document.Add(paragraph);
                pdfPTable.WidthPercentage = 100f;
                int i = num2;
                int arg_2ED_0;
                int arg_2ED_1;
                while (true)
                {
                    int expr_207 = arg_2ED_0 = i;
                    int expr_209 = arg_2ED_1 = num3;
                    if (false)
                    {
                        goto IL_2ED;
                    }
                    if (expr_207 >= expr_209)
                    {
                        goto Block_5;
                    }
                    pdfPTable.AddCell(new PdfPCell(new Phrase(dt.Columns[i].ToString(), font))
                    {
                        BackgroundColor = Color.LIGHT_GRAY
                    });
                    i++;
                }
            IL_2F1:
                num5 += num;
                continue;
            Block_5:
                foreach (DataRow dataRow in dt.Rows)
                {
                    for (i = num2; i < num3; i++)
                    {
                        string str = dataRow[i].ToString();
                        PdfPCell cell = new PdfPCell(new Phrase(str, font2));
                        pdfPTable.AddCell(cell);
                    }
                }
                num4 += num;
                if (num4 > dt.Columns.Count)
                {
                    num4 = num3;
                }
                if (num4 != num3)
                {
                    goto IL_2F1;
                }
                document.Add(pdfPTable);
                num2 = num4;
                arg_2ED_0 = num3;
                arg_2ED_1 = num;
            IL_2ED:
                num3 = arg_2ED_0 + arg_2ED_1;
                goto IL_2F1;
            }
            document.Close();
        }

        private void btnExporttopdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.dlg.FileName = this.filename;
                this.dlg.DefaultExt = ".pdf";
                this.dlg.Filter = "Pdf documents (.pdf)|*.pdf";
                DriveInfo driveInfo;
                if (3 != 0)
                {
                    if (this.IsEnabledExportToAnyDrive())
                    {
                        goto IL_D6;
                    }
                    this.dlg.FileOk += new CancelEventHandler(this.dlg_FileOk);
                    driveInfo = DriveInfo.GetDrives().Where(delegate(DriveInfo drive)
                    {
                        bool result;
                        while (8 != 0)
                        {
                            bool arg_36_0;
                            if (drive.DriveType == DriveType.Removable)
                            {
                                arg_36_0 = drive.IsReady;
                                if (2 != 0)
                                {
                                }
                            }
                            else
                            {
                                if (5 == 0 || false)
                                {
                                    continue;
                                }
                                arg_36_0 = false;
                            }
                            result = arg_36_0;
                            break;
                        }
                        return result;
                    }).FirstOrDefault<DriveInfo>();
                    if (driveInfo == null)
                    {
                        System.Windows.MessageBox.Show("No removable device found.");
                        return;
                    }
                }
            IL_AB:
            IL_AC:
                if (6 == 0)
                {
                    goto IL_AB;
                }
                this.dlg.InitialDirectory = driveInfo.Name;
            IL_D6:
                bool? flag = this.dlg.ShowDialog();
                bool? flag2 = flag;
                int arg_FD_0;
                bool arg_106_0 = ((!flag2.GetValueOrDefault()) ? (arg_FD_0 = 0) : (arg_FD_0 = (flag2.HasValue ? 1 : 0))) != 0;
                if (!false)
                {
                    bool flag3 = arg_FD_0 == 0;
                    if (false)
                    {
                        goto IL_AC;
                    }
                    arg_106_0 = flag3;
                }
                if (!arg_106_0)
                {
                    string fileName = this.dlg.FileName;
                    bool flag3 = !(this.cmbReportType.SelectedValue.ToString() == "11");
                    bool arg_14C_0;
                    if (!false)
                    {
                        if (flag3)
                        {
                            this.report.ExportToDisk(ExportFormatType.PortableDocFormat, fileName);
                            goto IL_16F;
                        }
                        bool expr_143 = arg_14C_0 = (this.dtDataToExport == null);
                        if (false)
                        {
                            goto IL_14C;
                        }
                        flag3 = expr_143;
                    }
                    arg_14C_0 = flag3;
                IL_14C:
                    if (!arg_14C_0)
                    {
                        this.ExportToPDF(this.dtDataToExport, fileName);
                    }
                IL_16F: ;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                do
                {
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (4 == 0);
            }
            finally
            {
                this.dlg.FileOk -= new CancelEventHandler(this.dlg_FileOk);
            }
        }

        private bool IsEnabledExportToAnyDrive()
        {
            bool flag = false;
            ConfigurationInfo configurationData = new ConfigBusiness().GetConfigurationData(LoginUser.SubStoreId);
            bool arg_5C_0;
            bool arg_1B_0;
            bool arg_34_0 = arg_1B_0 = (arg_5C_0 = (configurationData == null));
            while (true)
            {
                if (false)
                {
                    goto IL_31;
                }
                bool flag2 = arg_5C_0;
                arg_34_0 = (arg_1B_0 = (arg_5C_0 = flag2));
            IL_18:
                if (false)
                {
                    continue;
                }
                if (arg_1B_0 || false)
                {
                    goto IL_35;
                }
                arg_34_0 = (arg_1B_0 = (arg_5C_0 = Convert.ToBoolean(configurationData.IsExportReportToAnyDrive)));
            IL_31:
                if (4 != 0)
                {
                    break;
                }
                goto IL_18;
            }
            flag = arg_34_0;
        IL_35:
            bool result;
            if (!false)
            {
                result = flag;
            }
            return result;
        }

        private void dlg_FileOk(object sender, CancelEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(this.dlg.FileName);
            string text = fileInfo.Directory.Root.ToString();
            int arg_55_0;
            int expr_34 = arg_55_0 = text.Length;
            int arg_55_1;
            int expr_3A = arg_55_1 = 0;
            bool arg_5B_0;
            if (expr_3A == 0)
            {
                arg_55_1 = expr_3A;
                if (expr_3A == 0)
                {
                    if (expr_34 <= expr_3A)
                    {
                        arg_5B_0 = true;
                        goto IL_5A;
                    }
                    arg_55_0 = ((text.Substring(0, 1) == "\\") ? 1 : 0);
                    arg_55_1 = 0;
                }
            }
            arg_5B_0 = (arg_55_0 == arg_55_1);
        IL_5A:
            if (!arg_5B_0)
            {
                System.Windows.MessageBox.Show("You can save to removable device only.");
                e.Cancel = true;
                if (!false)
                {
                    return;
                }
            }
            else
            {
                DriveInfo driveInfo = new DriveInfo(text);
                if (driveInfo.DriveType == DriveType.Removable)
                {
                    return;
                }
            }
            System.Windows.MessageBox.Show("You can save to removable device only.");
            e.Cancel = true;
        }

        private void cmbReportType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (this.cmbReportType.SelectedIndex > -1)
                {
                    try
                    {
                        KeyValuePair<string, string> selectedItem = (KeyValuePair<string, string>)this.cmbReportType.SelectedItem;
                        ReportTypeDetails reportTypeDetails = this.ReportTypeDetail.SingleOrDefault();
                        //ReportTypeDetails reportTypeDetails = this.ReportTypeDetail.SingleOrDefault(delegate(ReportTypeDetails rpt)
                        //{
                        //    bool arg_38_0;
                        //    bool arg_34_0;
                        //    while (true)
                        //    {
                        //    IL_00:
                        //        bool arg_1C_0 = rpt.ReportLabel.Trim().ToLower().Equals(selectedItem.Key.ToString().Trim().ToLower());
                        //        while (arg_1C_0)
                        //        {
                        //            if (7 == 0)
                        //            {
                        //                goto IL_00;
                        //            }
                        //            arg_34_0 = (arg_1C_0 = (arg_38_0 = rpt.IsActive));
                        //            if (false || false)
                        //            {
                        //                return arg_38_0;
                        //            }
                        //            if (-1 != 0)
                        //            {
                        //                goto Block_4;
                        //            }
                        //        }
                        //        goto IL_32;
                        //    }
                        //Block_4:
                        //    goto IL_33;
                        //IL_32:
                        //    arg_34_0 = false;
                        //IL_33:
                        //    bool flag = arg_34_0;
                        //    arg_38_0 = flag;
                        //    return arg_38_0;
                        //});
                        if (reportTypeDetails != null)
                        {
                            this.btnExportToCSV.Visibility = (this.rdbtnCSV.Visibility = Visibility.Visible);
                        }
                        else
                        {
                            this.btnExportToCSV.Visibility = (this.rdbtnCSV.Visibility = Visibility.Collapsed);
                        }
                    }
                    catch (Exception serviceException)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                }
                if (this.cmbReportType.SelectedValue != null)
                {
                    if (!(this.cmbReportType.SelectedValue.ToString() == "11"))
                    {
                        this.ActivityReportviewer.Visibility = Visibility.Visible;
                        this.gridReport.Visibility = Visibility.Collapsed;
                        this.txtPackages.Visibility = Visibility.Collapsed;
                        goto IL_1A5;
                    }
                    this.ActivityReportviewer.Visibility = Visibility.Collapsed;
                    bool arg_14B_0 = this.gridReport.Items.Count > 0;
                    int arg_14B_1 = 0;
                IL_14B:
                    if ((arg_14B_0 ? 1 : 0) != arg_14B_1)
                    {
                        this.gridReport.Visibility = Visibility.Visible;
                    }
                    this.txtPackages.Visibility = Visibility.Visible;
                    this.cmbPackages.Visibility = Visibility.Visible;
                    goto IL_1B3;
                IL_1A5:
                    this.cmbPackages.Visibility = Visibility.Collapsed;
                IL_1B3:
                    if (this.cmbReportType.SelectedValue.ToString() == "0")
                    {
                        this.cmbPhotographer.Visibility = Visibility.Visible;
                        this.txtuser.Visibility = Visibility.Visible;
                        this.cmbLocation.Visibility = Visibility.Collapsed;
                        this.txtlocation.Visibility = Visibility.Collapsed;
                        this.chkChecked.Visibility = Visibility.Collapsed;
                        this.dtFrom1.Visibility = Visibility.Collapsed;
                        this.dtTo1.Visibility = Visibility.Collapsed;
                        this.from1.Visibility = Visibility.Collapsed;
                        this.to1.Visibility = Visibility.Collapsed;
                        this.txtlocation.Visibility = Visibility.Collapsed;
                        this.cmbsubstore.Visibility = Visibility.Collapsed;
                        this.txtsubstore.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        int expr_291 = (arg_14B_0 = (this.cmbReportType.SelectedValue.ToString() == "2")) ? 1 : 0;
                        int expr_297 = arg_14B_1 = 0;
                        if (expr_297 != 0)
                        {
                            goto IL_14B;
                        }
                        if (expr_291 != expr_297)
                        {
                            if (!false)
                            {
                                this.cmbPhotographer.Visibility = Visibility.Visible;
                                this.txtuser.Visibility = Visibility.Collapsed;
                                this.cmbPhotographer.Visibility = Visibility.Collapsed;
                                this.cmbLocation.Visibility = Visibility.Collapsed;
                                this.chkChecked.Visibility = Visibility.Visible;
                                this.dtFrom1.Visibility = Visibility.Visible;
                                this.dtTo1.Visibility = Visibility.Visible;
                                this.from1.Visibility = Visibility.Visible;
                                this.to1.Visibility = Visibility.Visible;
                                this.cmbsubstore.Visibility = Visibility.Collapsed;
                                this.txtsubstore.Visibility = Visibility.Collapsed;
                                goto IL_D26;
                            }
                        }
                        else
                        {
                            if (this.cmbReportType.SelectedValue.ToString() == "7")
                            {
                                this.cmbPhotographer.Visibility = Visibility.Collapsed;
                                this.txtuser.Visibility = Visibility.Collapsed;
                                this.cmbLocation.Visibility = Visibility.Collapsed;
                                this.txtlocation.Visibility = Visibility.Collapsed;
                                this.chkChecked.Visibility = Visibility.Collapsed;
                                this.dtFrom1.Visibility = Visibility.Collapsed;
                                this.dtTo1.Visibility = Visibility.Collapsed;
                                this.from1.Visibility = Visibility.Collapsed;
                                this.to1.Visibility = Visibility.Collapsed;
                                this.txtlocation.Visibility = Visibility.Collapsed;
                                this.cmbsubstore.Visibility = Visibility.Visible;
                                this.txtsubstore.Visibility = Visibility.Visible;
                                goto IL_D26;
                            }
                            if (this.cmbReportType.SelectedValue.ToString() == "5")
                            {
                                this.cmbPhotographer.Visibility = Visibility.Visible;
                                this.txtuser.Visibility = Visibility.Collapsed;
                                this.cmbPhotographer.Visibility = Visibility.Collapsed;
                                this.cmbLocation.Visibility = Visibility.Collapsed;
                                this.dtFrom1.Visibility = Visibility.Visible;
                                this.chkChecked.Visibility = Visibility.Visible;
                                this.dtTo1.Visibility = Visibility.Visible;
                                this.from1.Visibility = Visibility.Visible;
                                this.to1.Visibility = Visibility.Visible;
                                this.cmbsubstore.Visibility = Visibility.Collapsed;
                                this.txtsubstore.Visibility = Visibility.Collapsed;
                                goto IL_D26;
                            }
                            if (this.cmbReportType.SelectedValue.ToString() == "6")
                            {
                                this.cmbPhotographer.Visibility = Visibility.Visible;
                                this.txtuser.Visibility = Visibility.Collapsed;
                                this.chkChecked.Visibility = Visibility.Visible;
                                this.cmbPhotographer.Visibility = Visibility.Collapsed;
                                this.cmbLocation.Visibility = Visibility.Collapsed;
                                this.dtFrom1.Visibility = Visibility.Visible;
                                this.dtTo1.Visibility = Visibility.Visible;
                                this.from1.Visibility = Visibility.Visible;
                                this.to1.Visibility = Visibility.Visible;
                                this.cmbsubstore.Visibility = Visibility.Visible;
                                this.txtsubstore.Visibility = Visibility.Visible;
                                goto IL_D26;
                            }
                            if (this.cmbReportType.SelectedValue.ToString() == "3")
                            {
                                this.cmbPhotographer.Visibility = Visibility.Visible;
                                this.txtuser.Visibility = Visibility.Collapsed;
                                this.cmbPhotographer.Visibility = Visibility.Collapsed;
                                this.cmbLocation.Visibility = Visibility.Collapsed;
                                this.dtFrom1.Visibility = Visibility.Visible;
                                this.dtTo1.Visibility = Visibility.Visible;
                                this.dtFrom1.Visibility = Visibility.Collapsed;
                                this.dtTo1.Visibility = Visibility.Collapsed;
                                this.from1.Visibility = Visibility.Collapsed;
                                this.to1.Visibility = Visibility.Collapsed;
                                this.chkChecked.Visibility = Visibility.Collapsed;
                                this.cmbsubstore.Visibility = Visibility.Visible;
                                this.txtsubstore.Visibility = Visibility.Visible;
                                goto IL_D26;
                            }
                            if (!(this.cmbReportType.SelectedValue.ToString() == "1"))
                            {
                                if (this.cmbReportType.SelectedValue.ToString() == "4")
                                {
                                    this.cmbPhotographer.Visibility = Visibility.Collapsed;
                                    this.txtuser.Visibility = Visibility.Collapsed;
                                    this.cmbLocation.Visibility = Visibility.Collapsed;
                                }
                                else if (this.cmbReportType.SelectedValue.ToString() == "7")
                                {
                                    if (!false)
                                    {
                                        this.cmbPhotographer.Visibility = Visibility.Collapsed;
                                        this.txtuser.Visibility = Visibility.Collapsed;
                                        this.cmbLocation.Visibility = Visibility.Collapsed;
                                        this.txtlocation.Visibility = Visibility.Collapsed;
                                        this.chkChecked.Visibility = Visibility.Collapsed;
                                        this.dtFrom1.Visibility = Visibility.Collapsed;
                                        this.dtTo1.Visibility = Visibility.Collapsed;
                                        this.from1.Visibility = Visibility.Collapsed;
                                        this.to1.Visibility = Visibility.Collapsed;
                                        this.txtlocation.Visibility = Visibility.Collapsed;
                                        this.cmbsubstore.Visibility = Visibility.Visible;
                                        this.txtsubstore.Visibility = Visibility.Visible;
                                        goto IL_D26;
                                    }
                                }
                                else
                                {
                                    if (this.cmbReportType.SelectedValue.ToString() == "8")
                                    {
                                        this.cmbPhotographer.Visibility = Visibility.Collapsed;
                                        this.cmbLocation.Visibility = Visibility.Collapsed;
                                        this.dtFrom1.Visibility = Visibility.Collapsed;
                                        this.dtTo1.Visibility = Visibility.Collapsed;
                                        this.from1.Visibility = Visibility.Collapsed;
                                        this.to1.Visibility = Visibility.Visible;
                                        this.txtuser.Visibility = Visibility.Collapsed;
                                        this.from1.Visibility = Visibility.Collapsed;
                                        goto IL_950;
                                    }
                                    if (this.cmbReportType.SelectedValue.ToString() == "9")
                                    {
                                        this.cmbPhotographer.Visibility = Visibility.Collapsed;
                                        this.txtuser.Visibility = Visibility.Collapsed;
                                        this.cmbLocation.Visibility = Visibility.Collapsed;
                                        this.txtlocation.Visibility = Visibility.Collapsed;
                                        this.chkChecked.Visibility = Visibility.Collapsed;
                                        this.dtFrom1.Visibility = Visibility.Collapsed;
                                        this.dtTo1.Visibility = Visibility.Collapsed;
                                        this.from1.Visibility = Visibility.Collapsed;
                                        this.to1.Visibility = Visibility.Collapsed;
                                        this.txtlocation.Visibility = Visibility.Collapsed;
                                        this.cmbsubstore.Visibility = Visibility.Visible;
                                        this.txtsubstore.Visibility = Visibility.Visible;
                                        goto IL_D26;
                                    }
                                    if (this.cmbReportType.SelectedValue.ToString() == "10")
                                    {
                                        this.cmbPhotographer.Visibility = Visibility.Collapsed;
                                        this.txtuser.Visibility = Visibility.Collapsed;
                                        this.cmbLocation.Visibility = Visibility.Collapsed;
                                        this.txtlocation.Visibility = Visibility.Collapsed;
                                        this.chkChecked.Visibility = Visibility.Collapsed;
                                        this.dtFrom1.Visibility = Visibility.Collapsed;
                                        this.dtTo1.Visibility = Visibility.Collapsed;
                                        this.from1.Visibility = Visibility.Collapsed;
                                        this.to1.Visibility = Visibility.Collapsed;
                                        this.txtlocation.Visibility = Visibility.Collapsed;
                                        this.cmbsubstore.Visibility = Visibility.Collapsed;
                                        this.txtsubstore.Visibility = Visibility.Collapsed;
                                        goto IL_D26;
                                    }
                                    if (this.cmbReportType.SelectedValue.ToString() == "11")
                                    {
                                        this.cmbPhotographer.Visibility = Visibility.Collapsed;
                                        this.txtuser.Visibility = Visibility.Collapsed;
                                        this.cmbLocation.Visibility = Visibility.Collapsed;
                                        this.txtlocation.Visibility = Visibility.Collapsed;
                                        this.chkChecked.Visibility = Visibility.Collapsed;
                                        this.dtFrom1.Visibility = Visibility.Collapsed;
                                        this.dtTo1.Visibility = Visibility.Collapsed;
                                        this.from1.Visibility = Visibility.Collapsed;
                                        this.to1.Visibility = Visibility.Collapsed;
                                        this.txtlocation.Visibility = Visibility.Collapsed;
                                        this.cmbsubstore.Visibility = Visibility.Visible;
                                        this.txtsubstore.Visibility = Visibility.Visible;
                                        goto IL_D26;
                                    }
                                    if (this.cmbReportType.SelectedValue.ToString() == "12")
                                    {
                                        this.cmbPhotographer.Visibility = Visibility.Collapsed;
                                        this.txtuser.Visibility = Visibility.Collapsed;
                                        this.cmbLocation.Visibility = Visibility.Collapsed;
                                        this.txtlocation.Visibility = Visibility.Collapsed;
                                        this.chkChecked.Visibility = Visibility.Collapsed;
                                        this.dtFrom1.Visibility = Visibility.Collapsed;
                                        this.dtTo1.Visibility = Visibility.Collapsed;
                                        this.from1.Visibility = Visibility.Collapsed;
                                        this.to1.Visibility = Visibility.Collapsed;
                                        this.txtlocation.Visibility = Visibility.Collapsed;
                                        this.cmbsubstore.Visibility = Visibility.Visible;
                                        this.txtsubstore.Visibility = Visibility.Visible;
                                        goto IL_D26;
                                    }
                                    this.cmbPhotographer.Visibility = Visibility.Collapsed;
                                    this.txtuser.Visibility = Visibility.Collapsed;
                                    this.cmbLocation.Visibility = Visibility.Visible;
                                    this.chkChecked.Visibility = Visibility.Visible;
                                    this.dtFrom1.Visibility = Visibility.Visible;
                                    this.dtTo1.Visibility = Visibility.Visible;
                                    this.from1.Visibility = Visibility.Visible;
                                    this.to1.Visibility = Visibility.Visible;
                                    this.cmbsubstore.Visibility = Visibility.Collapsed;
                                    this.txtsubstore.Visibility = Visibility.Collapsed;
                                    goto IL_D26;
                                }
                                this.txtlocation.Visibility = Visibility.Collapsed;
                                this.chkChecked.Visibility = Visibility.Collapsed;
                                this.dtFrom1.Visibility = Visibility.Collapsed;
                                this.dtTo1.Visibility = Visibility.Collapsed;
                                this.from1.Visibility = Visibility.Collapsed;
                                this.to1.Visibility = Visibility.Collapsed;
                                this.txtlocation.Visibility = Visibility.Collapsed;
                                this.cmbsubstore.Visibility = Visibility.Visible;
                                this.txtsubstore.Visibility = Visibility.Visible;
                                goto IL_D26;
                            }
                            this.cmbPhotographer.Visibility = Visibility.Collapsed;
                            this.txtuser.Visibility = Visibility.Collapsed;
                            if (!false)
                            {
                                this.cmbLocation.Visibility = Visibility.Collapsed;
                                this.txtlocation.Visibility = Visibility.Collapsed;
                                this.chkChecked.Visibility = Visibility.Collapsed;
                                this.dtFrom1.Visibility = Visibility.Collapsed;
                                this.dtTo1.Visibility = Visibility.Collapsed;
                                this.from1.Visibility = Visibility.Collapsed;
                                this.to1.Visibility = Visibility.Collapsed;
                                this.txtlocation.Visibility = Visibility.Collapsed;
                                this.cmbsubstore.Visibility = Visibility.Visible;
                                this.txtsubstore.Visibility = Visibility.Visible;
                                goto IL_D26;
                            }
                            goto IL_1A5;
                        }
                    IL_950:
                        this.to1.Visibility = Visibility.Collapsed;
                        this.cmbsubstore.Visibility = Visibility.Collapsed;
                        this.txtsubstore.Visibility = Visibility.Collapsed;
                    }
                IL_D26: ;
                }
            }
            catch (Exception serviceException)
            {
                if (4 != 0)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void FillProductCombo()
        {
            try
            {
                do
                {
                    if (4 != 0)
                    {
                        List<ProductTypeInfo> packageType = new ProductBusiness().GetPackageType();
                        CommonUtility.BindComboWithSelect<ProductTypeInfo>(this.cmbPackages, packageType, "DG_Orders_ProductType_Name", "DG_Orders_ProductType_pkey", 0, ClientConstant.SelectString);
                        if (-1 != 0 && !false)
                        {
                            this.cmbPackages.SelectedIndex = 0;
                        }
                    }
                }
                while (false);
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            if (5 != 0)
            {
            }
        }

        private void chkChecked_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            this.report.Close();
            this.report.Dispose();
        }

        private void SetDBLogonForSubreports(ReportDocument report)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder;
            ConnectionInfo connectionInfo;
            do
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DigiConnectionString"].ToString();
                sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
                connectionInfo = new ConnectionInfo();
                connectionInfo.ServerName = sqlConnectionStringBuilder.DataSource;
                connectionInfo.DatabaseName = sqlConnectionStringBuilder.InitialCatalog;
            }
            while (-1 == 0);
            connectionInfo.UserID = sqlConnectionStringBuilder.UserID;
            connectionInfo.Password = sqlConnectionStringBuilder.Password;
            TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
            IEnumerator enumerator = report.Subreports.GetEnumerator();
            try
            {
                while (true)
                {
                    bool arg_116_0;
                    bool expr_107 = arg_116_0 = enumerator.MoveNext();
                    if (!false)
                    {
                        bool flag = expr_107;
                        if (7 == 0)
                        {
                            break;
                        }
                        arg_116_0 = flag;
                    }
                    if (!arg_116_0)
                    {
                        break;
                    }
                    ReportDocument reportDocument = (ReportDocument)enumerator.Current;
                    //using (IEnumerator enumerator2 = reportDocument.Database.Tables.GetEnumerator())
                    IEnumerator enumerator2 = reportDocument.Database.Tables.GetEnumerator();
                    try 
                    {
                        if (!false)
                        {
                            goto IL_D4;
                        }
                    IL_CA:
                        CrystalDecisions.CrystalReports.Engine.Table table;
                        table.ApplyLogOnInfo(tableLogOnInfo);
                    IL_D4:
                        bool arg_DB_0 = enumerator2.MoveNext();
                        bool expr_DD;
                        do
                        {
                            bool flag = arg_DB_0;
                            expr_DD = (arg_DB_0 = flag);
                        }
                        while (false);
                        if (expr_DD)
                        {
                            table = (CrystalDecisions.CrystalReports.Engine.Table)enumerator2.Current;
                            tableLogOnInfo = table.LogOnInfo;
                            tableLogOnInfo.ConnectionInfo = connectionInfo;
                            goto IL_CA;
                        }
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            finally
            {
                if (false)
                {
                    goto IL_13B;
                }
                IDisposable disposable = enumerator as IDisposable;
                if (disposable == null)
                {
                    goto IL_13C;
                }
            IL_134:
                disposable.Dispose();
            IL_13B:
            IL_13C:
                if (false)
                {
                    goto IL_134;
                }
            }
        }

        private void SetDBLogonReports(ReportDocument report)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder;
            ConnectionInfo connectionInfo;
            if (!false)
            {
                if (-1 != 0)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DigiConnectionString"].ToString();
                    sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
                }
                connectionInfo = new ConnectionInfo();
                connectionInfo.ServerName = sqlConnectionStringBuilder.DataSource;
            }
            connectionInfo.DatabaseName = sqlConnectionStringBuilder.InitialCatalog;
            do
            {
                connectionInfo.UserID = sqlConnectionStringBuilder.UserID;
                connectionInfo.Password = sqlConnectionStringBuilder.Password;
            }
            while (false);
            report.SetDatabaseLogon(connectionInfo.UserID, connectionInfo.Password, connectionInfo.DatabaseName, connectionInfo.ServerName);
        }

        private void btnMail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string expr_02 = string.Empty;
                string text;
                if (true)
                {
                    text = expr_02;
                }
                bool expr_13 = this.sendMailFlag;
                bool flag;
                if (!false)
                {
                    flag = expr_13;
                }
                if (!flag)
                {
                    System.Windows.MessageBox.Show("Generate Report Then Click On E-mail ");
                }
                else
                {
                    string str = "abc.xls";
                    flag = (this.cmbReportType.SelectedIndex <= -1);
                    if (flag)
                    {
                        goto IL_1E2;
                    }
                    bool arg_85_0 = this.rdbtnExcel.IsChecked == true;
                IL_83:
                    flag = !arg_85_0;
                    if (!flag)
                    {
                        str = this.cmbReportType.SelectedValue.ToString() + ".xls";
                        text = this.cmbReportType.SelectedItem.ToString().ToString().Split(new char[]
						{
							','
						}).First<string>().Replace("[", string.Empty).ToString();
                        goto IL_1E1;
                    }
                    flag = !(this.rdbtnCSV.IsChecked == true);
                IL_119:
                    if (!flag)
                    {
                        str = this.cmbReportType.SelectedValue.ToString() + ".csv";
                        text = this.cmbReportType.SelectedItem.ToString().ToString().Split(new char[]
						{
							','
						}).First<string>().Replace("[", string.Empty).ToString();
                    }
                    else
                    {
                        str = this.cmbReportType.SelectedValue.ToString() + ".pdf";
                        text = this.cmbReportType.SelectedItem.ToString().ToString().Split(new char[]
						{
							','
						}).First<string>().Replace("[", string.Empty).ToString();
                    }
                IL_1E1:
                IL_1E2:
                    DateTime dateTime = new CustomBusineses().ServerDateTime();
                    string[] array = new string[6];
                    array[0] = LoginUser.UserId.ToString();
                    array[1] = LoginUser.StoreId.ToString();
                    string text2;
                    string text3;
                    do
                    {
                        array[2] = LoginUser.SubStoreId.ToString();
                        array[3] = dateTime.Hour.ToString();
                        array[4] = dateTime.Minute.ToString();
                        array[5] = dateTime.Second.ToString();
                        text2 = string.Concat(array);
                        string path = dateTime.Date.ToString("ddMMyyyy");
                        text2 = text + "_" + text2 + str;
                        text3 = Path.Combine(LoginUser.DigiReportPath, path);
                        if (false)
                        {
                            goto IL_119;
                        }
                        flag = Directory.Exists(text3);
                        if (!flag)
                        {
                            Directory.CreateDirectory(text3);
                        }
                        flag = !(this.cmbReportType.SelectedValue.ToString() == "11");
                    }
                    while (false);
                    int arg_2F4_0;
                    int arg_2F4_1;
                    int arg_4D7_0;
                    int arg_487_0;
                    bool arg_493_0;
                    if (!flag)
                    {
                        arg_2F4_0 = ((this.dtDataToExport == null) ? 1 : 0);
                        arg_2F4_1 = 0;
                    }
                    else
                    {
                        flag = !(this.rdbtnExcel.IsChecked == true);
                        if (!flag)
                        {
                            this.report.ExportToDisk(ExportFormatType.Excel, Path.Combine(text3, text2));
                            goto IL_4F6;
                        }
                        if (this.rdbtnCSV.IsChecked == true && ActivityReport.ReportSource != null)
                        {
                            arg_487_0 = (arg_2F4_0 = (arg_4D7_0 = ((ActivityReport.ReportSource.Rows.Count > 0) ? 1 : 0)));
                            goto IL_47D;
                        }
                        arg_493_0 = true;
                        goto IL_492;
                    }
                    while (true)
                    {
                    IL_2F4:
                        flag = (arg_2F4_0 == arg_2F4_1);
                        while (flag)
                        {
                            bool? isChecked = this.rdbtnExcel.IsChecked;
                            int arg_332_0 = (!isChecked.GetValueOrDefault()) ? (arg_2F4_0 = 0) : (arg_2F4_0 = (isChecked.HasValue ? 1 : 0));
                            int expr_32F = arg_2F4_1 = 0;
                            if (expr_32F != 0)
                            {
                                goto IL_2F4;
                            }
                            flag = (arg_332_0 == expr_32F);
                            if (!flag)
                            {
                                goto Block_16;
                            }
                            bool arg_3B4_0 = ((!(this.rdbtnCSV.IsChecked == true) || ActivityReport.ReportSource == null) ? (arg_2F4_0 = (arg_487_0 = (arg_4D7_0 = 1))) : (arg_2F4_0 = (arg_487_0 = (arg_4D7_0 = ((ActivityReport.ReportSource.Rows.Count <= 0) ? 1 : 0))))) != 0;
                            if (false)
                            {
                                goto IL_47D;
                            }
                            flag = arg_3B4_0;
                            if (flag)
                            {
                                goto IL_3DF;
                            }
                            if (5 != 0)
                            {
                                ActivityReport.ReportSource.ExportToCSV("vw_GetActivityReports.DG_", Path.Combine(text3, text2));
                            }
                            if (!false)
                            {
                                goto Block_23;
                            }
                        }
                        break;
                    }
                    System.Windows.MessageBox.Show("Generate Report Then Click On E-mail ");
                    return;
                Block_16:
                    ActivityReport.ExportToExcel(this.dtDataToExport, Path.Combine(text3, text2 + "x"));
                    text2 += "x";
                Block_23:
                    goto IL_3F4;
                IL_3DF:
                    this.ExportToPDF(this.dtDataToExport, Path.Combine(text3, text2));
                IL_3F4:
                    goto IL_4F7;
                IL_47D:
                    int expr_47E = arg_2F4_1 = 0;
                    if (expr_47E != 0)
                    {
                        //goto IL_2F4;
                    }
                    int arg_4D7_1 = expr_47E;
                    if (expr_47E != 0)
                    {
                        goto IL_4D7;
                    }
                    arg_493_0 = (arg_85_0 = (arg_487_0 == expr_47E));
                    if (false)
                    {
                        goto IL_83;
                    }
                IL_492:
                    flag = arg_493_0;
                    if (!flag)
                    {
                        ActivityReport.ReportSource.ExportToCSV("vw_GetActivityReports.DG_", Path.Combine(text3, text2));
                        goto IL_4F6;
                    }
                    arg_4D7_0 = ((this.rdbtnPDF.IsChecked == true) ? 1 : 0);
                    arg_4D7_1 = 0;
                IL_4D7:
                    flag = (arg_4D7_0 == arg_4D7_1);
                    if (!flag)
                    {
                        this.report.ExportToDisk(ExportFormatType.PortableDocFormat, Path.Combine(text3, text2));
                    }
                IL_4F6:
                IL_4F7:
                    EMailInfo info = new EMailInfo
                    {
                        StoreId = LoginUser.StoreId.ToString(),
                        UserId = LoginUser.UserId.ToString(),
                        OrderId = Path.Combine(text3, text2).ToString(),
                        Sendername = LoginUser.UserName,
                        SubstoreId = LoginUser.SubStoreId.ToString(),
                        OtherMessage = text
                    };
                    this.MailPopUp.ShowHandlerDialog(info);
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            finally
            {
            }
        }

        private void NotifyPropertyChanged(string info)
        {
            if (!false)
            {
                bool arg_15_0;
                bool expr_0C = arg_15_0 = (this.propertyChangedSource == null);
                if (!false)
                {
                    bool flag = expr_0C;
                    arg_15_0 = flag;
                }
                if (arg_15_0)
                {
                    return;
                }
            }
            do
            {
                do
                {
                    this.propertyChangedSource(this, new PropertyChangedEventArgs(info));
                }
                while (false);
            }
            while (-1 == 0);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.propertyChanged != null)
            {
                this.propertyChanged(this, e);
            }
        }

        private void btnExportToCSV_Click(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                try
                {
                    this.dlg.FileName = this.filename;
                    this.dlg.DefaultExt = ".csv";
                    if (8 == 0)
                    {
                        goto IL_128;
                    }
                    this.dlg.Filter = "CSV files (.csv)|*.csv";
                    bool flag = this.IsEnabledExportToAnyDrive();
                    bool arg_60_0 = flag;
                IL_60:
                    if (!arg_60_0)
                    {
                        this.dlg.FileOk += new CancelEventHandler(this.dlg_FileOk);
                        DriveInfo driveInfo = DriveInfo.GetDrives().Where(delegate(DriveInfo drive)
                        {
                            bool result;
                            while (8 != 0)
                            {
                                bool arg_36_0;
                                if (drive.DriveType == DriveType.Removable)
                                {
                                    arg_36_0 = drive.IsReady;
                                    if (2 != 0)
                                    {
                                    }
                                }
                                else
                                {
                                    if (5 == 0 || false)
                                    {
                                        continue;
                                    }
                                    arg_36_0 = false;
                                }
                                result = arg_36_0;
                                break;
                            }
                            return result;
                        }).FirstOrDefault<DriveInfo>();
                        flag = (driveInfo == null);
                        if (!false)
                        {
                            if (flag)
                            {
                                System.Windows.MessageBox.Show("No removable device found.");
                                return;
                            }
                            this.dlg.InitialDirectory = driveInfo.Name;
                        }
                    }
                    bool? flag2 = this.dlg.ShowDialog();
                    bool? flag3;
                    if (4 != 0)
                    {
                        if (false)
                        {
                            goto IL_132;
                        }
                        flag3 = flag2;
                    }
                    flag = !(flag3 == true);
                    if (flag)
                    {
                        goto IL_144;
                    }
                    string fileName = this.dlg.FileName;
                    flag = (ActivityReport.ReportSource == null);
                IL_128:
                    bool expr_128 = arg_60_0 = flag;
                    if (false)
                    {
                        goto IL_60;
                    }
                    if (expr_128)
                    {
                        goto IL_143;
                    }
                IL_132:
                    ActivityReport.ReportSource.ExportToCSV("vw_GetActivityReports.DG_", fileName);
                IL_143:
                IL_144: ;
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                finally
                {
                    if (!false)
                    {
                        this.dlg.FileOk -= new CancelEventHandler(this.dlg_FileOk);
                    }
                }
            }
        }

    }
}
