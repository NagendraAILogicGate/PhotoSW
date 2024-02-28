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
    public class baFilePhotoInfo
        {
        public long Id { get; set; }
        public string Photo_RFID { get; set; }
        public string FileName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string HotFolderPath { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<filephotoinfo> lst_filephotoinfo = new List<filephotoinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    filephotoinfo filephotoinfo = new filephotoinfo();

                    filephotoinfo.Id = 1;
                    filephotoinfo.Photo_RFID = "";
                    filephotoinfo.FileName = "";                   
                    filephotoinfo.CreatedOn = DateTime.Now;
                    filephotoinfo.HotFolderPath = "";
                    filephotoinfo.IsActive = true;

                    lst_filephotoinfo.Add(filephotoinfo);

                    var Id = lst_filephotoinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.FilePhotoInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.FilePhotoInfos.AddRange(lst_filephotoinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.FilePhotoInfos.AddRange(lst_filephotoinfo);
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

        public static baFilePhotoInfo GetFilePhotoInfoDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.FilePhotoInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baFilePhotoInfo
                        {
                        Id = p.Id,
                        Photo_RFID = p.Photo_RFID,
                        FileName = p.FileName,
                        CreatedOn = p.CreatedOn,
                        HotFolderPath = p.HotFolderPath,
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

        public static List<baFilePhotoInfo> GetFilePhotoInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.FilePhotoInfos.Where(p => p.IsActive == true).Select(p => new baFilePhotoInfo
                        {
                        Id = p.Id,
                        Photo_RFID = p.Photo_RFID,
                        FileName = p.FileName,
                        CreatedOn = p.CreatedOn,
                        HotFolderPath = p.HotFolderPath,
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

        public static bool Insert ( baFilePhotoInfo baFilePhotoInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    filephotoinfo filephotoinfo = new filephotoinfo();

                    filephotoinfo.Id = filephotoinfo.Id;
                    filephotoinfo.Photo_RFID = filephotoinfo.Photo_RFID;
                    filephotoinfo.FileName = filephotoinfo.FileName;
                    filephotoinfo.CreatedOn = filephotoinfo.CreatedOn;
                    filephotoinfo.HotFolderPath = filephotoinfo.HotFolderPath;
                    filephotoinfo.IsActive = filephotoinfo.IsActive;

                    db.FilePhotoInfos.Add(filephotoinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baFilePhotoInfo baFilePhotoInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.FilePhotoInfos.Where(p => p.Id == baFilePhotoInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        filephotoinfo filephotoinfo = new filephotoinfo();

                        filephotoinfo.Id = filephotoinfo.Id;
                        filephotoinfo.Photo_RFID = filephotoinfo.Photo_RFID;
                        filephotoinfo.FileName = filephotoinfo.FileName;
                        filephotoinfo.CreatedOn = filephotoinfo.CreatedOn;
                        filephotoinfo.HotFolderPath = filephotoinfo.HotFolderPath;
                        filephotoinfo.IsActive = filephotoinfo.IsActive;

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
                    var obj = db.FilePhotoInfos.Where(p => p.Id == Id).FirstOrDefault();
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
