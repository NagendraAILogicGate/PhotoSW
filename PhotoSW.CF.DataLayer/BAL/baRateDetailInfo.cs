using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baRateDetailInfo
        {
        public int Id { get; set; }
        public long ProfileAuditID { get; set; }
        public string DG_Currency_Name { get; set; }
        public string DG_Currency_Code { get; set; }
        public decimal ExchangeRate { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<ratedetailinfo> lst_ratedetailinfo = new List<ratedetailinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    ratedetailinfo ratedetailinfo = new ratedetailinfo();

                    ratedetailinfo.Id = 1;
                    ratedetailinfo.ProfileAuditID = 1;
                    ratedetailinfo.DG_Currency_Name = "";
                    ratedetailinfo.DG_Currency_Code = "";
                    ratedetailinfo.ExchangeRate = 5;
                    ratedetailinfo.IsActive = true;

                    lst_ratedetailinfo.Add(ratedetailinfo);

                    var Id = lst_ratedetailinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.RateDetailInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.RateDetailInfos.AddRange(lst_ratedetailinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.RateDetailInfos.AddRange(lst_ratedetailinfo);
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

        public static baRateDetailInfo GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RateDetailInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baRateDetailInfo
                        {
                        Id = p.Id,
                        ProfileAuditID = p.ProfileAuditID,
                        DG_Currency_Name = p.DG_Currency_Name,
                        DG_Currency_Code = p.DG_Currency_Code,
                        ExchangeRate = p.ExchangeRate,                       
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

        public static List<baRateDetailInfo> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RateDetailInfos.Where(p => p.IsActive == true).Select(p => new baRateDetailInfo
                        {
                        Id = p.Id,
                        ProfileAuditID = p.ProfileAuditID,
                        DG_Currency_Name = p.DG_Currency_Name,
                        DG_Currency_Code = p.DG_Currency_Code,
                        ExchangeRate = p.ExchangeRate,
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

        public static bool Insert ( baRateDetailInfo baRateDetailInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    ratedetailinfo ratedetailinfo = new ratedetailinfo();

                    ratedetailinfo.Id = ratedetailinfo.Id;
                    ratedetailinfo.ProfileAuditID = ratedetailinfo.ProfileAuditID;
                    ratedetailinfo.DG_Currency_Name = ratedetailinfo.DG_Currency_Name;
                    ratedetailinfo.DG_Currency_Code = ratedetailinfo.DG_Currency_Code;
                    ratedetailinfo.ExchangeRate = ratedetailinfo.ExchangeRate;
                    ratedetailinfo.IsActive = ratedetailinfo.IsActive;

                    db.RateDetailInfos.Add(ratedetailinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baRateDetailInfo baRateDetailInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RateDetailInfos.Where(p => p.Id == baRateDetailInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        ratedetailinfo ratedetailinfo = new ratedetailinfo();

                        ratedetailinfo.Id = ratedetailinfo.Id;
                        ratedetailinfo.ProfileAuditID = ratedetailinfo.ProfileAuditID;
                        ratedetailinfo.DG_Currency_Name = ratedetailinfo.DG_Currency_Name;
                        ratedetailinfo.DG_Currency_Code = ratedetailinfo.DG_Currency_Code;
                        ratedetailinfo.ExchangeRate = ratedetailinfo.ExchangeRate;
                        ratedetailinfo.IsActive = ratedetailinfo.IsActive;


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
                    var obj = db.RateDetailInfos.Where(p => p.Id == Id).FirstOrDefault();
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
