using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baOrderReceiptReprintInfo
        {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int PaymentMode { get; set; }
        public double NetCost { get; set; }
        public double TotalCost { get; set; }
        public string CurrencySymbol { get; set; }
        public double DiscountTotal { get; set; }
        public string PaymentDetail { get; set; }
        public string PhotoIds { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<orderreceiptreprintinfo> lst_orderreceiptreprintinfo = new List<orderreceiptreprintinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    orderreceiptreprintinfo orderreceiptreprintinfo = new orderreceiptreprintinfo();

                    orderreceiptreprintinfo.Id = 1;
                    orderreceiptreprintinfo.OrderId = 2;
                    orderreceiptreprintinfo.OrderNumber = "";
                    orderreceiptreprintinfo.PaymentMode = 4;
                    orderreceiptreprintinfo.NetCost = 3;
                    orderreceiptreprintinfo.TotalCost = 5;
                    orderreceiptreprintinfo.CurrencySymbol = "";
                    orderreceiptreprintinfo.DiscountTotal = 5;
                    orderreceiptreprintinfo.PaymentDetail = "";
                    orderreceiptreprintinfo.PhotoIds = "";
                    orderreceiptreprintinfo.IsActive = true;

                    lst_orderreceiptreprintinfo.Add(orderreceiptreprintinfo);

                    var Id = lst_orderreceiptreprintinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.OrderReceiptReprintInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.OrderReceiptReprintInfos.AddRange(lst_orderreceiptreprintinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.OrderReceiptReprintInfos.AddRange(lst_orderreceiptreprintinfo);
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

        public static baOrderReceiptReprintInfo GetOrderReceiptReprintInfoById(int Id)
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderReceiptReprintInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baOrderReceiptReprintInfo
                        {

                        Id = p.Id,
                        OrderId = p.OrderId,
                        OrderNumber = p.OrderNumber,
                        PaymentMode = p.PaymentMode,
                        NetCost = p.NetCost,
                        TotalCost = p.TotalCost,
                        CurrencySymbol = p.CurrencySymbol,
                        DiscountTotal = p.DiscountTotal,
                        PaymentDetail = p.PaymentDetail,
                        PhotoIds = p.PhotoIds,
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

        public static List<baOrderReceiptReprintInfo> GetOrderReceiptReprintInfoData()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderReceiptReprintInfos.Where(p => p.IsActive == true).Select(p => new baOrderReceiptReprintInfo
                        {
                        Id = p.Id,
                        OrderId = p.OrderId,
                        OrderNumber = p.OrderNumber,
                        PaymentMode = p.PaymentMode,
                        NetCost = p.NetCost,
                        TotalCost = p.TotalCost,
                        CurrencySymbol = p.CurrencySymbol,
                        DiscountTotal = p.DiscountTotal,
                        PaymentDetail = p.PaymentDetail,
                        PhotoIds = p.PhotoIds,
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

        public static bool Insert ( baOrderReceiptReprintInfo baOrderReceiptReprintInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    orderreceiptreprintinfo orderreceiptreprintinfo = new orderreceiptreprintinfo();

                    orderreceiptreprintinfo.Id = baOrderReceiptReprintInfo.Id;
                    orderreceiptreprintinfo.OrderId = baOrderReceiptReprintInfo.OrderId;
                    orderreceiptreprintinfo.OrderNumber = baOrderReceiptReprintInfo.OrderNumber;
                    orderreceiptreprintinfo.PaymentMode = baOrderReceiptReprintInfo.PaymentMode;
                    orderreceiptreprintinfo.NetCost = baOrderReceiptReprintInfo.NetCost;
                    orderreceiptreprintinfo.TotalCost = baOrderReceiptReprintInfo.TotalCost;
                    orderreceiptreprintinfo.CurrencySymbol = baOrderReceiptReprintInfo.CurrencySymbol;
                    orderreceiptreprintinfo.DiscountTotal = baOrderReceiptReprintInfo.DiscountTotal;
                    orderreceiptreprintinfo.PaymentDetail = baOrderReceiptReprintInfo.PaymentDetail;
                    orderreceiptreprintinfo.PhotoIds = baOrderReceiptReprintInfo.PhotoIds;
                    orderreceiptreprintinfo.IsActive = baOrderReceiptReprintInfo.IsActive;

                    db.OrderReceiptReprintInfos.Add(orderreceiptreprintinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baOrderReceiptReprintInfo baOrderReceiptReprintInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderReceiptReprintInfos.Where(p => p.Id == baOrderReceiptReprintInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        orderreceiptreprintinfo orderreceiptreprintinfo = new orderreceiptreprintinfo();

                        orderreceiptreprintinfo.Id = baOrderReceiptReprintInfo.Id;
                        orderreceiptreprintinfo.OrderId = baOrderReceiptReprintInfo.OrderId;
                        orderreceiptreprintinfo.OrderNumber = baOrderReceiptReprintInfo.OrderNumber;
                        orderreceiptreprintinfo.PaymentMode = baOrderReceiptReprintInfo.PaymentMode;
                        orderreceiptreprintinfo.NetCost = baOrderReceiptReprintInfo.NetCost;
                        orderreceiptreprintinfo.TotalCost = baOrderReceiptReprintInfo.TotalCost;
                        orderreceiptreprintinfo.CurrencySymbol = baOrderReceiptReprintInfo.CurrencySymbol;
                        orderreceiptreprintinfo.DiscountTotal = baOrderReceiptReprintInfo.DiscountTotal;
                        orderreceiptreprintinfo.PaymentDetail = baOrderReceiptReprintInfo.PaymentDetail;
                        orderreceiptreprintinfo.PhotoIds = baOrderReceiptReprintInfo.PhotoIds;
                        orderreceiptreprintinfo.IsActive = baOrderReceiptReprintInfo.IsActive;

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
                    var obj = db.OrderReceiptReprintInfos.Where(p => p.Id == Id).FirstOrDefault();
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
