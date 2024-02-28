using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baOrderDetailInfo
        {
        public long Id { get; set; }
        public int PS_Orders_pkey { get; set; }
        public string PS_Orders_Number { get; set; }
        public DateTime PS_Orders_Date { get; set; }
        public int PS_Orders_LineItems_pkey { get; set; }
        public int? PS_Orders_ID { get; set; }
        public string PS_Photos_ID { get; set; }
        public DateTime? PS_Orders_LineItems_Created { get; set; }
        public string PS_Orders_LineItems_DiscountType { get; set; }
        public decimal? PS_Orders_LineItems_DiscountAmount { get; set; }
        public int? PS_Orders_LineItems_Quantity { get; set; }
        public decimal? PS_Orders_Details_Items_UniPrice { get; set; }
        public decimal? PS_Orders_Details_Items_TotalCost { get; set; }
        public decimal? PS_Orders_Details_Items_NetPrice { get; set; }
        public int? PS_Orders_Details_ProductType_pkey { get; set; }
        public int? PS_Orders_Details_LineItem_ParentID { get; set; }
        public int? PS_Orders_Details_LineItem_PrinterReferenceID { get; set; }
        public bool? PS_Photos_Burned { get; set; }
        public int? PS_Order_SubStoreId { get; set; }
        public int? IsPostedToServer { get; set; }
        public int? PS_Order_IdentifierType { get; set; }
        public string PS_Order_ImageUniqueIdentifier { get; set; }
        public int? PS_Order_Status { get; set; }
        public decimal? PS_Orders_Cost { get; set; }
        public decimal? PS_Orders_NetCost { get; set; }
        public double? PS_Orders_Total_Discount { get; set; }
        public long TotalQuantity { get; set; }
        public bool PS_Orders_ProductType_IsBundled { get; set; }
        public decimal LineItemshare { get; set; }
        public bool PS_IsPackage { get; set; }
        public string PS_Orders_ProductType_Name { get; set; }
        public orderinfo OrderInfo { get; set; }
        public int PS_Orders_ProductType_pkey { get; set; }
        public string PS_Orders_ProductCode { get; set; }
        public int LineItemID { get; set; }
        public decimal Discount { get; set; }
        public float Value { get; set; }
        public bool PS_IsBorder { get; set; }
        public bool InPercentmode { get; set; }
        public string SyncCode { get; set; }
        public string RFID { get; set; }
        public string PhotoID { get; set; }
        public double? TaxPercent { get; set; }
        public decimal? TaxAmount { get; set; }
        public bool? IsTaxIncluded { get; set; }
        public string PS_Photos_IDUnSold { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<orderdetailinfo> lst_orderdetailinfo = new List<orderdetailinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    orderdetailinfo orderdetailinfo = new orderdetailinfo();

                    orderdetailinfo.Id = 2;
                    orderdetailinfo.PS_Orders_pkey = 3;
                    orderdetailinfo.PS_Orders_Number = "";
                    orderdetailinfo.PS_Orders_Date = DateTime.Now;
                    orderdetailinfo.PS_Orders_LineItems_pkey = 2;
                    orderdetailinfo.PS_Orders_ID = 5;
                    orderdetailinfo.PS_Photos_ID = "";
                    orderdetailinfo.PS_Orders_LineItems_Created = DateTime.Now;
                    orderdetailinfo.PS_Orders_LineItems_DiscountType = "";
                    orderdetailinfo.PS_Orders_LineItems_DiscountAmount = 3;
                    orderdetailinfo.PS_Orders_LineItems_Quantity = 4;
                    orderdetailinfo.PS_Orders_Details_Items_UniPrice = 3;
                    orderdetailinfo.PS_Orders_Details_Items_TotalCost = 5;
                    orderdetailinfo.PS_Orders_Details_Items_NetPrice = 7;
                    orderdetailinfo.PS_Orders_Details_ProductType_pkey = 5;
                    orderdetailinfo.PS_Orders_Details_LineItem_ParentID = 2;
                    orderdetailinfo.PS_Orders_Details_LineItem_PrinterReferenceID = 3;
                    orderdetailinfo.PS_Photos_Burned = false;
                    orderdetailinfo.PS_Order_SubStoreId = 3;
                    orderdetailinfo.IsPostedToServer = 7;
                    orderdetailinfo.PS_Order_IdentifierType = 3;
                    orderdetailinfo.PS_Order_ImageUniqueIdentifier = "";
                    orderdetailinfo.PS_Order_Status = 4;
                    orderdetailinfo.PS_Orders_Cost = 7;
                    orderdetailinfo.PS_Orders_NetCost = 8;
                    orderdetailinfo.PS_Orders_Total_Discount = 9;
                    orderdetailinfo.TotalQuantity = 2;
                    orderdetailinfo.PS_Orders_ProductType_IsBundled = false;
                    orderdetailinfo.LineItemshare = 5;
                    orderdetailinfo.PS_IsPackage = false;
                    orderdetailinfo.PS_Orders_ProductType_Name = "";
                  //  orderdetailinfo.OrderInfo = 5;
                    orderdetailinfo.PS_Orders_ProductType_pkey = 5;
                    orderdetailinfo.PS_Orders_ProductCode = "";
                    orderdetailinfo.LineItemID = 2;
                    orderdetailinfo.Discount = 5;
                    orderdetailinfo.Value = 6;
                    orderdetailinfo.PS_IsBorder = false;
                    orderdetailinfo.InPercentmode = false;
                    orderdetailinfo.SyncCode = "";
                    orderdetailinfo.RFID = "";
                    orderdetailinfo.PhotoID = "";
                    orderdetailinfo.TaxPercent = 5;
                    orderdetailinfo.TaxAmount = 8;
                    orderdetailinfo.IsTaxIncluded = false;
                    orderdetailinfo.PS_Photos_IDUnSold = "";
                    orderdetailinfo.IsActive = true;

                    lst_orderdetailinfo.Add(orderdetailinfo);

                    var Id = lst_orderdetailinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.OrderDetailInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.OrderDetailInfos.AddRange(lst_orderdetailinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.OrderDetailInfos.AddRange(lst_orderdetailinfo);
                        db.SaveChanges();
                        }
                    return true;
                    }
                }
            catch(Exception ex)
                {
                return false;
                }
            }

        public static baOrderDetailInfo GetOrderDetailInfoById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderDetailInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baOrderDetailInfo
                        {

                        Id = p.Id,
                        PS_Orders_pkey = p.PS_Orders_pkey,
                        PS_Orders_Number = p.PS_Orders_Number,
                        PS_Orders_Date = p.PS_Orders_Date,
                        PS_Orders_LineItems_pkey=p.PS_Orders_LineItems_pkey,
                        PS_Orders_ID=p.PS_Orders_ID,
                        PS_Photos_ID = p.PS_Photos_ID,
                        PS_Orders_LineItems_Created = p.PS_Orders_LineItems_Created,
                        PS_Orders_LineItems_DiscountType = p.PS_Orders_LineItems_DiscountType,
                        PS_Orders_LineItems_DiscountAmount = p.PS_Orders_LineItems_DiscountAmount,
                        PS_Orders_LineItems_Quantity = p.PS_Orders_LineItems_Quantity,
                        PS_Orders_Details_Items_UniPrice = p.PS_Orders_Details_Items_UniPrice,
                        PS_Orders_Details_Items_TotalCost = p.PS_Orders_Details_Items_TotalCost,
                        PS_Orders_Details_Items_NetPrice = p.PS_Orders_Details_Items_NetPrice,
                        PS_Orders_Details_ProductType_pkey = p.PS_Orders_Details_ProductType_pkey,
                        PS_Orders_Details_LineItem_ParentID = p.PS_Orders_Details_LineItem_ParentID,
                        PS_Orders_Details_LineItem_PrinterReferenceID = p.PS_Orders_Details_LineItem_PrinterReferenceID,
                        PS_Photos_Burned = p.PS_Photos_Burned,
                        PS_Order_SubStoreId = p.PS_Order_SubStoreId,
                        IsPostedToServer = p.IsPostedToServer,
                        PS_Order_IdentifierType = p.PS_Order_IdentifierType,
                        PS_Order_ImageUniqueIdentifier = p.PS_Order_ImageUniqueIdentifier,
                        PS_Order_Status = p.PS_Order_Status,
                        PS_Orders_Cost = p.PS_Orders_Cost,
                        PS_Orders_NetCost = p.PS_Orders_NetCost,
                        PS_Orders_Total_Discount = p.PS_Orders_Total_Discount,
                        TotalQuantity = p.TotalQuantity,
                        PS_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        LineItemshare = p.LineItemshare,
                        PS_IsPackage = p.PS_IsPackage,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        //OrderInfo 
                        PS_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
                        PS_Orders_ProductCode = p.PS_Orders_ProductCode,
                        LineItemID = p.LineItemID,
                        Discount = p.Discount,
                        Value = p.Value,
                        PS_IsBorder = p.PS_IsBorder,
                        InPercentmode = p.InPercentmode,
                        SyncCode = p.SyncCode,
                        RFID = p.RFID,
                        PhotoID = p.PhotoID,
                        TaxPercent = p.TaxPercent,
                        TaxAmount = p.TaxAmount,
                        IsTaxIncluded = p.IsTaxIncluded,
                        PS_Photos_IDUnSold = p.PS_Photos_IDUnSold,
                        IsActive = p.IsActive

                        }).FirstOrDefault();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static List<baOrderDetailInfo> GetOrderDetailInfoData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderDetailInfos.Where(p => p.IsActive == true).Select(p => new baOrderDetailInfo
                        {
                        Id = p.Id,
                        PS_Orders_pkey = p.PS_Orders_pkey,
                        PS_Orders_Number = p.PS_Orders_Number,
                        PS_Orders_Date = p.PS_Orders_Date,
                        PS_Orders_LineItems_pkey = p.PS_Orders_LineItems_pkey,
                        PS_Orders_ID = p.PS_Orders_ID,
                        PS_Photos_ID = p.PS_Photos_ID,
                        PS_Orders_LineItems_Created = p.PS_Orders_LineItems_Created,
                        PS_Orders_LineItems_DiscountType = p.PS_Orders_LineItems_DiscountType,
                        PS_Orders_LineItems_DiscountAmount = p.PS_Orders_LineItems_DiscountAmount,
                        PS_Orders_LineItems_Quantity = p.PS_Orders_LineItems_Quantity,
                        PS_Orders_Details_Items_UniPrice = p.PS_Orders_Details_Items_UniPrice,
                        PS_Orders_Details_Items_TotalCost = p.PS_Orders_Details_Items_TotalCost,
                        PS_Orders_Details_Items_NetPrice = p.PS_Orders_Details_Items_NetPrice,
                        PS_Orders_Details_ProductType_pkey = p.PS_Orders_Details_ProductType_pkey,
                        PS_Orders_Details_LineItem_ParentID = p.PS_Orders_Details_LineItem_ParentID,
                        PS_Orders_Details_LineItem_PrinterReferenceID = p.PS_Orders_Details_LineItem_PrinterReferenceID,
                        PS_Photos_Burned = p.PS_Photos_Burned,
                        PS_Order_SubStoreId = p.PS_Order_SubStoreId,
                        IsPostedToServer = p.IsPostedToServer,
                        PS_Order_IdentifierType = p.PS_Order_IdentifierType,
                        PS_Order_ImageUniqueIdentifier = p.PS_Order_ImageUniqueIdentifier,
                        PS_Order_Status = p.PS_Order_Status,
                        PS_Orders_Cost = p.PS_Orders_Cost,
                        PS_Orders_NetCost = p.PS_Orders_NetCost,
                        PS_Orders_Total_Discount = p.PS_Orders_Total_Discount,
                        TotalQuantity = p.TotalQuantity,
                        PS_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        LineItemshare = p.LineItemshare,
                        PS_IsPackage = p.PS_IsPackage,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        //OrderInfo 
                        PS_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
                        PS_Orders_ProductCode = p.PS_Orders_ProductCode,
                        LineItemID = p.LineItemID,
                        Discount = p.Discount,
                        Value = p.Value,
                        PS_IsBorder = p.PS_IsBorder,
                        InPercentmode = p.InPercentmode,
                        SyncCode = p.SyncCode,
                        RFID = p.RFID,
                        PhotoID = p.PhotoID,
                        TaxPercent = p.TaxPercent,
                        TaxAmount = p.TaxAmount,
                        IsTaxIncluded = p.IsTaxIncluded,
                        PS_Photos_IDUnSold = p.PS_Photos_IDUnSold,
                        IsActive = p.IsActive

                        }).ToList();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static bool Insert ( baOrderDetailInfo baOrderDetailInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    orderdetailinfo orderdetailinfo = new orderdetailinfo();

                    orderdetailinfo.Id = baOrderDetailInfo.Id;
                    orderdetailinfo.PS_Orders_pkey = baOrderDetailInfo.PS_Orders_pkey;
                    orderdetailinfo.PS_Orders_Number = baOrderDetailInfo.PS_Orders_Number;
                    orderdetailinfo.PS_Orders_Date = baOrderDetailInfo.PS_Orders_Date;
                    orderdetailinfo.PS_Orders_LineItems_pkey = baOrderDetailInfo.PS_Orders_LineItems_pkey;
                    orderdetailinfo.PS_Orders_ID = baOrderDetailInfo.PS_Orders_ID;
                    orderdetailinfo.PS_Photos_ID = baOrderDetailInfo.PS_Photos_ID;
                    orderdetailinfo.PS_Orders_LineItems_Created = baOrderDetailInfo.PS_Orders_LineItems_Created;
                    orderdetailinfo.PS_Orders_LineItems_DiscountType = baOrderDetailInfo.PS_Orders_LineItems_DiscountType;
                    orderdetailinfo.PS_Orders_LineItems_DiscountAmount = baOrderDetailInfo.PS_Orders_LineItems_DiscountAmount;
                    orderdetailinfo.PS_Orders_LineItems_Quantity = baOrderDetailInfo.PS_Orders_LineItems_Quantity;
                    orderdetailinfo.PS_Orders_Details_Items_UniPrice = baOrderDetailInfo.PS_Orders_Details_Items_UniPrice;
                    orderdetailinfo.PS_Orders_Details_Items_TotalCost = baOrderDetailInfo.PS_Orders_Details_Items_TotalCost;
                    orderdetailinfo.PS_Orders_Details_Items_NetPrice = baOrderDetailInfo.PS_Orders_Details_Items_NetPrice;
                    orderdetailinfo.PS_Orders_Details_ProductType_pkey = baOrderDetailInfo.PS_Orders_Details_ProductType_pkey;
                    orderdetailinfo.PS_Orders_Details_LineItem_ParentID = baOrderDetailInfo.PS_Orders_Details_LineItem_ParentID;
                    orderdetailinfo.PS_Orders_Details_LineItem_PrinterReferenceID = baOrderDetailInfo.PS_Orders_Details_LineItem_PrinterReferenceID;
                    orderdetailinfo.PS_Photos_Burned = baOrderDetailInfo.PS_Photos_Burned;
                    orderdetailinfo.PS_Order_SubStoreId = baOrderDetailInfo.PS_Order_SubStoreId;
                    orderdetailinfo.IsPostedToServer = baOrderDetailInfo.IsPostedToServer;
                    orderdetailinfo.PS_Order_IdentifierType = baOrderDetailInfo.PS_Order_IdentifierType;
                    orderdetailinfo.PS_Order_ImageUniqueIdentifier = baOrderDetailInfo.PS_Order_ImageUniqueIdentifier;
                    orderdetailinfo.PS_Order_Status = baOrderDetailInfo.PS_Order_Status;
                    orderdetailinfo.PS_Orders_Cost = baOrderDetailInfo.PS_Orders_Cost;
                    orderdetailinfo.PS_Orders_NetCost = baOrderDetailInfo.PS_Orders_NetCost;
                    orderdetailinfo.PS_Orders_Total_Discount = baOrderDetailInfo.PS_Orders_Total_Discount;
                    orderdetailinfo.TotalQuantity = baOrderDetailInfo.TotalQuantity;
                    orderdetailinfo.PS_Orders_ProductType_IsBundled = baOrderDetailInfo.PS_Orders_ProductType_IsBundled;
                    orderdetailinfo.LineItemshare = baOrderDetailInfo.LineItemshare;
                    orderdetailinfo.PS_IsPackage = baOrderDetailInfo.PS_IsPackage;
                    orderdetailinfo.PS_Orders_ProductType_Name = baOrderDetailInfo.PS_Orders_ProductType_Name;
                    orderdetailinfo.PS_Orders_ProductType_pkey = baOrderDetailInfo.PS_Orders_ProductType_pkey;
                    orderdetailinfo.PS_Orders_ProductCode = baOrderDetailInfo.PS_Orders_ProductCode;
                    orderdetailinfo.LineItemID = baOrderDetailInfo.LineItemID;
                    orderdetailinfo.Discount = baOrderDetailInfo.Discount;
                    orderdetailinfo.Value = baOrderDetailInfo.Value;
                    orderdetailinfo.PS_IsBorder = baOrderDetailInfo.PS_IsBorder;
                    orderdetailinfo.InPercentmode = baOrderDetailInfo.InPercentmode;
                    orderdetailinfo.SyncCode = baOrderDetailInfo.SyncCode;
                    orderdetailinfo.RFID = baOrderDetailInfo.RFID;
                    orderdetailinfo.PhotoID = baOrderDetailInfo.PhotoID;
                    orderdetailinfo.TaxPercent = baOrderDetailInfo.TaxPercent;
                    orderdetailinfo.TaxAmount = baOrderDetailInfo.TaxAmount;
                    orderdetailinfo.IsTaxIncluded = baOrderDetailInfo.IsTaxIncluded;
                    orderdetailinfo.PS_Photos_IDUnSold = baOrderDetailInfo.PS_Photos_IDUnSold;
                    orderdetailinfo.IsActive = baOrderDetailInfo.IsActive;

                    db.OrderDetailInfos.Add(orderdetailinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baOrderDetailInfo baOrderDetailInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderDetailInfos.Where(p => p.Id == baOrderDetailInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        orderdetailinfo orderdetailinfo = new orderdetailinfo();

                        orderdetailinfo.Id = baOrderDetailInfo.Id;
                        orderdetailinfo.PS_Orders_pkey = baOrderDetailInfo.PS_Orders_pkey;
                        orderdetailinfo.PS_Orders_Number = baOrderDetailInfo.PS_Orders_Number;
                        orderdetailinfo.PS_Orders_Date = baOrderDetailInfo.PS_Orders_Date;
                        orderdetailinfo.PS_Orders_LineItems_pkey = baOrderDetailInfo.PS_Orders_LineItems_pkey;
                        orderdetailinfo.PS_Orders_ID = baOrderDetailInfo.PS_Orders_ID;
                        orderdetailinfo.PS_Photos_ID = baOrderDetailInfo.PS_Photos_ID;
                        orderdetailinfo.PS_Orders_LineItems_Created = baOrderDetailInfo.PS_Orders_LineItems_Created;
                        orderdetailinfo.PS_Orders_LineItems_DiscountType = baOrderDetailInfo.PS_Orders_LineItems_DiscountType;
                        orderdetailinfo.PS_Orders_LineItems_DiscountAmount = baOrderDetailInfo.PS_Orders_LineItems_DiscountAmount;
                        orderdetailinfo.PS_Orders_LineItems_Quantity = baOrderDetailInfo.PS_Orders_LineItems_Quantity;
                        orderdetailinfo.PS_Orders_Details_Items_UniPrice = baOrderDetailInfo.PS_Orders_Details_Items_UniPrice;
                        orderdetailinfo.PS_Orders_Details_Items_TotalCost = baOrderDetailInfo.PS_Orders_Details_Items_TotalCost;
                        orderdetailinfo.PS_Orders_Details_Items_NetPrice = baOrderDetailInfo.PS_Orders_Details_Items_NetPrice;
                        orderdetailinfo.PS_Orders_Details_ProductType_pkey = baOrderDetailInfo.PS_Orders_Details_ProductType_pkey;
                        orderdetailinfo.PS_Orders_Details_LineItem_ParentID = baOrderDetailInfo.PS_Orders_Details_LineItem_ParentID;
                        orderdetailinfo.PS_Orders_Details_LineItem_PrinterReferenceID = baOrderDetailInfo.PS_Orders_Details_LineItem_PrinterReferenceID;
                        orderdetailinfo.PS_Photos_Burned = baOrderDetailInfo.PS_Photos_Burned;
                        orderdetailinfo.PS_Order_SubStoreId = baOrderDetailInfo.PS_Order_SubStoreId;
                        orderdetailinfo.IsPostedToServer = baOrderDetailInfo.IsPostedToServer;
                        orderdetailinfo.PS_Order_IdentifierType = baOrderDetailInfo.PS_Order_IdentifierType;
                        orderdetailinfo.PS_Order_ImageUniqueIdentifier = baOrderDetailInfo.PS_Order_ImageUniqueIdentifier;
                        orderdetailinfo.PS_Order_Status = baOrderDetailInfo.PS_Order_Status;
                        orderdetailinfo.PS_Orders_Cost = baOrderDetailInfo.PS_Orders_Cost;
                        orderdetailinfo.PS_Orders_NetCost = baOrderDetailInfo.PS_Orders_NetCost;
                        orderdetailinfo.PS_Orders_Total_Discount = baOrderDetailInfo.PS_Orders_Total_Discount;
                        orderdetailinfo.TotalQuantity = baOrderDetailInfo.TotalQuantity;
                        orderdetailinfo.PS_Orders_ProductType_IsBundled = baOrderDetailInfo.PS_Orders_ProductType_IsBundled;
                        orderdetailinfo.LineItemshare = baOrderDetailInfo.LineItemshare;
                        orderdetailinfo.PS_IsPackage = baOrderDetailInfo.PS_IsPackage;
                        orderdetailinfo.PS_Orders_ProductType_Name = baOrderDetailInfo.PS_Orders_ProductType_Name;
                        orderdetailinfo.PS_Orders_ProductType_pkey = baOrderDetailInfo.PS_Orders_ProductType_pkey;
                        orderdetailinfo.PS_Orders_ProductCode = baOrderDetailInfo.PS_Orders_ProductCode;
                        orderdetailinfo.LineItemID = baOrderDetailInfo.LineItemID;
                        orderdetailinfo.Discount = baOrderDetailInfo.Discount;
                        orderdetailinfo.Value = baOrderDetailInfo.Value;
                        orderdetailinfo.PS_IsBorder = baOrderDetailInfo.PS_IsBorder;
                        orderdetailinfo.InPercentmode = baOrderDetailInfo.InPercentmode;
                        orderdetailinfo.SyncCode = baOrderDetailInfo.SyncCode;
                        orderdetailinfo.RFID = baOrderDetailInfo.RFID;
                        orderdetailinfo.PhotoID = baOrderDetailInfo.PhotoID;
                        orderdetailinfo.TaxPercent = baOrderDetailInfo.TaxPercent;
                        orderdetailinfo.TaxAmount = baOrderDetailInfo.TaxAmount;
                        orderdetailinfo.IsTaxIncluded = baOrderDetailInfo.IsTaxIncluded;
                        orderdetailinfo.PS_Photos_IDUnSold = baOrderDetailInfo.PS_Photos_IDUnSold;
                        orderdetailinfo.IsActive = baOrderDetailInfo.IsActive;

                        db.SaveChanges();

                        return true;
                        }
                    else
                        {
                        return false;
                        }
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Delete ( int Id )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderDetailInfos.Where(p => p.Id == Id).FirstOrDefault();
                    if(obj != null)
                        {
                        obj.IsActive = false;
                        db.SaveChanges();

                        }
                    return true;

                    }
                }
            catch(Exception)
                {
                throw;
                }

            }


        }
    }
