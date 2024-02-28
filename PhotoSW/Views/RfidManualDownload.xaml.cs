using Baracoda.Cameleon.PC.Modularity.GuiFeatures;
using Baracoda.Cameleon.PC.Readers;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using FrameworkHelper.RfidLib;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;

namespace PhotoSW.Views
{
    public partial class RfidManualDownload : Window, IComponentConnector
    {
        private List<DataContainer> _readerList = new List<DataContainer>();

        private RfidBusiness _rfidBusiness = new RfidBusiness();

        private readonly MainModel _model;

        

        public RfidManualDownload()
        {
            this.InitializeComponent();
            OnGui.Initialize(Dispatcher.CurrentDispatcher);
            this._model = new MainModel();
            this._model.ListRefreshNeeded += new EventHandler(this.OnListRefreshNeeded);
            this._model.DataReceived += new EventHandler<DataEventArgs>(this.OnDataReceived);
            this.ShowWait();
        }

        private void ShowWait()
        {
            if (false)
            {
                goto IL_18;
            }
            if (-1 == 0)
            {
                goto IL_1F;
            }
            int arg_11_0 = this._readerList.Count<DataContainer>();
        IL_10:
            bool flag = arg_11_0 != 0;
        IL_18:
            bool expr_69 = (arg_11_0 = (flag ? 1 : 0)) != 0;
            if (false)
            {
                goto IL_10;
            }
            if (expr_69)
            {
                goto IL_49;
            }
        IL_1F:
            DataContainer dataContainer = new DataContainer();
            dataContainer.Id = "No Device Found.";
            dataContainer.TagId = "";
            this._readerList.Add(dataContainer);
        IL_49:
            this.DGUsbReader.ItemsSource = this._readerList;
        }

        private void OnDataReceived(object sender, DataEventArgs e)
        {
            while (true)
            {
                if (false)
                {
                    goto IL_26;
                }
            IL_19:
                if (false)
                {
                    continue;
                }
                BaracodaReaderBase baracodaReaderBase = (BaracodaReaderBase)sender;
            IL_26:
                bool arg_2F_0;
                bool arg_36_0 = arg_2F_0 = (baracodaReaderBase == null);
                while (7 != 0)
                {
                    bool expr_2F = arg_2F_0 = (arg_36_0 = !arg_2F_0);
                    if (!false)
                    {
                        bool flag = expr_2F;
                        arg_36_0 = flag;
                        break;
                    }
                }
                if (!arg_36_0)
                {
                    break;
                }
                OnGui.Run(delegate
                {
                    RfidManualDownload expr_06 = this;
                    DataContainer expr_A6 = e.RfidData;
                    if (5 != 0)
                    {
                        expr_06.SaveIntoDatabase(expr_A6);
                    }
                    DataContainer dataContainer = this._readerList.FirstOrDefault(delegate(DataContainer o)
                    {
                        int arg_29_0;
                        bool flag2;
                        while (4 != 0)
                        {
                            int arg_4C_0;
                            int expr_45 = arg_29_0 = (arg_4C_0 = string.Compare(o.TagId, e.RfidData.Id, true));
                            if (!false)
                            {
                                arg_4C_0 = (arg_29_0 = ((expr_45 == 0) ? 1 : 0));
                            }
                            if (6 == 0)
                            {
                                return arg_29_0 != 0;
                            }
                            if (!false)
                            {
                                flag2 = (arg_4C_0 != 0);
                            }
                            if (!false)
                            {
                                break;
                            }
                        }
                        arg_29_0 = (flag2 ? 1 : 0);
                        return arg_29_0 != 0;
                    });
                    if (dataContainer != null)
                    {
                        dataContainer.NoOfIdReceived++;
                    }
                    this.DGUsbReader.ItemsSource = this._readerList;
                    this.DGUsbReader.Items.Refresh();
                });
                if (-1 != 0)
                {
                    break;
                }
                goto IL_19;
            }
        }

