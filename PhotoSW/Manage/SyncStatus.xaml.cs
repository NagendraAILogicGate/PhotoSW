using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Primitives;
using PhotoSW.PSControls;
using PhotoSW.Views;

namespace PhotoSW.Manage
{
    public partial class SyncStatus : Window, IComponentConnector
    {
        private List<SyncStatusInfo> _lstReSyncOnline;

        private List<SyncStatusInfo> _lstReSyncNormal;

        private List<SyncStatusInfo> _lstReSyncForm;

        private Statistics statictics = new Statistics();

        private int TotalOrderCount = 0;

        private int SucessOrderCount = 0;

        private int ImageUploadedCount = 0;

        private int ImageFailedCount = 0;

        private int SuccesfullImagesCount = 0;

       

        public SyncStatus()
        {
            this.InitializeComponent();
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
        }

        private void GetSyncData()
        {
            UpDownBase<DateTime?> arg_E7_0 = this.dtFrom;
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.Date;
            arg_E7_0.Value = new DateTime?(dateTime.Add(new TimeSpan(6, 0, 0)));
            UpDownBase<DateTime?> arg_64_0 = this.dtTo;
            dateTime = DateTime.Now;
            dateTime = dateTime.Date;
            arg_64_0.Value = new DateTime?(dateTime.Add(new TimeSpan(23, 0, 0)));
            this._lstReSyncOnline = new SyncStatusBusiness().GetOrdersyncStatus(this.dtFrom.Value, this.dtTo.Value);
            this.DGManageSyncStatus.ItemsSource = this._lstReSyncOnline;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dateTime;
                do
                {
                    UpDownBase<DateTime?> arg_172_0 = this.dtFrom;
                    dateTime = DateTime.Now;
                    dateTime = dateTime.Date;
                    arg_172_0.Value = new DateTime?(dateTime.Add(new TimeSpan(6, 0, 0)));
                    UpDownBase<DateTime?> arg_65_0 = this.dtTo;
                    dateTime = DateTime.Now;
                    dateTime = dateTime.Date;
                    arg_65_0.Value = new DateTime?(dateTime.Add(new TimeSpan(23, 0, 0)));
                    UpDownBase<DateTime?> arg_93_0 = this.dtFromNormalOrd;
                    dateTime = DateTime.Now;
                    dateTime = dateTime.Date;
                    arg_93_0.Value = new DateTime?(dateTime.Add(new TimeSpan(6, 0, 0)));
                    UpDownBase<DateTime?> arg_C2_0 = this.dtToNormalOrd;
                    dateTime = DateTime.Now;
                    dateTime = dateTime.Date;
                    arg_C2_0.Value = new DateTime?(dateTime.Add(new TimeSpan(23, 0, 0)));
                    UpDownBase<DateTime?> arg_F0_0 = this.dtFromOpenCloseForm;
                    dateTime = DateTime.Now;
                    dateTime = dateTime.Date;
                    arg_F0_0.Value = new DateTime?(dateTime.Add(new TimeSpan(6, 0, 0)));
                }
                while (false);
                UpDownBase<DateTime?> arg_125_0 = this.dtToOpenCloseForm;
                dateTime = DateTime.Now;
                dateTime = dateTime.Date;
                arg_125_0.Value = new DateTime?(dateTime.Add(new TimeSpan(23, 0, 0)));
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
                if (!false)
                {
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            this.GetSyncResult();
        }

        private void chkALLOnline_Checked(object sender, RoutedEventArgs e)
        {
            do
            {
                if (3 != 0)
                {
                    try
                    {
                        do
                        {
                            this._lstReSyncOnline.ForEach(delegate(SyncStatusInfo z)
                            {
                                z.IsAvailable = new bool?(true);
                            });
                            do
                            {
                                this.DGManageSyncStatus.ItemsSource = this._lstReSyncOnline;
                            }
                            while (2 == 0);
                            if (3 == 0)
                            {
                                break;
                            }
                            this.DGManageSyncStatus.Items.Refresh();
                        }
                        while (2 == 0);
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (2 == 0);
        }

        private void chkALLOnline_Unchecked(object sender, RoutedEventArgs e)
        {
            do
            {
                if (3 != 0)
                {
                    try
                    {
                        do
                        {
                            this._lstReSyncOnline.ForEach(delegate(SyncStatusInfo z)
                            {
                                z.IsAvailable = new bool?(false);
                            });
                            do
                            {
                                this.DGManageSyncStatus.ItemsSource = this._lstReSyncOnline;
                            }
                            while (2 == 0);
                            if (3 == 0)
                            {
                                break;
                            }
                            this.DGManageSyncStatus.Items.Refresh();
                        }
                        while (2 == 0);
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (2 == 0);
        }

        private void btnReSyncOnline_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                if (2 != 0)
                {
                    try
                    {
                        while (true)
                        {
                            if (!false)
                            {
                                this.ReSync(this._lstReSyncOnline);
                                if (!false)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (false);
        }

        private void chkALLNormal_Checked(object sender, RoutedEventArgs e)
        {
            do
            {
                if (3 != 0)
                {
                    try
                    {
                        do
                        {
                            this._lstReSyncNormal.ForEach(delegate(SyncStatusInfo z)
                            {
                                z.IsAvailable = new bool?(true);
                            });
                            do
                            {
                                this.DGManageSyncStatusNormalOrd.ItemsSource = this._lstReSyncNormal;
                            }
                            while (2 == 0);
                            if (3 == 0)
                            {
                                break;
                            }
                            this.DGManageSyncStatusNormalOrd.Items.Refresh();
                        }
                        while (2 == 0);
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (2 == 0);
        }

        private void chkALLNormal_Unchecked(object sender, RoutedEventArgs e)
        {
            do
            {
                if (3 != 0)
                {
                    try
                    {
                        do
                        {
                            this._lstReSyncNormal.ForEach(delegate(SyncStatusInfo z)
                            {
                                z.IsAvailable = new bool?(false);
                            });
                            do
                            {
                                this.DGManageSyncStatusNormalOrd.ItemsSource = this._lstReSyncNormal;
                            }
                            while (2 == 0);
                            if (3 == 0)
                            {
                                break;
                            }
                            this.DGManageSyncStatusNormalOrd.Items.Refresh();
                        }
                        while (2 == 0);
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (2 == 0);
        }

        private void btnReSyncNormal_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                if (2 != 0)
                {
                    try
                    {
                        while (true)
                        {
                            if (!false)
                            {
                                this.ReSync(this._lstReSyncNormal);
                                if (!false)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (false);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (-1 != 0)
            {
                try
                {
                    ManageHome manageHome = new ManageHome();
                    manageHome.Show();
                    base.Close();
                }
                catch (Exception serviceException)
                {
                    while (!false && !false)
                    {
                        if (-1 != 0)
                        {
                            ErrorHandler.ErrorHandler.LogError(serviceException);
                            break;
                        }
                    }
                }
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
                        AuditLog.AddUserLog(LoginUser.UserId, 39, "Logged out at ");
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

        private void btnBackNormalOrd_Click(object sender, RoutedEventArgs e)
        {
            if (-1 != 0)
            {
                try
                {
                    ManageHome manageHome = new ManageHome();
                    manageHome.Show();
                    base.Close();
                }
                catch (Exception serviceException)
                {
                    while (!false && !false)
                    {
                        if (-1 != 0)
                        {
                            ErrorHandler.ErrorHandler.LogError(serviceException);
                            break;
                        }
                    }
                }
            }
        }

        private void btnSearchNormal_Click(object sender, RoutedEventArgs e)
        {
            if (8 != 0)
            {
                try
                {
                    DateTime? value = this.dtFromNormalOrd.Value;
                    DateTime? value2 = this.dtToNormalOrd.Value;
                    bool arg_C5_0;
                    if (!value.HasValue)
                    {
                        arg_C5_0 = true;
                        goto IL_43;
                    }
                IL_36:
                    arg_C5_0 = !value2.HasValue;
                IL_40:
                IL_43:
                    if (8 == 0)
                    {
                        goto IL_40;
                    }
                    if (!arg_C5_0)
                    {
                        this.GetSyncStatusNormalOrders(value.Value, value2.Value);
                        goto IL_7C;
                    }
                IL_66:
                    if (3 != 0)
                    {
                        System.Windows.MessageBox.Show("From date or To date cannot be empty!", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Hand);
                    }
                IL_7C:
                    if (false)
                    {
                        goto IL_66;
                    }
                    if (false)
                    {
                        goto IL_36;
                    }
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                    while (-1 == 0);
                }
            }
        }

        private void GetSyncStatusNormalOrders(DateTime fromDate, DateTime toDate)
        {
            try
            {
                this._lstReSyncNormal = new SyncStatusBusiness().GetSyncStatusList(fromDate, toDate);
                if (false)
                {
                    goto IL_54;
                }
                if (false)
                {
                    goto IL_79;
                }
                bool flag = this._lstReSyncNormal.Count > 0;
            IL_3A:
                if (!flag)
                {
                    System.Windows.MessageBox.Show("No records found!", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    this.DGManageSyncStatusNormalOrd.ItemsSource = this._lstReSyncNormal;
                }
            IL_54:
                this.chkALLNormal.IsChecked = new bool?(false);
            IL_79:
                if (3 == 0)
                {
                    goto IL_3A;
                }
            }
            catch (Exception serviceException)
            {
                do
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (!true);
            }
            if (4 != 0)
            {
            }
        }

        private void GetSyncStatusopenCloseForm(DateTime fromDate, DateTime toDate)
        {
            try
            {
                this._lstReSyncNormal = new SyncStatusBusiness().GetSyncStatusList(fromDate, toDate);
                if (false)
                {
                    goto IL_54;
                }
                if (false)
                {
                    goto IL_79;
                }
                bool flag = this._lstReSyncNormal.Count > 0;
            IL_3A:
                if (!flag)
                {
                    System.Windows.MessageBox.Show("No records found!", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    this.DGManageSyncStatusNormalOrd.ItemsSource = this._lstReSyncNormal;
                }
            IL_54:
                this.chkALLNormal.IsChecked = new bool?(false);
            IL_79:
                if (3 == 0)
                {
                    goto IL_3A;
                }
            }
            catch (Exception serviceException)
            {
                do
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (!true);
            }
            if (4 != 0)
            {
            }
        }

        private void ReSync(List<SyncStatusInfo> lstReSync)
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (3 == 0)
            {
            }
            List<SyncStatusInfo>.Enumerator enumerator = lstReSync.GetEnumerator();
            //goto IL_24;
            try
            {
                while (true)
                {
                IL_24:
                    while (true)
                    {
                    IL_7C:
                        bool arg_83_0 = enumerator.MoveNext() ?true : false;
                        while (arg_83_0)
                        {
                            SyncStatusInfo current = enumerator.Current;
                            if (false)
                            {
                                goto IL_7C;
                            }
                            bool? isAvailable = current.IsAvailable;
                            if (!false)
                            {
                                bool arg_57_0;
                                if (isAvailable.GetValueOrDefault())
                                {
                                    arg_83_0 = (arg_57_0 = (isAvailable.HasValue ? true : false));
                                    if (-1 == 0)
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    arg_57_0 = false;
                                }
                                if (arg_57_0 )
                                {
                                    stringBuilder.Append(current.ChangeTrackingId + ",");
                                }
                                goto IL_7C;
                            }
                            goto IL_24;
                        }
                        goto Block_12;
                    }
                }
            Block_12: ;
            }
            finally
            {
                ((IDisposable)enumerator).Dispose();
            }
            bool arg_BB_0 = stringBuilder.Length > 0;
            while (arg_BB_0)
            {
                bool arg_ED_0;
                bool expr_DD = arg_BB_0 = (arg_ED_0 = new SyncStatusBusiness().ReSync(stringBuilder.ToString().Substring(0, stringBuilder.Length - 1)));
                if (!false)
                {
                    bool flag = expr_DD;
                    arg_ED_0 = (arg_BB_0 = !flag);
                }
                if (!false)
                {
                    if (!arg_ED_0)
                    {
                        System.Windows.MessageBox.Show("Sync Re-initiated Successfully");
                    }
                    break;
                }
            }
        }

        private void ReSyncImages(List<SyncStatusInfo> lstReSync)
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (3 == 0)
            {
            }
            List<SyncStatusInfo>.Enumerator enumerator = lstReSync.GetEnumerator();
            //goto IL_24;
            try
            {
                while (true)
                {
                IL_24:
                    while (true)
                    {
                    IL_7C:
                        bool arg_83_0 = enumerator.MoveNext() ? true : false;
                        while (arg_83_0)
                        {
                            SyncStatusInfo current = enumerator.Current;
                            if (false)
                            {
                                goto IL_7C;
                            }
                            bool? isAvailable = current.IsAvailable;
                            if (!false)
                            {
                                bool arg_57_0;
                                if (isAvailable.GetValueOrDefault())
                                {
                                    arg_83_0 = (arg_57_0 = (isAvailable.HasValue ? true : false));
                                    if (-1 == 0)
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    arg_57_0 = false;
                                }
                                if (arg_57_0 )
                                {
                                    stringBuilder.Append(current.DGOrderspkey + ",");
                                }
                                goto IL_7C;
                            }
                            goto IL_24;
                        }
                        goto Block_12;
                    }
                }
            Block_12: ;
            }
            finally
            {
                ((IDisposable)enumerator).Dispose();
            }
            bool arg_BB_0 = stringBuilder.Length > 0;
            while (arg_BB_0)
            {
                bool arg_ED_0;
                bool expr_DD = arg_BB_0 = (arg_ED_0 = new SyncStatusBusiness().ReSyncImages(stringBuilder.ToString().Substring(0, stringBuilder.Length - 1)));
                if (!false)
                {
                    bool flag = expr_DD;
                    arg_ED_0 = (arg_BB_0 = !flag);
                }
                if (!false)
                {
                    if (!arg_ED_0)
                    {
                        System.Windows.MessageBox.Show("Image ReSync started Successfully");
                    }
                    break;
                }
            }
        }

        private void btnReSyncImages_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                if (2 != 0)
                {
                    try
                    {
                        while (true)
                        {
                            if (!false)
                            {
                                this.ReSyncImages(this._lstReSyncOnline);
                                if (!false)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (false);
        }

        private void DGManageSyncStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void statistics_Click(object sender, RoutedEventArgs e)
        {
            if (3 != 0)
            {
                this.GetSyncResult();
                int arg_78_0;
                do
                {
                    int arg_51_0;
                    int arg_39_0;
                    int expr_A2 = arg_39_0 = (arg_51_0 = (arg_78_0 = this._lstReSyncOnline.Count));
                    if (4 != 0)
                    {
                        if (false)
                        {
                            goto IL_78;
                        }
                        bool expr_28 = expr_A2 <= 0;
                        bool flag;
                        if (!false)
                        {
                            flag = expr_28;
                        }
                        arg_51_0 = (arg_39_0 = (flag ? 1 : 0));
                    }
                    if (!false)
                    {
                        if (arg_39_0 != 0)
                        {
                            return;
                        }
                        this.statictics.SetParent(this);
                        arg_51_0 = this.SucessOrderCount;
                    }
                    Statistics.SucessOrderCounts = arg_51_0;
                    Statistics.ImageFailedCounts = this.ImageFailedCount;
                }
                while (false);
                Statistics.ImageUploadedCounts = this.ImageUploadedCount;
                arg_78_0 = this.TotalOrderCount;
            IL_78:
                Statistics.TotalOrderCounts = arg_78_0;
            }
            this.StatisticsControl.ShowPanHandlerDialog();
        }

        public void GetSyncResult()
        {
            try
            {
                this.TotalOrderCount = 0;
                this.SucessOrderCount = 0;
                this.ImageUploadedCount = 0;
                this.ImageFailedCount = 0;
                this.SuccesfullImagesCount = 0;
                DateTime value = DateTime.Now;
                DateTime value2 = DateTime.Now;
                if (this.dtFrom.Text != null)
                {
                    value = this.dtFrom.Value.Value;
                }
                if (this.dtTo.Text != null)
                {
                    value2 = this.dtTo.Value.Value;
                }
                this._lstReSyncOnline = new SyncStatusBusiness().GetOrdersyncStatus(new DateTime?(value), new DateTime?(value2));
                bool arg_C9_0 = this._lstReSyncOnline.Count > 0;
                bool expr_CB;
                do
                {
                    bool flag = arg_C9_0;
                    expr_CB = (arg_C9_0 = flag);
                }
                while (false);
                if (!expr_CB)
                {
                    System.Windows.MessageBox.Show("No Record Found");
                }
                else
                {
                    foreach (string current in from x in this._lstReSyncOnline
                                               select x.ImageSynced)
                    {
                        string input = current.Substring(current.LastIndexOf('/') + 1);
                        string input2 = current.Split(new char[]
						{
							'/'
						})[0];
                        this.ImageUploadedCount += input.ToInt32(false);
                        this.SuccesfullImagesCount += input2.ToInt32(false);
                    }
                }
                foreach (string current2 in from x in this._lstReSyncOnline
                                            select x.Syncstatus)
                {
                    if (current2 == "Successful")
                    {
                        this.SucessOrderCount++;
                    }
                }
                using (IEnumerator<string> enumerator = (from x in this._lstReSyncOnline.Where(delegate(SyncStatusInfo x)
                {
                    int arg_0B_0 = (x.Syncstatus == "Successful") ? 1 : 0;
                    bool arg_2E_0;
                    while (true)
                    {
                        int arg_51_0;
                        if (arg_0B_0 == 0)
                        {
                            arg_2E_0 = ((arg_0B_0 = (arg_51_0 = ((x.Syncstatus == "Failed") ? 1 : 0))) != 0);
                            if (!false)
                            {
                                goto IL_21;
                            }
                        }
                        else
                        {
                            if (!false)
                            {
                                arg_51_0 = 1;
                                goto IL_21;
                            }
                            goto IL_26;
                        }
                    IL_28:
                        if (false)
                        {
                            goto IL_22;
                        }
                        if (!false)
                        {
                            break;
                        }
                        continue;
                    IL_26:
                        bool flag2;
                        arg_2E_0 = ((arg_0B_0 = (arg_51_0 = (flag2 ? 1 : 0))) != 0);
                        goto IL_28;
                    IL_22:
                        flag2 = (arg_51_0 != 0);
                        goto IL_26;
                    IL_21:
                        goto IL_22;
                    }
                    return arg_2E_0;
                })
                                                         select x.ImageSynced).GetEnumerator())
                {
                    while (true)
                    {
                        while (true)
                        {
                            bool flag = enumerator.MoveNext();
                            if (4 != 0)
                            {
                                if (!flag)
                                {
                                    goto Block_23;
                                }
                                string current3 = enumerator.Current;
                                string input3 = current3.Substring(current3.LastIndexOf('/') + 1);
                                string input4 = current3.Split(new char[]
								{
									'/'
								})[0];
                                this.ImageFailedCount = input3.ToInt32(false) - input4.ToInt32(false);
                            }
                        }
                    }
                Block_23: ;
                }
                this.TotalOrderCount = this._lstReSyncOnline.Count;
                this.DGManageSyncStatus.ItemsSource = this._lstReSyncOnline;
                this.chkALLOnline.IsChecked = new bool?(false);
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void btnSearchOpenCloseForm_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    DateTime? value = this.dtFromOpenCloseForm.Value;
                    DateTime value2 = value.Value;
                    value = this.dtToOpenCloseForm.Value;
                    DateTime value3 = value.Value;
                    this._lstReSyncForm = (from x in new SyncStatusBusiness().GetFormSyncStatusList(value2, value3)
                                           orderby x.SyncFormTransDate descending
                                           select x).ToList<SyncStatusInfo>();
                    int arg_8E_0;
                    int expr_7F = arg_8E_0 = this._lstReSyncForm.Count;
                    if (!false)
                    {
                        bool flag = expr_7F > 0;
                        arg_8E_0 = (flag ? 1 : 0);
                    }
                    if (arg_8E_0 == 0)
                    {
                        System.Windows.MessageBox.Show("No records found!", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    this.DGManageSyncStatusOpenCloseForm.ItemsSource = this._lstReSyncForm;
                    this.chkALLNormal.IsChecked = new bool?(false);
                }
                catch (Exception serviceException)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
            while (false);
        }

        private void chkALLOpenCloseForm_Checked(object sender, RoutedEventArgs e)
        {
            do
            {
                if (3 != 0)
                {
                    try
                    {
                        do
                        {
                            this._lstReSyncForm.ForEach(delegate(SyncStatusInfo z)
                            {
                                z.IsAvailable = new bool?(true);
                            });
                            do
                            {
                                this.DGManageSyncStatusOpenCloseForm.ItemsSource = this._lstReSyncForm;
                            }
                            while (2 == 0);
                            if (3 == 0)
                            {
                                break;
                            }
                            this.DGManageSyncStatusOpenCloseForm.Items.Refresh();
                        }
                        while (2 == 0);
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (2 == 0);
        }

        private void chkALLOpenCloseForm_Unchecked(object sender, RoutedEventArgs e)
        {
            do
            {
                if (3 != 0)
                {
                    try
                    {
                        do
                        {
                            this._lstReSyncForm.ForEach(delegate(SyncStatusInfo z)
                            {
                                z.IsAvailable = new bool?(false);
                            });
                            do
                            {
                                this.DGManageSyncStatusOpenCloseForm.ItemsSource = this._lstReSyncForm;
                            }
                            while (2 == 0);
                            if (3 == 0)
                            {
                                break;
                            }
                            this.DGManageSyncStatusOpenCloseForm.Items.Refresh();
                        }
                        while (2 == 0);
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (2 == 0);
        }

        private void btnReSyncOpenCloseForm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StoreSubStoreDataBusniess storeSubStoreDataBusniess = new StoreSubStoreDataBusniess();
                if (3 != 0)
                {
                    storeSubStoreDataBusniess.GetStore();
                    while (true)
                    {
                        if (false)
                        {
                            goto IL_3F;
                        }
                        this.ReSync(this._lstReSyncForm);
                        if (7 != 0)
                        {
                            goto IL_3F;
                        }
                    }
                    goto IL_C6;
                }
            IL_3F:
                this._lstReSyncForm = (from x in new SyncStatusBusiness().GetFormSyncStatusList(this.dtFromOpenCloseForm.Value.Value, this.dtToOpenCloseForm.Value.Value)
                                       orderby x.SyncFormTransDate descending
                                       select x).ToList<SyncStatusInfo>();
                this.DGManageSyncStatusOpenCloseForm.ItemsSource = this._lstReSyncForm;
                this.DGManageSyncStatusOpenCloseForm.Items.Refresh();
            IL_C6: ;
            }
            catch (Exception serviceException)
            {
                if (4 != 0)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
            while (3 == 0)
            {
            }
        }

        private void btnChkConnectivity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StoreSubStoreDataBusniess expr_46 = new StoreSubStoreDataBusniess();
                StoreSubStoreDataBusniess storeSubStoreDataBusniess;
                if (true)
                {
                    storeSubStoreDataBusniess = expr_46;
                }
                bool arg_61_0 = storeSubStoreDataBusniess.GetStore().IsOnline;
                bool expr_16;
                while (true)
                {
                    bool flag = arg_61_0;
                    bool expr_64 = arg_61_0 = flag;
                    if (!false)
                    {
                        expr_16 = (arg_61_0 = !expr_64);
                        if (8 != 0)
                        {
                            break;
                        }
                    }
                }
                if (!expr_16)
                {
                    System.Windows.MessageBox.Show("You are online. Data is syncing on server", "Spectra Photo");
                }
                else
                {
                    System.Windows.MessageBox.Show("You are offline. Data is not syncing on server, please contact IT administrator", "Spectra Photo");
                }
            }
            catch (Exception serviceException)
            {
                if (5 != 0)
                {
                    if (!false && !false)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
        }

        
    }
}
