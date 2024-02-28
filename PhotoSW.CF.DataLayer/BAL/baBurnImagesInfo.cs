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
    public class baBurnImagesInfo
        {
            public long Id { get; set; }
            private int ImageID { get; set; }
            private int producttype { get; set; }
            public bool? IsActive { get; set; }

            public static bool Marge()
            {
                List<burnimagesinfo> lst_burnimagesinfo = new List<burnimagesinfo>();

                try
                {
                    using (PhotoSWEntities db = new PhotoSWEntities())
                    {
                        burnimagesinfo burnimagesinfo = new burnimagesinfo();

                        burnimagesinfo.Id = 1;
                        burnimagesinfo.ImageID = 1;
                        burnimagesinfo.producttype = 1;
                        burnimagesinfo.IsActive = true;

                        lst_burnimagesinfo.Add(burnimagesinfo);

                        var Id = lst_burnimagesinfo.Where(t => t.Id == 1).First().Id;
                        var IsExist = db.BurnImagesInfos.Where(p => p.Id == Id).ToList();
                        if (IsExist == null)
                        {
                            db.BurnImagesInfos.AddRange(lst_burnimagesinfo);
                            db.SaveChanges();
                        }
                        else if (IsExist.Count == 0)
                        {
                            db.BurnImagesInfos.AddRange(lst_burnimagesinfo);
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

            public static baBurnImagesInfo GetBurnImagesInfoDataById(long Id)
            {
                try
                {

                    using (PhotoSWEntities db = new PhotoSWEntities())
                    {

                        var obj = db.BurnImagesInfos.Where(p => p.Id == Id && p.IsActive == true)
                            .Select(p => new baBurnImagesInfo
                        {
                            Id = p.Id,
                            ImageID = p.ImageID,
                            producttype = p.producttype,
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

            public static List<baBurnImagesInfo> GetBurnImagesInfoData()
            {
                try
                {

                    using (PhotoSWEntities db = new PhotoSWEntities())
                    {
                        var obj = db.BurnImagesInfos.Where(p => p.IsActive == true).Select(p => new baBurnImagesInfo
                        {
                            Id = p.Id,
                            ImageID = p.ImageID,
                            producttype = p.producttype,
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

        public static bool Insert ( baBurnImagesInfo baBurnImagesInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    burnimagesinfo burnimagesinfo = new burnimagesinfo();

                    burnimagesinfo.Id = baBurnImagesInfo.Id;
                    burnimagesinfo.ImageID = baBurnImagesInfo.ImageID;
                    burnimagesinfo.producttype = baBurnImagesInfo.producttype;                  
                    burnimagesinfo.IsActive = true;
                    db.BurnImagesInfos.Add(burnimagesinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baBurnImagesInfo baBurnImagesInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.BurnImagesInfos.Where(p => p.Id == baBurnImagesInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        burnimagesinfo burnimagesinfo = new burnimagesinfo();

                        burnimagesinfo.Id = baBurnImagesInfo.Id;
                        burnimagesinfo.ImageID = baBurnImagesInfo.ImageID;
                        burnimagesinfo.producttype = baBurnImagesInfo.producttype;
                        burnimagesinfo.IsActive = true;

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
                    var obj = db.BurnImagesInfos.Where(p => p.Id == Id).FirstOrDefault();
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
