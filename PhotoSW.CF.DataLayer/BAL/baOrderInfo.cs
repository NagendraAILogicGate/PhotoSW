using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baOrderInfo
        {
        public long Id { get; set; }
        public int PS_Orders_pkey { get; set; }
        public string PS_Orders_Number { get; set; }
        public DateTime? PS_Orders_Date { get; set; }
        public int? PS_Albums_ID { get; set; }
        public string PS_Order_Mode { get; set; }
        public int? PS_Orders_UserID { get; set; }
        public decimal? PS_Orders_Cost { get; set; }
        public decimal? PS_Orders_NetCost { get; set; }
        public int? PS_Orders_Currency_ID { get; set; }
        public string PS_Orders_Currency_Conversion_Rate { get; set; }
        public double? PS_Orders_Total_Discount { get; set; }
        public string PS_Orders_Total_Discount_Details { get; set; }
        public int? PS_Orders_PaymentMode { get; set; }
        public string PS_Orders_PaymentDetails { get; set; }
        public bool? PS_Orders_Canceled { get; set; }
        public DateTime? PS_Orders_Canceled_Date { get; set; }
        public string PS_Orders_Canceled_Reason { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public bool SyncStatus { get; set; }
        public DateTime SyncDate { get; set; }
        public int PS_Photos_ID { get; set; }
        public string PS_StoreCode { get; set; }
        public string PosName { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<orderinfo> lst_orderinfo = new List<orderinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    orderinfo orderinfo = new orderinfo();

                     orderinfo.Id = 1;
                     orderinfo.PS_Orders_pkey = 1;
                     orderinfo.PS_Orders_Number = "";
                     orderinfo.PS_Orders_Date = DateTime.Now;
                     orderinfo.PS_Albums_ID = 1;
                     orderinfo.PS_Order_Mode = "";
                     orderinfo.PS_Orders_UserID = 1;
                     orderinfo.PS_Orders_Cost = 1;
                     orderinfo.PS_Orders_NetCost = 1;
                     orderinfo.PS_Orders_Currency_ID = 1;
                     orderinfo.PS_Orders_Currency_Conversion_Rate = "";
                     orderinfo.PS_Orders_Total_Discount = 1;
                     orderinfo.PS_Orders_Total_Discount_Details = "";
                     orderinfo.PS_Orders_PaymentMode = 1;
                     orderinfo.PS_Orders_PaymentDetails = "";
                     orderinfo.PS_Orders_Canceled = false;
                     orderinfo.PS_Orders_Canceled_Date = DateTime.Now;
                     orderinfo.PS_Orders_Canceled_Reason = "";
                     orderinfo.SyncCode = "";
                     orderinfo.IsSynced = false;
                     orderinfo.SyncStatus = false;
                     orderinfo.SyncDate = DateTime.Now;
                     orderinfo.PS_Photos_ID = 1;
                     orderinfo.PS_StoreCode = "";
                     orderinfo.PosName = "";
                     orderinfo.IsActive = true;

                    lst_orderinfo.Add(orderinfo);

                    var Id = lst_orderinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.OrderInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.OrderInfos.AddRange(lst_orderinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.OrderInfos.AddRange(lst_orderinfo);
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

        public static baOrderInfo GetOrderInfoById(int Id)
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baOrderInfo
                        {

                        Id = p.Id,
                        PS_Orders_pkey = p.PS_Orders_pkey,
                        PS_Orders_Number =  p.PS_Orders_Number,
                        PS_Orders_Date = p.PS_Orders_Date,
                        PS_Albums_ID = p.PS_Albums_ID,
                        PS_Order_Mode =  p.PS_Order_Mode,
                        PS_Orders_UserID = p.PS_Orders_UserID,
                        PS_Orders_Cost = p.PS_Orders_Cost,
                        PS_Orders_NetCost = p.PS_Orders_NetCost,
                        PS_Orders_Currency_ID = p.PS_Orders_Currency_ID,
                        PS_Orders_Currency_Conversion_Rate = p.PS_Orders_Currency_Conversion_Rate,
                        PS_Orders_Total_Discount = p.PS_Orders_Total_Discount,
                        PS_Orders_Total_Discount_Details =  p.PS_Orders_Total_Discount_Details,
                        PS_Orders_PaymentMode = p.PS_Orders_PaymentMode,
                        PS_Orders_PaymentDetails =  p.PS_Orders_PaymentDetails,
                        PS_Orders_Canceled = p.PS_Orders_Canceled,
                        PS_Orders_Canceled_Date = p.PS_Orders_Canceled_Date,
                        PS_Orders_Canceled_Reason =  p.PS_Orders_Canceled_Reason,
                        SyncCode =  p.SyncCode,
                        IsSynced = p.IsSynced,
                        SyncStatus = p.SyncStatus,
                        SyncDate = p.SyncDate,
                        PS_Photos_ID = p.PS_Photos_ID,
                        PS_StoreCode =  p.PS_StoreCode,
                        PosName =  p.PosName,
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

        public static List<baOrderInfo> GetOrderInfoData()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderInfos.Where(p => p.IsActive == true).Select(p => new baOrderInfo
                        {
                        Id = p.Id,
                        PS_Orders_pkey = p.PS_Orders_pkey,
                        PS_Orders_Number = p.PS_Orders_Number,
                        PS_Orders_Date = p.PS_Orders_Date,
                        PS_Albums_ID = p.PS_Albums_ID,
                        PS_Order_Mode = p.PS_Order_Mode,
                        PS_Orders_UserID = p.PS_Orders_UserID,
                        PS_Orders_Cost = p.PS_Orders_Cost,
                        PS_Orders_NetCost = p.PS_Orders_NetCost,
                        PS_Orders_Currency_ID = p.PS_Orders_Currency_ID,
                        PS_Orders_Currency_Conversion_Rate = p.PS_Orders_Currency_Conversion_Rate,
                        PS_Orders_Total_Discount = p.PS_Orders_Total_Discount,
                        PS_Orders_Total_Discount_Details = p.PS_Orders_Total_Discount_Details,
                        PS_Orders_PaymentMode = p.PS_Orders_PaymentMode,
                        PS_Orders_PaymentDetails = p.PS_Orders_PaymentDetails,
                        PS_Orders_Canceled = p.PS_Orders_Canceled,
                        PS_Orders_Canceled_Date = p.PS_Orders_Canceled_Date,
                        PS_Orders_Canceled_Reason = p.PS_Orders_Canceled_Reason,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        SyncStatus = p.SyncStatus,
                        SyncDate = p.SyncDate,
                        PS_Photos_ID = p.PS_Photos_ID,
                        PS_StoreCode = p.PS_StoreCode,
                        PosName = p.PosName,
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

        public static baOrderInfo InsertOrderInfo ( baOrderInfo baOrderInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    orderinfo orderinfo = new orderinfo();

                    orderinfo.Id = baOrderInfo.Id;
                    orderinfo.PS_Orders_pkey = baOrderInfo.PS_Orders_pkey;
                    orderinfo.PS_Orders_Number = baOrderInfo.PS_Orders_Number;
                    orderinfo.PS_Orders_Date = baOrderInfo.PS_Orders_Date;
                    orderinfo.PS_Albums_ID = baOrderInfo.PS_Albums_ID;
                    orderinfo.PS_Order_Mode = baOrderInfo.PS_Order_Mode;
                    orderinfo.PS_Orders_UserID = baOrderInfo.PS_Orders_UserID;
                    orderinfo.PS_Orders_Cost = baOrderInfo.PS_Orders_Cost;
                    orderinfo.PS_Orders_NetCost = baOrderInfo.PS_Orders_NetCost;
                    orderinfo.PS_Orders_Currency_ID = baOrderInfo.PS_Orders_Currency_ID;
                    orderinfo.PS_Orders_Currency_Conversion_Rate = baOrderInfo.PS_Orders_Currency_Conversion_Rate;
                    orderinfo.PS_Orders_Total_Discount = baOrderInfo.PS_Orders_Total_Discount;
                    orderinfo.PS_Orders_Total_Discount_Details = baOrderInfo.PS_Orders_Total_Discount_Details;
                    orderinfo.PS_Orders_PaymentMode = baOrderInfo.PS_Orders_PaymentMode;
                    orderinfo.PS_Orders_PaymentDetails = baOrderInfo.PS_Orders_PaymentDetails;
                    orderinfo.PS_Orders_Canceled = baOrderInfo.PS_Orders_Canceled;
                    orderinfo.PS_Orders_Canceled_Date = baOrderInfo.PS_Orders_Canceled_Date;
                    orderinfo.PS_Orders_Canceled_Reason = baOrderInfo.PS_Orders_Canceled_Reason;
                    orderinfo.SyncCode = baOrderInfo.SyncCode;
                    orderinfo.IsSynced = baOrderInfo.IsSynced;
                    orderinfo.SyncStatus = baOrderInfo.SyncStatus;
                    orderinfo.SyncDate = baOrderInfo.SyncDate;
                    orderinfo.PS_Photos_ID = baOrderInfo.PS_Photos_ID;
                    orderinfo.PS_StoreCode = baOrderInfo.PS_StoreCode;
                    orderinfo.PosName = baOrderInfo.PosName;
                    orderinfo.IsActive = baOrderInfo.IsActive;

                    db.OrderInfos.Add(orderinfo);
                    db.SaveChanges();

                    return GetOrderInfoById((int)orderinfo.Id);
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }
        public static bool Insert ( baOrderInfo baOrderInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    orderinfo orderinfo = new orderinfo();

                    orderinfo.Id = baOrderInfo.Id;
                    orderinfo.PS_Orders_pkey = baOrderInfo.PS_Orders_pkey;
                    orderinfo.PS_Orders_Number = baOrderInfo.PS_Orders_Number;
                    orderinfo.PS_Orders_Date = baOrderInfo.PS_Orders_Date;
                    orderinfo.PS_Albums_ID = baOrderInfo.PS_Albums_ID;
                    orderinfo.PS_Order_Mode = baOrderInfo.PS_Order_Mode;
                    orderinfo.PS_Orders_UserID = baOrderInfo.PS_Orders_UserID;
                    orderinfo.PS_Orders_Cost = baOrderInfo.PS_Orders_Cost;
                    orderinfo.PS_Orders_NetCost = baOrderInfo.PS_Orders_NetCost;
                    orderinfo.PS_Orders_Currency_ID = baOrderInfo.PS_Orders_Currency_ID;
                    orderinfo.PS_Orders_Currency_Conversion_Rate = baOrderInfo.PS_Orders_Currency_Conversion_Rate;
                    orderinfo.PS_Orders_Total_Discount = baOrderInfo.PS_Orders_Total_Discount;
                    orderinfo.PS_Orders_Total_Discount_Details = baOrderInfo.PS_Orders_Total_Discount_Details;
                    orderinfo.PS_Orders_PaymentMode = baOrderInfo.PS_Orders_PaymentMode;
                    orderinfo.PS_Orders_PaymentDetails = baOrderInfo.PS_Orders_PaymentDetails;
                    orderinfo.PS_Orders_Canceled = baOrderInfo.PS_Orders_Canceled;
                    orderinfo.PS_Orders_Canceled_Date = baOrderInfo.PS_Orders_Canceled_Date;
                    orderinfo.PS_Orders_Canceled_Reason = baOrderInfo.PS_Orders_Canceled_Reason;
                    orderinfo.SyncCode = baOrderInfo.SyncCode;
                    orderinfo.IsSynced = baOrderInfo.IsSynced;
                    orderinfo.SyncStatus = baOrderInfo.SyncStatus;
                    orderinfo.SyncDate = baOrderInfo.SyncDate;
                    orderinfo.PS_Photos_ID = baOrderInfo.PS_Photos_ID;
                    orderinfo.PS_StoreCode = baOrderInfo.PS_StoreCode;
                    orderinfo.PosName = baOrderInfo.PosName;
                    orderinfo.IsActive = baOrderInfo.IsActive;

                    db.OrderInfos.Add(orderinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baOrderInfo baOrderInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderInfos.Where(p => p.Id == baOrderInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        orderinfo orderinfo = new orderinfo();

                        orderinfo.Id = baOrderInfo.Id;
                        orderinfo.PS_Orders_pkey = baOrderInfo.PS_Orders_pkey;
                        orderinfo.PS_Orders_Number = baOrderInfo.PS_Orders_Number;
                        orderinfo.PS_Orders_Date = baOrderInfo.PS_Orders_Date;
                        orderinfo.PS_Albums_ID = baOrderInfo.PS_Albums_ID;
                        orderinfo.PS_Order_Mode = baOrderInfo.PS_Order_Mode;
                        orderinfo.PS_Orders_UserID = baOrderInfo.PS_Orders_UserID;
                        orderinfo.PS_Orders_Cost = baOrderInfo.PS_Orders_Cost;
                        orderinfo.PS_Orders_NetCost = baOrderInfo.PS_Orders_NetCost;
                        orderinfo.PS_Orders_Currency_ID = baOrderInfo.PS_Orders_Currency_ID;
                        orderinfo.PS_Orders_Currency_Conversion_Rate = baOrderInfo.PS_Orders_Currency_Conversion_Rate;
                        orderinfo.PS_Orders_Total_Discount = baOrderInfo.PS_Orders_Total_Discount;
                        orderinfo.PS_Orders_Total_Discount_Details = baOrderInfo.PS_Orders_Total_Discount_Details;
                        orderinfo.PS_Orders_PaymentMode = baOrderInfo.PS_Orders_PaymentMode;
                        orderinfo.PS_Orders_PaymentDetails = baOrderInfo.PS_Orders_PaymentDetails;
                        orderinfo.PS_Orders_Canceled = baOrderInfo.PS_Orders_Canceled;
                        orderinfo.PS_Orders_Canceled_Date = baOrderInfo.PS_Orders_Canceled_Date;
                        orderinfo.PS_Orders_Canceled_Reason = baOrderInfo.PS_Orders_Canceled_Reason;
                        orderinfo.SyncCode = baOrderInfo.SyncCode;
                        orderinfo.IsSynced = baOrderInfo.IsSynced;
                        orderinfo.SyncStatus = baOrderInfo.SyncStatus;
                        orderinfo.SyncDate = baOrderInfo.SyncDate;
                        orderinfo.PS_Photos_ID = baOrderInfo.PS_Photos_ID;
                        orderinfo.PS_StoreCode = baOrderInfo.PS_StoreCode;
                        orderinfo.PosName = baOrderInfo.PosName;
                        orderinfo.IsActive = baOrderInfo.IsActive;

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
                    var obj = db.OrderInfos.Where(p => p.Id == Id).FirstOrDefault();
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
