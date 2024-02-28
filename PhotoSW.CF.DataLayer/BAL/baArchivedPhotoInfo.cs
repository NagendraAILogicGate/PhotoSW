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
    public class baArchivedPhotoInfo
        {
        public long Id { get; set; }
        public string FileName { get; set; }
        public int MediaType { get; set; }
        public int ArchivedPhotoId { get; set; }
        public bool FileDeleted { get; set; }      
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<archivedphotoinfo> lst_archivedphotoinfo = new List<archivedphotoinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    archivedphotoinfo archivedphotoinfo = new archivedphotoinfo();

                    archivedphotoinfo.Id = 1;
                    archivedphotoinfo.FileName = "";
                    archivedphotoinfo.MediaType = 3;
                    archivedphotoinfo.ArchivedPhotoId = 2;
                    archivedphotoinfo.FileDeleted = false;
                    archivedphotoinfo.IsActive = true;

                    lst_archivedphotoinfo.Add(archivedphotoinfo);

                    var Id = lst_archivedphotoinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ArchivedPhotoInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ArchivedPhotoInfos.AddRange(lst_archivedphotoinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ArchivedPhotoInfos.AddRange(lst_archivedphotoinfo);
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
        public static baArchivedPhotoInfo GetArchivedPhotoInfoDataById ( long Id )
            {
            try
                {

                archivedphotoinfo archivedphotoinfo = new archivedphotoinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.ArchivedPhotoInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baArchivedPhotoInfo
                        {
                        Id = p.Id,
                        FileName = p.FileName,
                        MediaType = p.MediaType,
                        ArchivedPhotoId = p.ArchivedPhotoId,
                        FileDeleted = p.FileDeleted,
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

        public static List<baArchivedPhotoInfo> GetArchivedPhotoInfoData ()
            {
            try
                {

                archivedphotoinfo archivedphotoinfo = new archivedphotoinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ArchivedPhotoInfos.Where(p => p.IsActive == true).Select(p => new baArchivedPhotoInfo
                        {
                        Id = p.Id,
                        FileName = p.FileName,
                        MediaType = p.MediaType,
                        ArchivedPhotoId = p.ArchivedPhotoId,
                        FileDeleted = p.FileDeleted,
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

        public static bool Insert ( baArchivedPhotoInfo baArchivedPhotoInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    archivedphotoinfo archivedphotoinfo = new archivedphotoinfo();

                    archivedphotoinfo.Id = archivedphotoinfo.Id;
                    archivedphotoinfo.FileName = archivedphotoinfo.FileName;
                    archivedphotoinfo.MediaType = archivedphotoinfo.MediaType;
                    archivedphotoinfo.ArchivedPhotoId = archivedphotoinfo.ArchivedPhotoId;
                    archivedphotoinfo.FileDeleted = archivedphotoinfo.FileDeleted;
                    archivedphotoinfo.IsActive = archivedphotoinfo.IsActive;

                    db.ArchivedPhotoInfos.Add(archivedphotoinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baArchivedPhotoInfo baArchivedPhotoInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ArchivedPhotoInfos.Where(p => p.Id == baArchivedPhotoInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        archivedphotoinfo archivedphotoinfo = new archivedphotoinfo();

                        archivedphotoinfo.Id = archivedphotoinfo.Id;
                        archivedphotoinfo.FileName = archivedphotoinfo.FileName;
                        archivedphotoinfo.MediaType = archivedphotoinfo.MediaType;
                        archivedphotoinfo.ArchivedPhotoId = archivedphotoinfo.ArchivedPhotoId;
                        archivedphotoinfo.FileDeleted = archivedphotoinfo.FileDeleted;
                        archivedphotoinfo.IsActive = archivedphotoinfo.IsActive;

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
                    var obj = db.ArchivedPhotoInfos.Where(p => p.Id == Id).FirstOrDefault();
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
