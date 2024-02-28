using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Xml.Serialization;
using PhotoSW.Views;
using PhotoSW.ViewModels;

namespace PhotoSW.Manage
{
    public partial class ManageMasterData : Window, IComponentConnector
    {
        private string _filedatasource = string.Empty;

        private string packagefilename = string.Empty;

        private CurrencyExchangeBussiness _objCurrencyBusiness = null;

        private BackgroundWorker BackupWorker;

        private BusyWindow bs = new BusyWindow();

        private DataTable _dtExcel;

        private DataTable _dt;

        private DataTable dtSite;

        private DataTable dtItem;

        private DataTable dtpkg;


        public ManageMasterData()
        {
            this.InitializeComponent();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login;
            do
            {
                int arg_2F_0 = LoginUser.UserId;
                do
                {
                    arg_2F_0 = (AuditLog.AddUserLog(arg_2F_0, 39, "Logged out at") ? 1 : 0);
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    if (4 != 0)
                    {
                        ManageHome manageHome = new ManageHome();
                        Window expr_25 = manageHome;
                        if (-1 != 0)
                        {
                            expr_25.Show();
                        }
                        if (6 == 0)
                        {
                            goto IL_19;
                        }
                    }
                    base.Close();
                IL_19: ;
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    while (-1 == 0);
                }
            }
            while (!true);
            if (!false)
            {
            }
        }

        private void Import(string filedatasource)
        {
            if (filedatasource != string.Empty)
            {
                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(OfflineMasterDataFile));
                    FileStream fileStream = new FileStream(filedatasource, FileMode.Open);
                    OfflineMasterDataFile offlineMasterDataFile;
                    try
                    {
                        offlineMasterDataFile = (OfflineMasterDataFile)xmlSerializer.Deserialize(fileStream);
                    }
                    finally
                    {
                        if (fileStream != null)
                        {
                            if (7 != 0)
                            {
                                ((IDisposable)fileStream).Dispose();
                            }
                        }
                    }
                    bool arg_126_0;
                    bool arg_D6_0;
                    if (LoginUser.countrycode.ToLower() == offlineMasterDataFile.Venue.CountryCode.ToLower())
                    {
                        bool expr_A6 = arg_126_0 = (LoginUser.StoreName.ToLower() == offlineMasterDataFile.Venue.VenueName.ToLower());
                        if (7 == 0)
                        {
                            goto IL_126;
                        }
                        if (expr_A6)
                        {
                            arg_D6_0 = !(LoginUser.Storecode.ToLower() == offlineMasterDataFile.Venue.VenueCode.ToLower());
                            goto IL_D5;
                        }
                    }
                    arg_D6_0 = true;
                IL_D5:
                    if (arg_D6_0)
                    {
                        System.Windows.MessageBox.Show("The file does not contain the valid Country/Venue.");
                        goto IL_429;
                    }
                    Site site = (from c in offlineMasterDataFile.Venue.SiteDetails
                                 where c.SiteCode.Length > 4
                                 select c).FirstOrDefault<Site>();
                    bool flag = site != null;
                    if (2 == 0)
                    {
                        goto IL_2E6;
                    }
                    arg_126_0 = flag;
                IL_126:
                    if (arg_126_0)
                    {
                        System.Windows.MessageBox.Show("The file contain wrong site code.");
                        goto IL_413;
                    }
                IL_12B:
                    List<Site> list = new List<Site>();
                    List<Item> list2 = new List<Item>();
                    List<PackageDetail> list3 = new List<PackageDetail>();
                    using (List<Site>.Enumerator enumerator = offlineMasterDataFile.Venue.SiteDetails.GetEnumerator())
                    {
                        while (true)
                        {
                            bool arg_23C_0;
                            bool expr_230 = arg_23C_0 = enumerator.MoveNext();
                            if (8 != 0)
                            {
                                flag = expr_230;
                                arg_23C_0 = flag;
                            }
                            if (!arg_23C_0)
                            {
                                break;
                            }
                            Site current = enumerator.Current;
                            list.Add(current);
                            foreach (Item current2 in current.ItemDetails)
                            {
                                current2.ItemSiteSyncCode = current.SiteSyncCode;
                                list2.Add(current2);
                                do
                                {
                                    foreach (PackageDetail current3 in current2.PackageKittingDetails)
                                    {
                                        current3.PkgSiteSyncCode = current.SiteSyncCode;
                                        current3.pkgitemcode = current2.ItemCode;
                                        list3.Add(current3);
                                    }
                                }
                                while (false);
                            }
                        }
                    }
                    this.dtpkg = ManageMasterData.ConvertListToDataTable(list3);
                    this.dtSite = this.ToDataTable<Site>(list);
                    this.dtItem = this.ToDataTable<Item>(list2);
                    DataView dataView = new DataView(this.dtSite);
                    if (5 == 0)
                    {
                        goto IL_403;
                    }
                    this.dtSite = dataView.ToTable("Selected", false, new string[]
					{
						"SiteName",
						"SiteCode",
						"SiteSyncCode",
						"IsLogical",
						"LogicalSyncCode"
					});
                    dataView = new DataView(this.dtItem);
                IL_2E6:
                    this.dtItem = dataView.ToTable("Selected", false, new string[]
					{
						"ItemName",
						"ItemCode",
						"IsPackage",
						"IsAccessory",
						"IsActive",
						"ItemSyncCode",
						"Price",
						"ItemSiteSyncCode",
						"ItemDescription"
					});
                    dataView = new DataView(this.dtpkg);
                    if (!false)
                    {
                        this.dtpkg = dataView.ToTable("Selected", false, new string[]
						{
							"ItemName",
							"ItemCode",
							"IsPackage",
							"IsAccessory",
							"IsActive",
							"ItemSyncCode",
							"Price",
							"MaxImages",
							"PkgSiteSyncCode",
							"ItemDescription",
							"pkgitemcode"
						});
                        this.bs.Show();
                        this.BackupWorker.RunWorkerAsync();
                    }
                IL_403:
                IL_413:
                    if (!true)
                    {
                        goto IL_12B;
                    }
                IL_429: ;
                }
                catch (InvalidOperationException var_11_456)
                {
                    System.Windows.MessageBox.Show("Invalid xml file.");
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable;
            if (8 != 0)
            {
                dataTable = new DataTable(typeof(T).Name);
            }
            DataTable result;
            do
            {
                PropertyInfo[] properties;
                if (4 != 0)
                {
                    properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                }
                PropertyInfo[] expr_14F = properties;
                PropertyInfo[] array;
                if (!false)
                {
                    array = expr_14F;
                }
                int i = 0;
                if (2 == 0)
                {
                    return result;
                }
                while (i < array.Length)
                {
                    PropertyInfo propertyInfo = array[i];
                    dataTable.Columns.Add(propertyInfo.Name);
                    i++;
                }
                using (List<T>.Enumerator enumerator = items.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (!false)
                        {
                            T current = enumerator.Current;
                            object[] array2 = new object[properties.Length];
                            int num = 0;
                            while (true)
                            {
                                bool flag = num < properties.Length;
                                if (6 != 0)
                                {
                                    if (!flag)
                                    {
                                        break;
                                    }
                                    array2[num] = properties[num].GetValue(current, null);
                                }
                                num++;
                            }
                            dataTable.Rows.Add(array2);
                        }
                    }
                }
            }
            while (8 == 0 || 5 == 0);
            result = dataTable;
            return result;
        }

