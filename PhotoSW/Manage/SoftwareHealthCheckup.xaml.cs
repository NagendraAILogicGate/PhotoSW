using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper.Common;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Security.Principal;
using System.ServiceProcess;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Markup;
using DigiPhoto;
using PhotoSW.Views;

namespace PhotoSW.Manage
{
    public partial class SoftwareHealthCheckup : Window, IComponentConnector, IStyleConnector
    {
        protected PerformanceCounter cpuCounter;

        protected PerformanceCounter ramCounter;

       

        public SoftwareHealthCheckup()
        {
            try
            {
                this.InitializeComponent();
                this.GetAllrunningServices();
                this.txbUserName.Text = LoginUser.UserName;
                this.txbStoreName.Text = LoginUser.StoreName;
                this.cpuCounter = new PerformanceCounter();
                this.cpuCounter.CategoryName = "Processor";
                this.cpuCounter.CounterName = "% Processor Time";
                this.cpuCounter.InstanceName = "_Total";
                this.ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                this.DigiDate.Text = "Digi " + this.CurrentRegistryVersion();
                this.SystemMetaData();
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private string CurrentRegistryVersion()
        {
            while (-1 == 0)
            {
            }
            if (6 == 0)
            {
                goto IL_21;
            }
            ModifyRegistry modifyRegistry = new ModifyRegistry();
        IL_0B:
            string text;
            if (!false)
            {
                text = modifyRegistry.Read("InstallVersion");
            }
            string expr_3E = text;
            string result;
            if (7 != 0)
            {
                result = expr_3E;
            }
        IL_21:
            if (!false)
            {
                return result;
            }
            goto IL_0B;
        }

        public string getCurrentCpuUsage()
        {
            if (!true)
            {
                goto IL_21;
            }
            if (!false)
            {
            }
        IL_07:
            string result;
            if (3 != 0)
            {
                result = this.cpuCounter.NextValue() + "%";
            }
        IL_21:
            if (8 != 0)
            {
                return result;
            }
            goto IL_07;
        }

        public string getAvailableRAM()
        {
            string result;
            while (true)
            {
                if (!false)
                {
                }
                while (8 != 0)
                {
                    float num = this.ramCounter.NextValue();
                    if (false)
                    {
                        break;
                    }
                    result = num.ToString();
                    if (8 != 0)
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        public static bool IsAdministrator()
        {
            WindowsIdentity current = WindowsIdentity.GetCurrent();
            bool arg_13_0;
            bool expr_08 = arg_13_0 = (null == current);
            if (4 != 0)
            {
                bool flag;
                if (!false)
                {
                    flag = expr_08;
                }
                arg_13_0 = flag;
            }
            bool result;
            if (arg_13_0)
            {
                if (!false)
                {
                    result = false;
                    return result;
                }
                goto IL_2F;
            }
        IL_15:
        IL_16:
            if (false)
            {
                goto IL_15;
            }
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
            if (!false)
            {
                result = windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        IL_2F:
            if (4 == 0)
            {
                goto IL_16;
            }
            return result;
        }

        private void LoadPieChartData(double available, double used, double application, double total)
        {
            KeyValuePair<string, double>[] array;
            do
            {
                DataPointSeries arg_67_0 = (PieSeries)this.mcChart.Series[0];
                KeyValuePair<string, double>[] expr_1C = new KeyValuePair<string, double>[2];
                if (!false)
                {
                    array = expr_1C;
                }
                array[0] = new KeyValuePair<string, double>("Available Memory (in MB)", available);
                array[1] = new KeyValuePair<string, double>("System Memory Consumption(in MB)", used);
                arg_67_0.ItemsSource = array;
            }
            while (6 == 0);
            DataPointSeries arg_BD_0 = (PieSeries)this.mcChart1.Series[0];
            array = new KeyValuePair<string, double>[]
			{
				new KeyValuePair<string, double>("Total Memory", total),
				new KeyValuePair<string, double>("DigiPhoto Consumption", application)
			};
            arg_BD_0.ItemsSource = array;
        }

        public void SystemMetaData()
        {
            ObjectQuery query = new ObjectQuery("select Capacity from Win32_PhysicalMemory");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query);
            while (true)
            {
                ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
                double num = 0.0;
                while (true)
                {
                    using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator())
                    {
                        while (true)
                        {
                        IL_88:
                            bool flag = enumerator.MoveNext();
                            while (flag)
                            {
                                ManagementObject managementObject = (ManagementObject)enumerator.Current;
                                if (true)
                                {
                                    num += managementObject.GetPropertyValue("Capacity").ToDouble(false);
                                    goto IL_88;
                                }
                            }
                            break;
                        }
                    }
                    this.TotalMemory.Text = "Installed Memory(RAM): " + num / 1073741824.0 + " GB";
                    double used = num / 1024.0 / 1024.0 - this.getAvailableRAM().ToDouble(false);
                    double num2 = this.getAvailableRAM().ToDouble(false);
                    double num3 = num / 1024.0 / 1024.0;
                    used = num3 - num2;
                    PerformanceCounter performanceCounter = new PerformanceCounter("Process", "Working Set - Private", Process.GetCurrentProcess().ProcessName);
                    if (true)
                    {
                        this.LoadPieChartData(num2, used, (double)((float)performanceCounter.RawValue / 1024f / 1024f), num3);
                        ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("SELECT Name FROM Win32_Processor");
                        ManagementObjectCollection managementObjectCollection2 = managementObjectSearcher2.Get();
                        string str = string.Empty;
                        using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection2.GetEnumerator())
                        {
                            while (enumerator.MoveNext())
                            {
                                ManagementObject managementObject2 = (ManagementObject)enumerator.Current;
                                do
                                {
                                    str = managementObject2["Name"].ToString();
                                }
                                while (5 == 0);
                            }
                        }
                        this.Processor.Text = "Processor: " + str;
                        this.OS.Text = "Operating System: " + Environment.OSVersion.ToString();
                    }
                    this.MachineName.Text = "Computer Name: " + Environment.MachineName.ToString();
                    if (7 != 0)
                    {
                        goto Block_5;
                    }
                }
            }
        Block_5:
            if (Environment.Is64BitOperatingSystem && 7 != 0)
            {
                this.SystemType.Text = "System Type : 64-bit Operating System";
            }
            else if (!false)
            {
                this.SystemType.Text = "System Type : 32-bit Operating System";
            }
            this.CPUUsage.Text = "CPU Usage: " + this.getCurrentCpuUsage();
        }

        private void GetAllrunningServices()
        {
            ServicesStatus servicesStatus = null;
            List<ServicesInfo> runningServices = new SoftwareHealthCheckBusiness().GetRunningServices();
            this.lstServices.Items.Clear();
            using (List<ServicesInfo>.Enumerator enumerator = runningServices.GetEnumerator())
            {
                while (true)
                {
                    bool arg_8C_0;
                    bool expr_204 = arg_8C_0 = enumerator.MoveNext();
                    if (false)
                    {
                        goto IL_8B;
                    }
                    if (!expr_204)
                    {
                        break;
                    }
                    ServicesInfo current = enumerator.Current;
                    servicesStatus = new ServicesStatus();
                    if (false)
                    {
                        goto IL_1D6;
                    }
                    Process[] processesByName;
                    if (current.DG_Sevice_Name == "DigiEmailService")
                    {
                        processesByName = Process.GetProcessesByName("EmailService");
                        goto IL_10B;
                    }
                    arg_8C_0 = (current.DG_Sevice_Name == "DigiphotoDataSyncService");
                    goto IL_8B;
                IL_1EF:
                    this.lstServices.Items.Add(servicesStatus);
                    continue;
                IL_10B:
                    Process process = processesByName.FirstOrDefault<Process>();
                    if (process != null)
                    {
                        servicesStatus.ButtonText = "Stop";
                        servicesStatus.RunningStatus = "Running";
                        servicesStatus.ServiceName = current.DG_Service_Display_Name;
                        servicesStatus.Originalservicename = current.DG_Sevice_Name;
                        servicesStatus.ServicePath = current.DG_Service_Path;
                        servicesStatus.IsInterface = current.IsInterface;
                        servicesStatus.BackColor = "#9AFF9A";
                        servicesStatus.BackOffsetColor = "#006400";
                        goto IL_1EF;
                    }
                    servicesStatus.ButtonText = "Start";
                    servicesStatus.RunningStatus = "Not running";
                    if (!false)
                    {
                        servicesStatus.ServiceName = current.DG_Service_Display_Name;
                        servicesStatus.Originalservicename = current.DG_Sevice_Name;
                        servicesStatus.ServicePath = current.DG_Service_Path;
                        servicesStatus.IsInterface = current.IsInterface;
                        goto IL_1D5;
                    }
                IL_1E1:
                    servicesStatus.BackOffsetColor = "#FFB60000";
                    goto IL_1EF;
                IL_1D6:
                    servicesStatus.BackColor = "#FFE46B6B";
                    goto IL_1E1;
                IL_8B:
                    if (arg_8C_0)
                    {
                        processesByName = Process.GetProcessesByName("DataSyncWinService");
                        goto IL_10B;
                    }
                    if (false)
                    {
                        break;
                    }
                    bool arg_E3_0;
                    bool expr_B2 = arg_E3_0 = (current.DG_Sevice_Name == "DigiPreSoldService");
                    if (6 != 0)
                    {
                        if (expr_B2)
                        {
                            processesByName = Process.GetProcessesByName("PreSoldService");
                            goto IL_10B;
                        }
                        arg_E3_0 = !(current.DG_Sevice_Name == "DigiReportExportService");
                    }
                    bool flag = arg_E3_0;
                    if (!false && flag)
                    {
                        processesByName = Process.GetProcessesByName(current.DG_Sevice_Name);
                        goto IL_10B;
                    }
                    if (!false)
                    {
                        processesByName = Process.GetProcessesByName("DGReportExportService");
                        goto IL_10B;
                    }
                IL_1D5:
                    goto IL_1D6;
                }
            }
        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string text;
                int arg_183_0;
                int arg_183_1;
                Process[] array;
                int num=0;
                if (true)
                {
                    new Process();
                    new Button();
                    Button button = (Button)sender;
                    ServiceController serviceController;
                    while (true)
                    {
                        text = button.Tag.ToString();
                        if (button.Content.ToString() == "Start")
                        {
                            break;
                        }
                        if (button.ToolTip.ToBoolean(false))
                        {
                            goto Block_8;
                        }
                        serviceController = new ServiceController(text);
                        string a = serviceController.Status.ToString();
                        if (!(a != "Stopped"))
                        {
                            goto IL_1D8;
                        }
                        if (true)
                        {
                            goto IL_1C6;
                        }
                    }
                    int expr_64 = arg_183_0 = (button.ToolTip.ToBoolean(false) ? 1 : 0);
                    int expr_6A = arg_183_1 = 0;
                    if (expr_6A == 0)
                    {
                        ProcessStartInfo processStartInfo;
                        if (expr_64 != expr_6A)
                        {
                            if (!false)
                            {
                                processStartInfo = new ProcessStartInfo
                                {
                                    UseShellExecute = true,
                                    FileName = button.CommandParameter.ToString()
                                };
                                if (SoftwareHealthCheckup.IsAdministrator())
                                {
                                    //goto IL_C1;
                                }
                            }
                        }
                        else
                        {
                            serviceController = new ServiceController(text);
                            serviceController.Start();
                            if (!false)
                            {
                                goto IL_FF;
                            }
                        }
                        processStartInfo.Verb = "runas";
                        if (false)
                        {
                            goto IL_1C6;
                        }
                        try
                        {
                        IL_C1:
                            Process.Start(processStartInfo);
                        }
                        catch (Win32Exception serviceException)
                        {
                            ErrorHandler.ErrorHandler.LogError(serviceException);
                        }
                        this.btnback.Focus();
                    IL_FF:
                        goto IL_1DA;
                    }
                    goto IL_183;
                Block_8:
                    Process[] processes = Process.GetProcesses();
                    array = processes;
                    num = 0;
                    goto IL_17D;
                IL_1C6:
                    serviceController.Stop();
                    serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                IL_1D8:
                    goto IL_1D9;
                }
            IL_12D:
               
                array =  Process.GetProcesses();
                Process process = array[num];
                if (process.ProcessName == text)
                {
                    try
                    {
                        process.Kill();
                        if (!false)
                        {
                            Thread.Sleep(2000);
                        }
                    }
                    catch (Exception serviceException2)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException2);
                    }
                }
                num++;
            IL_17D:
                arg_183_0 = num;
                arg_183_1 = array.Length;
            IL_183:
                if (arg_183_0 < arg_183_1)
                {
                    goto IL_12D;
                }
            IL_1D9:
            IL_1DA:
                this.GetAllrunningServices();
            }
            catch (Exception serviceException2)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException2);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (2 != 0)
                {
                    int expr_28 = LoginUser.UserId;
                    if (8 != 0)
                    {
                        AuditLog.AddUserLog(expr_28, 39, "Logged out at ");
                    }
                    Login login = new Login();
                    login.Show();
                }
                do
                {
                    base.Close();
                }
                while (false);
            }
            catch (Exception serviceException)
            {
                do
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (6 == 0);
            }
            finally
            {
                MemoryManagement.FlushMemory();
            }
            if (5 != 0)
            {
            }
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
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

