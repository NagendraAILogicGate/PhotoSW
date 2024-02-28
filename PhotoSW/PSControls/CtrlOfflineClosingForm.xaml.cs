using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;

namespace PhotoSW.PSControls
{
    public partial class CtrlOfflineClosingForm : UserControl, IComponentConnector
    {
        private UIElement _parent;

        private bool _hideRequest = false;

        private string _result;

        private TextBox controlon;

        private SaveFileDialog dlg = new SaveFileDialog();

        //private bool _contentLoaded;

        public string encData
        {
            get;
            set;
        }

        public string filename
        {
            get;
            set;
        }

        public CtrlOfflineClosingForm()
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
            base.Visibility = Visibility.Visible;
            this._hideRequest = false;
            string result;
            while (true)
            {
                int arg_99_0;
                int arg_50_0;
                int arg_4E_0;
                bool expr_8E = (arg_4E_0 = (arg_50_0 = (arg_99_0 = (this._hideRequest ? 1 : 0)))) != 0;
                if (!false)
                {
                    arg_99_0 = ((!expr_8E) ? 1 : 0);
                    goto IL_99;
                }
            IL_47:
                bool flag;
                if (!false)
                {
                    if (8 == 0)
                    {
                        goto IL_99;
                    }
                    flag = (arg_4E_0 != 0);
                    arg_50_0 = (flag ? 1 : 0);
                }
                if (arg_50_0 == 0)
                {
                    goto IL_A0;
                }
                base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                }));
                int arg_9B_0;
                int expr_83 = arg_9B_0 = 20;
                if (expr_83 != 0)
                {
                    Thread.Sleep(expr_83);
                    continue;
                }
            IL_9B:
                if (arg_9B_0 == 0)
                {
                    goto IL_A0;
                }
                if (!false)
                {
                    arg_50_0 = (base.Dispatcher.HasShutdownStarted ? (arg_4E_0 = (arg_99_0 = 0)) : (arg_4E_0 = (arg_99_0 = ((!base.Dispatcher.HasShutdownFinished) ? 1 : 0))));
                    goto IL_47;
                }
            IL_A7:
                if (!false)
                {
                    break;
                }
                continue;
            IL_A0:
                result = this._result;
                goto IL_A7;
            IL_99:
                flag = (arg_99_0 != 0);
                arg_9B_0 = (flag ? 1 : 0);
                goto IL_9B;
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

        private void btnShowhdeForm_Click(object sender, RoutedEventArgs e)
        {
            this._result = string.Empty;
            this.HideHandlerDialog();
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.dlg.FileName = this.filename;
                this.dlg.DefaultExt = ".xml";
                this.dlg.Filter = "Xml documents (.xml)|*.xml";
                if (false)
                {
                    goto IL_11B;
                }
                bool flag = this.IsEnabledExportToAnyDrive();
            IL_58:
                if (!flag)
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
                    while (!false)
                    {
                        flag = (driveInfo == null);
                        if (flag)
                        {
                            MessageBox.Show("No removable device found.");
                            return;
                        }
                        if (true)
                        {
                            break;
                        }
                    }
                    this.dlg.InitialDirectory = driveInfo.Name;
                    if (5 == 0)
                    {
                        goto IL_EE;
                    }
                }
                bool? flag2 = this.dlg.ShowDialog();
            IL_EE:
                flag = !(flag2 == true);
                if (flag)
                {
                    goto IL_12F;
                }
                string fileName = this.dlg.FileName;
            IL_11B:
                File.WriteAllText(fileName, this.encData);
            IL_127:
                if (6 == 0)
                {
                    goto IL_58;
                }
            IL_12F:
                if (false)
                {
                    goto IL_127;
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
                while (4 == 0)
                {
                }
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
                MessageBox.Show("You can save to removable device only.");
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
            MessageBox.Show("You can save to removable device only.");
            e.Cancel = true;
        }


    }
}
