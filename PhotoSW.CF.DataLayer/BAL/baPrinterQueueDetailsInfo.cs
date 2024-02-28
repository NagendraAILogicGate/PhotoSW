using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPrinterQueueDetailsInfo
        {
        public long Id { get; set; }
        public int PS_AssociatedPrinters_Pkey { get; set; }
        public string PS_AssociatedPrinters_Name { get; set; }
        public int PS_Orders_pkey { get; set; }
        public string PS_Orders_Number { get; set; }
        public int PS_Order_SubStoreId { get; set; }
        public string PS_Orders_ProductType_Name { get; set; }
        public int PS_Orders_ProductType_pkey { get; set; }
        public int PS_PrinterQueue_Pkey { get; set; }
        public int PS_PrinterQueue_ProductID { get; set; }
        public string PS_PrinterQueue_Image_Pkey { get; set; }
        public int PS_Associated_PrinterId { get; set; }
        public int PS_Order_Details_Pkey { get; set; }
        public bool PS_SentToPrinter { get; set; }
        public bool is_Active { get; set; }
        public int QueueIndex { get; set; }
        public string PS_Photos_RFID { get; set; }
        public string PS_Photos_pKey { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<printerqueuedetailsinfo> lst_printerqueuedetailsinfo = new List<printerqueuedetailsinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    printerqueuedetailsinfo printerqueuedetailsinfo = new printerqueuedetailsinfo();

                    printerqueuedetailsinfo.Id = 1;
                    printerqueuedetailsinfo.PS_AssociatedPrinters_Pkey = 1;
                    printerqueuedetailsinfo.PS_AssociatedPrinters_Name = "";
                    printerqueuedetailsinfo.PS_Orders_pkey = 1;
                    printerqueuedetailsinfo.PS_Orders_Number = "";
                    printerqueuedetailsinfo.PS_Order_SubStoreId = 1;
                    printerqueuedetailsinfo.PS_Orders_ProductType_Name = "";
                    printerqueuedetailsinfo.PS_Orders_ProductType_pkey = 1;
                    printerqueuedetailsinfo.PS_PrinterQueue_Pkey = 1;
                    printerqueuedetailsinfo.PS_PrinterQueue_ProductID = 1;
                    printerqueuedetailsinfo.PS_PrinterQueue_Image_Pkey = "";
                    printerqueuedetailsinfo.PS_Associated_PrinterId = 1;
                    printerqueuedetailsinfo.PS_Order_Details_Pkey = 1;
                    printerqueuedetailsinfo.PS_SentToPrinter = false;
                    printerqueuedetailsinfo.is_Active = false;
                    printerqueuedetailsinfo.QueueIndex = 1; 
                    printerqueuedetailsinfo.PS_Photos_RFID = "";
                    printerqueuedetailsinfo.PS_Photos_pKey = "";
                    printerqueuedetailsinfo.IsActive = true;

                    lst_printerqueuedetailsinfo.Add(printerqueuedetailsinfo);

                    var Id = lst_printerqueuedetailsinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PrinterQueueDetailsInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PrinterQueueDetailsInfos.AddRange(lst_printerqueuedetailsinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PrinterQueueDetailsInfos.AddRange(lst_printerqueuedetailsinfo);
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

        public static baPrinterQueueDetailsInfo GetPrinterQueueDetailsInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrinterQueueDetailsInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPrinterQueueDetailsInfo
                        {
                        Id = p.Id,
                        PS_AssociatedPrinters_Pkey = p.PS_AssociatedPrinters_Pkey,
                        PS_AssociatedPrinters_Name = p.PS_AssociatedPrinters_Name,
                        PS_Orders_pkey = p.PS_Orders_pkey,
                        PS_Orders_Number = p.PS_Orders_Number,
                        PS_Order_SubStoreId = p.PS_Order_SubStoreId,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PS_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
                        PS_PrinterQueue_Pkey = p.PS_PrinterQueue_Pkey,
                        PS_PrinterQueue_ProductID = p.PS_PrinterQueue_ProductID,
                        PS_PrinterQueue_Image_Pkey = p.PS_PrinterQueue_Image_Pkey,
                        PS_Associated_PrinterId = p.PS_Associated_PrinterId,
                        PS_Order_Details_Pkey = p.PS_Order_Details_Pkey,
                        PS_SentToPrinter = p.PS_SentToPrinter,
                        is_Active = p.is_Active,
                        QueueIndex = p.QueueIndex,
                        PS_Photos_RFID = p.PS_Photos_RFID,
                        PS_Photos_pKey = p.PS_Photos_pKey,
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

        public static List<baPrinterQueueDetailsInfo> GetPrinterQueueDetailsInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrinterQueueDetailsInfos.Where(p => p.IsActive == true).Select(p => new baPrinterQueueDetailsInfo
                        {
                        Id = p.Id,
                        PS_AssociatedPrinters_Pkey = p.PS_AssociatedPrinters_Pkey,
                        PS_AssociatedPrinters_Name = p.PS_AssociatedPrinters_Name,
                        PS_Orders_pkey = p.PS_Orders_pkey,
                        PS_Orders_Number = p.PS_Orders_Number,
                        PS_Order_SubStoreId = p.PS_Order_SubStoreId,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PS_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
                        PS_PrinterQueue_Pkey = p.PS_PrinterQueue_Pkey,
                        PS_PrinterQueue_ProductID = p.PS_PrinterQueue_ProductID,
                        PS_PrinterQueue_Image_Pkey = p.PS_PrinterQueue_Image_Pkey,
                        PS_Associated_PrinterId = p.PS_Associated_PrinterId,
                        PS_Order_Details_Pkey = p.PS_Order_Details_Pkey,
                        PS_SentToPrinter = p.PS_SentToPrinter,
                        is_Active = p.is_Active,
                        QueueIndex = p.QueueIndex,
                        PS_Photos_RFID = p.PS_Photos_RFID,
                        PS_Photos_pKey = p.PS_Photos_pKey,
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

        public static bool Insert ( baPrinterQueueDetailsInfo baPrinterQueueDetailsInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    printerqueuedetailsinfo printerqueuedetailsinfo = new printerqueuedetailsinfo();

                    printerqueuedetailsinfo.Id = baPrinterQueueDetailsInfo.Id;
                    printerqueuedetailsinfo.PS_AssociatedPrinters_Pkey = baPrinterQueueDetailsInfo.PS_AssociatedPrinters_Pkey;
                    printerqueuedetailsinfo.PS_AssociatedPrinters_Name = baPrinterQueueDetailsInfo.PS_AssociatedPrinters_Name;
                    printerqueuedetailsinfo.PS_Orders_pkey = baPrinterQueueDetailsInfo.PS_Orders_pkey;
                    printerqueuedetailsinfo.PS_Orders_Number = baPrinterQueueDetailsInfo.PS_Orders_Number;
                    printerqueuedetailsinfo.PS_Order_SubStoreId = baPrinterQueueDetailsInfo.PS_Order_SubStoreId;
                    printerqueuedetailsinfo.PS_Orders_ProductType_Name = baPrinterQueueDetailsInfo.PS_Orders_ProductType_Name;
                    printerqueuedetailsinfo.PS_Orders_ProductType_pkey = baPrinterQueueDetailsInfo.PS_Orders_ProductType_pkey;
                    printerqueuedetailsinfo.PS_PrinterQueue_Pkey = baPrinterQueueDetailsInfo.PS_PrinterQueue_Pkey;
                    printerqueuedetailsinfo.PS_PrinterQueue_ProductID = baPrinterQueueDetailsInfo.PS_PrinterQueue_ProductID;
                    printerqueuedetailsinfo.PS_PrinterQueue_Image_Pkey = baPrinterQueueDetailsInfo.PS_PrinterQueue_Image_Pkey;
                    printerqueuedetailsinfo.PS_Associated_PrinterId = baPrinterQueueDetailsInfo.PS_Associated_PrinterId;
                    printerqueuedetailsinfo.PS_Order_Details_Pkey = baPrinterQueueDetailsInfo.PS_Order_Details_Pkey;
                    printerqueuedetailsinfo.PS_SentToPrinter = baPrinterQueueDetailsInfo.PS_SentToPrinter;
                    printerqueuedetailsinfo.is_Active = baPrinterQueueDetailsInfo.is_Active;
                    printerqueuedetailsinfo.QueueIndex = baPrinterQueueDetailsInfo.QueueIndex;
                    printerqueuedetailsinfo.PS_Photos_RFID = baPrinterQueueDetailsInfo.PS_Photos_RFID;
                    printerqueuedetailsinfo.PS_Photos_pKey = baPrinterQueueDetailsInfo.PS_Photos_pKey;
                    printerqueuedetailsinfo.IsActive = baPrinterQueueDetailsInfo.IsActive;

                    db.PrinterQueueDetailsInfos.Add(printerqueuedetailsinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPrinterQueueDetailsInfo baPrinterQueueDetailsInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrinterQueueDetailsInfos.Where(p => p.Id == baPrinterQueueDetailsInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        printerqueuedetailsinfo printerqueuedetailsinfo = new printerqueuedetailsinfo();

                        printerqueuedetailsinfo.Id = baPrinterQueueDetailsInfo.Id;
                        printerqueuedetailsinfo.PS_AssociatedPrinters_Pkey = baPrinterQueueDetailsInfo.PS_AssociatedPrinters_Pkey;
                        printerqueuedetailsinfo.PS_AssociatedPrinters_Name = baPrinterQueueDetailsInfo.PS_AssociatedPrinters_Name;
                        printerqueuedetailsinfo.PS_Orders_pkey = baPrinterQueueDetailsInfo.PS_Orders_pkey;
                        printerqueuedetailsinfo.PS_Orders_Number = baPrinterQueueDetailsInfo.PS_Orders_Number;
                        printerqueuedetailsinfo.PS_Order_SubStoreId = baPrinterQueueDetailsInfo.PS_Order_SubStoreId;
                        printerqueuedetailsinfo.PS_Orders_ProductType_Name = baPrinterQueueDetailsInfo.PS_Orders_ProductType_Name;
                        printerqueuedetailsinfo.PS_Orders_ProductType_pkey = baPrinterQueueDetailsInfo.PS_Orders_ProductType_pkey;
                        printerqueuedetailsinfo.PS_PrinterQueue_Pkey = baPrinterQueueDetailsInfo.PS_PrinterQueue_Pkey;
                        printerqueuedetailsinfo.PS_PrinterQueue_ProductID = baPrinterQueueDetailsInfo.PS_PrinterQueue_ProductID;
                        printerqueuedetailsinfo.PS_PrinterQueue_Image_Pkey = baPrinterQueueDetailsInfo.PS_PrinterQueue_Image_Pkey;
                        printerqueuedetailsinfo.PS_Associated_PrinterId = baPrinterQueueDetailsInfo.PS_Associated_PrinterId;
                        printerqueuedetailsinfo.PS_Order_Details_Pkey = baPrinterQueueDetailsInfo.PS_Order_Details_Pkey;
                        printerqueuedetailsinfo.PS_SentToPrinter = baPrinterQueueDetailsInfo.PS_SentToPrinter;
                        printerqueuedetailsinfo.is_Active = baPrinterQueueDetailsInfo.is_Active;
                        printerqueuedetailsinfo.QueueIndex = baPrinterQueueDetailsInfo.QueueIndex;
                        printerqueuedetailsinfo.PS_Photos_RFID = baPrinterQueueDetailsInfo.PS_Photos_RFID;
                        printerqueuedetailsinfo.PS_Photos_pKey = baPrinterQueueDetailsInfo.PS_Photos_pKey;
                        printerqueuedetailsinfo.IsActive = baPrinterQueueDetailsInfo.IsActive;

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
                    var obj = db.PrinterQueueDetailsInfos.Where(p => p.Id == Id).FirstOrDefault();
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
