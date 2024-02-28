using DigiAuditLogger;
using PhotoSW.Common;
using DigiPhoto.DataLayer;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media;
using PhotoSW.Views;
using PhotoSW.IMIX.Business;
using PhotoSW.DataLayer;
namespace PhotoSW.Manage
{
    public partial class ManageCurrencyProfile : Window, IComponentConnector, IStyleConnector
    {
        private string _filedatasource = string.Empty;
        private string packagefilename = string.Empty;
        private CurrencyExchangeBussiness _objCurrencyBusiness = null;
        private BackgroundWorker BackupWorker;
        private BusyWindow bs = new BusyWindow();
        private DataTable _dtExcel;
        private DataTable _dt;

        public ManageCurrencyProfile()
        {
            this.InitializeComponent();
            this.GetProfileData();
            this.CtrlProfileRate.SetParent(this.modelparent);
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
        }

        private void GetProfileData()
        {
            do
            {
                List<CurrencyExchangeinfo> itemsSource;
                if (8 != 0)
                {
                    this._objCurrencyBusiness = new CurrencyExchangeBussiness();
                    itemsSource = new List<CurrencyExchangeinfo>();
                    if (!false)
                    {
                        itemsSource = this._objCurrencyBusiness.GetCurrencyProfileList();
                    }
                }
                if (!false)
                {
                    this.dgProfile.ItemsSource = itemsSource;
                }
            }
            while (false);
        }

        private void dgProfile_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            while (true)
            {
            IL_00:
                while (true)
                {
                    DataGridRow row = e.Row;
                    DataRowView arg_5E_0 = row.Item as DataRowView;
                    bool arg_1E_0 = ((CurrencyExchangeinfo)row.Item).IsCurrent;
                    while (true)
                    {
                        bool flag = !arg_1E_0;
                        while (true)
                        {
                            bool expr_21 = arg_1E_0 = flag;
                            if (false)
                            {
                                break;
                            }
                            if (expr_21)
                            {
                                goto IL_3D;
                            }
                            e.Row.Background = Brushes.LightGreen;
                        IL_38:
                            if (false)
                            {
                                continue;
                            }
                        IL_3D:
                            if (false)
                            {
                                goto IL_00;
                            }
                            if (!false)
                            {
                                goto Block_3;
                            }
                            goto IL_38;
                        }
                    }
                Block_3:
                    if (true)
                    {
                        return;
                    }
                }
            }
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

        private void btndetail_Click(object sender, RoutedEventArgs e)
        {
            if (-1 != 0 && 8 != 0)
            {
                if (true)
                {
                    if (7 == 0)
                    {
                        return;
                    }
                    this.CtrlProfileRate.ProfileID = ((System.Windows.Controls.Button)sender).Tag.ToInt64(false);
                }
            }
            this.CtrlProfileRate.ShowHandlerDialog("Rate detail");
        }

