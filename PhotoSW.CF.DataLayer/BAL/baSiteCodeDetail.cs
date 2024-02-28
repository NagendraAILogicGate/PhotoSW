using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baSiteCodeDetail
        {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public string SiteCode { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<sitecodedetail> lst_sitecodedetail = new List<sitecodedetail>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    sitecodedetail sitecodedetail = new sitecodedetail();

                    sitecodedetail.Id = 1;
                    sitecodedetail.SiteId = 1;
                    sitecodedetail.SiteCode = "";
                    sitecodedetail.IsActive = true;

                    lst_sitecodedetail.Add(sitecodedetail);

                    var Id = lst_sitecodedetail.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SiteCodeDetails.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.SiteCodeDetails.AddRange(lst_sitecodedetail);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.SiteCodeDetails.AddRange(lst_sitecodedetail);
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

        public static baSiteCodeDetail GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SiteCodeDetails.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSiteCodeDetail
                        {
                        Id = p.Id,
                        SiteId = p.SiteId,
                        SiteCode = p.SiteCode,
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

        public static List<baSiteCodeDetail> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SiteCodeDetails.Where(p => p.IsActive == true).Select(p => new baSiteCodeDetail
                        {
                        Id = p.Id,
                        SiteId = p.SiteId,
                        SiteCode = p.SiteCode,
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

        public static bool Insert ( baSiteCodeDetail baSiteCodeDetail )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    sitecodedetail sitecodedetail = new sitecodedetail();

                    sitecodedetail.Id = baSiteCodeDetail.Id;
                    sitecodedetail.SiteId = baSiteCodeDetail.SiteId;
                    sitecodedetail.SiteCode = baSiteCodeDetail.SiteCode;
                    sitecodedetail.IsActive = baSiteCodeDetail.IsActive;

                    db.SiteCodeDetails.Add(sitecodedetail);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSiteCodeDetail baSiteCodeDetail )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SiteCodeDetails.Where(p => p.Id == baSiteCodeDetail.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        sitecodedetail sitecodedetail = new sitecodedetail();

                        sitecodedetail.Id = baSiteCodeDetail.Id;
                        sitecodedetail.SiteId = baSiteCodeDetail.SiteId;
                        sitecodedetail.SiteCode = baSiteCodeDetail.SiteCode;
                        sitecodedetail.IsActive = baSiteCodeDetail.IsActive;

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
                    var obj = db.SiteCodeDetails.Where(p => p.Id == Id).FirstOrDefault();
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
