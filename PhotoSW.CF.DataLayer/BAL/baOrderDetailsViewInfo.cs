using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;


namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baOrderDetailsViewInfo
        {
        public long Id { get; set; }
        public int PS_Orders_LineItems_pkey { get; set; }
        public int? PS_Orders_ID { get; set; }
        public string PS_Photos_ID { get; set; }
        public DateTime? PS_Orders_LineItems_Created { get; set; }
        public string PS_Orders_LineItems_DiscountType { get; set; }
        public decimal? PS_Orders_LineItems_DiscountAmount { get; set; }
        public int PS_Orders_LineItems_Quantity { get; set; }
        public decimal? PS_Orders_Details_Items_UniPrice { get; set; }
        public decimal? PS_Orders_Details_Items_TotalCost { get; set; }
        public decimal? PS_Orders_Details_Items_NetPrice { get; set; }
        public int? PS_Orders_Details_ProductType_pkey { get; set; }
        public int? PS_Orders_Details_LineItem_ParentID { get; set; }
        public int? PS_Orders_Details_LineItem_PrinterReferenceID { get; set; }
        public string PS_Orders_Number { get; set; }
        public DateTime? PS_Orders_Date { get; set; }
        public decimal? PS_Orders_Cost { get; set; }
        public decimal? PS_Orders_NetCost { get; set; }
        public int? PS_Orders_Currency_ID { get; set; }
        public string PS_Orders_Currency_Conversion_Rate { get; set; }
        public float? PS_Orders_Total_Discount { get; set; }
        public string PS_Orders_Total_Discount_Details { get; set; }
        public string PS_Orders_PaymentDetails { get; set; }
        public int? PS_Orders_PaymentMode { get; set; }
        public string PS_Orders_ProductType_Name { get; set; }
        public bool? PS_IsBorder { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<orderdetailsviewinfo> lst_orderdetailsviewinfo = new List<orderdetailsviewinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    orderdetailsviewinfo orderdetailsviewinfo = new orderdetailsviewinfo();

                    orderdetailsviewinfo.Id = 1 ;
                    orderdetailsviewinfo.PS_Orders_LineItems_pkey = 1 ;
                    orderdetailsviewinfo.PS_Orders_ID = 1 ;
                    orderdetailsviewinfo.PS_Photos_ID = "" ;
                    orderdetailsviewinfo.PS_Orders_LineItems_Created = DateTime.Now; ;
                    orderdetailsviewinfo.PS_Orders_LineItems_DiscountType = "" ;
                    orderdetailsviewinfo.PS_Orders_LineItems_DiscountAmount = 1 ;
                    orderdetailsviewinfo.PS_Orders_LineItems_Quantity = 1 ;
                    orderdetailsviewinfo.PS_Orders_Details_Items_UniPrice = 1 ;
                    orderdetailsviewinfo.PS_Orders_Details_Items_TotalCost = 1 ;
                    orderdetailsviewinfo.PS_Orders_Details_Items_NetPrice = 1 ;
                    orderdetailsviewinfo.PS_Orders_Details_ProductType_pkey = 1 ;
                    orderdetailsviewinfo.PS_Orders_Details_LineItem_ParentID = 1 ;
                    orderdetailsviewinfo.PS_Orders_Details_LineItem_PrinterReferenceID = 1 ;
                    orderdetailsviewinfo.PS_Orders_Number = "" ;
                    orderdetailsviewinfo.PS_Orders_Date = DateTime.Now ;
                    orderdetailsviewinfo.PS_Orders_Cost = 1 ;
                    orderdetailsviewinfo.PS_Orders_NetCost = 1 ;
                    orderdetailsviewinfo.PS_Orders_Currency_ID = 1 ;
                    orderdetailsviewinfo.PS_Orders_Currency_Conversion_Rate = "" ;
                    orderdetailsviewinfo.PS_Orders_Total_Discount = 1 ;
                    orderdetailsviewinfo.PS_Orders_Total_Discount_Details = "" ;
                    orderdetailsviewinfo.PS_Orders_PaymentDetails ="" ;
                    orderdetailsviewinfo.PS_Orders_PaymentMode = 1 ;
                    orderdetailsviewinfo.PS_Orders_ProductType_Name = "" ;
                    orderdetailsviewinfo.PS_IsBorder = false ;
                    orderdetailsviewinfo.IsActive = true;

                    lst_orderdetailsviewinfo.Add(orderdetailsviewinfo);

                    var Id = lst_orderdetailsviewinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.OrderDetailsViewInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.OrderDetailsViewInfos.AddRange(lst_orderdetailsviewinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.OrderDetailsViewInfos.AddRange(lst_orderdetailsviewinfo);
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

        public static baOrderDetailsViewInfo GetOrderDetailsViewInfoById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderDetailsViewInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baOrderDetailsViewInfo
                        {

                        Id = p.Id,
                        PS_Orders_LineItems_pkey =  p.PS_Orders_LineItems_pkey,
                        PS_Orders_ID =  p.PS_Orders_ID,
                        PS_Photos_ID = p.PS_Photos_ID,
                        PS_Orders_LineItems_Created = p.PS_Orders_LineItems_Created,
                        PS_Orders_LineItems_DiscountType = p.PS_Orders_LineItems_DiscountType,
                        PS_Orders_LineItems_DiscountAmount =  p.PS_Orders_LineItems_DiscountAmount,
                        PS_Orders_LineItems_Quantity =  p.PS_Orders_LineItems_Quantity,
                        PS_Orders_Details_Items_UniPrice =  p.PS_Orders_Details_Items_UniPrice,
                        PS_Orders_Details_Items_TotalCost =  p.PS_Orders_Details_Items_TotalCost,
                        PS_Orders_Details_Items_NetPrice =  p.PS_Orders_Details_Items_NetPrice,
                        PS_Orders_Details_ProductType_pkey =  p.PS_Orders_Details_ProductType_pkey,
                        PS_Orders_Details_LineItem_ParentID =  p.PS_Orders_Details_LineItem_ParentID,
                        PS_Orders_Details_LineItem_PrinterReferenceID =  p.PS_Orders_Details_LineItem_PrinterReferenceID,
                        PS_Orders_Number = p.PS_Orders_Number,
                        PS_Orders_Date = p.PS_Orders_Date,
                        PS_Orders_Cost =  p.PS_Orders_Cost,
                        PS_Orders_NetCost =  p.PS_Orders_NetCost,
                        PS_Orders_Currency_ID =  p.PS_Orders_Currency_ID,
                        PS_Orders_Currency_Conversion_Rate = p.PS_Orders_Currency_Conversion_Rate,
                        PS_Orders_Total_Discount =  p.PS_Orders_Total_Discount,
                        PS_Orders_Total_Discount_Details = p.PS_Orders_Total_Discount_Details,
                        PS_Orders_PaymentDetails = p.PS_Orders_PaymentDetails,
                        PS_Orders_PaymentMode =  p.PS_Orders_PaymentMode,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PS_IsBorder = p.PS_IsBorder,
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

        public static List<baOrderDetailsViewInfo> GetOrderDetailsViewInfoData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderDetailsViewInfos.Where(p => p.IsActive == true).Select(p => new baOrderDetailsViewInfo
                        {
                        Id = p.Id,
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
                        PS_Orders_Number = p.PS_Orders_Number,
                        PS_Orders_Date = p.PS_Orders_Date,
                        PS_Orders_Cost = p.PS_Orders_Cost,
                        PS_Orders_NetCost = p.PS_Orders_NetCost,
                        PS_Orders_Currency_ID = p.PS_Orders_Currency_ID,
                        PS_Orders_Currency_Conversion_Rate = p.PS_Orders_Currency_Conversion_Rate,
                        PS_Orders_Total_Discount = p.PS_Orders_Total_Discount,
                        PS_Orders_Total_Discount_Details = p.PS_Orders_Total_Discount_Details,
                        PS_Orders_PaymentDetails = p.PS_Orders_PaymentDetails,
                        PS_Orders_PaymentMode = p.PS_Orders_PaymentMode,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PS_IsBorder = p.PS_IsBorder,
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

        public static bool Insert ( baOrderDetailsViewInfo baOrderDetailsViewInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    orderdetailsviewinfo orderdetailsviewinfo = new orderdetailsviewinfo();

                    orderdetailsviewinfo.Id = baOrderDetailsViewInfo.Id;
                    orderdetailsviewinfo.PS_Orders_LineItems_pkey = baOrderDetailsViewInfo.PS_Orders_LineItems_pkey;
                    orderdetailsviewinfo.PS_Orders_ID = baOrderDetailsViewInfo.PS_Orders_ID;
                    orderdetailsviewinfo.PS_Photos_ID = baOrderDetailsViewInfo.PS_Photos_ID;
                    orderdetailsviewinfo.PS_Orders_LineItems_Created = baOrderDetailsViewInfo.PS_Orders_LineItems_Created;
                    orderdetailsviewinfo.PS_Orders_LineItems_DiscountType = baOrderDetailsViewInfo.PS_Orders_LineItems_DiscountType;
                    orderdetailsviewinfo.PS_Orders_LineItems_DiscountAmount = baOrderDetailsViewInfo.PS_Orders_LineItems_DiscountAmount;
                    orderdetailsviewinfo.PS_Orders_LineItems_Quantity = baOrderDetailsViewInfo.PS_Orders_LineItems_Quantity;
                    orderdetailsviewinfo.PS_Orders_Details_Items_UniPrice = baOrderDetailsViewInfo.PS_Orders_Details_Items_UniPrice;
                    orderdetailsviewinfo.PS_Orders_Details_Items_TotalCost = baOrderDetailsViewInfo.PS_Orders_Details_Items_TotalCost;
                    orderdetailsviewinfo.PS_Orders_Details_Items_NetPrice = baOrderDetailsViewInfo.PS_Orders_Details_Items_NetPrice;
                    orderdetailsviewinfo.PS_Orders_Details_ProductType_pkey = baOrderDetailsViewInfo.PS_Orders_Details_ProductType_pkey;
                    orderdetailsviewinfo.PS_Orders_Details_LineItem_ParentID = baOrderDetailsViewInfo.PS_Orders_Details_LineItem_ParentID;
                    orderdetailsviewinfo.PS_Orders_Details_LineItem_PrinterReferenceID = baOrderDetailsViewInfo.PS_Orders_Details_LineItem_PrinterReferenceID;
                    orderdetailsviewinfo.PS_Orders_Number = baOrderDetailsViewInfo.PS_Orders_Number;
                    orderdetailsviewinfo.PS_Orders_Date = baOrderDetailsViewInfo.PS_Orders_Date;
                    orderdetailsviewinfo.PS_Orders_Cost = baOrderDetailsViewInfo.PS_Orders_Cost;
                    orderdetailsviewinfo.PS_Orders_NetCost = baOrderDetailsViewInfo.PS_Orders_NetCost;
                    orderdetailsviewinfo.PS_Orders_Currency_ID = baOrderDetailsViewInfo.PS_Orders_Currency_ID;
                    orderdetailsviewinfo.PS_Orders_Currency_Conversion_Rate = baOrderDetailsViewInfo.PS_Orders_Currency_Conversion_Rate;
                    orderdetailsviewinfo.PS_Orders_Total_Discount = baOrderDetailsViewInfo.PS_Orders_Total_Discount;
                    orderdetailsviewinfo.PS_Orders_Total_Discount_Details = baOrderDetailsViewInfo.PS_Orders_Total_Discount_Details;
                    orderdetailsviewinfo.PS_Orders_PaymentDetails = baOrderDetailsViewInfo.PS_Orders_PaymentDetails;
                    orderdetailsviewinfo.PS_Orders_PaymentMode = baOrderDetailsViewInfo.PS_Orders_PaymentMode;
                    orderdetailsviewinfo.PS_Orders_ProductType_Name = baOrderDetailsViewInfo.PS_Orders_ProductType_Name;
                    orderdetailsviewinfo.PS_IsBorder = baOrderDetailsViewInfo.PS_IsBorder;
                    orderdetailsviewinfo.IsActive = baOrderDetailsViewInfo.IsActive;

                    db.OrderDetailsViewInfos.Add(orderdetailsviewinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baOrderDetailsViewInfo baOrderDetailsViewInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderDetailsViewInfos.Where(p => p.Id == baOrderDetailsViewInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        orderdetailsviewinfo orderdetailsviewinfo = new orderdetailsviewinfo();

                        orderdetailsviewinfo.Id = baOrderDetailsViewInfo.Id;
                        orderdetailsviewinfo.PS_Orders_LineItems_pkey = baOrderDetailsViewInfo.PS_Orders_LineItems_pkey;
                        orderdetailsviewinfo.PS_Orders_ID = baOrderDetailsViewInfo.PS_Orders_ID;
                        orderdetailsviewinfo.PS_Photos_ID = baOrderDetailsViewInfo.PS_Photos_ID;
                        orderdetailsviewinfo.PS_Orders_LineItems_Created = baOrderDetailsViewInfo.PS_Orders_LineItems_Created;
                        orderdetailsviewinfo.PS_Orders_LineItems_DiscountType = baOrderDetailsViewInfo.PS_Orders_LineItems_DiscountType;
                        orderdetailsviewinfo.PS_Orders_LineItems_DiscountAmount = baOrderDetailsViewInfo.PS_Orders_LineItems_DiscountAmount;
                        orderdetailsviewinfo.PS_Orders_LineItems_Quantity = baOrderDetailsViewInfo.PS_Orders_LineItems_Quantity;
                        orderdetailsviewinfo.PS_Orders_Details_Items_UniPrice = baOrderDetailsViewInfo.PS_Orders_Details_Items_UniPrice;
                        orderdetailsviewinfo.PS_Orders_Details_Items_TotalCost = baOrderDetailsViewInfo.PS_Orders_Details_Items_TotalCost;
                        orderdetailsviewinfo.PS_Orders_Details_Items_NetPrice = baOrderDetailsViewInfo.PS_Orders_Details_Items_NetPrice;
                        orderdetailsviewinfo.PS_Orders_Details_ProductType_pkey = baOrderDetailsViewInfo.PS_Orders_Details_ProductType_pkey;
                        orderdetailsviewinfo.PS_Orders_Details_LineItem_ParentID = baOrderDetailsViewInfo.PS_Orders_Details_LineItem_ParentID;
                        orderdetailsviewinfo.PS_Orders_Details_LineItem_PrinterReferenceID = baOrderDetailsViewInfo.PS_Orders_Details_LineItem_PrinterReferenceID;
                        orderdetailsviewinfo.PS_Orders_Number = baOrderDetailsViewInfo.PS_Orders_Number;
                        orderdetailsviewinfo.PS_Orders_Date = baOrderDetailsViewInfo.PS_Orders_Date;
                        orderdetailsviewinfo.PS_Orders_Cost = baOrderDetailsViewInfo.PS_Orders_Cost;
                        orderdetailsviewinfo.PS_Orders_NetCost = baOrderDetailsViewInfo.PS_Orders_NetCost;
                        orderdetailsviewinfo.PS_Orders_Currency_ID = baOrderDetailsViewInfo.PS_Orders_Currency_ID;
                        orderdetailsviewinfo.PS_Orders_Currency_Conversion_Rate = baOrderDetailsViewInfo.PS_Orders_Currency_Conversion_Rate;
                        orderdetailsviewinfo.PS_Orders_Total_Discount = baOrderDetailsViewInfo.PS_Orders_Total_Discount;
                        orderdetailsviewinfo.PS_Orders_Total_Discount_Details = baOrderDetailsViewInfo.PS_Orders_Total_Discount_Details;
                        orderdetailsviewinfo.PS_Orders_PaymentDetails = baOrderDetailsViewInfo.PS_Orders_PaymentDetails;
                        orderdetailsviewinfo.PS_Orders_PaymentMode = baOrderDetailsViewInfo.PS_Orders_PaymentMode;
                        orderdetailsviewinfo.PS_Orders_ProductType_Name = baOrderDetailsViewInfo.PS_Orders_ProductType_Name;
                        orderdetailsviewinfo.PS_IsBorder = baOrderDetailsViewInfo.PS_IsBorder;
                        orderdetailsviewinfo.IsActive = baOrderDetailsViewInfo.IsActive;

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
                    var obj = db.OrderDetailsViewInfos.Where(p => p.Id == Id).FirstOrDefault();
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
