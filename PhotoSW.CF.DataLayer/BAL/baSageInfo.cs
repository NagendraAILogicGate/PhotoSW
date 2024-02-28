using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
{

    public class baSageInfo
    {
        public long Id { get; set; }
        public long OpeningFormDetailID { get; set; }
        public long sixEightStartingNumber { get; set; }
        public long eightTenStartingNumber { get; set; }
        public long sixEightAutoStartingNumber { get; set; }
        public long eightTenAutoStartingNumber { get; set; }
        public long PosterStartingNumber { get; set; }
        public decimal CashFloatAmount { get; set; }
        public int SubStoreID { get; set; }
        public DateTime? OpeningDate { get; set; }
        public string FilledBySyncCode { get; set; }
        public int FilledBy { get; set; }
        public long OpenCloseProcDetailID { get; set; }
        public int FormTypeID { get; set; }
        public DateTime? FilledOn { get; set; }
        public DateTime? TransDate { get; set; }
        public int FormID { get; set; }
        public string SyncCode { get; set; }
        public DateTime? BusinessDate { get; set; }
        public DateTime ServerTime { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<sageinfo> lst_sageinfo = new List<sageinfo>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                  
                    sageinfo sageinfo = new sageinfo();

                    sageinfo.Id = 1;

                    sageinfo.OpeningFormDetailID = 1;
                    sageinfo.sixEightStartingNumber = 6;
                    sageinfo.eightTenStartingNumber = 8;
                    sageinfo.sixEightAutoStartingNumber = 6;
                    sageinfo.eightTenAutoStartingNumber = 8;
                    sageinfo.PosterStartingNumber = 4;
                    sageinfo.CashFloatAmount = 3;
                    sageinfo.SubStoreID = 3;
                    sageinfo.OpeningDate = DateTime.Now;
                    sageinfo.FilledBySyncCode = "";
                    sageinfo.FilledBy = 1;
                    sageinfo.OpenCloseProcDetailID = 1;
                    sageinfo.FormTypeID = 1;
                    sageinfo.FilledOn = DateTime.Now;
                    sageinfo.TransDate = DateTime.Now;
                    sageinfo.FormID = 1;
                    sageinfo.SyncCode = "";
                    sageinfo.BusinessDate = DateTime.Now;
                    sageinfo.ServerTime = DateTime.Now;

                    sageinfo.IsActive = true;


                    lst_sageinfo.Add(sageinfo);
                    // }
                    var Id = lst_sageinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SageInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.SageInfos.AddRange(lst_sageinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.SageInfos.AddRange(lst_sageinfo);
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static baSageInfo GetSageInfoDataById(int Id)
        {
            try
            {

                sageinfo sageinfo = new sageinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SageInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSageInfo
                    {
                        Id = p.Id,
                        OpeningFormDetailID = p.OpenCloseProcDetailID,
                        sixEightStartingNumber = p.sixEightStartingNumber,
                        eightTenStartingNumber = p.eightTenAutoStartingNumber,
                        sixEightAutoStartingNumber = p.sixEightAutoStartingNumber,
                        eightTenAutoStartingNumber = p.eightTenAutoStartingNumber,
                        PosterStartingNumber = p.PosterStartingNumber,
                        CashFloatAmount = p.CashFloatAmount,
                        SubStoreID = p.SubStoreID,
                        OpeningDate = p.OpeningDate,
                        FilledBySyncCode = p.FilledBySyncCode,
                        FilledBy = p.FilledBy,
                        OpenCloseProcDetailID = p.OpenCloseProcDetailID,
                        FormTypeID = p.FormTypeID,
                        FilledOn = p.FilledOn,
                        TransDate = p.TransDate,
                        FormID = p.FormID,
                        SyncCode = p.SyncCode,
                        BusinessDate = p.BusinessDate,
                        ServerTime = p.ServerTime,

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
        public static List<baSageInfo> GetSageInfoData()
        {
            try
            {
                sageinfo sageinfo = new sageinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SageInfos.Where(p => p.IsActive == true).Select(p => new baSageInfo
                    {
                        Id = p.Id,
                        OpeningFormDetailID = p.OpenCloseProcDetailID,
                        sixEightStartingNumber = p.sixEightStartingNumber,
                        eightTenStartingNumber = p.eightTenAutoStartingNumber,
                        sixEightAutoStartingNumber = p.sixEightAutoStartingNumber,
                        eightTenAutoStartingNumber = p.eightTenAutoStartingNumber,
                        PosterStartingNumber = p.PosterStartingNumber,
                        CashFloatAmount = p.CashFloatAmount,
                        SubStoreID = p.SubStoreID,
                        OpeningDate = p.OpeningDate,
                        FilledBySyncCode = p.FilledBySyncCode,
                        FilledBy = p.FilledBy,
                        OpenCloseProcDetailID = p.OpenCloseProcDetailID,
                        FormTypeID = p.FormTypeID,
                        FilledOn = p.FilledOn,
                        TransDate = p.TransDate,
                        FormID = p.FormID,
                        SyncCode = p.SyncCode,
                        BusinessDate = p.BusinessDate,
                        ServerTime = p.ServerTime,

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


        public static bool Insert ( baSageInfo baSageInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    sageinfo sageinfo = new sageinfo();

                    sageinfo.Id = baSageInfo.Id;
                    sageinfo.OpeningFormDetailID = baSageInfo.OpeningFormDetailID;
                    sageinfo.sixEightStartingNumber = baSageInfo.sixEightStartingNumber;
                    sageinfo.eightTenStartingNumber = baSageInfo.eightTenStartingNumber;
                    sageinfo.sixEightAutoStartingNumber = baSageInfo.sixEightAutoStartingNumber;
                    sageinfo.eightTenAutoStartingNumber = baSageInfo.eightTenAutoStartingNumber;
                    sageinfo.PosterStartingNumber = baSageInfo.PosterStartingNumber;
                    sageinfo.CashFloatAmount = baSageInfo.CashFloatAmount;
                    sageinfo.SubStoreID = baSageInfo.SubStoreID;
                    sageinfo.OpeningDate = baSageInfo.OpeningDate;
                    sageinfo.FilledBySyncCode = baSageInfo.FilledBySyncCode;
                    sageinfo.FilledBy = baSageInfo.FilledBy;
                    sageinfo.OpenCloseProcDetailID = baSageInfo.OpenCloseProcDetailID;
                    sageinfo.FormTypeID = baSageInfo.FormTypeID;
                    sageinfo.FilledOn = baSageInfo.FilledOn;
                    sageinfo.TransDate = baSageInfo.TransDate;
                    sageinfo.FormID = baSageInfo.FormID;
                    sageinfo.SyncCode = baSageInfo.SyncCode;
                    sageinfo.BusinessDate = baSageInfo.BusinessDate;
                    sageinfo.ServerTime = baSageInfo.ServerTime;
                    sageinfo.IsActive = baSageInfo.IsActive;
                    db.SageInfos.Add(sageinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSageInfo baSageInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SageInfos.Where(p => p.Id == baSageInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        sageinfo sageinfo = new sageinfo();

                        sageinfo.Id = baSageInfo.Id;
                        sageinfo.OpeningFormDetailID = baSageInfo.OpeningFormDetailID;
                        sageinfo.sixEightStartingNumber = baSageInfo.sixEightStartingNumber;
                        sageinfo.eightTenStartingNumber = baSageInfo.eightTenStartingNumber;
                        sageinfo.sixEightAutoStartingNumber = baSageInfo.sixEightAutoStartingNumber;
                        sageinfo.eightTenAutoStartingNumber = baSageInfo.eightTenAutoStartingNumber;
                        sageinfo.PosterStartingNumber = baSageInfo.PosterStartingNumber;
                        sageinfo.CashFloatAmount = baSageInfo.CashFloatAmount;
                        sageinfo.SubStoreID = baSageInfo.SubStoreID;
                        sageinfo.OpeningDate = baSageInfo.OpeningDate;
                        sageinfo.FilledBySyncCode = baSageInfo.FilledBySyncCode;
                        sageinfo.FilledBy = baSageInfo.FilledBy;
                        sageinfo.OpenCloseProcDetailID = baSageInfo.OpenCloseProcDetailID;
                        sageinfo.FormTypeID = baSageInfo.FormTypeID;
                        sageinfo.FilledOn = baSageInfo.FilledOn;
                        sageinfo.TransDate = baSageInfo.TransDate;
                        sageinfo.FormID = baSageInfo.FormID;
                        sageinfo.SyncCode = baSageInfo.SyncCode;
                        sageinfo.BusinessDate = baSageInfo.BusinessDate;
                        sageinfo.ServerTime = baSageInfo.ServerTime;
                        sageinfo.IsActive = baSageInfo.IsActive;

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
                    var obj = db.SageInfos.Where(p => p.Id == Id).FirstOrDefault();
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