        private void btnexplore_Click(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                try
                {
                    this.Datetimelist.Items.Clear();
                    this.versionlist.Items.Clear();
                    List<VersionHistoryInfo> versionDetails = new SoftwareHealthCheckBusiness().GetVersionDetails(Environment.MachineName);
                    List<VersionHistoryInfo>.Enumerator enumerator = versionDetails.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            bool expr_A6 = enumerator.MoveNext();
                            bool flag;
                            if (5 != 0)
                            {
                                flag = expr_A6;
                                goto IL_B0;
                            }
                        IL_82:
                            DateTime dateTime;
                            if (!false)
                            {
                                this.Datetimelist.Items.Add(dateTime.ToString("MMMM dd yyyy, hh:mm:ss"));
                                continue;
                            }
                        IL_B0:
                            if (!flag)
                            {
                                break;
                            }
                            VersionHistoryInfo current = enumerator.Current;
                            dateTime = new DateTime(current.DG_Version_Date.Ticks);
                            this.versionlist.Items.Add(current.DG_Version_Number);
                            goto IL_82;
                        }
                    }
                    finally
                    {
                        do
                        {
                            ((IDisposable)enumerator).Dispose();
                        }
                        while (false);
                    }
                    this.GrdPopup.Visibility = Visibility.Visible;
                }
                catch (Exception serviceException)
                {
                    while (true)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                        while (8 != 0)
                        {
                            if (!false)
                            {
                                goto Block_10;
                            }
                        }
                    }
                Block_10: ;
                }
            }
        }

        private void btncloseversion_Click(object sender, RoutedEventArgs e)
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
                                this.GrdPopup.Visibility = Visibility.Collapsed;
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

        void IStyleConnector.Connect(int connectionId, object target)
        {
            while (true)
            {
                if (8 == 0)
                {
                    goto IL_15;
                }
                int arg_0E_0 = connectionId;
                if (8 != 0)
                {
                    arg_0E_0 = connectionId;
                }
                if (arg_0E_0 == 1 || false)
                {
                    goto IL_15;
                }
            IL_2E:
                if (!false)
                {
                    break;
                }
                continue;
            IL_15:
                ((Button)target).Click += new RoutedEventHandler(this.btnAction_Click);
                goto IL_2E;
            }
        }
    }
}
