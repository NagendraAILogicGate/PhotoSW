using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.BAL;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.Business
{
   public class OrderBusiness
    {
       public int AddSemiOrderDetails(int? PhotoId, string ProductTypeId, 
           int LocationId, string SyncCode, 
           bool IsSentToPrinter, int SubStoreId)
       {
           return 0 ;
       }
       public bool chKIsWaterMarkedOrNot(int PackageID)
       {
           return false;
       }
       public PhotoSW.IMIX.Model.OrderInfo GenerateOrder(string OrderNumber,
           decimal Ordercost, decimal OrderNetCost, string PaymentDetails,
           int PaymentMode, double TotalDiscount, string DiscountDetails,
           int UserID, int CurrencyId, string OrderMode,
           string SyncCode, string StoreCode)
       {

           try
           {
               baOrderInfo baOrderInfo=new baOrderInfo();
                      baOrderInfo.PS_Orders_Number = OrderNumber ;
                      baOrderInfo.PS_Orders_Cost=Ordercost;
                      baOrderInfo.PS_Orders_NetCost=OrderNetCost;
                      baOrderInfo.PS_Orders_PaymentMode=PaymentMode;
                      baOrderInfo.PS_Orders_Total_Discount=TotalDiscount;
                      baOrderInfo.PS_Orders_Total_Discount_Details=DiscountDetails;
                      baOrderInfo.PS_Orders_UserID=UserID;
                      baOrderInfo.PS_Orders_Currency_ID=CurrencyId;
                      baOrderInfo.PS_Order_Mode=OrderMode;
                      baOrderInfo.SyncCode=SyncCode;
                      baOrderInfo.PS_StoreCode =StoreCode;
                      baOrderInfo.PS_Orders_Date = DateTime.Now;
                      baOrderInfo.IsActive = true;
                      var obj = baOrderInfo.InsertOrderInfo(baOrderInfo);
              
               //var obj1 = baOrderInfo.GetOrderInfoData()
               //    .Where(p => 
               //           p.PS_Orders_Number == OrderNumber 
               //        && p.PS_Orders_Cost==Ordercost
               //        && p.PS_Orders_NetCost==OrderNetCost
               //        && p.PS_Orders_PaymentMode==PaymentMode
               //        && p.PS_Orders_Total_Discount==TotalDiscount
               //        && p.PS_Orders_Total_Discount_Details==DiscountDetails
               //        && p.PS_Orders_UserID==UserID
               //        && p.PS_Orders_Currency_ID==CurrencyId
               //        && p.PS_Order_Mode==OrderMode
               //        && p.SyncCode==SyncCode
               //        && p.PS_StoreCode ==StoreCode

               //    )
               //    .Select(p => new OrderInfo
               //{
                   
               //    DG_Orders_pkey = p.PS_Orders_pkey,
               //    DG_Orders_Number = p.PS_Orders_Number,
               //    DG_Orders_Date = p.PS_Orders_Date,
               //    DG_Albums_ID = p.PS_Albums_ID,
               //    DG_Order_Mode = p.PS_Order_Mode,
               //    DG_Orders_UserID = p.PS_Orders_UserID,
               //    DG_Orders_Cost = p.PS_Orders_Cost,
               //    DG_Orders_NetCost = p.PS_Orders_NetCost,
               //    DG_Orders_Currency_ID = p.PS_Orders_Currency_ID,
               //    DG_Orders_Currency_Conversion_Rate = p.PS_Orders_Currency_Conversion_Rate,
               //    DG_Orders_Total_Discount = p.PS_Orders_Total_Discount,
               //    DG_Orders_Total_Discount_Details = p.PS_Orders_Total_Discount_Details,
               //    DG_Orders_PaymentMode = p.PS_Orders_PaymentMode,
               //    DG_Orders_PaymentDetails = p.PS_Orders_PaymentDetails,
               //    DG_Orders_Canceled = p.PS_Orders_Canceled,
               //    DG_Orders_Canceled_Date = p.PS_Orders_Canceled_Date,
               //    DG_Orders_Canceled_Reason = p.PS_Orders_Canceled_Reason,
               //    SyncCode = p.SyncCode,
               //    IsSynced = p.IsSynced,
               //    SyncStatus = p.SyncStatus,
               //    SyncDate = p.SyncDate,
               //    DG_Photos_ID = p.PS_Photos_ID,
               //    DG_StoreCode = p.PS_StoreCode,
               //    PosName = p.PosName,


               //}).FirstOrDefault();

                      PhotoSW.IMIX.Model.OrderInfo obj1 = new OrderInfo();
                          obj1.DG_Orders_pkey =(int) obj.Id;
                          obj1.DG_Orders_Number = obj.PS_Orders_Number;
                          obj1.DG_Orders_Date = obj.PS_Orders_Date;
                          obj1.DG_Albums_ID = obj.PS_Albums_ID;
                          obj1.DG_Order_Mode = obj.PS_Order_Mode;
                          obj1.DG_Orders_UserID = obj.PS_Orders_UserID;
                          obj1.DG_Orders_Cost = obj.PS_Orders_Cost;
                          obj1.DG_Orders_NetCost = obj.PS_Orders_NetCost;
                          obj1.DG_Orders_Currency_ID = obj.PS_Orders_Currency_ID;
                          obj1.DG_Orders_Currency_Conversion_Rate = obj.PS_Orders_Currency_Conversion_Rate;
                          obj1.DG_Orders_Total_Discount = obj.PS_Orders_Total_Discount;
                          obj1.DG_Orders_Total_Discount_Details = obj.PS_Orders_Total_Discount_Details;
                          obj1.DG_Orders_PaymentMode = obj.PS_Orders_PaymentMode;
                          obj1.DG_Orders_PaymentDetails = obj.PS_Orders_PaymentDetails;
                          obj1.DG_Orders_Canceled = obj.PS_Orders_Canceled;
                          obj1.DG_Orders_Canceled_Date = obj.PS_Orders_Canceled_Date;
                          obj1.DG_Orders_Canceled_Reason = obj.PS_Orders_Canceled_Reason;
                          obj1.SyncCode = obj.SyncCode;
                          obj1.IsSynced = obj.IsSynced;
                          obj1.SyncStatus = obj.SyncStatus;
                          obj1.SyncDate = obj.SyncDate;
                          obj1.DG_Photos_ID = obj.PS_Photos_ID;
                          obj1.DG_StoreCode = obj.PS_StoreCode;
                          obj1.PosName = obj.PosName;
               return obj1;
           }
           catch (Exception)
           {

               return null;
           }


           //PhotoSW.IMIX.Model.OrderInfo obj = new OrderInfo();
           //return obj;
       }
       public List<PhotoSW.IMIX.Model.BurnOrderInfo> GetBODetails(int boId)
       {
           try
           {
               var obj = baBurnOrderInfo.GetBurnOrderInfoData().Where(p => p.Id == boId).Select(p => new BurnOrderInfo
               {
                   OrderNumber = p.OrderNumber,
                   OrderDetailId = p.OrderDetailId,
                   ProductType = p.ProductType,
                   PhotosId = p.PhotosId,
                   Status = p.Status

               }).ToList();
               return obj;
           }
           catch (Exception)
           {

               return null;
           }
       }
       public PhotoSW.IMIX.Model.OrderInfo GetOrder(string OrderNo)
       {
           try
           {
               var obj = baOrderInfo.GetOrderInfoData()
                   .Where(p => p.PS_Orders_Number == OrderNo
                   )
                   .Select(p => new OrderInfo
                   {

                       DG_Orders_pkey = p.PS_Orders_pkey,
                       DG_Orders_Number = p.PS_Orders_Number,
                       DG_Orders_Date = p.PS_Orders_Date,
                       DG_Albums_ID = p.PS_Albums_ID,
                       DG_Order_Mode = p.PS_Order_Mode,
                       DG_Orders_UserID = p.PS_Orders_UserID,
                       DG_Orders_Cost = p.PS_Orders_Cost,
                       DG_Orders_NetCost = p.PS_Orders_NetCost,
                       DG_Orders_Currency_ID = p.PS_Orders_Currency_ID,
                       DG_Orders_Currency_Conversion_Rate = p.PS_Orders_Currency_Conversion_Rate,
                       DG_Orders_Total_Discount = p.PS_Orders_Total_Discount,
                       DG_Orders_Total_Discount_Details = p.PS_Orders_Total_Discount_Details,
                       DG_Orders_PaymentMode = p.PS_Orders_PaymentMode,
                       DG_Orders_PaymentDetails = p.PS_Orders_PaymentDetails,
                       DG_Orders_Canceled = p.PS_Orders_Canceled,
                       DG_Orders_Canceled_Date = p.PS_Orders_Canceled_Date,
                       DG_Orders_Canceled_Reason = p.PS_Orders_Canceled_Reason,
                       SyncCode = p.SyncCode,
                       IsSynced = p.IsSynced,
                       SyncStatus = p.SyncStatus,
                       SyncDate = p.SyncDate,
                       DG_Photos_ID = p.PS_Photos_ID,
                       DG_StoreCode = p.PS_StoreCode,
                       PosName = p.PosName,


                   }).FirstOrDefault();
               return obj;
           }
           catch (Exception)
           {

               return null;
           }

       }
       public string GetOrderDateByOrderNo(string OrderNo)
       { 
           return "";
       }
       public PhotoSW.IMIX.Model.OrderReceiptReprintInfo GetOrderDetailForReceipt(int OrderId)
       {
           try
           {
            
               var obj = baOrderReceiptReprintInfo.GetOrderReceiptReprintInfoData()
                   .Where (p=>p.OrderId==OrderId)
                   .Select(p => new OrderReceiptReprintInfo
                   {
                       OrderId = p.OrderId,
                       OrderNumber = p.OrderNumber,
                       PaymentMode = p.PaymentMode,
                       NetCost = p.NetCost,
                       TotalCost = p.TotalCost,
                       CurrencySymbol = p.CurrencySymbol,
                       DiscountTotal = p.DiscountTotal,
                       PaymentDetail = p.PaymentDetail,
                       PhotoIds = p.PhotoIds
                   }
                   ).FirstOrDefault();
               return obj;
           }
           catch (Exception)
           {

               return null;
           }

          
       }
       public PhotoSW.IMIX.Model.OrderDetailsViewInfo GetOrderDetailsByID(int orderid)
       {
           PhotoSW.IMIX.Model.OrderDetailsViewInfo obj = new OrderDetailsViewInfo();
           return obj;
       }
       public List<PhotoSW.IMIX.Model.OrderDetailInfo> GetOrderDetailsforRefund(string OrderNo)
       {
           List<PhotoSW.IMIX.Model.OrderDetailInfo> obj = new List<OrderDetailInfo>();
           return obj;
       }
       public string GetOrderInvoiceNumber(int OrderId)
       {
           return "";
       }
       public List<PhotoSW.IMIX.Model.BurnOrderInfo> GetPendingBurnOrders(bool all)
       {
           //List<PhotoSW.IMIX.Model.BurnOrderInfo> obj = new List<BurnOrderInfo>();
           try
           {
               var obj = baBurnOrderInfo.GetBurnOrderInfoData().Select(p => new BurnOrderInfo
                   {
                       OrderNumber = p.OrderNumber,
                       OrderDetailId = p.OrderDetailId,
                       ProductType = p.ProductType,
                       PhotosId = p.PhotosId,
                       Status = p.Status

                   }).ToList();
               return obj;
           }
           catch (Exception)
           {

              return  null;
           }
           
       }
       public List<PhotoSW.IMIX.Model.OrderDetailInfo> GetPhotoToUpload()
       {
           List<PhotoSW.IMIX.Model.OrderDetailInfo> obj = new List<OrderDetailInfo>();
           return obj;
       }
       public PhotoSW.IMIX.Model.OrderDetailInfo GetSemiOrderImage(string photoId)
       {
           PhotoSW.IMIX.Model.OrderDetailInfo obj = new OrderDetailInfo();
           return obj;
       }
       public bool GetSemiOrderImageforValidation(string imageNumber)
       {
           return false;
       }
       public string getSystemName()
       {
           return "";
       }
       public bool IsSemiOrderImage(int OrderDetailsID)
       {
           return false;
       }
       public int SaveOrderLineItems(int ProductType, int? OrderID,
           string PhotoId, int Qty, string DisCountDetails,
           decimal TotalDiscount, decimal UnitPrice,
           decimal TotalPrice, decimal NetPrice, int ParentID,
           int SubStoreID, int IdentifierType, string UniqueIdentifier,
           string SyncCode, string photoIDsUnsold, double? TaxPercent = null,
           decimal? TaxAmount = null, bool? IsTaxIncluded = null)
       {
       try
           {
           baOrderDetailInfo baOrderDetailInfo = new baOrderDetailInfo();

           //baOrderDetailInfo.PS_Orders_Number ="";
           baOrderDetailInfo.PS_Orders_Date = DateTime.Now;
          // baOrderDetailInfo.PS_Orders_LineItems_pkey = 2;
           baOrderDetailInfo.PS_Orders_ID = OrderID;
           baOrderDetailInfo.PS_Photos_ID = PhotoId;
           baOrderDetailInfo.PS_Orders_LineItems_Created = DateTime.Now;
           baOrderDetailInfo.PS_Orders_LineItems_DiscountType = DisCountDetails;
           //baOrderDetailInfo.PS_Orders_LineItems_DiscountAmount = 3;
           baOrderDetailInfo.PS_Orders_LineItems_Quantity = Qty;
           baOrderDetailInfo.PS_Orders_Details_Items_UniPrice = UnitPrice;
           //baOrderDetailInfo.PS_Orders_Details_Items_TotalCost = 5;
           baOrderDetailInfo.PS_Orders_Details_Items_NetPrice = NetPrice;
           baOrderDetailInfo.PS_Orders_Details_ProductType_pkey = ProductType;
           baOrderDetailInfo.PS_Orders_Details_LineItem_ParentID = ParentID;
           //baOrderDetailInfo.PS_Orders_Details_LineItem_PrinterReferenceID = 3;
           baOrderDetailInfo.PS_Photos_Burned = false;
           baOrderDetailInfo.PS_Order_SubStoreId = SubStoreID;
           //baOrderDetailInfo.IsPostedToServer = 7;
           baOrderDetailInfo.PS_Order_IdentifierType = IdentifierType;
           baOrderDetailInfo.PS_Order_ImageUniqueIdentifier = UniqueIdentifier;
           //baOrderDetailInfo.PS_Order_Status = 4;
           //baOrderDetailInfo.PS_Orders_Cost = 7;
           //baOrderDetailInfo.PS_Orders_NetCost = 8;
           baOrderDetailInfo.PS_Orders_Total_Discount = (double)TotalDiscount;
           baOrderDetailInfo.TotalQuantity = Qty;
           baOrderDetailInfo.PS_Orders_ProductType_IsBundled = false;
           //baOrderDetailInfo.LineItemshare = 5;
           baOrderDetailInfo.PS_IsPackage = false;
           //baOrderDetailInfo.PS_Orders_ProductType_Name = "";

           baOrderDetailInfo.PS_Orders_ProductType_pkey = ProductType;
           //baOrderDetailInfo.PS_Orders_ProductCode = "";
          // baOrderDetailInfo.LineItemID = 2;
          // baOrderDetailInfo.Discount = 5;
          // baOrderDetailInfo.Value = 6;
           baOrderDetailInfo.PS_IsBorder = false;
           baOrderDetailInfo.InPercentmode = false;
           baOrderDetailInfo.SyncCode = SyncCode;
           //baOrderDetailInfo.RFID = "";
           baOrderDetailInfo.PhotoID = PhotoId;
           baOrderDetailInfo.TaxPercent = TaxPercent;
           baOrderDetailInfo.TaxAmount = TaxAmount;
           baOrderDetailInfo.IsTaxIncluded = IsTaxIncluded;
           baOrderDetailInfo.PS_Photos_IDUnSold = photoIDsUnsold;
           baOrderDetailInfo.IsActive = true;
           var obj = baOrderDetailInfo.Insert(baOrderDetailInfo);

           return Convert.ToInt32(obj);
           }
       catch
           {
           return 0;
           }
       }
       public bool SetCancelOrder(string OrderNo, string CancelReason)
       {
           return false;
       }
       public int SetOrderDetails(int? PhotoId, string ProductTypeId, int SubStoreId, string SyncCode)
       {
           return 0;
       }
       public bool SetOrderDetailsForReprint(int LineItemId, int substoreID)
       {
           return false;
       }
       public bool setSemiOrderImageOrderDetails(int? orderId, string imageNumber,
           int? parentId, int substorId, string discountType,
           decimal discountAmt, decimal totalCost,
           decimal netPrice)
       {
           return false;
       }
       public bool UpdateBurnOrderStatus(int boId, int stat, int procBy, DateTime dateProcessed)
       {
           return false;
       }
       public void UpdatePostedOrder(string orderNumber, int Status)
       {
           
       }
    }
}