        private static DataTable ConvertListToDataTable(List<PackageDetail> list)
        {
            DataTable dataTable = new DataTable(typeof(PackageDetail).Name);
            PropertyInfo[] properties = typeof(PackageDetail).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] properties2 = typeof(Item).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] array;
            int num;
            if (2 != 0)
            {
                array = properties;
                num = 0;
                goto IL_C9;
            }
        IL_6E:
            PropertyInfo[] array2 = properties2;
            for (int i = 0; i < array2.Length; i++)
            {
                PropertyInfo propertyInfo = array2[i];
                dataTable.Columns.Add(propertyInfo.Name);
                if (false)
                {
                    break;
                }
            }
        IL_C2:
            num++;
        IL_C9:
            if (num >= array.Length)
            {
                using (List<PackageDetail>.Enumerator enumerator = list.GetEnumerator())
                {
                    while (true)
                    {
                    IL_1BD:
                        bool arg_1C4_0 = enumerator.MoveNext();
                    IL_1C4:
                        while (arg_1C4_0)
                        {
                            PackageDetail current = enumerator.Current;
                            int num2 = 0;
                            object[] array3 = new object[properties.Length + properties2.Length - 1];
                            int num3 = 0;
                            if (5 != 0)
                            {
                                goto IL_19E;
                            }
                        IL_110:
                            bool flag = num3 != 1;
                            bool arg_11D_0 = flag;
                            while (arg_11D_0)
                            {
                                array3[num2] = properties[num3].GetValue(current, null);
                                if (num3 != 0)
                                {
                                    int expr_18A = (arg_11D_0 = (num2 != 0)) ? 1 : 0;
                                    if (4 == 0)
                                    {
                                        continue;
                                    }
                                    num2 = expr_18A + 1;
                                }
                            IL_197:
                                num3++;
                                goto IL_19E;
                            }
                            int num4 = 0;
                            int arg_1A3_0;
                            while (true)
                            {
                                int expr_149 = arg_1A3_0 = num4;
                                if (false)
                                {
                                    goto IL_1A0;
                                }
                                bool expr_151 = arg_1C4_0 = (expr_149 < properties2.Length);
                                if (8 == 0)
                                {
                                    goto IL_1C4;
                                }
                                if (!expr_151)
                                {
                                    goto Block_11;
                                }
                                if (4 == 0)
                                {
                                    break;
                                }
                                array3[num3 + num4] = properties2[num4].GetValue(current.BaseProduct, null);
                                num4++;
                            }
                    
                        Block_11:
                            int arg_167_0;
                            int expr_15E = arg_167_0 = properties.Length;
                            int arg_167_1;
                            int expr_160 = arg_167_1 = properties2.Length;
                            if (!false)
                            {
                                arg_167_0 = expr_15E + expr_160;
                                arg_167_1 = 3;
                            }
                            num2 = arg_167_0 - arg_167_1;
                           // goto IL_16B;
                        IL_1A0:
                            if (arg_1A3_0 >= properties.Length)
                            {
                                dataTable.Rows.Add(array3);
                                goto IL_1BD;
                            }
                            goto IL_110;
                        IL_19E:
                            arg_1A3_0 = num3;
                            goto IL_1A0;
                        }
                        break;
                    }
                }
                return dataTable;
            }
            PropertyInfo propertyInfo2 = array[num];
            if (propertyInfo2.Name == "BaseProduct")
            {
                goto IL_6E;
            }
            dataTable.Columns.Add(propertyInfo2.Name);
            goto IL_C2;
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            this.BackupWorker = new BackgroundWorker();
            this.BackupWorker.DoWork += new DoWorkEventHandler(this.BackupWorker_DoWork);
            this.BackupWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BackupWorker_RunWorkerCompleted);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select file";
            openFileDialog.Filter = "XML File(*.xml)|*.xml|All Files(*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this._filedatasource = openFileDialog.FileName;
                string[] source = openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
                this.packagefilename = source.Last<string>();
                string[] array = this.packagefilename.Split(new char[]
				{
					'.'
				});
                if (array[1] == "xml")
                {
                    this.Import(this._filedatasource);
                    System.Windows.Forms.Application.DoEvents();
                }
                else
                {
                    System.Windows.MessageBox.Show("Please select a valid file(.xml)");
                }
            }
        }

        private void BackupWorker_DoWork(object Sender, DoWorkEventArgs e)
        {
            while (true)
            {
                bool flag = new CommonBusiness().ImportMasterData(this.dtSite, this.dtItem, this.dtpkg);
                if (!false)
                {
                    bool arg_34_0;
                    bool expr_77 = arg_34_0 = flag;
                    if (false || 8 == 0)
                    {
                        goto IL_34;
                    }
                    bool flag2 = !expr_77;
                    if (!false)
                    {
                        arg_34_0 = flag2;
                        goto IL_34;
                    }
                IL_37:
                    System.Windows.MessageBox.Show("Master Data imported successfully.");
                    if (!false)
                    {
                        break;
                    }
                    continue;
                IL_34:
                    if (!arg_34_0)
                    {
                        goto IL_37;
                    }
                    goto IL_48;
                }
            }
            return;
        IL_48:
            System.Windows.MessageBox.Show("There is some error while importing master data");
        }

        private void BackupWorker_RunWorkerCompleted(object Sender, RunWorkerCompletedEventArgs e)
        {
            this.bs.Hide();
        }

        private bool IsAllColumnExist(DataTable tableNameToCheck)
        {
            List<string> list = new List<string>();
            list.Add("ProfileName");
            if (!false)
            {
                list.Add("StartDate");
            }
            bool result;
            while (true)
            {
                list.Add("EndDate");
                list.Add("CurrencyRate");
                while (!false)
                {
                    list.Add("CurrencyName");
                    list.Add("CurrencyCode");
                    list.Add("PublishedOn");
                    list.Add("VenueName");
                    list.Add("CountryName");
                    if (!false)
                    {
                        if (5 != 0)
                        {
                            bool flag = true;
                            try
                            {
                                if (tableNameToCheck != null && tableNameToCheck.Columns != null)
                                {
                                    using (List<string>.Enumerator enumerator = list.GetEnumerator())
                                    {
                                        while (true)
                                        {
                                            while (enumerator.MoveNext())
                                            {
                                                string current = enumerator.Current;
                                                if (!tableNameToCheck.Columns.Contains(current))
                                                {
                                                    flag = false;
                                                    if (!false)
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                            break;
                                        }
                                    }
                                    goto IL_108;
                                }
                            IL_105:
                                flag = false;
                            IL_108:
                                if (-1 == 0)
                                {
                                    goto IL_105;
                                }
                            }
                            catch (Exception var_3_10E)
                            {
                            }
                            result = flag;
                            return result;
                        }
                        return result;
                    }
                }
            }
            return result;
        }

 
    }
}
