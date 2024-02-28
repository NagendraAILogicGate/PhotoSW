using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using SAPBusinessObjects.WPF.Viewer;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Markup;
using System.Drawing.Printing;

namespace PhotoSW.Orders
{
    public partial class TestBill : Window, IComponentConnector
    {
        private ReportDocument _report = new ReportDocument();

        private string _imagedetails = string.Empty;

        private string logoImgName = string.Empty;

     

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        public TestBill(string strName, string opName, string orderNo, string photos, string refund, string amntDue, string txtCash, string txtChange, List<LinetItemsDetails> itemDetails, string paymentType, string cardNumber, string cardHolderName, string customerName, string hotelName, string roomNo, string voucherNo, string currency, int orderId, bool IsReprint)
        {
            this.InitializeComponent();
            string code = orderNo.Replace("SP-", "");
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            BarCodeGenerator.Code39 code2 = new BarCodeGenerator.Code39(code);
            Bitmap bitmap = new Bitmap(code2.Paint());
            StoreInfo storeInfo = new StoreInfo();
            TaxBusiness taxBusiness = new TaxBusiness();
            storeInfo = taxBusiness.getTaxConfigData();
            this.GetStoreConfigData();
            TaxDetailInfo taxDetailInfo = new TaxDetailInfo();
            List<TaxDetailInfo> taxDetail = taxBusiness.GetTaxDetail(new int?(orderId));
            try
            {
                bitmap.Save(Environment.CurrentDirectory + "\\Reports\\myimg.jpg");
                if (paymentType == "CARD")
                {
                    if (storeInfo.IsTaxEnabled)
                    {
                        if (storeInfo.IsTaxIncluded)
                        {
                            this._report.Load(baseDirectory + "\\Reports\\CardBill.rpt");
                        }
                        else
                        {
                            this._report.Load(baseDirectory + "\\Reports\\CardBillTaxExtra.rpt");
                        }
                    }
                    else
                    {
                        this._report.Load(baseDirectory + "\\Reports\\CardBill.rpt");
                    }
                }
                else if (paymentType == "CASH")
                {
                    if (storeInfo.IsTaxEnabled)
                    {
                        if (storeInfo.IsTaxIncluded)
                        {
                            this._report.Load(baseDirectory + "\\Reports\\CashBill.rpt");
                        }
                        else
                        {
                            this._report.Load(baseDirectory + "\\Reports\\CashBillTaxExtra.rpt");
                        }
                    }
                    else
                    {
                        this._report.Load(baseDirectory + "\\Reports\\CashBill.rpt");
                    }
                }
                else if (paymentType == "ROOM")
                {
                    if (storeInfo.IsTaxEnabled)
                    {
                        if (storeInfo.IsTaxIncluded)
                        {
                            this._report.Load(baseDirectory + "\\Reports\\RoomBill.rpt");
                        }
                        else
                        {
                            this._report.Load(baseDirectory + "\\Reports\\RoomBillTaxExtra.rpt");
                        }
                    }
                    else
                    {
                        this._report.Load(baseDirectory + "\\Reports\\RoomBill.rpt");
                    }
                }
                else if (paymentType == "VOUCHER")
                {
                    if (storeInfo.IsTaxEnabled)
                    {
                        if (storeInfo.IsTaxIncluded)
                        {
                            this._report.Load(baseDirectory + "\\Reports\\VoucherBill.rpt");
                        }
                        else
                        {
                            this._report.Load(baseDirectory + "\\Reports\\VoucherBillTaxExtra.rpt");
                        }
                    }
                    else
                    {
                        this._report.Load(baseDirectory + "\\Reports\\VoucherBill.rpt");
                    }
                }
                else if (paymentType == "KVL")
                {
                    if (storeInfo.IsTaxEnabled)
                    {
                        if (storeInfo.IsTaxIncluded)
                        {
                            this._report.Load(baseDirectory + "\\Reports\\KVLBill.rpt");
                        }
                        else
                        {
                            this._report.Load(baseDirectory + "\\Reports\\KVLBillTaxExtra.rpt");
                        }
                    }
                    else
                    {
                        this._report.Load(baseDirectory + "\\Reports\\KVLBill.rpt");
                    }
                }
                TextObject textObject = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["Txtstorename"];
                textObject.Text = strName;
                TextObject textObject2 = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["txtReceiptTitle"];
                textObject2.Text = storeInfo.BillReceiptTitle;
                TextObject textObject3 = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["txtSeqNo"];
                textObject3.Text = ((storeInfo.IsSequenceNoRequired == true) ? ("Invoice Number: " + new OrderBusiness().GetOrderInvoiceNumber(orderId)) : string.Empty);
                TextObject textObject4 = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["txtAddress"];
                textObject4.Text = (storeInfo.Address.Replace("\n", " ").Replace("\r", "") ?? "");
                TextObject textObject5 = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["txtPhone"];
                textObject5.Text = "Phone: " + storeInfo.PhoneNo;
                TextObject textObject6 = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["txtEmail"];
                textObject6.Text = "Email: " + storeInfo.EmailID;
                TextObject textObject7 = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["txtUrl"];
                textObject7.Text = storeInfo.WebsiteURL;
                TextObject textObject8 = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["txtRegistrationNo"];
                textObject8.Text = storeInfo.TaxRegistrationText + ((!string.IsNullOrEmpty(storeInfo.TaxRegistrationText)) ? ": " : string.Empty) + storeInfo.TaxRegistrationNumber;
                TextObject textObject9 = (TextObject)this._report.ReportDefinition.Sections["Section2"].ReportObjects["txtoperator"];
                textObject9.Text = opName;
                TextObject textObject10 = (TextObject)this._report.ReportDefinition.Sections["Section2"].ReportObjects["txtorderno"];
                textObject10.Text = orderNo;
                TextObject textObject11 = (TextObject)this._report.ReportDefinition.Sections["Section2"].ReportObjects["textphotono"];
                textObject11.Text = "Photo No: " + photos;
                textObject11.Height = 192 * (textObject11.Text.Length / 45);
                TextObject textObject12 = (TextObject)this._report.ReportDefinition.Sections["Section4"].ReportObjects["txtrefund"];
                textObject12.Text = refund;
                TextObject textObject13 = (TextObject)this._report.ReportDefinition.Sections["Section4"].ReportObjects["txtamountdue"];
                textObject13.Text = amntDue;
                TextObject textObject14 = (TextObject)this._report.ReportDefinition.Sections["Section2"].ReportObjects["txtCurrency"];
                textObject14.Text = " (" + currency + ")";
                if (paymentType == "CASH")
                {
                    TextObject textObject15 = (TextObject)this._report.ReportDefinition.Sections["Section4"].ReportObjects["txtcash"];
                    textObject15.Text = txtCash;
                    TextObject textObject16 = (TextObject)this._report.ReportDefinition.Sections["Section4"].ReportObjects["txtchange"];
                    textObject16.Text = txtChange;
                }
                if (paymentType == "CARD" || paymentType == "ROOM" || paymentType == "VOUCHER")
                {
                    TextObject textObject17 = (TextObject)this._report.ReportDefinition.Sections["Section4"].ReportObjects["txtsubtotal"];
                    textObject17.Text = amntDue;
                }
                if (paymentType == "CARD")
                {
                    TextObject textObject18 = (TextObject)this._report.ReportDefinition.Sections["Section4"].ReportObjects["txtCardno"];
                    textObject18.Text = cardNumber;
                    TextObject textObject19 = (TextObject)this._report.ReportDefinition.Sections["Section4"].ReportObjects["txtcustomername"];
                    textObject19.Text = cardHolderName;
                }
                if (paymentType == "ROOM")
                {
                    TextObject textObject20 = (TextObject)this._report.ReportDefinition.Sections["Section4"].ReportObjects["txtname"];
                    textObject20.Text = customerName;
                    TextObject textObject21 = (TextObject)this._report.ReportDefinition.Sections["Section4"].ReportObjects["txthotel"];
                    textObject21.Text = hotelName;
                    TextObject textObject22 = (TextObject)this._report.ReportDefinition.Sections["Section4"].ReportObjects["txtroomno"];
                    textObject22.Text = roomNo;
                }
                if (paymentType == "VOUCHER")
                {
                    TextObject textObject20 = (TextObject)this._report.ReportDefinition.Sections["Section4"].ReportObjects["txtname"];
                    textObject20.Text = customerName;
                    TextObject textObject23 = (TextObject)this._report.ReportDefinition.Sections["Section4"].ReportObjects["txtvoucherno"];
                    textObject23.Text = voucherNo;
                }
                foreach (LinetItemsDetails current in itemDetails)
                {
                    if (this._imagedetails == string.Empty)
                    {
                        this._imagedetails = string.Concat(new string[]
						{
							"<LineItems><Item><Name>",
							current.Productname,
							"</Name><Qty>",
							current.Productquantity,
							"</Qty><Price>",
							current.Productprice,
							"</Price></Item>"
						});
                    }
                    else
                    {
                        string imagedetails = this._imagedetails;
                        this._imagedetails = string.Concat(new string[]
						{
							imagedetails,
							"<Item><Name>",
							current.Productname,
							"</Name><Qty>",
							current.Productquantity,
							"</Qty><Price>",
							current.Productprice,
							"</Price></Item>"
						});
                    }
                }
                this._imagedetails += "</LineItems>";
                DataTable dataTablefromStream = this.GetDataTablefromStream(this._imagedetails);
                if (!string.IsNullOrEmpty(this.logoImgName) && File.Exists(this.logoImgName))
                {
                    this._report.DataDefinition.FormulaFields[1].Text = "'" + this.logoImgName + "'";
                }
                this._report.DataDefinition.FormulaFields[0].Text = "'" + Environment.CurrentDirectory + "\\Reports\\myimg.jpg'";
                this._report.SetDataSource(dataTablefromStream);
                this._report.Subreports[0].SetDataSource(taxDetail);
                this._report.Refresh();

                this._report.PrintOptions.PrinterName = GetDefaultPrinter();//LoginUser.ReceiptPrinterPath;
                int noOfBillReceipt = this.GetNoOfBillReceipt();
                PageMargins margin = default(PageMargins);
                margin.leftMargin = 0;
                margin.rightMargin = 0;
                margin.topMargin = 0;
                margin.bottomMargin = 292;
                this._report.PrintOptions.ApplyPageMargins(margin);
                for (int i = 0; i < noOfBillReceipt; i++)
                {
                    TextObject textObject24 = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["txtBillType"];
                    if (i == 0)
                    {
                        textObject24.Text = "Original";
                    }
                    else
                    {
                        textObject24.Text = "Duplicate";
                    }
                    if (IsReprint)
                    {
                        textObject24.Text = "Duplicate";
                        this._report.PrintToPrinter(1, true, 1, 0);
                        return;
                    }
                    this._report.PrintToPrinter(1, true, 1, 0);
                }
                if (!IsReprint)
                {
                    this.SaveOrderNo(orderNo);
                    string digiFolderPath = LoginUser.DigiFolderPath;
                    string text = Path.Combine(digiFolderPath, "OrderReceipt\\" + DateTime.Now.ToString("yyyyMMdd"));
                    if (!Directory.Exists(text))
                    {
                        Directory.CreateDirectory(text);
                    }
                    string text2 = orderNo + ".pdf";
                    this._report.ExportToDisk(ExportFormatType.PortableDocFormat, text2);
                    string text3 = Environment.CurrentDirectory + "\\" + text2;
                    if (File.Exists(text3))
                    {
                        File.Move(text3, text + "\\" + text2);
                    }
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
            finally
            {
                if (bitmap != null)
                {
                    IntPtr hbitmap = bitmap.GetHbitmap();
                    TestBill.DeleteObject(hbitmap);
                    bitmap.Dispose();
                }
                this.BillReportviewer = null;
                this._report.Dispose();
            }
        }
       public string GetDefaultPrinter ()
            {
            PrinterSettings settings = new PrinterSettings();
            foreach(string printer in PrinterSettings.InstalledPrinters)
                {
                settings.PrinterName = printer;
                if(settings.IsDefaultPrinter)
                    return printer;
                }
            return string.Empty;
            }
        public DataTable GetDataTablefromStream(string xmlData)
        {
            xmlData = xmlData.Replace("&", "&amp;");
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable("Item");
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Qty", typeof(string));
            dataTable.Columns.Add("Price", typeof(string));
            dataSet.Tables.Add(dataTable);
            StringReader reader = new StringReader(xmlData);
            dataSet.ReadXml(reader, XmlReadMode.IgnoreSchema);
            return dataSet.Tables[0];
        }

        public TestBill(string storeName, string operatorName, string casboxOpenReason)
        {
            try
            {
                this.InitializeComponent();
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                TaxBusiness taxBusiness = new TaxBusiness();
                StoreInfo taxConfigData = taxBusiness.getTaxConfigData();
                this._report.Load(baseDirectory + "\\Reports\\CashBoxOpenRecipt.rpt");
                TextObject textObject = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["txtReceiptTitle"];
                textObject.Text = taxConfigData.BillReceiptTitle;
                TextObject textObject2 = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["txtAddress"];
                textObject2.Text = (taxConfigData.Address.Replace("\n", " ").Replace("\r", "") ?? "");
                TextObject textObject3 = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["txtPhone"];
                textObject3.Text = "Phone: " + taxConfigData.PhoneNo;
                TextObject textObject4 = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["txtEmail"];
                textObject4.Text = "Email: " + taxConfigData.EmailID;
                TextObject textObject5 = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["txtUrl"];
                textObject5.Text = taxConfigData.WebsiteURL;
                TextObject textObject6 = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["txtRegistrationNo"];
                textObject6.Text = taxConfigData.TaxRegistrationText + ": " + taxConfigData.TaxRegistrationNumber;
                TextObject textObject7 = (TextObject)this._report.ReportDefinition.Sections["Section1"].ReportObjects["Txtstorename"];
                textObject7.Text = storeName;
                TextObject textObject8 = (TextObject)this._report.ReportDefinition.Sections["Section3"].ReportObjects["txtOperator"];
                textObject8.Text = operatorName;
                TextObject textObject9 = (TextObject)this._report.ReportDefinition.Sections["DetailSection1"].ReportObjects["txtCashboxOpenReason"];
                textObject9.Text = casboxOpenReason;
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("StoreName", typeof(string));
                dataTable.Columns.Add("Operator", typeof(string));
                dataTable.Columns.Add("Reason", typeof(string));
                dataTable.Rows.Add(new object[]
				{
					textObject7,
					operatorName,
					textObject9.Text
				});
                this._report.SetDataSource(dataTable);
                this._report.Refresh();
                this._report.PrintOptions.PrinterName = LoginUser.ReceiptPrinterPath;
                this._report.PrintToPrinter(1, true, 1, 1);
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private int GetNoOfBillReceipt()
        {
            int num = 1;
            try
            {
                while (2 == 0)
                {
                }
                if (!false)
                {
                    num = new ConfigBusiness().GetConfigurationData(LoginUser.SubStoreId).DG_NoOfBillReceipt.ToInt32(false);
                }
            }
            catch (Exception serviceException)
            {
                do
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (false);
            }
            int arg_63_0;
            int num2;
            if (2 != 0)
            {
                int expr_6A = arg_63_0 = num;
                if (false)
                {
                    return arg_63_0;
                }
                num2 = expr_6A;
            }
            arg_63_0 = num2;
            return arg_63_0;
        }

        private void SaveOrderNo(string OrderNo)
        {
            if (true)
            {
                try
                {
                    string text = string.Empty;
                    string currentDirectory = Environment.CurrentDirectory;
                    bool flag = !File.Exists(currentDirectory + "\\on.dat");
                    do
                    {
                        if (!flag)
                        {
                            using (StreamReader streamReader = new StreamReader(Environment.CurrentDirectory + "\\on.dat"))
                            {
                                if (-1 != 0)
                                {
                                }
                                do
                                {
                                    string cipherString = streamReader.ReadLine();
                                    if (!false)
                                    {
                                        text = PhotoSW.CryptorEngine.Decrypt(cipherString, true);
                                    }
                                }
                                while (!true);
                            }
                            File.Delete(currentDirectory + "\\on.dat");
                        }
                        while (true)
                        {
                            flag = (text.Split(new char[]
							{
								','
							}).Count<string>() > 2);
                            if (!flag)
                            {
                                break;
                            }
                            text = text.Remove(0, text.IndexOf(',') + 1);
                        }
                    }
                    while (false);
                    text += (string.IsNullOrEmpty(text) ? OrderNo : ("," + OrderNo));
                    using (StreamWriter streamWriter = new StreamWriter(File.Open(currentDirectory + "\\on.dat", FileMode.Create)))
                    {
                        streamWriter.Write(PhotoSW.CryptorEngine.Encrypt(text, true));
                        streamWriter.Close();
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    do
                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    while (!false && false);
                }
            }
        }

        private void GetStoreConfigData()
        {
            ConfigBusiness configBusiness = new ConfigBusiness();
            if (false)
            {
                goto IL_49;
            }
            List<iMIXStoreConfigurationInfo> storeConfigData = configBusiness.GetStoreConfigData();
            int num;
            if (!false)
            {
                num = 0;
                goto IL_8A;
            }
            goto IL_83;
        IL_29:
            long iMIXConfigurationMasterId = storeConfigData[num].IMIXConfigurationMasterId;
            if (iMIXConfigurationMasterId != 205L)
            {
                goto IL_82;
            }
        IL_49:
            this.logoImgName = ((storeConfigData[num].ConfigurationValue != null) ? Path.Combine(PhotoSW.IMIX.Business.ConfigManager.FolderPath, "ReceiptLogo", storeConfigData[num].ConfigurationValue) : string.Empty);
        IL_80:
        IL_82:
        IL_83:
            if (false)
            {
                goto IL_29;
            }
            int arg_88_0 = num;
        IL_87:
            num = arg_88_0 + 1;
        IL_8A:
            if (false)
            {
                goto IL_80;
            }
            int expr_8D = arg_88_0 = num;
            if (-1 == 0 || -1 == 0)
            {
                goto IL_87;
            }
            if (expr_8D >= storeConfigData.Count)
            {
                return;
            }
            goto IL_29;
        }


    }
}
