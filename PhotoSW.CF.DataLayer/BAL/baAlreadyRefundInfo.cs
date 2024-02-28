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
    public class baAlreadyRefundInfo
        {
        public long Id { get; set; }
        public int Photo { get; set; }
        public int LineItemId { get; set; }        
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<alreadyrefundinfo> lst_alreadyrefundinfo = new List<alreadyrefundinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {                  
                    alreadyrefundinfo alreadyrefundinfo = new alreadyrefundinfo();

                    alreadyrefundinfo.Id = 1;
                    alreadyrefundinfo.Photo = 1;
                    alreadyrefundinfo.LineItemId = 3;              
                    alreadyrefundinfo.IsActive = true;

                    lst_alreadyrefundinfo.Add(alreadyrefundinfo);
                   
                    var Id = lst_alreadyrefundinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.AlreadyrefundInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.AlreadyrefundInfos.AddRange(lst_alreadyrefundinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.AlreadyrefundInfos.AddRange(lst_alreadyrefundinfo);
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

        public static baAlreadyRefundInfo GetAlreadyRefundInfoDataById ( long Id )
            {
            try
                {

                alreadyrefundinfo alreadyrefundinfo = new alreadyrefundinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    
                    var obj = db.AlreadyrefundInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baAlreadyRefundInfo
                        {
                        Id = p.Id,
                        Photo = p.Photo,
                        LineItemId = p.LineItemId,
                        IsActive = true

                    }).FirstOrDefault();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static List<baAlreadyRefundInfo> GetAlreadyRefundInfoData ()
            {
            try
                {

                alreadyrefundinfo alreadyrefundinfo = new alreadyrefundinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.AlreadyrefundInfos.Where(p => p.IsActive == true).Select(p => new baAlreadyRefundInfo
                        {
                        Id = p.Id,
                        Photo = p.Photo,
                        LineItemId = p.LineItemId,
                        IsActive = true

                        }).ToList();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static bool Insert ( baAlreadyRefundInfo baAlreadyRefundInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    alreadyrefundinfo alreadyrefundinfo = new alreadyrefundinfo();

                    alreadyrefundinfo.Id = alreadyrefundinfo.Id;
                    alreadyrefundinfo.Photo = alreadyrefundinfo.Photo;
                    alreadyrefundinfo.LineItemId = alreadyrefundinfo.LineItemId;
                    alreadyrefundinfo.IsActive = alreadyrefundinfo.IsActive;
                    db.AlreadyrefundInfos.Add(alreadyrefundinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baAlreadyRefundInfo baAlreadyRefundInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.AlreadyrefundInfos.Where(p => p.Id == baAlreadyRefundInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        alreadyrefundinfo alreadyrefundinfo = new alreadyrefundinfo();

                        alreadyrefundinfo.Id = alreadyrefundinfo.Id;
                        alreadyrefundinfo.Photo = alreadyrefundinfo.Photo;
                        alreadyrefundinfo.LineItemId = alreadyrefundinfo.LineItemId;
                        alreadyrefundinfo.IsActive = alreadyrefundinfo.IsActive;

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
                    var obj = db.AlreadyrefundInfos.Where(p => p.Id == Id).FirstOrDefault();
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
