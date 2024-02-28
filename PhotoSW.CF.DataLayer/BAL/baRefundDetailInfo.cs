using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baRefundDetailInfo
        {
        public int Id { get; set; }
        public int DG_RefundDetail_ID { get; set; }
        public int? DG_LineItemId { get; set; }
        public string RefundPhotoId { get; set; }
        public int? DG_RefundMaster_ID { get; set; }
        public decimal? Refunded_Amount { get; set; }
        public string RefundReason { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<refunddetailinfo> lst_refunddetailinfo = new List<refunddetailinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    refunddetailinfo refunddetailinfo = new refunddetailinfo();

                    refunddetailinfo.Id = 1;
                    refunddetailinfo.DG_RefundDetail_ID = 1;
                    refunddetailinfo.DG_LineItemId = 2;
                    refunddetailinfo.RefundPhotoId = "";
                    refunddetailinfo.DG_RefundMaster_ID = 5;
                    refunddetailinfo.Refunded_Amount = 5;
                    refunddetailinfo.RefundReason = "";
                    refunddetailinfo.IsActive = true;

                    lst_refunddetailinfo.Add(refunddetailinfo);

                    var Id = lst_refunddetailinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.RefundDetailInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.RefundDetailInfos.AddRange(lst_refunddetailinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.RefundDetailInfos.AddRange(lst_refunddetailinfo);
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

        public static baRefundDetailInfo GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RefundDetailInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baRefundDetailInfo
                        {
                        Id = p.Id,
                        DG_RefundDetail_ID = p.DG_RefundDetail_ID,
                        DG_LineItemId = p.DG_LineItemId,
                        RefundPhotoId = p.RefundPhotoId,
                        DG_RefundMaster_ID = p.DG_RefundMaster_ID,
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

        public static List<baRefundDetailInfo> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RefundDetailInfos.Where(p => p.IsActive == true).Select(p => new baRefundDetailInfo
                        {
                        Id = p.Id,
                        DG_RefundDetail_ID = p.DG_RefundDetail_ID,
                        DG_LineItemId = p.DG_LineItemId,
                        RefundPhotoId = p.RefundPhotoId,
                        DG_RefundMaster_ID = p.DG_RefundMaster_ID,
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


        public static bool Insert ( baRefundDetailInfo baRefundDetailInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    refunddetailinfo refunddetailinfo = new refunddetailinfo();

                    refunddetailinfo.Id = baRefundDetailInfo.Id;
                    refunddetailinfo.DG_RefundDetail_ID = baRefundDetailInfo.DG_RefundDetail_ID;
                    refunddetailinfo.DG_LineItemId = baRefundDetailInfo.DG_LineItemId;
                    refunddetailinfo.RefundPhotoId = baRefundDetailInfo.RefundPhotoId;
                    refunddetailinfo.DG_RefundMaster_ID = baRefundDetailInfo.DG_RefundMaster_ID;
                    refunddetailinfo.Refunded_Amount = baRefundDetailInfo.Refunded_Amount;
                    refunddetailinfo.RefundReason = baRefundDetailInfo.RefundReason;
                    refunddetailinfo.IsActive = baRefundDetailInfo.IsActive;

                    db.RefundDetailInfos.Add(refunddetailinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baRefundDetailInfo baRefundDetailInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RefundDetailInfos.Where(p => p.Id == baRefundDetailInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        refunddetailinfo refunddetailinfo = new refunddetailinfo();

                        refunddetailinfo.Id = baRefundDetailInfo.Id;
                        refunddetailinfo.DG_RefundDetail_ID = baRefundDetailInfo.DG_RefundDetail_ID;
                        refunddetailinfo.DG_LineItemId = baRefundDetailInfo.DG_LineItemId;
                        refunddetailinfo.RefundPhotoId = baRefundDetailInfo.RefundPhotoId;
                        refunddetailinfo.DG_RefundMaster_ID = baRefundDetailInfo.DG_RefundMaster_ID;
                        refunddetailinfo.Refunded_Amount = baRefundDetailInfo.Refunded_Amount;
                        refunddetailinfo.RefundReason = baRefundDetailInfo.RefundReason;
                        refunddetailinfo.IsActive = baRefundDetailInfo.IsActive;

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
                    var obj = db.RefundDetailInfos.Where(p => p.Id == Id).FirstOrDefault();
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
