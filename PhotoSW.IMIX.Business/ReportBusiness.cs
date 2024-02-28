using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
   public class ReportBusiness
   {
       public void CollectActivityReportData(DateTime fromdate, DateTime todate)
       {
       }
       public void CollectFinancialAuditData(DateTime fromdate, DateTime todate)
       {
       }
       public void CollectOperatorPerformanceData(DateTime fromdate, DateTime todate)
       {
       }
       public void CollectOrderDetailedDiscountData(DateTime fromdate, DateTime todate)
       {
       }
       public PhotoSW.IMIX.Model.ReportParams FetchReportFormatDetails(int reportType)
       {
            try
                {
                var obj = baReportParams.GetReportParamsData()
                    .Select(p => new PhotoSW.IMIX.Model.ReportParams
                        {
                        ReportType = p.ReportType

                        }).FirstOrDefault();
                return obj;
                }
            catch
                {
                return new PhotoSW.IMIX.Model.ReportParams();
                }
            //  return new PhotoSW.IMIX.Model.ReportParams();
            }
       public DataSet GetActivityReport(DateTime fromDate, DateTime toDate, int userId)
       {
           return new DataSet();
       }
       public DataSet GetAuditTrail(DateTime FromDate, DateTime ToDate, int SubStorePKey)
       {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("DG_Orders_Number",typeof(int));
            dataTable.Columns.Add("SubStoreName",typeof(string));
            dataTable.Rows.Add(1,"Bhopal");
            dataSet.Tables.Add(dataTable);
            return dataSet;
          // return new DataSet();
       }
       public DataSet GetDataForIPContentTracking(DateTime fromdate, DateTime todate, int SubStoreId, int packageID)
       {
           return new DataSet();
       }
       public DataSet GetDataForIPPrintTracking(DateTime fromdate, DateTime todate, int SubStoreId, int packageID)
       {
           return new DataSet();
       }
       public DataSet GetDataForPrintingLog(DateTime fromdate, DateTime todate, int SubStoreId)
       {
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();

            var obj = baGetPrintedProduct_Result.GetPrintedProduct_ResultData();

            dataTable.Columns.Add("PrintedQuantity", typeof(int));
            dataTable.Columns.Add("PS_Orders_ProductType_Name", typeof(string));
            dataTable.Columns.Add("PS_Print_Date", typeof(DateTime));
            dataTable.Columns.Add("PhotoNumber", typeof(string));
            dataTable.Columns.Add("PS_SubStore_Name", typeof(string));
            dataTable.Columns.Add("ProductCode", typeof(string));
            dataTable.Columns.Add("ReprintCount", typeof(string));

            foreach(var obj1 in obj)
                {
                dataTable.Rows.Add(obj1.PrintedQuantity, obj1.PS_Orders_ProductType_Name, obj1.PS_Print_Date, obj1.PhotoNumber, obj1.PS_SubStore_Name, obj1.ProductCode, "");
                }
            dataSet.Tables.Add(dataTable);
            return dataSet;
          //  return new DataSet();
       }
       public DataSet GetDataForPrintingSummary(DateTime fromdate, DateTime todate, int SubStoreId)
       {
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();

            dataTable.Columns.Add("PrintedQuantity", typeof(int));
            dataTable.Columns.Add("PS_Orders_ProductType_Name", typeof(string));
            dataTable.Columns.Add("PrintedSold", typeof(int));
            dataTable.Columns.Add("ReprintCount", typeof(string));

            dataTable.Rows.Add(2,"Product Type","2","4");
            dataSet.Tables.Add(dataTable);
            return new DataSet();
       }
       public DataSet GetFinancialAuditData(string username, string storename, DateTime startdat, DateTime enddate, int SubStoreId)
       {
            DataTable dataTable = new DataTable("dtFinancialauditreport");
            DataSet dataSet = new DataSet();
            var obj =  baFinancialAuditTrail_Result.GetFinancialAuditTrail_ResultData();

            dataTable.Columns.Add("UserName",typeof(string));
            dataTable.Columns.Add("StoreName",typeof(string));
            dataTable.Columns.Add("StartDate",typeof(DateTime));
            dataTable.Columns.Add("EndDate", typeof(DateTime));
            dataTable.Columns.Add("OrderNumber", typeof(string));
            dataTable.Columns.Add("OrderDate", typeof(DateTime));
            dataTable.Columns.Add("ProductType", typeof(string));
            dataTable.Columns.Add("SellPrice", typeof(string));
            dataTable.Columns.Add("Quantity", typeof(int));
            dataTable.Columns.Add("TotalPrice", typeof(string));
            dataTable.Columns.Add("Discount", typeof(string));
            dataTable.Columns.Add("Revenue",typeof(string));
            dataTable.Columns.Add("TotalOrderPrice", typeof(string));
            dataTable.Columns.Add("PS_Order_SubStoreId", typeof(string));
            dataTable.Columns.Add("ProductCode", typeof(string));
            
            foreach(var objNew in obj)
                {
                dataTable.Rows.Add(objNew.UserName,objNew.StoreName,objNew.StartDate,objNew.EndDate,objNew.OrderNumber,objNew.OrderDate, objNew.ProductType,objNew.SellPrice,objNew.Quantity,objNew.TotalPrice,objNew.Discount, objNew.revenue, objNew.TotalOrderPrice,objNew.PS_Order_SubStoreId,objNew.ProductCode);
                }

            dataSet.Tables.Add(dataTable);
            return dataSet;
          // return new DataSet();
       }
       public DataSet GetLocationPerformanceReports(DateTime FromDate, DateTime ToDate, DateTime secfromDate, DateTime SecToDate, string StoreName, string UserName, bool Comparision, string subStore, int SubStoreId)
       {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            var obj = baGetLocationPerformance_Result.GetLocationPerformance_ResultData();
            dataTable.Columns.Add("selectedSubStore", typeof(string));
            dataTable.Columns.Add("Number_of_Capture", typeof(int));
            dataTable.Columns.Add("Number_of_Sales", typeof(int));
            dataTable.Columns.Add("ImageSold", typeof(int));
            dataTable.Columns.Add("Revenue",typeof(int));
            dataTable.Columns.Add("PS_Location_Name", typeof(string));
            dataTable.Columns.Add("PS_Location_pkey", typeof(int));
            dataTable.Columns.Add("Shots_Previewed", typeof(int));
            dataTable.Columns.Add("DataFlag", typeof(string));
            dataTable.Columns.Add("PrintedBy", typeof(string));
            dataTable.Columns.Add("StoreName", typeof(string));
            dataTable.Columns.Add("FromDate", typeof(DateTime));
            dataTable.Columns.Add("ToDate", typeof(DateTime));
            dataTable.Columns.Add("SecondFromDate", typeof(DateTime));
            dataTable.Columns.Add("SecondToDate", typeof(DateTime));
            dataTable.Columns.Add("AveragePrice", typeof(decimal));
            dataTable.Columns.Add("SellThru", typeof(decimal));
            dataTable.Columns.Add("PS_SubStore_Name", typeof(string));
            dataTable.Columns.Add("defaultCurrency", typeof(string));
            dataTable.Columns.Add("TotalSiteRevenue", typeof(decimal));
            dataTable.Columns.Add("PrintCount68", typeof(string));
            dataTable.Columns.Add("PrintCount810", typeof(string));

            foreach(var obj1 in obj)
                {
                dataTable.Rows.Add(obj1.selectedSubStore,obj1.Number_of_Capture,obj1.Number_of_Sales, obj1.ImageSold, obj1.Revenue, obj1.PS_Location_Name, obj1.PS_Location_pkey, obj1.Shots_Previewed, obj1.DataFlag, obj1.Printedby, obj1.StoreName, obj1.FromDate, obj1.ToDate, obj1.SecondFromDate, obj1.SecondToDate, obj1.AveragePrice, obj1.SellThru, obj1.PS_SubStore_Name, obj1.defaultCurrency, obj1.TotalSiteRevenue, "6*8","8*10");

                }
            dataSet.Tables.Add(dataTable);
            return dataSet;
           // return new DataSet();
       }
       public DataSet GetOperatorReports(int CurrencyId, DateTime FromDate, DateTime ToDate, DateTime secfromDate, DateTime SecToDate, string StoreName, string UserName, bool Comparision)
       {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();


            dataTable.Columns.Add("CurrencySymbol",typeof(string));
            dataTable.Columns.Add("StoreName", typeof(string));
            dataTable.Columns.Add("UserName", typeof(string));
            dataTable.Columns.Add("FromDate", typeof(DateTime));
            dataTable.Columns.Add("ToDate", typeof(DateTime));
            dataTable.Columns.Add("Date1", typeof(int));
            dataTable.Columns.Add("Revenue", typeof(decimal));
            dataTable.Columns.Add("TotalSale", typeof(long));
            dataTable.Columns.Add("Images_Sold", typeof(long));
            dataTable.Columns.Add("Capture", typeof(int));
            dataTable.Columns.Add("Shots_Previewed", typeof(int));
            dataTable.Columns.Add("TotalBurned", typeof(int));
            dataTable.Columns.Add("OperatorName", typeof(string));

            //dataTable.Columns.Add("CD/USB Sold", typeof(int));
            //dataTable.Columns.Add("Avg S. Price", typeof(int));
           
            dataTable.Rows.Add("Currency",0,0, "1/12/2018", "1/12/2018",0,1,2,3,4);
            dataSet.Tables.Add(dataTable);

            return dataSet;
            //return new DataSet();
       }
       public DataSet GetOrderDetailReport(DateTime FromDate, DateTime ToDate, string StoreName, string UserName)
       {

            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
           // dataTable.Rows.Add("Currency");
            dataTable.Columns.Add("PS_Orders_Date", typeof(DateTime));
            dataTable.Columns.Add("PS_Orders_Cost", typeof(decimal));
            dataTable.Columns.Add("PS_Orders_Total_Discount", typeof(double));
            dataTable.Columns.Add("PS_Orders_pkey", typeof(int));
            dataTable.Columns.Add("PS_Orders_Number", typeof(string));
            dataTable.Columns.Add("PS_Orders_NetCost", typeof(decimal));
            dataTable.Columns.Add("OrderDetailId", typeof(int));
            dataTable.Columns.Add("PS_Orders_ProductType_Name", typeof(string));
            dataTable.Columns.Add("PS_Orders_ProductCode", typeof(string));
            dataTable.Columns.Add("Quantity", typeof(int));
            dataTable.Columns.Add("Discount", typeof(string));
            dataTable.Columns.Add("Value", typeof(string));
            dataTable.Columns.Add("InPercentmode", typeof(bool));
            dataTable.Columns.Add("PhotNumber", typeof(string));
            dataTable.Columns.Add("PS_Orders_Details_Items_UniPrice", typeof(decimal));
            dataTable.Columns.Add("PS_Orders_Details_Items_TotalCost", typeof(decimal));
            dataTable.Columns.Add("PS_Orders_Details_Items_NetPrice", typeof(decimal));
            dataTable.Columns.Add("StoreName", typeof(string));
            dataTable.Columns.Add("FromDate", typeof(DateTime));
            dataTable.Columns.Add("ToDate", typeof(DateTime));
            dataTable.Columns.Add("TotalOrderDiscountDetails", typeof(string));
            dataTable.Columns.Add("ActualValue", typeof(double));
            dataTable.Columns.Add("TotalLineItemDiscount", typeof(decimal));
            
            dataSet.Tables.Add(dataTable);
            return dataSet;
          //  return new DataSet();
       }
       public List<PhotoSW.IMIX.Model.PaymentSummaryInfo> GetPaymentSummary(DateTime FromDt, DateTime ToDt, string storeName)
       {
            try
                {
                var obj = baPaymentSummaryInfo.GetPaymentSummaryInfoData().Select(p => new PhotoSW.IMIX.Model.PaymentSummaryInfo

                    {
                    StoreId = p.StoreId,
                    StoreName = p.StoreName,
                    TotalStoreSale = p.TotalStoreSale,
                    TotalStoreSaleTransactionCount = p.TotalStoreSaleTransactionCount,
                    StoreVoidSale = p.StoreVoidSale,
                    StoreVoidSaleTransactionCount = p.StoreVoidSaleTransactionCount,
                    StoreCashSale = p.StoreCashSale,
                    StoreCardSaleTransactionsCount = p.StoreCardSaleTransactionsCount,
                    StoreDiscountSale = p.StoreDiscountSale,
                    StoreDiscountSaleTransactionsCount = p.StoreDiscountSaleTransactionsCount,
                    StoreRoomChargeSale = p.StoreRoomChargeSale,
                    StoreRoomChargeSaleTransactionsCount = p.StoreRoomChargeSaleTransactionsCount,
                    FC = p.FC,
                    FCStoreTransactionCount = p.FCStoreTransactionCount,
                    KVLStoreTransactionAmount = p.KVLStoreTransactionAmount,
                    KVLStoreTransactionCount = p.KVLStoreTransactionCount,
                    StoreCashSaleVoid = p.StoreCashSaleVoid,
                    StoreCashSaleTransactionsCountVoid = p.StoreCashSaleTransactionsCountVoid,
                    StoreCardSaleVoid = p.StoreCardSaleVoid,
                    StoreCardSaleTransactionsCountVoid = p.StoreCardSaleTransactionsCountVoid,
                    StoreDiscountSaleVoid = p.StoreDiscountSaleVoid,
                    StoreDiscountSaleTransactionsCountVoid = p.StoreDiscountSaleTransactionsCountVoid,
                    StoreRoomChargeSaleVoid = p.StoreRoomChargeSaleVoid,
                    StoreRoomChargeSaleTransactionsCountVoid = p.StoreRoomChargeSaleTransactionsCountVoid,
                    FCVoid = p.FCVoid,
                    FCStoreTransactionCountVoid = p.FCStoreTransactionCountVoid,
                    KVLStoreTransactionAmountVoid = p.KVLStoreTransactionAmountVoid,
                    KVLStoreTransactionCountVoid = p.KVLStoreTransactionCountVoid,
                    SubStoreId = p.SubStoreId,
                    SubStoreName = p.SubStoreName,
                    SubStoreCashSale = p.SubStoreCashSale,
                    SubStoreCashSaleVoid = p.SubStoreCashSaleVoid,
                    SubStoreCardSale = p.SubStoreCardSale,
                    SubStoreCardSaleVoid = p.SubStoreCardSaleVoid,
                    SubStoreDiscountSale = p.SubStoreDiscountSale,
                    SubStoreDiscountSaleVoid = p.SubStoreDiscountSaleVoid,
                    SubStoreRoomChargeSale = p.SubStoreRoomChargeSale,
                    SubStoreRoomChargeSaleVoid = p.SubStoreRoomChargeSaleVoid,
                    SubStoreFC = p.SubStoreFC,
                    SubStoreFCVoid = p.SubStoreFCVoid,
                    TotalSubStoreFCTransactionCount = p.TotalSubStoreFCTransactionCount,
                    TotalSubStoreFCTransactionCountVoid = p.TotalSubStoreFCTransactionCountVoid,
                    SubStoreKVLTransactionCount = p.SubStoreKVLTransactionCount,
                    SubStoreKVLTransactionCountVoid = p.SubStoreKVLTransactionCountVoid,
                    SubStoreKVLTransactionAmount = p.SubStoreKVLTransactionAmount,
                    SubStoreKVLTransactionAmountVoid = p.SubStoreKVLTransactionAmountVoid,
                    Productcode = p.Productcode,
                    Quantity = p.Quantity,
                    ProductUnitPrice = p.ProductUnitPrice,
                    TotalCost = p.TotalCost,
                    Tax = p.Tax,
                    DiscountAmount = p.DiscountAmount,
                    SubStoreVoidSaleTransactionCount = p.SubStoreVoidSaleTransactionCount,
                    NetPrice = p.NetPrice,
                    FromDate = p.FromDate,
                    ToDate = p.ToDate,
                    ConSubStoreName = p.ConSubStoreName,
                    SubStoreCashTransactionCount = p.SubStoreCashTransactionCount,
                    SubStoreCashTransactionCountVoid = p.SubStoreCashTransactionCountVoid,
                    SubStoreCCTransactionCount = p.SubStoreCCTransactionCount,
                    SubStoreCCTransactionCountVoid = p.SubStoreCCTransactionCountVoid,
                    SubstoreRoomChargeTransactionCount = p.SubstoreRoomChargeTransactionCount,
                    SubstoreRoomChargeTransactionCountVoid = p.SubstoreRoomChargeTransactionCountVoid,
                    SubStoreDiscountedVoucherTransactionCount = p.SubStoreDiscountedVoucherTransactionCount,
                    SubStoreDiscountedVoucherTransactionCountVoid = p.SubStoreDiscountedVoucherTransactionCountVoid,
                    SubStoreVoidSale = p.SubStoreVoidSale,
                    TotalSubStoreSaleTransactionCount = p.TotalSubStoreSaleTransactionCount

                    }).ToList();

                return obj;
                }
            catch
                {
                return new List<Model.PaymentSummaryInfo>();
                }
          // return new List<Model.PaymentSummaryInfo>();
       }
       public DataSet GetPhotographerPerformanceReports(DateTime FromDate, DateTime ToDate, DateTime secfromDate, DateTime SecToDate, string StoreName, string UserName, bool Comparision)
       {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            var obj = baGetPhotgrapherPerformance_Result.GetPhotgrapherPerformance_ResultData();

            dataTable.Columns.Add("Username", typeof(string));
            dataTable.Columns.Add("NumberofSales", typeof(int));
            dataTable.Columns.Add("ImageSold", typeof(int));
            dataTable.Columns.Add("PrintImageSold", typeof(string));
            dataTable.Columns.Add("Revenue", typeof(decimal));
            dataTable.Columns.Add("Dataflag", typeof(string));
            dataTable.Columns.Add("PS_User_pkey", typeof(int));
            dataTable.Columns.Add("NumberofCapture", typeof(int));
            dataTable.Columns.Add("Shots_Previewed", typeof(int));
            dataTable.Columns.Add("StoreName", typeof(string));
            dataTable.Columns.Add("Printedby", typeof(string));
            dataTable.Columns.Add("FromDate1", typeof(DateTime));
            dataTable.Columns.Add("ToDate1", typeof(DateTime));
            dataTable.Columns.Add("FromDate2", typeof(DateTime));
            dataTable.Columns.Add("ToDate2", typeof(DateTime));
            dataTable.Columns.Add("SellThru", typeof(decimal));
            dataTable.Columns.Add("AveragePrice", typeof(decimal));

            foreach(var obj1 in obj)
                {
                dataTable.Rows.Add(obj1.UserName, obj1.NumberofSales, obj1.ImageSold, obj1.PrintImageSold, obj1.Revenue,obj1.DataFlag,obj1.PS_User_pkey,obj1.NumberofCapture,obj1.Shots_Previewed, obj1.StoreName,obj1.Printedby,obj1.FromDate1,obj1.ToDate1,obj1.FromDate2,obj1.ToDate2, obj1.SellThru,obj1.AveragePrice);
                }
            dataSet.Tables.Add(dataTable);
            return dataSet;
           // return new DataSet();
       }
       public DataSet GetPrintSummaryDetail(DateTime from, DateTime to, int SubStoreId)
       {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("SaleType", typeof(string));
            dataTable.Columns.Add("PhotoNumbers", typeof(string));

            dataTable.Rows.Add("Test","1002");

            dataSet.Tables.Add(dataTable);
            return dataSet;
            //return new DataSet();
            }
       public DataSet GetTakingReport(bool ISFromDate, bool IsToDate, DateTime? FromDate, DateTime? ToDate, int UserID, int SubStorePKey)
       {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            var obj = baVW_TakingReport.GetPhotoGroupInfoData();
            dataTable.Columns.Add("PS_Orders_Number", typeof(string));
            dataTable.Columns.Add("PS_Orders_Date", typeof(DateTime));
            dataTable.Columns.Add("PS_Orders_PaymentMode", typeof(string));
            dataTable.Columns.Add("PS_Orders_Currency_ID", typeof(string));
            dataTable.Columns.Add("NetCost", typeof(decimal));
            dataTable.Columns.Add("ItemDetail", typeof(string));
            dataTable.Columns.Add("State", typeof(int));
            dataTable.Columns.Add("PS_Orders_pkey", typeof(int));
            dataTable.Columns.Add("s1", typeof(string));
            dataTable.Columns.Add("PS_SubStore_Name", typeof(string));
            dataTable.Columns.Add("ItemCode", typeof(string));
                      
            foreach(var objList in obj)
                {
                dataTable.Rows.Add(objList.PS_Orders_Number, objList.PS_Orders_Date, objList.PS_Orders_PaymentMode, objList.PS_Orders_Currency_ID, objList.NetCost, objList.ItemDetail, objList.State, objList.PS_Orders_pkey, objList.s1, objList.PS_SubStore_Name, objList.ItemCode);
                }

            dataSet.Tables.Add(dataTable);
            return dataSet;
          //  return new DataSet();
       }
       public void PurgeActivityReportData(DateTime fromdate, DateTime todate)
       {
           
       }
       public void PurgeFinancialAuditData(DateTime fromdate, DateTime todate)
       {
       }
       public void PurgeOperatorPerformanceData(DateTime fromdate, DateTime todate)
       {
         
       }
       public void PurgeOrderDetailedDiscountData(DateTime fromdate, DateTime todate)
       {
          
       }
    }
}