        private void Import(string filedatasource)
        {
            if (filedatasource != string.Empty)
            {
                try
                {
                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filedatasource + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                    OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    oleDbCommand.CommandType = CommandType.Text;
                    oleDbCommand.Connection = oleDbConnection;
                    OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand);
                    this._dtExcel = new DataTable("Package");
                    oleDbConnection.Open();
                    DataTable oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    int i;
                    for (i = 0; i < oleDbSchemaTable.Rows.Count; i++)
                    {
                        if (oleDbSchemaTable.Rows[i]["Table_Name"].ToString().EndsWith("$"))
                        {
                            break;
                        }
                    }
                    if (i >= oleDbSchemaTable.Rows.Count)
                    {
                        throw new Exception("There is no valid Excel Sheet");
                    }
                    string str = oleDbSchemaTable.Rows[i]["Table_Name"].ToString();
                    oleDbCommand.CommandText = "SELECT * FROM [" + str + "]";
                    oleDbDataAdapter.SelectCommand = oleDbCommand;
                    oleDbDataAdapter.Fill(this._dtExcel);
                    oleDbConnection.Close();
                    if (!this.IsAllColumnExist(this._dtExcel))
                    {
                        throw new Exception("Please upload a valid Excel Sheet");
                    }
                    DataColumn column = new DataColumn("SyncCode", typeof(string));
                    this._dtExcel.Columns.Add(column);
                    string value = string.Empty;
                    string b = "";
                    string b2 = "";
                    string b3 = "";
                    foreach (DataRow dataRow in this._dtExcel.Rows)
                    {
                        if (!string.IsNullOrWhiteSpace(Convert.ToString(dataRow[0])))
                        {
                            if (Convert.ToString(dataRow[0]) != b && Convert.ToString(dataRow[8]) != b2 && Convert.ToString(dataRow[7]) != b3)
                            {
                                b = Convert.ToString(dataRow[0]);
                                b2 = Convert.ToString(dataRow[8]);
                                b3 = Convert.ToString(dataRow[7]);
                                value = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Product).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
                            }
                        }
                        dataRow["SyncCode"] = value;
                    }
                    this._dt = this._dtExcel.Rows.Cast<DataRow>().Where(delegate(DataRow row)
                    {
                        bool arg_3A_0;
                        while (true)
                        {
                            bool arg_26_0 = row.ItemArray.All(delegate(object field)
                            {
                                if (-1 == 0)
                                {
                                    goto IL_26;
                                }
                                int arg_3E_0;
                                int arg_30_0;
                                if (!(field is DBNull))
                                {
                                    int expr_37 = arg_30_0 = (arg_3E_0 = string.Compare(field as string, string.Empty));
                                    if (false)
                                    {
                                        goto IL_2A;
                                    }
                                    arg_3E_0 = ((expr_37 == 0) ? 1 : 0);
                                }
                                else
                                {
                                    arg_3E_0 = 1;
                                }
                            IL_23:
                            IL_24:
                                bool flag2 = arg_3E_0 != 0;
                            IL_26:
                                arg_3E_0 = (arg_30_0 = (flag2 ? 1 : 0));
                            IL_2A:
                                if (false)
                                {
                                    goto IL_24;
                                }
                                if (true)
                                {
                                    return arg_30_0 != 0;
                                }
                                goto IL_23;
                            });
                            while (true)
                            {
                                bool expr_26 = arg_26_0 = (arg_3A_0 = !arg_26_0);
                                if (!false)
                                {
                                    bool flag = expr_26;
                                    if (!false)
                                    {
                                    }
                                    if (false)
                                    {
                                        break;
                                    }
                                    arg_3A_0 = (arg_26_0 = flag);
                                }
                                if (7 != 0)
                                {
                                    return arg_3A_0;
                                }
                            }
                        }
                        return arg_3A_0;
                    }).CopyToDataTable<DataRow>();
                    DataView dataView = new DataView(this._dt);
                    this._dt = dataView.ToTable("Selected", false, new string[]
					{
						"ProfileName",
						"StartDate",
						"EndDate",
						"CurrencyRate",
						"CurrencyName",
						"CurrencyCode",
						"VenueName",
						"CountryName",
						"PublishedOn",
						"SyncCode"
					});
                    this.bs.Show();
                    this.BackupWorker.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            this.BackupWorker = new BackgroundWorker();
            this.BackupWorker.DoWork += new DoWorkEventHandler(this.BackupWorker_DoWork);
            this.BackupWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BackupWorker_RunWorkerCompleted);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (-1 != 0)
            {
                openFileDialog.Title = "Select file";
                while (true)
                {
                    openFileDialog.Filter = "Excel Sheet(*.xls)|*.xls|Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
                    while (true)
                    {
                        openFileDialog.FilterIndex = 1;
                        if (false)
                        {
                            goto IL_A1;
                        }
                        if (false)
                        {
                            break;
                        }
                        openFileDialog.RestoreDirectory = true;
                        if (!false)
                        {
                            goto Block_4;
                        }
                    }
                }
            Block_4:
                bool flag = openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK;
                int arg_9B_0 = flag ? 1 : 0;
            IL_9B:
                if (arg_9B_0 != 0)
                {
                    return;
                }
            IL_A1:
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
                int arg_11D_0;
                if (!(array[1] == "xls"))
                {
                    bool expr_108 = (arg_9B_0 = (arg_11D_0 = ((array[1] == "xlsx") ? 1 : 0))) != 0;
                    if (4 != 0)
                    {
                        arg_11D_0 = (arg_9B_0 = ((!expr_108) ? 1 : 0));
                    }
                }
                else
                {
                    arg_11D_0 = (arg_9B_0 = 0);
                }
                if (7 == 0)
                {
                    goto IL_9B;
                }
                bool expr_11E;
                do
                {
                    flag = (arg_11D_0 != 0);
                    expr_11E = ((arg_11D_0 = (flag ? 1 : 0)) != 0);
                }
                while (false);
                if (!expr_11E)
                {
                    this.Import(this._filedatasource);
                    System.Windows.Forms.Application.DoEvents();
                }
                else
                {
                    System.Windows.MessageBox.Show("Please select a valid file(.xls/.xlsx)");
                }
            }
        }

        private void BackupWorker_DoWork(object Sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (8 != 0)
                {
                    bool flag = new CurrencyExchangeBussiness().UploadCurrencyData((long)LoginUser.UserId, DateTime.Now, this._dt);
                    if (!false)
                    {
                        bool arg_1C_0 = flag;
                        bool expr_1C;
                        do
                        {
                            expr_1C = (arg_1C_0 = !arg_1C_0);
                        }
                        while (false);
                        if (expr_1C)
                        {
                            goto IL_3C;
                        }
                    }
                }
            IL_28:
                System.Windows.MessageBox.Show("Currency imported successfully.");
                if (false)
                {
                    continue;
                }
                if (!false)
                {
                    break;
                }
                goto IL_28;
            }
            return;
        IL_3C:
            System.Windows.MessageBox.Show("There is some error while saving Currency");
        }

        private void BackupWorker_RunWorkerCompleted(object Sender, RunWorkerCompletedEventArgs e)
        {
            this.bs.Hide();
            this.GetProfileData();
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

        void IStyleConnector.Connect(int connectionId, object target)
        {
            while (true)
            {
                if (8 == 0)
                {
                    goto IL_16;
                }
                int arg_0F_0 = connectionId;
                if (8 != 0)
                {
                    arg_0F_0 = connectionId;
                }
                if (arg_0F_0 == 14 || false)
                {
                    goto IL_16;
                }
            IL_2F:
                if (!false)
                {
                    break;
                }
                continue;
            IL_16:
                ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btndetail_Click);
                goto IL_2F;
            }
        }
    }
}
