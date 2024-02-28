using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baRefundInfo
        {
        public int Id { get; set; }
        public int PS_RefundId { get; set; }
        public int PS_OrderId { get; set; }
        public decimal RefundAmount { get; set; }
        public DateTime RefundDate { get; set; }
        public int UserId { get; set; }
        public int Refund_Mode { get; set; }
        public int PS_LineItemId { get; set; }
        public int RefundPhotoId { get; set; }
        public int PS_RefundMaster_ID { get; set; }
        public decimal? Refunded_Amount { get; set; }
        public string RefundReason { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<refundinfo> lst_refundinfo = new List<refundinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    refundinfo refundinfo = new refundinfo();

                    refundinfo.Id = 1;
                    refundinfo.PS_RefundId = 1;
                    refundinfo.PS_OrderId = 2;
                    refundinfo.RefundAmount = 5;
                    refundinfo.RefundDate = DateTime.Now;
                    refundinfo.UserId = 5;
                    refundinfo.Refund_Mode = 5;
                    refundinfo.PS_LineItemId = 2;
                    refundinfo.RefundPhotoId = 1;
                    refundinfo.PS_RefundMaster_ID = 2;
                    refundinfo.Refunded_Amount = 5;
                    refundinfo.RefundReason = "";
                    refundinfo.IsActive = true;

                    lst_refundinfo.Add(refundinfo);

                    var Id = lst_refundinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.RefundInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.RefundInfos.AddRange(lst_refundinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.RefundInfos.AddRange(lst_refundinfo);
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

        public static baRefundInfo GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RefundInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baRefundInfo
                        {
                        Id = p.Id,
                        PS_RefundId = p.PS_RefundId,
                        PS_OrderId = p.PS_OrderId,
                        RefundAmount = p.RefundAmount,
                        RefundDate = p.RefundDate,
                        UserId = p.UserId,
                        Refund_Mode = p.Refund_Mode,
                        PS_LineItemId = p.PS_LineItemId,
                        RefundPhotoId = p.RefundPhotoId,
                        PS_RefundMaster_ID = p.PS_RefundMaster_ID,
                        Refunded_Amount = p.Refunded_Amount,
                        RefundReason = p.RefundReason,
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

        public static List<baRefundInfo> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RefundInfos.Where(p => p.IsActive == true).Select(p => new baRefundInfo
                        {
                        Id = p.Id,
                        PS_RefundId = p.PS_RefundId,
                        PS_OrderId = p.PS_OrderId,
                        RefundAmount = p.RefundAmount,
                        RefundDate = p.RefundDate,
                        UserId = p.UserId,
                        Refund_Mode = p.Refund_Mode,
                        PS_LineItemId = p.PS_LineItemId,
                        RefundPhotoId = p.RefundPhotoId,
                        PS_RefundMaster_ID = p.PS_RefundMaster_ID,
                        Refunded_Amount = p.Refunded_Amount,
                        RefundReason = p.RefundReason,
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

        public static bool Insert ( baRefundInfo baRefundInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    refundinfo refundinfo = new refundinfo();

                    refundinfo.Id = baRefundInfo.Id;
                    refundinfo.PS_RefundId = baRefundInfo.PS_RefundId;
                    refundinfo.PS_OrderId = baRefundInfo.PS_OrderId;
                    refundinfo.RefundAmount = baRefundInfo.RefundAmount;
                    refundinfo.RefundDate = baRefundInfo.RefundDate;
                    refundinfo.UserId = baRefundInfo.UserId;
                    refundinfo.Refund_Mode = baRefundInfo.Refund_Mode;
                    refundinfo.PS_LineItemId = baRefundInfo.PS_LineItemId;
                    refundinfo.RefundPhotoId = baRefundInfo.RefundPhotoId;
                    refundinfo.PS_RefundMaster_ID = baRefundInfo.PS_RefundMaster_ID;
                    refundinfo.Refunded_Amount = baRefundInfo.Refunded_Amount;
                    refundinfo.RefundReason = baRefundInfo.RefundReason;
                    refundinfo.IsActive = baRefundInfo.IsActive;

                    db.RefundInfos.Add(refundinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baRefundInfo baRefundInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RefundInfos.Where(p => p.Id == baRefundInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        refundinfo refundinfo = new refundinfo();

                        refundinfo.Id = baRefundInfo.Id;
                        refundinfo.PS_RefundId = baRefundInfo.PS_RefundId;
                        refundinfo.PS_OrderId = baRefundInfo.PS_OrderId;
                        refundinfo.RefundAmount = baRefundInfo.RefundAmount;
                        refundinfo.RefundDate = baRefundInfo.RefundDate;
                        refundinfo.UserId = baRefundInfo.UserId;
                        refundinfo.Refund_Mode = baRefundInfo.Refund_Mode;
                        refundinfo.PS_LineItemId = baRefundInfo.PS_LineItemId;
                        refundinfo.RefundPhotoId = baRefundInfo.RefundPhotoId;
                        refundinfo.PS_RefundMaster_ID = baRefundInfo.PS_RefundMaster_ID;
                        refundinfo.Refunded_Amount = baRefundInfo.Refunded_Amount;
                        refundinfo.RefundReason = baRefundInfo.RefundReason;
                        refundinfo.IsActive = baRefundInfo.IsActive;

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
                    var obj = db.RefundInfos.Where(p => p.Id == Id).FirstOrDefault();
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
