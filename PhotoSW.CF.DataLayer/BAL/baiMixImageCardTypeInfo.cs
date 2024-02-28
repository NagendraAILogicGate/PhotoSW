using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baiMixImageCardTypeInfo
        {
        public long Id { get; set; }
        public int IMIXImageCardTypeId { get; set; }
        public string Name { get; set; }
        public string CardIdentificationDigit { get; set; }
        public int ImageIdentificationType { get; set; }
        public int MaxImages { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? IsWaterMark { get; set; }
        public bool IsPrepaid { get; set; }
        public int PackageId { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<imiximagecardtypeinfo> lst_imiximagecardtypeinfo = new List<imiximagecardtypeinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {                 
                    imiximagecardtypeinfo imiximagecardtypeinfo = new imiximagecardtypeinfo();

                    imiximagecardtypeinfo.Id = 1;
                    imiximagecardtypeinfo.IMIXImageCardTypeId = 2;
                    imiximagecardtypeinfo.Name = "";
                    imiximagecardtypeinfo.CardIdentificationDigit = "";
                    imiximagecardtypeinfo.ImageIdentificationType = 3;
                    imiximagecardtypeinfo.MaxImages = 4;
                    imiximagecardtypeinfo.Description  = "";
                    imiximagecardtypeinfo.CreatedOn    = DateTime.Now;
                    imiximagecardtypeinfo.IsWaterMark  = false;
                    imiximagecardtypeinfo.IsPrepaid    = false;
                    imiximagecardtypeinfo.PackageId = 1;

                    imiximagecardtypeinfo.IsActive = true;

                    lst_imiximagecardtypeinfo.Add(imiximagecardtypeinfo);

                    var Id = lst_imiximagecardtypeinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.iMixImageCardTypeInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.iMixImageCardTypeInfos.AddRange(lst_imiximagecardtypeinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.iMixImageCardTypeInfos.AddRange(lst_imiximagecardtypeinfo);
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

        public static baiMixImageCardTypeInfo GetiMixImageCardTypeInfoById ( int Id )
            {
            try
                {
             
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMixImageCardTypeInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baiMixImageCardTypeInfo
                        {
                        Id = p.Id,
                        IMIXImageCardTypeId = p.IMIXImageCardTypeId,
                        Name = p.Name,
                        CardIdentificationDigit = p.CardIdentificationDigit,
                        ImageIdentificationType = p.ImageIdentificationType,
                        MaxImages = p.MaxImages,
                        Description = p.Description,
                        CreatedOn   = p.CreatedOn,
                        IsWaterMark = p.IsWaterMark,
                        IsPrepaid   = p.IsPrepaid,
                        PackageId = p.PackageId,
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

        public static List<baiMixImageCardTypeInfo> GetiMixImageCardTypeInfoData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMixImageCardTypeInfos.Where(p => p.IsActive == true).Select(p => new baiMixImageCardTypeInfo
                        {
                        Id = p.Id,
                        IMIXImageCardTypeId = p.IMIXImageCardTypeId,
                        Name = p.Name,
                        CardIdentificationDigit = p.CardIdentificationDigit,
                        ImageIdentificationType = p.ImageIdentificationType,
                        MaxImages = p.MaxImages,
                        Description = p.Description,
                        CreatedOn = p.CreatedOn,
                        IsWaterMark = p.IsWaterMark,
                        IsPrepaid = p.IsPrepaid,
                        PackageId = p.PackageId,
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

        public static bool Insert ( baiMixImageCardTypeInfo baiMixImageCardTypeInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    imiximagecardtypeinfo imiximagecardtypeinfo = new imiximagecardtypeinfo();

                    imiximagecardtypeinfo.Id = baiMixImageCardTypeInfo.Id;
                    imiximagecardtypeinfo.IMIXImageCardTypeId = baiMixImageCardTypeInfo.IMIXImageCardTypeId;
                    imiximagecardtypeinfo.Name = baiMixImageCardTypeInfo.Name;
                    imiximagecardtypeinfo.CardIdentificationDigit = baiMixImageCardTypeInfo.CardIdentificationDigit;
                    imiximagecardtypeinfo.ImageIdentificationType = baiMixImageCardTypeInfo.ImageIdentificationType;
                    imiximagecardtypeinfo.MaxImages = baiMixImageCardTypeInfo.MaxImages;
                    imiximagecardtypeinfo.Description = baiMixImageCardTypeInfo.Description;
                    imiximagecardtypeinfo.CreatedOn = baiMixImageCardTypeInfo.CreatedOn;
                    imiximagecardtypeinfo.IsWaterMark = baiMixImageCardTypeInfo.IsWaterMark;
                    imiximagecardtypeinfo.IsPrepaid = baiMixImageCardTypeInfo.IsPrepaid;
                    imiximagecardtypeinfo.PackageId = baiMixImageCardTypeInfo.PackageId;
                    imiximagecardtypeinfo.IsActive = baiMixImageCardTypeInfo.IsActive;

                    db.iMixImageCardTypeInfos.Add(imiximagecardtypeinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baiMixImageCardTypeInfo baiMixImageCardTypeInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMixImageCardTypeInfos.Where(p => p.Id == baiMixImageCardTypeInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        imiximagecardtypeinfo imiximagecardtypeinfo = new imiximagecardtypeinfo();

                        imiximagecardtypeinfo.Id = baiMixImageCardTypeInfo.Id;
                        imiximagecardtypeinfo.IMIXImageCardTypeId = baiMixImageCardTypeInfo.IMIXImageCardTypeId;
                        imiximagecardtypeinfo.Name = baiMixImageCardTypeInfo.Name;
                        imiximagecardtypeinfo.CardIdentificationDigit = baiMixImageCardTypeInfo.CardIdentificationDigit;
                        imiximagecardtypeinfo.ImageIdentificationType = baiMixImageCardTypeInfo.ImageIdentificationType;
                        imiximagecardtypeinfo.MaxImages = baiMixImageCardTypeInfo.MaxImages;
                        imiximagecardtypeinfo.Description = baiMixImageCardTypeInfo.Description;
                        imiximagecardtypeinfo.CreatedOn = baiMixImageCardTypeInfo.CreatedOn;
                        imiximagecardtypeinfo.IsWaterMark = baiMixImageCardTypeInfo.IsWaterMark;
                        imiximagecardtypeinfo.IsPrepaid = baiMixImageCardTypeInfo.IsPrepaid;
                        imiximagecardtypeinfo.PackageId = baiMixImageCardTypeInfo.PackageId;
                        imiximagecardtypeinfo.IsActive = baiMixImageCardTypeInfo.IsActive;

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
                    var obj = db.iMixImageCardTypeInfos.Where(p => p.Id == Id).FirstOrDefault();
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