        private void OnListRefreshNeeded(object sender, EventArgs e)
        {
            OnGui.Run(delegate
            {
                DataContainer dataContainer;
                do
                {
                    this._readerList.Clear();
                    dataContainer = null;
                    foreach (BaracodaReaderBase current in this._model.Readers)
                    {
                        dataContainer = new DataContainer();
                        dataContainer.Id = current.Id + "(" + current.Retrieved.SerialNumber + ")";
                        do
                        {
                            dataContainer.TagId = current.Retrieved.SerialNumber;
                        }
                        while (5 == 0);
                        this._readerList.Add(dataContainer);
                    }
                    if (this._readerList.Count<DataContainer>() != 0)
                    {
                        goto IL_F9;
                    }
                }
                while (5 == 0);
                dataContainer = new DataContainer();
            IL_D3:
                dataContainer.Id = "No Device Found.";
                dataContainer.TagId = "";
                this._readerList.Add(dataContainer);
            IL_F9:
                this.DGUsbReader.ItemsSource = this._readerList;
                if (2 != 0)
                {
                    this.DGUsbReader.Items.Refresh();
                    return;
                }
                goto IL_D3;
            });
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            base.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (3 == 0)
            {
                goto IL_7D;
            }
            this._model.ListRefreshNeeded -= new EventHandler(this.OnListRefreshNeeded);
            this._model.DataReceived -= new EventHandler<DataEventArgs>(this.OnDataReceived);
            MainModel expr_49 = this._model;
            if (!false)
            {
                expr_49.CloseForced();
            }
        IL_55:
            base.ClearValue(TextBox.TextProperty);
        IL_66:
            base.ClearValue(FrameworkElement.TagProperty);
            base.ClearValue(FrameworkElement.WidthProperty);
        IL_7D:
            if (8 != 0)
            {
                if (3 == 0)
                {
                    goto IL_9E;
                }
                base.ClearValue(FrameworkElement.HeightProperty);
            }
            if (false)
            {
                goto IL_66;
            }
            base.ClearValue(TextBlock.TextProperty);
        IL_9E:
            if (5 != 0)
            {
                base.ClearValue(TextBlock.TextProperty);
                return;
            }
            goto IL_55;
        }

        private void SaveIntoDatabase(DataContainer tagData)
        {
            try
            {
                string arg_45_0;
                if (tagData.Content == null)
                {
                    arg_45_0 = string.Empty;
                }
                else
                {
                    string arg_211_0 = tagData.Content;
                    char[] expr_20 = new char[1];
                    char[] array;
                    if (7 != 0)
                    {
                        array = expr_20;
                    }
                    array[0] = ']';
                    arg_45_0 = arg_211_0.Split(array).LastOrDefault<string>();
                }
                string text = arg_45_0;
                string arg_76_0;
                if (tagData.Content == null)
                {
                    arg_76_0 = string.Empty;
                }
                else
                {
                    string arg_6B_0 = tagData.Content;
                    char[] array = new char[]
					{
						'['
					};
                    arg_76_0 = arg_6B_0.Split(array).FirstOrDefault<string>();
                }
                string text2 = arg_76_0;
                DateTime? scanningTime = new DateTime?(default(DateTime));
                try
                {
                    DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
                    dateTimeFormatInfo.ShortDatePattern = "dd/MM/yyyy HH:mm:ss";
                    if (!string.IsNullOrEmpty(text2) && text2.Length >= 12)
                    {
                        scanningTime = new DateTime?(Convert.ToDateTime(string.Concat(new string[]
						{
							text2.Substring(4, 2),
							"/",
							text2.Substring(2, 2),
							"/",
							text2.Substring(0, 2),
							" ",
							text2.Substring(6, 2),
							":",
							text2.Substring(8, 2),
							":",
							text2.Substring(10, 2)
						}), dateTimeFormatInfo));
                    }
                    else
                    {
                        scanningTime = null;
                    }
                }
                catch (Exception serviceException)
                {
                    scanningTime = null;
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                bool arg_18A_0;
                bool expr_17E = arg_18A_0 = (text == null);
                if (7 != 0)
                {
                    bool flag = !expr_17E;
                    arg_18A_0 = flag;
                }
                if (!arg_18A_0)
                {
                    text = string.Empty;
                }
                RFIDTagInfo rfidTag = new RFIDTagInfo
                {
                    SerialNo = tagData.Id,
                    TagId = text,
                    RawData = tagData.Content,
                    ScanningTime = scanningTime
                };
                this._rfidBusiness.SaveRfidTag(rfidTag);
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

       
    }
}
